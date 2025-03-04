using System;

namespace Karkas.CodeGeneration.Oracle.Implementations;

public class HelperOracleDataTypes
{

	public static string GetDotNetType(string pSqlTypeName)
	{
		pSqlTypeName = pSqlTypeName.ToLowerInvariant();
		if (
			pSqlTypeName.Equals("varchar") ||
			pSqlTypeName.Equals("nvarchar") ||
			pSqlTypeName.Equals("nvarchar2") ||
			pSqlTypeName.Equals("varchar2") ||
			pSqlTypeName.Equals("clob") ||
			pSqlTypeName.Equals("nclob") ||
			pSqlTypeName.Equals("char") ||
			pSqlTypeName.Equals("nchar") ||
			pSqlTypeName.Equals("ntext") ||
			pSqlTypeName.Equals("xml") ||
			pSqlTypeName.Equals("text") ||
			pSqlTypeName.Equals("xmltype") ||
			pSqlTypeName.Equals("xmltypeextra") ||
			pSqlTypeName.Equals("xmltypepi")

		)
		{

			return "string";
		}

		if (
			pSqlTypeName.Equals("date")
		)
		{
			return "DateTime";
		}
		if (

			// TODO HERE
			pSqlTypeName.Equals("number"))
		{
			return "decimal";
		}
		if (pSqlTypeName.Equals("float"))
		{
			return "double";
		}
		if (pSqlTypeName.Equals("real"))
		{
			return "float";
		}
		if (
			pSqlTypeName.Equals("image") ||
			pSqlTypeName.Equals("long") ||
			pSqlTypeName.Equals("blob") ||
			pSqlTypeName.Equals("binary") ||
			pSqlTypeName.Equals("varbinary") ||
			pSqlTypeName.Equals("timestamp")
		)
		{
			return "byte[]";
		}
		if (pSqlTypeName.Equals("sql_variant"))
		{
			return "object";
		}
		return "Unknown";

	}

}
