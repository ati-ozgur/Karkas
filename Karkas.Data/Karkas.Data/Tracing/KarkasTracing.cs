using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Karkas.Data.Tracing
{
	/// <summary>
	/// Process-wide settings for query tracing.
	/// Every query Karkas runs gets two ids:
	/// <list type="bullet">
	/// <item><b>QueryId</b>: the same for every run of the same call site, for example
	/// <c>CustomerDal.QueryByCustomerId</c>.</item>
	/// <item><b>ExecutionId</b>: new for every run.</item>
	/// </list>
	/// Both ids are written to log scopes, to <see cref="System.Diagnostics.Activity"/> tags
	/// (source <see cref="ActivitySourceName"/>) and to the Data of exceptions thrown by Karkas.
	/// With <see cref="TagMode"/> they can also be written into the SQL text.
	/// </summary>
	public static class KarkasTracing
	{
		/// <summary>Name of the ActivitySource; add it to OpenTelemetry with AddSource("Karkas.Data").</summary>
		public const string ActivitySourceName = "Karkas.Data";

		/// <summary>Logger category used for query logs.</summary>
		public const string LoggerCategory = "Karkas.Data";

		/// <summary>Key in <see cref="Exception.Data"/> that holds the query id.</summary>
		public const string QueryIdDataKey = "Karkas.QueryId";

		/// <summary>Key in <see cref="Exception.Data"/> that holds the execution id.</summary>
		public const string ExecutionIdDataKey = "Karkas.ExecutionId";

		internal static readonly ActivitySource ActivitySource = new ActivitySource(ActivitySourceName);

		private static readonly AsyncLocal<string> currentQueryId = new AsyncLocal<string>();

		private static ILoggerFactory loggerFactory;
		private static volatile ILogger logger = NullLogger.Instance;
		private static volatile Func<string> executionIdFactory = DefaultExecutionId;

		/// <summary>
		/// Logger factory used by Karkas. Null (default) means nothing is logged.
		/// Queries are logged at Debug level, failures at Error level.
		/// </summary>
		public static ILoggerFactory LoggerFactory
		{
			get { return loggerFactory; }
			set
			{
				loggerFactory = value;
				logger = value == null ? (ILogger)NullLogger.Instance : value.CreateLogger(LoggerCategory);
			}
		}

		internal static ILogger Logger
		{
			get { return logger; }
		}

		/// <summary>Whether the ids are also written into the SQL text. Default is <see cref="QueryTagMode.None"/>.</summary>
		public static QueryTagMode TagMode { get; set; } = QueryTagMode.None;

		/// <summary>
		/// Whether parameter values are written to the logs. Default false, because values can contain personal data.
		/// </summary>
		public static bool LogParameterValues { get; set; }

		/// <summary>
		/// Creates execution ids. Default is a new Guid in "N" format.
		/// Setting null restores the default.
		/// </summary>
		public static Func<string> ExecutionIdFactory
		{
			get { return executionIdFactory; }
			set { executionIdFactory = value ?? DefaultExecutionId; }
		}

		/// <summary>The query id set by the innermost <see cref="BeginQuery"/> scope, or null.</summary>
		public static string CurrentQueryId
		{
			get { return currentQueryId.Value; }
		}

		/// <summary>
		/// Gives every query run inside the scope the given query id,
		/// instead of the id Karkas would pick itself. Scopes can be nested; the innermost wins.
		/// <code>
		/// using (KarkasTracing.BeginQuery("Reports.MonthlySales"))
		/// {
		///     var rows = template.GetRows(sql);
		/// }
		/// </code>
		/// </summary>
		public static IDisposable BeginQuery(string queryId)
		{
			if (string.IsNullOrWhiteSpace(queryId))
			{
				throw new ArgumentException("queryId can not be empty", nameof(queryId));
			}
			string previous = currentQueryId.Value;
			currentQueryId.Value = queryId;
			return new QueryIdScope(previous);
		}

		/// <summary>
		/// Like <see cref="BeginQuery"/>, but does nothing when a scope is already active,
		/// so a name chosen by the caller wins. Karkas and generated code use it to name
		/// queries that run through shared helpers such as QueryUsingColumnName.
		/// </summary>
		public static IDisposable BeginDefaultQuery(string queryId)
		{
			if (currentQueryId.Value != null)
			{
				return NoScope.Instance;
			}
			return BeginQuery(queryId);
		}

		/// <summary>Query id attached to an exception thrown by Karkas, or null.</summary>
		public static string GetQueryId(Exception ex)
		{
			return ex == null ? null : ex.Data[QueryIdDataKey] as string;
		}

		/// <summary>Execution id attached to an exception thrown by Karkas, or null.</summary>
		public static string GetExecutionId(Exception ex)
		{
			return ex == null ? null : ex.Data[ExecutionIdDataKey] as string;
		}

		internal static string NewExecutionId()
		{
			string id = null;
			try
			{
				id = executionIdFactory();
			}
			catch (Exception)
			{
				// a broken user factory must not break queries
			}
			return string.IsNullOrEmpty(id) ? DefaultExecutionId() : id;
		}

		private static string DefaultExecutionId()
		{
			return Guid.NewGuid().ToString("N");
		}

		private sealed class NoScope : IDisposable
		{
			public static readonly NoScope Instance = new NoScope();

			public void Dispose()
			{
			}
		}

		private sealed class QueryIdScope : IDisposable
		{
			private readonly string previous;
			private bool disposed;

			public QueryIdScope(string previous)
			{
				this.previous = previous;
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					currentQueryId.Value = previous;
				}
			}
		}
	}
}
