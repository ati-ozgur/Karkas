using Xunit;
using Microsoft.Data.Sqlite;
using Karkas.Data;
using Karkas.Data.Sqlite;

namespace Karkas.Tests.Data.Tests;

/// <summary>
/// GetRows can return column names as they are, in lower case or in upper case (issue #13).
/// </summary>
public class ColumnNameCaseTest
{
	private const string Sql = "select 1 as AlbumId, 'x' as Title";

	private static AdoTemplateSqlite CreateTemplate()
	{
		return new AdoTemplateSqlite(new SqliteConnection("Data Source=:memory:"));
	}

	[Fact]
	public void GetRowsKeepsColumnNamesByDefault()
	{
		var rows = CreateTemplate().GetRows(Sql);

		Assert.Equal(new[] { "AlbumId", "Title" }, rows[0].Keys);
	}

	[Fact]
	public void GetRowsAsItIs()
	{
		var rows = CreateTemplate().GetRows(Sql, ColumnNameCase.AsItIs);

		Assert.Equal(new[] { "AlbumId", "Title" }, rows[0].Keys);
	}

	[Fact]
	public void GetRowsToLower()
	{
		var rows = CreateTemplate().GetRows(Sql, ColumnNameCase.ToLower);

		Assert.Equal(new[] { "albumid", "title" }, rows[0].Keys);
		Assert.Equal(1L, rows[0]["albumid"]);
		Assert.Equal("x", rows[0]["title"]);
	}

	[Fact]
	public void GetRowsToUpper()
	{
		var rows = CreateTemplate().GetRows(Sql, ColumnNameCase.ToUpper);

		Assert.Equal(new[] { "ALBUMID", "TITLE" }, rows[0].Keys);
	}

	[Fact]
	public void GetRowsWithParametersAndTimeoutChangesCase()
	{
		var template = CreateTemplate();
		var parameter = new SqliteParameter("@Id", 5);

		var rows = template.GetRows("select @Id as AlbumId", new System.Data.Common.DbParameter[] { parameter },
			null, ColumnNameCase.ToLower);

		Assert.Equal(5L, rows[0]["albumid"]);
	}

	[Fact]
	public void GetTopRowsChangesCase()
	{
		var rows = CreateTemplate().GetTopRows(Sql, 1, ColumnNameCase.ToUpper);

		Assert.Single(rows);
		Assert.Equal(new[] { "ALBUMID", "TITLE" }, rows[0].Keys);
	}

	[Fact]
	public void GetTopRowsWithParametersChangesCase()
	{
		var parameters = new System.Data.Common.DbParameter[] { new SqliteParameter("@Id", 5) };
		var rows = CreateTemplate().GetTopRows("select @Id as AlbumId", parameters, 1, ColumnNameCase.ToLower);

		Assert.Equal(5L, rows[0]["albumid"]);
	}

	[Fact]
	public void GetOneRowChangesCase()
	{
		var row = CreateTemplate().GetOneRow(Sql, ColumnNameCase.ToLower);

		Assert.NotNull(row);
		Assert.Equal(new[] { "albumid", "title" }, row.Keys);
	}

	[Fact]
	public void GetOneRowWithParametersChangesCase()
	{
		var parameters = new System.Data.Common.DbParameter[] { new SqliteParameter("@Id", 5) };
		var row = CreateTemplate().GetOneRow("select @Id as AlbumId", parameters, ColumnNameCase.ToUpper);

		Assert.NotNull(row);
		Assert.Equal(5L, row["ALBUMID"]);
	}

	[Fact]
	public void GetOneRowKeepsColumnNamesByDefault()
	{
		var row = CreateTemplate().GetOneRow(Sql);

		Assert.NotNull(row);
		Assert.Equal(new[] { "AlbumId", "Title" }, row.Keys);
	}

	[Fact]
	public void GetRowsSuffixesNamesThatCollideAfterCaseChange()
	{
		var rows = CreateTemplate().GetRows("select 1 as Name, 2 as NAME", ColumnNameCase.ToLower);

		Assert.Equal(new[] { "name", "name_2" }, rows[0].Keys);
	}

	[Fact]
	public void GetRowsToUpperIgnoresTurkishCulture()
	{
		var previous = System.Globalization.CultureInfo.CurrentCulture;
		try
		{
			System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
			var rows = CreateTemplate().GetRows("select 1 as id, 2 as ID", ColumnNameCase.ToUpper);

			Assert.Equal(new[] { "ID", "ID_2" }, rows[0].Keys);
		}
		finally
		{
			System.Globalization.CultureInfo.CurrentCulture = previous;
		}
	}
}
