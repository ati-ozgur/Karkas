using Xunit;
using Karkas.CodeGeneration.Oracle.Implementations;

namespace Karkas.Tests.CodeGeneration.Oracle.Tests;

public class HelperOracleDataTypesTest
{

	// ANSI Supported Data Types
	// https://docs.oracle.com/en/database/oracle/oracle-database/23/sqlqr/Data-Types.html

	// Even though following data types are supported by Oracle Database in CREATE TABLE statements,
	// They are STILL changed to internal oracle types.
	// { CHARACTER[VARYING] (size)
	// | { CHAR | NCHAR } VARYING(size)
	// | VARCHAR(size)
	// | NATIONAL { CHARACTER | CHAR }
	//      [VARYING] (size)

	// FOR example
	// 	CREATE TABLE ANSI_STRING(
	// 		C1 CHARACTER(5),
	// 	C2 CHARACTER VARYING(5),
	// 	C3 NATIONAL CHARACTER(5),
	// 	C4 NATIONAL CHARACTER VARYING(5)
	// );
	// is changed to
	// C1 CHAR(5)
	// C2 VARCHAR2(5)
	// C3 NCHAR(5)
	// C4 NVARCHAR2(5)
	// Thus we only need to test for char and varchar2, nchar and nvarchar2


	[Theory]
	[InlineData("CHAR", "string")]
	[InlineData("VARCHAR2", "string")]
	[InlineData("NCHAR", "string")]
	[InlineData("NVARCHAR2", "string")]
	public void ANSISupportCharacter_ShouldReturnString(string oracleType, string expectedDotNetType)
	{
		// Act
		var result = HelperOracleDataTypes.GetDotNetType(oracleType);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}

	// Even though following data types are supported by Oracle Database in CREATE TABLE statements,
	// They are STILL changed to internal oracle types.
	// | { NUMERIC | DECIMAL | DEC }
	// [(precision[, scale])]
	// | { INTEGER | INT | SMALLINT }
	// | FLOAT[(size)]
	// | DOUBLE PRECISION
	// | REAL
	// }
	// FOR example
	// CREATE TABLE ANSI_NUMERIC(
	// 	C01 NUMERIC,
	// 	C02 DECIMAL,
	// 	C03 DEC,
	// 	C04 INTEGER,
	// 	C05 INT,
	// 	C06 INTEGER,
	// 	C07 SMALLINT,
	// 	C08 FLOAT,
	// 	C09 DOUBLE PRECISION,
	// 	C10 REAL
	// );
	// CREATE TABLE ANSI_NUMERIC
	// 	(C01 NUMBER(38,0),
	// 	C02 NUMBER(38,0),
	// 	C03 NUMBER(38,0),
	// 	C04 NUMBER(38,0),
	// 	C05 NUMBER(38,0),
	// 	C06 NUMBER(38,0),
	// 	C07 NUMBER(38,0),
	// 	C08 FLOAT(126),
	// 	C09 FLOAT(126),
	// 	C10 FLOAT(63)
	//    ) ;
	// Thus we only need to test for NUMBER and FLOAT

	[Theory]
	[InlineData("NUMBER", 38, 0, "OracleDecimal")]
	public void ANSISupportWholeNumbers_ShouldReturnWholeNumbers(string oracleType,  int dataPrecision, int dataScale, string expectedDotNetType)
	{
		// Act
		var result = HelperOracleDataTypes.GetDotNetType(oracleType, dataScale, dataPrecision);

		// Assert
		Assert.Equal(expectedDotNetType, result);
	}



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
	[InlineData("NUMBER",10,1, "decimal")]
	[InlineData("NUMBER",20,1, "decimal")]
	[InlineData("NUMBER",25,1, "decimal")]
	[InlineData("NUMBER",5,1, "decimal")]
	[InlineData("NUMBER",30,1, "OracleDecimal")]
	public void GetDotNetType_ShouldReturnDecimal1(string oracleType, int dataLength, int dataScale, string expectedDotNetType)
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
	[InlineData("NUMBER",0,20, "decimal")]
	[InlineData("NUMBER",0,25, "decimal")]
	[InlineData("NUMBER",0,38, "OracleDecimal")]
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

