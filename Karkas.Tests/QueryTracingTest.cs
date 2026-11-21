using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Karkas.Data;
using Karkas.Data.Exceptions;
using Karkas.Data.Sqlite;
using Karkas.Data.Tracing;

namespace Karkas.Tests.Data.Tests;

/// <summary>KarkasTracing is process-wide, so these tests must not run next to each other.</summary>
[CollectionDefinition(Name, DisableParallelization = true)]
public class QueryTracingCollection
{
	public const string Name = "KarkasTracing";
}

/// <summary>
/// Every query gets a query id (same for every run of a call site) and an execution id (new for every run).
/// </summary>
[Collection(QueryTracingCollection.Name)]
public class QueryTracingTest : IDisposable
{
	private readonly ConcurrentQueue<Activity> activities = new ConcurrentQueue<Activity>();
	private readonly ActivityListener listener;

	public QueryTracingTest()
	{
		// ParameterBuilderSqlite looks the provider up by name, as applications do at startup
		DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);
		listener = new ActivityListener
		{
			ShouldListenTo = source => source.Name == KarkasTracing.ActivitySourceName,
			Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
			ActivityStopped = activity => activities.Enqueue(activity),
		};
		ActivitySource.AddActivityListener(listener);
	}

	public void Dispose()
	{
		listener.Dispose();
		KarkasTracing.TagMode = QueryTagMode.None;
		KarkasTracing.LoggerFactory = null;
		KarkasTracing.LogParameterValues = false;
		KarkasTracing.ExecutionIdFactory = null;
	}

	private static AdoTemplateSqlite CreateTemplate()
	{
		return new AdoTemplateSqlite(new SqliteConnection("Data Source=:memory:"));
	}

	private static string Tag(Activity a, string name)
	{
		return (string)a.GetTagItem(name)!;
	}

	private Activity Single()
	{
		return Assert.Single(activities);
	}

	[Fact]
	public void TaggingIsOffByDefault()
	{
		Assert.Equal(QueryTagMode.None, KarkasTracing.TagMode);

		CreateTemplate().GetRows("select 1 as A");

		Activity a = Single();
		Assert.Equal("select 1 as A", Tag(a, "db.query.text"));
		Assert.Equal("sqlite", Tag(a, "db.system"));
		Assert.False(string.IsNullOrEmpty(Tag(a, "karkas.execution_id")));
	}

	[Fact]
	public void QueryIdIsStableAndExecutionIdIsNewForEveryRun()
	{
		KarkasTracing.TagMode = QueryTagMode.QueryId;
		AdoTemplateSqlite template = CreateTemplate();

		template.GetRows("select 1 as A");
		template.GetRows("select 1 as A");

		Activity[] runs = activities.ToArray();
		Assert.Equal(2, runs.Length);
		string queryId = Tag(runs[0], "karkas.query_id");
		Assert.StartsWith("AdoTemplateSqlite.GetRows#", queryId);
		Assert.Equal(queryId, Tag(runs[1], "karkas.query_id"));
		Assert.Equal(queryId, runs[0].DisplayName);
		Assert.NotEqual(Tag(runs[0], "karkas.execution_id"), Tag(runs[1], "karkas.execution_id"));
		// same SQL text on both runs, so database plan caches are not affected
		Assert.Equal("/* karkas:" + queryId + " */ select 1 as A", Tag(runs[0], "db.query.text"));
		Assert.Equal(Tag(runs[0], "db.query.text"), Tag(runs[1], "db.query.text"));
	}

	[Fact]
	public void DifferentSqlGetsDifferentQueryId()
	{
		AdoTemplateSqlite template = CreateTemplate();

		template.GetRows("select 1 as A");
		template.GetRows("select 2 as A");

		Activity[] runs = activities.ToArray();
		Assert.NotEqual(Tag(runs[0], "karkas.query_id"), Tag(runs[1], "karkas.query_id"));
	}

	[Fact]
	public void QueryIdAndExecutionIdModeWritesBothIntoSql()
	{
		KarkasTracing.TagMode = QueryTagMode.QueryIdAndExecutionId;
		KarkasTracing.ExecutionIdFactory = () => "exec-1";

		object value = CreateTemplate().GetOneValue("select 42");

		Assert.Equal(42L, value);
		Activity a = Single();
		Assert.Equal("/* karkas:" + Tag(a, "karkas.query_id") + " exec:exec-1 */ select 42", Tag(a, "db.query.text"));
		Assert.Equal("exec-1", Tag(a, "karkas.execution_id"));
	}

	[Fact]
	public void BeginQueryOverridesTheIdAndCanBeNested()
	{
		AdoTemplateSqlite template = CreateTemplate();

		using (KarkasTracing.BeginQuery("Reports.Outer"))
		{
			template.GetRows("select 1");
			using (KarkasTracing.BeginQuery("Reports.Inner"))
			{
				template.GetRows("select 1");
			}
			template.GetRows("select 1");
		}
		Assert.Null(KarkasTracing.CurrentQueryId);

		Assert.Equal(new[] { "Reports.Outer", "Reports.Inner", "Reports.Outer" },
			activities.Select(a => Tag(a, "karkas.query_id")));
	}

	[Fact]
	public void ReusedCommandIsTaggedOnlyOnce()
	{
		KarkasTracing.TagMode = QueryTagMode.QueryIdAndExecutionId;
		AdoTemplateSqlite template = CreateTemplate();
		DbCommand cmd = template.getDatabaseCommand("select 1", template.Connection);

		template.GetOneValue(cmd);
		template.GetOneValue(cmd);

		Assert.Single(System.Text.RegularExpressions.Regex.Matches(cmd.CommandText, "karkas:"));
		Assert.EndsWith(" */ select 1", cmd.CommandText);
		Activity[] runs = activities.ToArray();
		Assert.Equal(Tag(runs[0], "karkas.query_id"), Tag(runs[1], "karkas.query_id"));
	}

	[Fact]
	public void ExceptionCarriesTheIds()
	{
		KarkasDataException ex = Assert.ThrowsAny<KarkasDataException>(
			() => CreateTemplate().GetRows("select * from NoSuchTable"));

		Activity a = Single();
		Assert.Equal(Tag(a, "karkas.query_id"), ex.QueryId);
		Assert.Equal(Tag(a, "karkas.execution_id"), ex.ExecutionId);
		Assert.Equal(ex.QueryId, KarkasTracing.GetQueryId(ex));
		Assert.Contains("[QueryId: " + ex.QueryId + ", ExecutionId: " + ex.ExecutionId + "]", ex.Message);
		Assert.Equal(ActivityStatusCode.Error, a.Status);
	}

	private static SqliteConnection CreateItemTable()
	{
		SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
		connection.Open();
		using (DbCommand create = connection.CreateCommand())
		{
			create.CommandText = "CREATE TABLE Item (Id INTEGER PRIMARY KEY, Name TEXT)";
			create.ExecuteNonQuery();
		}
		return connection;
	}

	[Fact]
	public void DalQueriesAreNamedAfterTheDalAndTheCallingMethod()
	{
		using SqliteConnection connection = CreateItemTable();
		ItemDal dal = new ItemDal(connection) { AutomaticConnectionManagement = false };

		Item item = new Item { Id = 1, Name = "first" };
		dal.Insert(item);
		item.Name = "second";
		dal.Update(item);
		Assert.Equal("second", dal.QueryByName("second")!.Name);
		Assert.Single(dal.QueryAll());
		Assert.Equal(1, dal.TableRowCount);
		dal.Delete(item);

		Assert.Equal(
			new[]
			{
				"ItemDal.Insert", "ItemDal.Update", "ItemDal.QueryByName", "ItemDal.QueryAll",
				"ItemDal.TableRowCount", "ItemDal.Delete",
			},
			activities.Select(a => Tag(a, "karkas.query_id")));
	}

	[Fact]
	public void GeneratedStyleForeignKeyQueryIsNamedAfterItsMethod()
	{
		using SqliteConnection connection = CreateItemTable();
		ItemDal dal = new ItemDal(connection) { AutomaticConnectionManagement = false };

		dal.QueryByNameUsingColumnName("x");
		dal.QueryUsingColumnName("Name", "x");
		using (KarkasTracing.BeginQuery("Caller.Choice"))
		{
			dal.QueryByNameUsingColumnName("x");
		}

		Assert.Equal(new[] { "ItemDal.QueryByNameUsingColumnName", "ItemDal.QueryUsingColumnName", "Caller.Choice" },
			activities.Select(a => Tag(a, "karkas.query_id")));
		Assert.Null(KarkasTracing.CurrentQueryId);
	}

	[Fact]
	public void LogsQueriesWithoutParameterValuesByDefault()
	{
		CapturingLoggerProvider provider = new CapturingLoggerProvider();
		KarkasTracing.LoggerFactory = LoggerFactory.Create(b => b.AddProvider(provider).SetMinimumLevel(LogLevel.Debug));
		AdoTemplateSqlite template = CreateTemplate();
		IParameterBuilder builder = template.getParameterBuilder();
		builder.AddParameter("@secret", DbType.String, "password123");

		template.GetRows("select @secret as A", builder.GetParameterArray());

		string executing = Assert.Single(provider.Messages, m => m.Contains("Executing"));
		Assert.Contains("@secret", executing);
		Assert.DoesNotContain("password123", executing);
		Assert.Contains(provider.Messages, m => m.Contains("Executed"));
		Assert.Contains("ExecutionId", provider.ScopeKeys);
		Assert.Contains("QueryId", provider.ScopeKeys);
	}

	[Fact]
	public void LogsParameterValuesWhenAskedTo()
	{
		CapturingLoggerProvider provider = new CapturingLoggerProvider();
		KarkasTracing.LoggerFactory = LoggerFactory.Create(b => b.AddProvider(provider).SetMinimumLevel(LogLevel.Debug));
		KarkasTracing.LogParameterValues = true;
		AdoTemplateSqlite template = CreateTemplate();
		IParameterBuilder builder = template.getParameterBuilder();
		builder.AddParameter("@value", DbType.String, "visible");

		template.GetRows("select @value as A", builder.GetParameterArray());

		Assert.Contains(provider.Messages, m => m.Contains("@value = 'visible'"));
	}

	[Fact]
	public void LogsFailuresAtErrorLevel()
	{
		CapturingLoggerProvider provider = new CapturingLoggerProvider();
		KarkasTracing.LoggerFactory = LoggerFactory.Create(b => b.AddProvider(provider));

		Assert.ThrowsAny<KarkasDataException>(() => CreateTemplate().GetRows("select * from NoSuchTable"));

		Assert.Contains(provider.Messages, m => m.StartsWith("Error: Failed ") && m.Contains("NoSuchTable"));
	}

	[Theory]
	[InlineData("a*/b")]
	[InlineData("a/*b")]
	[InlineData("a\nb")]
	public void QueryIdCanNotBreakOutOfTheComment(string queryId)
	{
		KarkasTracing.TagMode = QueryTagMode.QueryId;

		using (KarkasTracing.BeginQuery(queryId))
		{
			Assert.Equal(1L, CreateTemplate().GetOneValue("select 1"));
		}

		string text = Tag(Single(), "db.query.text");
		Assert.EndsWith(" */ select 1", text);
		Assert.Single(System.Text.RegularExpressions.Regex.Matches(text, @"\*/"));
		Assert.DoesNotContain("\n", text);
	}

	private sealed class CapturingLoggerProvider : ILoggerProvider
	{
		public ConcurrentQueue<string> Messages { get; } = new ConcurrentQueue<string>();
		public ConcurrentQueue<string> ScopeKeys { get; } = new ConcurrentQueue<string>();

		public ILogger CreateLogger(string categoryName)
		{
			return new CapturingLogger(this);
		}

		public void Dispose()
		{
		}

		private sealed class CapturingLogger : ILogger
		{
			private readonly CapturingLoggerProvider provider;

			public CapturingLogger(CapturingLoggerProvider provider)
			{
				this.provider = provider;
			}

			public IDisposable? BeginScope<TState>(TState state) where TState : notnull
			{
				if (state is IEnumerable<KeyValuePair<string, object>> pairs)
				{
					foreach (var pair in pairs)
					{
						provider.ScopeKeys.Enqueue(pair.Key);
					}
				}
				return null;
			}

			public bool IsEnabled(LogLevel logLevel)
			{
				return true;
			}

			public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
				Func<TState, Exception?, string> formatter)
			{
				provider.Messages.Enqueue(logLevel + ": " + formatter(state, exception));
			}
		}
	}
}

public class Item : BaseTypeLibrary
{
	public long Id { get; set; }
	public string? Name { get; set; }
}

/// <summary>A hand-written Dal shaped like the generated ones.</summary>
public class ItemDal : BaseDalSqlite<Item, AdoTemplateSqlite, ParameterBuilderSqlite>
{
	public ItemDal()
	{
	}

	public ItemDal(DbConnection connection) : base(connection)
	{
	}

	public Item? QueryByName(string name)
	{
		List<Item> list = new List<Item>();
		IParameterBuilder builder = Template.getParameterBuilder();
		builder.AddParameter("@Name", DbType.String, name);
		ExecuteQuery(list, " Name = @Name", builder.GetParameterArray());
		return list.FirstOrDefault();
	}

	/// <summary>Same body as a generated foreign key query (DalGenerator.GetNamedQueryStatements).</summary>
	public List<Item> QueryByNameUsingColumnName(string name)
	{
		using (Karkas.Data.Tracing.KarkasTracing.BeginDefaultQuery(QueryIdFor("QueryByNameUsingColumnName")))
		{
			return this.QueryUsingColumnName("Name", name);
		}
	}

	protected override string SelectCountString => "SELECT COUNT(*) FROM Item";
	protected override string SelectString => "SELECT Id, Name FROM Item";
	protected override string InsertString => "INSERT INTO Item (Id, Name) VALUES (@Id, @Name)";
	protected override string UpdateString => "UPDATE Item SET Name = @Name WHERE Id = @Id";
	protected override string DeleteString => "DELETE FROM Item WHERE Id = @Id";
	protected override bool IdentityExists => false;
	protected override bool IsPkGuid => false;
	public override string PrimaryKey => "Id";

	protected override void ProcessRow(IDataReader dr, Item row)
	{
		row.Id = dr.GetInt64(0);
		row.Name = dr.IsDBNull(1) ? null : dr.GetString(1);
	}

	protected override void InsertCommandParametersAdd(DbCommand cmd, Item row)
	{
		AddIdAndName(cmd, row);
	}

	protected override void UpdateCommandParametersAdd(DbCommand cmd, Item row)
	{
		AddIdAndName(cmd, row);
	}

	protected override void DeleteCommandParametersAdd(DbCommand cmd, Item row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@Id", DbType.Int64, row.Id);
	}

	private void AddIdAndName(DbCommand cmd, Item row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@Id", DbType.Int64, row.Id);
		builder.AddParameter("@Name", DbType.String, row.Name);
	}
}
