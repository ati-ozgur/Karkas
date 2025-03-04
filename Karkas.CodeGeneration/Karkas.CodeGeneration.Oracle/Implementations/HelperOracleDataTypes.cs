using System;

namespace Karkas.CodeGeneration.Oracle.Implementations;

public class HelperOracleDataTypes
{
	readonly static int MAX_INT32_LENGTH = Int32.MaxValue.ToString().Length;
	readonly static int MAX_INT64_LENGTH = Int64.MaxValue.ToString().Length;
	readonly static int MAX_INT128_LENGTH = Int128.MaxValue.ToString().Length;
	// int32 max 10 bytes
	// int64 max 19 bytes
	// int128 max 39 bytes

	public static string GetDotNetType(string dataTypeInDatabase,int dataScale = 0,int dataPrecision = 0, bool changeNumericToLong = true)
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
			dataTypeInDatabase.Equals("xml") ||
			dataTypeInDatabase.Equals("text") ||
			dataTypeInDatabase.Equals("xmltype") ||
			dataTypeInDatabase.Equals("xmltypeextra") ||
			dataTypeInDatabase.Equals("xmltypepi")

		)
		{
			return "string";
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
			dataTypeInDatabase.Equals("image") ||
			dataTypeInDatabase.Equals("long") ||
			dataTypeInDatabase.Equals("blob") ||
			dataTypeInDatabase.Equals("binary") ||
			dataTypeInDatabase.Equals("varbinary") ||
			dataTypeInDatabase.Equals("timestamp")
		)
		{
			return "byte[]";
		}
		if (dataTypeInDatabase.Equals("sql_variant"))
		{
			return "object";
		}

		if (dataTypeInDatabase.Equals("number"))
		{
			if (dataPrecision == 0 && dataScale == 0)
			{
				throw new ArgumentException("number data length and data scale cannot be 0");
			}
			// .net decimal supports 28-29 digits
			// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types
			if (dataScale > 0 && dataPrecision < 29)
			{
				return "decimal";
			}
			else if (dataScale > 0 && dataPrecision > 29)
			{
				return "OracleDecimal";
			}
			else
			{
				if (dataPrecision <= MAX_INT32_LENGTH)
				{
					return  "int";
				}
				else if (dataPrecision <= MAX_INT64_LENGTH)
				{
					return "long";
				}
				else if (dataPrecision <= MAX_INT128_LENGTH)
				{
					return "Int128";
				}
				else
				{
					return "OracleDecimal";
				}
			}
		}

		return "Unknown";

	}

}
