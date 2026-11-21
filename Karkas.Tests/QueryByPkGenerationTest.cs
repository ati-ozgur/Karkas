using Xunit;
using Karkas.CodeGeneration.Helpers.Generators;

namespace Karkas.Tests.CodeGeneration.Helpers.Tests;

/// <summary>
/// The generated QueryBy&lt;Pk&gt; method must bind the key as a parameter instead of formatting it into the
/// SQL text, so it is safe against SQL injection (old code: String.Format(" REGION_ID = '{0}'", p)).
/// </summary>
public class QueryByPkGenerationTest
{
	[Fact]
	public void SqliteStatementsUseParameter()
	{
		string[] statements = DalGenerator.GetQueryByPkStatements("CountryCode", "pCountryCode", "@", false);

		Assert.Equal(new[]
		{
			"IParameterBuilder builder = getParameterBuilder();",
			"builder.AddParameter(\"@CountryCode\", pCountryCode);",
			"ExecuteQuery(list, \" CountryCode = @CountryCode\", builder.GetParameterArray());",
		}, statements);
	}

	[Fact]
	public void ForeignKeyAndIndexQueriesAreNamedForTracing()
	{
		string[] statements = DalGenerator.GetNamedQueryStatements("QueryByArtistId",
			"this.QueryUsingColumnName(Album.ColumnNames.ArtistId,pArtistId)");

		Assert.Equal(new[]
		{
			"using (Karkas.Data.Tracing.KarkasTracing.BeginDefaultQuery(QueryIdFor(\"QueryByArtistId\")))",
			"{",
			"\treturn this.QueryUsingColumnName(Album.ColumnNames.ArtistId,pArtistId);",
			"}",
		}, statements);
	}

	[Fact]
	public void OracleStatementsUseColonParameter()
	{
		string[] statements = DalGenerator.GetQueryByPkStatements("REGION_ID", "pREGION_ID", ":", false);

		Assert.Equal("builder.AddParameter(\":REGION_ID\", pREGION_ID);", statements[1]);
		Assert.Equal("ExecuteQuery(list, \" REGION_ID = :REGION_ID\", builder.GetParameterArray());", statements[2]);
	}

	[Fact]
	public void QuotedColumnNameKeepsParameterNameUnquoted()
	{
		string[] statements = DalGenerator.GetQueryByPkStatements("RegionId", "pRegionId", ":", true);

		// The column is quoted inside the generated C# string literal; the parameter name is not.
		Assert.Equal("builder.AddParameter(\":RegionId\", pRegionId);", statements[1]);
		Assert.Equal("ExecuteQuery(list, \" \\\"RegionId\\\" = :RegionId\", builder.GetParameterArray());",
			statements[2]);
	}

	[Theory]
	[InlineData("@", false)]
	[InlineData(":", true)]
	public void ValueIsNeverFormattedIntoSql(string parameterSymbol, bool useQuotes)
	{
		string[] statements = DalGenerator.GetQueryByPkStatements("Id", "pId", parameterSymbol, useQuotes);

		foreach (string statement in statements)
		{
			Assert.DoesNotContain("String.Format", statement, StringComparison.OrdinalIgnoreCase);
			Assert.DoesNotContain("'{0}'", statement);
			Assert.DoesNotContain("+ pId", statement);
		}
	}
}
