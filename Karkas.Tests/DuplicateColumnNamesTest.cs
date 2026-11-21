using Xunit;
using Microsoft.Data.Sqlite;
using Karkas.Data.Sqlite;

namespace Karkas.Tests.Data.Tests;

/// <summary>
/// A select that returns the same column name more than once must not throw
/// "An item with the same key has already been added" (issue #12).
/// Repeated names get a numeric suffix: Name, Name_2, Name_3 ...
/// </summary>
public class DuplicateColumnNamesTest
{
	private static AdoTemplateSqlite CreateTemplate()
	{
		return new AdoTemplateSqlite(new SqliteConnection("Data Source=:memory:"));
	}

	[Fact]
	public void GetRowsSuffixesDuplicateColumnNames()
	{
		var rows = CreateTemplate().GetRows("select 1 as Name, 2 as Name, 3 as Name");

		Assert.Single(rows);
		Assert.Equal(new[] { "Name", "Name_2", "Name_3" }, rows[0].Keys);
		Assert.Equal(1L, rows[0]["Name"]);
		Assert.Equal(2L, rows[0]["Name_2"]);
		Assert.Equal(3L, rows[0]["Name_3"]);
	}

	[Fact]
	public void GetRowsDoesNotOverwriteExistingSuffixedColumn()
	{
		var rows = CreateTemplate().GetRows("select 1 as Name, 2 as Name, 3 as Name_2");

		Assert.Equal(new[] { "Name", "Name_2", "Name_2_2" }, rows[0].Keys);
		Assert.Equal(2L, rows[0]["Name_2"]);
		Assert.Equal(3L, rows[0]["Name_2_2"]);
	}

	[Fact]
	public void GetRowsWorksWithJoinOfSameColumnNames()
	{
		var rows = CreateTemplate().GetRows(
			"select a.Name, b.Name from (select 'artist' as Name) a cross join (select 'album' as Name) b");

		Assert.Equal("artist", rows[0]["Name"]);
		Assert.Equal("album", rows[0]["Name_2"]);
	}

	[Fact]
	public void GetRowsKeepsUniqueColumnNamesUnchanged()
	{
		var rows = CreateTemplate().GetRows("select 1 as AlbumId, 'x' as Title");

		Assert.Equal(new[] { "AlbumId", "Title" }, rows[0].Keys);
	}
}
