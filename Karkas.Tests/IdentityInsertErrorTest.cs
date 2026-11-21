using System.Data;
using System.Data.Common;
using Xunit;
using Microsoft.Data.Sqlite;
using Karkas.Data;
using Karkas.Data.Sqlite;

namespace Karkas.Tests.Data.Tests;

/// <summary>
/// An identity Insert that fails after the row is written (here: the new id can not be converted to the
/// primary key type) must throw. It used to swallow the error and return default(PRIMARY_KEY) as if it worked.
/// </summary>
[Collection(QueryTracingCollection.Name)]
public class IdentityInsertErrorTest
{
	[Fact]
	public void SqliteIdentityInsertRethrowsNonDatabaseErrors()
	{
		DbProviderFactories.RegisterFactory("Microsoft.Data.Sqlite", SqliteFactory.Instance);
		using SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
		connection.Open();
		using (DbCommand create = connection.CreateCommand())
		{
			create.CommandText = "CREATE TABLE Thing (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT)";
			create.ExecuteNonQuery();
		}
		WrongKeyTypeThingDal dal = new WrongKeyTypeThingDal(connection) { AutomaticConnectionManagement = false };

		Assert.Throws<InvalidCastException>(() => dal.Insert(new Thing { Name = "x" }));
	}
}

public class Thing : BaseTypeLibrary
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
}

/// <summary>Declares a Guid key, but SQLite returns a long row id.</summary>
public class WrongKeyTypeThingDal : BaseDalForIdentitySqlite<Thing, Guid, AdoTemplateSqlite, ParameterBuilderSqlite>
{
	public WrongKeyTypeThingDal(DbConnection connection) : base(connection)
	{
	}

	public override string IdentityParameterName => "Id";
	protected override string SelectCountString => "SELECT COUNT(*) FROM Thing";
	protected override string SelectString => "SELECT Id, Name FROM Thing";
	protected override string InsertString => "INSERT INTO Thing (Name) VALUES (@Name);select last_insert_rowid();";
	protected override string UpdateString => "UPDATE Thing SET Name = @Name WHERE Id = @Id";
	protected override string DeleteString => "DELETE FROM Thing WHERE Id = @Id";
	protected override bool IdentityExists => true;
	protected override bool IsPkGuid => false;
	public override string PrimaryKey => "Id";

	protected override void setIdentityColumnValue(Thing pTypeLibrary, Guid pIdentityColumnValue)
	{
		pTypeLibrary.Id = pIdentityColumnValue;
	}

	protected override void ProcessRow(IDataReader dr, Thing row)
	{
		row.Name = dr.IsDBNull(1) ? null : dr.GetString(1);
	}

	protected override void InsertCommandParametersAdd(DbCommand cmd, Thing row)
	{
		ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@Name", DbType.String, row.Name);
	}

	protected override void UpdateCommandParametersAdd(DbCommand cmd, Thing row)
	{
	}

	protected override void DeleteCommandParametersAdd(DbCommand cmd, Thing row)
	{
	}
}
