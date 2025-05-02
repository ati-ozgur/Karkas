using System;

namespace Karkas.CodeGeneration.Oracle.Implementations;

public class HelperOracleDataTypes
{
	readonly static int MAX_INT32_LENGTH = Int32.MaxValue.ToString().Length;
	readonly static int MAX_INT64_LENGTH = Int64.MaxValue.ToString().Length;
	readonly static int MAX_DECIMAL_LENGTH = Int64.MaxValue.ToString().Length;
	readonly static int MAX_INT128_LENGTH = Int128.MaxValue.ToString().Length;
	// int32 max 10 digits
	// int64 max 19 digits
	// decimal max 28 digits
	// int128 max 39 digits

	const int MAX_DIGIT_DOTNET_DECIMAL = 28;

	public static string GetDotNetType(string dataTypeInDatabase,
				bool forceIdentityToNumeric = false,
				int dataPrecision = 0,
				int dataScale = 0,
				bool forceOracleDecimalToIntegersAndDecimal = true)
	{
		dataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
		if (
			dataTypeInDatabase.Equals("varchar") ||
			dataTypeInDatabase.Equals("nvarchar") ||
			dataTypeInDatabase.Equals("nvarchar2") ||
			dataTypeInDatabase.Equals("varchar2") ||
			dataTypeInDatabase.Equals("clob") ||
			dataTypeInDatabase.Equals("nclob") ||
			dataTypeInDatabase.Equals("char") ||
			dataTypeInDatabase.Equals("nchar") ||
			dataTypeInDatabase.Equals("ntext") ||
			dataTypeInDatabase.Equals("long") ||  // long is deprecated
			dataTypeInDatabase.Equals("xml") ||
			dataTypeInDatabase.Equals("text") ||
			dataTypeInDatabase.Equals("xmltype") ||
			dataTypeInDatabase.Equals("xmltypeextra") ||
			dataTypeInDatabase.Equals("xmltypepi")

		)
		{
			return "string";
		}
		if (dataTypeInDatabase == "bfile")
		{
			return "OracleBFile";
		}
		if (dataTypeInDatabase == "binary_float")
		{
			return "float";
		}
		if (dataTypeInDatabase == "binary_double")
		{
			return "double";
		}

		if (
			dataTypeInDatabase.Equals("date")
		)
		{
			return "DateTime";
		}
		if (dataTypeInDatabase.Equals("float"))
		{
			return "double";
		}
		if (dataTypeInDatabase.Equals("real"))
		{
			return "float";
		}
		if (
			dataTypeInDatabase.Equals("blob") ||
			dataTypeInDatabase.Equals("raw") ||
			dataTypeInDatabase.Equals("long raw")
		)
		{
			return "byte[]";
		}


		if (dataTypeInDatabase.Equals("number"))
		{
			if (forceIdentityToNumeric)
			{
				return "long";
			}
			//  Precision is the total number of digits, can be between 1 and 38.
				// Scale is the number of digits after the decimal point
				// may also be set as negative for rounding.

				if (dataPrecision <= 0)
				{
					throw new ArgumentException("number data precision must be at least 1");
				}
			if(dataScale <= 0)
			{
				if (dataPrecision <= MAX_INT32_LENGTH && forceOracleDecimalToIntegersAndDecimal)
				{
					return "int";
				}
				else if (dataPrecision <= MAX_INT64_LENGTH && forceOracleDecimalToIntegersAndDecimal)
				{
					return "long";
				}
			}
			// .net decimal supports 28-29 digits
			// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
			if (dataPrecision < MAX_DIGIT_DOTNET_DECIMAL)
			{
				return "decimal";
			}
			if (forceOracleDecimalToIntegersAndDecimal)
			{
				return "decimal";
			}
			else if (dataPrecision > MAX_DIGIT_DOTNET_DECIMAL)
			{
				return "OracleDecimal";
			}
			return "decimal";
		}

		return "Unknown";

	}

}
