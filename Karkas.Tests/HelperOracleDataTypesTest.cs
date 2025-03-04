using Xunit;
using Karkas.CodeGeneration.Oracle.Implementations;

namespace Karkas.Tests.CodeGeneration.Oracle.Tests;

public class HelperOracleDataTypesTest
{

	[Fact]
	public void GetDotNetType_ShouldThrowException()
	{
		Assert.Throws<ArgumentException>(() =>  HelperOracleDataTypes.GetDotNetType("NUMBER",0,0));
	}

	[Theory]
	[InlineData("VARCHAR2", "string")]
	[InlineData("DATE", "DateTime")]
	[InlineData("CHAR", "string")]
	[InlineData("CLOB", "string")]
	[InlineData("BLOB", "byte[]")]
	public void GetDotNetType_ShouldReturnCorrectDotNetType(string oracleType, string expectedDotNetType)
	{
		// Act
		var result = HelperOracleDataTypes.GetDotNetType(oracleType);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}


	[Theory]
	[InlineData("NUMBER",1,10, "decimal")]
	[InlineData("NUMBER",1,20, "decimal")]
	[InlineData("NUMBER",1,25, "decimal")]
	[InlineData("NUMBER",1,5, "decimal")]
	[InlineData("NUMBER",1,30, "OracleDecimal")]
	public void GetDotNetType_ShouldReturnDecimal1(string oracleType,int dataScale, int dataLength, string expectedDotNetType)
	{
		// Act
		var result = HelperOracleDataTypes.GetDotNetType(oracleType,dataScale,dataLength);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}
}

