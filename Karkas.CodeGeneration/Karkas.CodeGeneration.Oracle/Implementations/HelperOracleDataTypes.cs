using System;

namespace Karkas.CodeGeneration.Oracle.Implementations;

public class HelperOracleDataTypes
{

	public static string GetDotNetType(string dataTypeInDatabase)
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
		if (

			// TODO HERE
			//
			dataTypeInDatabase.Equals("number"))
		{
			return "decimal";
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
		return "Unknown";

	}

}
