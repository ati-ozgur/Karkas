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

	[Theory]
	[InlineData("NUMBER",1,10, "decimal")]
	[InlineData("NUMBER",1,20, "decimal")]
	[InlineData("NUMBER",1,25, "decimal")]
	[InlineData("NUMBER",1,5, "decimal")]
	[InlineData("NUMBER",1,30, "OracleDecimal")]
	public void GetDotNetType_ShouldReturnIntTypes1(string oracleType,int dataScale, int dataLength, string expectedDotNetType)
	{
		// Act
		// since we have datascale 1, change number to true does not affect the result
		var result = HelperOracleDataTypes.GetDotNetType(oracleType,dataScale,dataLength,true);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}

	[Theory]
	[InlineData("NUMBER",0,10, "int")]
	[InlineData("NUMBER",0,15, "long")]
	[InlineData("NUMBER",0,20, "Int128")]
	[InlineData("NUMBER",0,25, "Int128")]
	[InlineData("NUMBER",0,38, "Int128")]
	public void GetDotNetType_ShouldReturnIntTypes2(string oracleType,int dataScale, int dataLength, string expectedDotNetType)
	{

		// int32 max 10 bytes
		// int64 max 19 bytes
		// int128 max 39 bytes

		// since we have datascale 0, change number to true should make them int,long, Int128
		var result = HelperOracleDataTypes.GetDotNetType(oracleType,dataScale,dataLength,true);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}

}

