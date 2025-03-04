using Xunit;
using Karkas.CodeGeneration.Oracle.Implementations;

namespace Karkas.Tests.CodeGeneration.Oracle.Tests;

public class HelperOracleDataTypesTest
{
	[Theory]
	[InlineData("VARCHAR2", "string")]
	[InlineData("NUMBER", "decimal")]
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
}

