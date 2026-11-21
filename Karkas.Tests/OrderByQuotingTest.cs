using System.Data;
using System.Data.Common;
using Xunit;
using Karkas.Data;
using Karkas.Data.Oracle;

namespace Karkas.Tests.Data.Tests;

/// <summary>
/// Oracle turns an unquoted CustomerId into CUSTOMERID, which fails on tables created with quoted
/// mixed-case names (ORA-00904). So Oracle DALs quote plain column names in ORDER BY;
/// other databases write them as given.
/// </summary>
public class OrderByQuotingTest
{
	[Theory]
	[InlineData("CustomerId", OrderByEnum.ASC, "\"CustomerId\" ASC")]
	[InlineData("SupportRepId", OrderByEnum.DESC, "\"SupportRepId\" DESC")]
	[InlineData("CUSTOMER_ID", OrderByEnum.ASC, "\"CUSTOMER_ID\" ASC")]
	[InlineData("_x$1#", OrderByEnum.ASC, "\"_x$1#\" ASC")]
	public void QuotingPlainColumnNames(string column, OrderByEnum direction, string expected)
	{
		Assert.Equal(expected, new OrderBy(column, direction).GetSqlForm(true));
	}

	[Theory]
	[InlineData("\"CustomerId\"")]
	[InlineData("[CustomerId]")]
	[InlineData("c.CustomerId")]
	[InlineData("LOWER(Name)")]
	[InlineData("1")]
	[InlineData("Name COLLATE NOCASE")]
	public void QuotingLeavesOtherExpressionsAsGiven(string column)
	{
		Assert.Equal(column + " ASC", new OrderBy(column).GetSqlForm(true));
	}

	[Fact]
	public void SqlFormDoesNotQuote()
	{
		Assert.Equal("CustomerId ASC", new OrderBy("CustomerId").SqlForm);
		Assert.Equal("CustomerId DESC", new OrderBy("CustomerId", OrderByEnum.DESC).GetSqlForm(false));
	}

	[Fact]
	public void QueryHelperDoesNotQuoteByDefault()
	{
		QueryHelper helper = new QueryHelper("@");
		helper.AddOrderBy("SupportRepId", OrderByEnum.ASC);
		helper.AddOrderBy("CustomerId", "desc");

		Assert.False(helper.QuoteOrderByColumnNames);
		Assert.EndsWith("ORDER BY SupportRepId ASC,CustomerId desc", helper.GetCriteriaResultsWithoutWhere());
	}

	[Fact]
	public void QueryHelperQuotesWhenAsked()
	{
		QueryHelper helper = new QueryHelper(":", true);
		helper.AddOrderBy("SupportRepId", OrderByEnum.ASC);
		helper.AddOrderBy("CustomerId", "desc");

		Assert.EndsWith("ORDER BY \"SupportRepId\" ASC,\"CustomerId\" desc", helper.GetCriteriaResultsWithoutWhere());
	}

	[Fact]
	public void OnlyOracleDalsQuote()
	{
		Assert.True(new OracleItemDal().GetNewQueryHelper().QuoteOrderByColumnNames);
		Assert.False(new ItemDal().GetNewQueryHelper().QuoteOrderByColumnNames);
	}
}

/// <summary>Minimal Oracle Dal; only used to check the Oracle base class settings, it never runs a query.</summary>
public class OracleItemDal : BaseDalOracle<Item, AdoTemplateOracle, ParameterBuilderOracle>
{
	protected override string SelectCountString => "SELECT COUNT(*) FROM \"Item\"";
	protected override string SelectString => "SELECT \"Id\", \"Name\" FROM \"Item\"";
	protected override string InsertString => "";
	protected override string UpdateString => "";
	protected override string DeleteString => "";
	protected override bool IdentityExists => false;
	protected override bool IsPkGuid => false;

	protected override void ProcessRow(IDataReader dr, Item row)
	{
	}

	protected override void InsertCommandParametersAdd(DbCommand cmd, Item row)
	{
	}

	protected override void UpdateCommandParametersAdd(DbCommand cmd, Item row)
	{
	}

	protected override void DeleteCommandParametersAdd(DbCommand cmd, Item row)
	{
	}
}
