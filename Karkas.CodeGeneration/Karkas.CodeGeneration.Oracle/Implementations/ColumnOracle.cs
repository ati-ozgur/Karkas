using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.Helpers;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        public ColumnOracle(IAdoTemplate<IParameterBuilder> pTemplate, IContainer pTableOrView,string pColumnName)
        {

            template = pTemplate;
            tableOrView = pTableOrView;
            this.columnName = pColumnName;
        }

        private string columnName;
        private IAdoTemplate<IParameterBuilder> template;

        private IContainer tableOrView;

        private const string SQL_SEQUENCE_EXISTS = @" SELECT COUNT(*) FROM user_sequences
                                                WHERE
                                                SEQUENCE_NAME LIKE '%' || :tableName || '%'";


        private bool? relatedSequenceExists;

        public bool RelatedSequenceExists
        {
            get
                {
                    if (!relatedSequenceExists.HasValue)
                    {
                        IParameterBuilder builder = template.getParameterBuilder();
                        builder.AddParameter("tableName", DbType.String, Table.Name);
                        Object objResult = template.GetOneValue(SQL_SEQUENCE_EXISTS, builder.GetParameterArray());
                        Decimal result = (Decimal)objResult;
                        if (result > 0)
                        {
                            relatedSequenceExists = true;
                        }
                        else
                        {
                            relatedSequenceExists = false;
                        }

                    }
                    return relatedSequenceExists.Value;
                }
        }

        private bool? isAutoKey = null;
        public bool IsAutoKey
        {
            get
            {
                if (!isAutoKey.HasValue)
                {

                    isAutoKey = IsIdentity || IsComputed;

                }
                return isAutoKey.Value;
            }
        }




        public string Name
        {
            get { return columnName; }
        }

        private bool? isInPrimaryKey;

        private const string SQL_PRIMARY_KEY = @" SELECT
  COUNT(*)
    FROM all_constraints cons
    INNER JOIN 
    all_cons_columns cols
ON
   cons.constraint_name = cols.constraint_name
AND cons.owner = cols.owner
   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND COLS.COLUMN_NAME =  :columnName
         AND cons.constraint_type = 'P'
         ";


        public bool IsInPrimaryKey
        {
            get
            {
                if (!isInPrimaryKey.HasValue)
                {
                    IParameterBuilder builder = template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, tableOrView.Name);
                    builder.AddParameter("schemaName", DbType.String, tableOrView.Schema);
                    builder.AddParameter("columnName", DbType.String, Name);
                    Object objResult = template.GetOneValue(SQL_PRIMARY_KEY, builder.GetParameterArray());
                    Decimal result = (Decimal)objResult;
                    if (result > 0)
                    {
                        isInPrimaryKey = true;
                    }
                    else
                    {
                        isInPrimaryKey = false;
                    }

                }
                return isInPrimaryKey.Value;

            }
        }
        private const string SQL_FOREIGN_KEY = @" SELECT
  COUNT(*)
    FROM all_constraints cons
    INNER JOIN 
    all_cons_columns cols
ON
   cons.constraint_name = cols.constraint_name
 AND cons.owner = cols.owner
   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND COLS.COLUMN_NAME =  :columnName
         AND cons.constraint_type = 'R'
        ";

        private bool? isInForeignKey;
        public bool IsInForeignKey
        {
            get
            {
                if (!isInForeignKey.HasValue)
                {
                    IParameterBuilder builder = template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, tableOrView.Name);
                    builder.AddParameter("schemaName", DbType.String, tableOrView.Schema);
                    builder.AddParameter("columnName", DbType.String, Name);
                    Object objResult = template.GetOneValue(SQL_FOREIGN_KEY, builder.GetParameterArray());
                    Decimal result = (Decimal)objResult;
                    if (result > 0)
                    {
                        isInForeignKey = true;
                    }
                    else
                    {
                        isInForeignKey = false;
                    }

                }
                return isInForeignKey.Value;

            }
        }

        public ForeignKeyInformation ForeignKeyInformation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private bool? isNullable = null;
        public bool IsNullable
        {
            get 
            {
                if (!isNullable.HasValue)
                {
                    String NullableValueInDatabase = ColumnValuesInDatabase["NULLABLE"].ToString();
                    if (NullableValueInDatabase == "N")
                    {
                        isNullable = false;
                    }
                    if (NullableValueInDatabase == "Y")
                    {
                        isNullable = true;
                    }

                }
                return isNullable.Value;
            }
        }

        public bool IsRequired
        {
            get
            {
                return !IsNullable;
            }
        }



        private string languageType = null;
        private string dataTypeInDatabase = null;




        private const string SQL_COLUMN_VALUES = @"
WITH FUNCTION GET_VARCHAR_DATA_DEFAULT(p_schema_name IN varchar2,p_table_name IN varchar2,p_column_name IN varchar2) RETURN varchar2 IS s_data_default varchar2(1000);
BEGIN
		select C.data_default into s_data_default
		FROM ALL_TAB_COLS C
		WHERE 
		C.table_name = p_table_name
		 AND C.OWNER = p_schema_name
		 AND C.COLUMN_NAME =  p_column_name;
		
		return s_data_default;
END;

select 
OWNER,
TABLE_NAME,
COLUMN_NAME,
DATA_TYPE,
DATA_LENGTH, 
NULLABLE,
GET_VARCHAR_DATA_DEFAULT(C.OWNER,C.TABLE_NAME,C.COLUMN_NAME)  DATA_DEFAULT,
VIRTUAL_COLUMN,
IDENTITY_COLUMN
from ALL_TAB_COLS  C 
   WHERE
   1 = 1
AND
        C.table_name = :tableName
         AND C.OWNER = :schemaName
         AND C.COLUMN_NAME =  :columnName
";




        private Dictionary<string,object> columnValuesInDatabase = null;


        private Dictionary<string, object> ColumnValuesInDatabase
        {
            get
            {
                if (columnValuesInDatabase == null)
                {
                    IParameterBuilder builder = template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, tableOrView.Name);
                    builder.AddParameter("schemaName", DbType.String, tableOrView.Schema);
                    builder.AddParameter("columnName", DbType.String, Name);
                    var liste = template.GetRows(SQL_COLUMN_VALUES, builder.GetParameterArray());

                    if (liste.Count > 0)
                    {
                        columnValuesInDatabase = liste[0];
                    }
                }
                return columnValuesInDatabase;
            }
        }
        public string GetColumnInformationSchemaProperty(string propertyName)
        {
            return ColumnValuesInDatabase[propertyName].ToString();
        }


        public string DataTypeInDatabase
        {
            get
            {
                if (dataTypeInDatabase == null)
                {

                    dataTypeInDatabase = ColumnValuesInDatabase["DATA_TYPE"].ToString();
                    languageType = sqlTypeToDotnetCSharpType(dataTypeInDatabase);
                }
                return dataTypeInDatabase;
            }
        }
            


        public string LanguageType
        {
            get 
            {
                if (languageType == null)
                {

                    dataTypeInDatabase = ColumnValuesInDatabase["DATA_TYPE"].ToString();
                    languageType = sqlTypeToDotnetCSharpType(dataTypeInDatabase);
                }
                return languageType;
            }
        }

        public ITable Table
        {
            get 
            {
                if (tableOrView is ITable)
                {
                    return (ITable)tableOrView;
                }
                throw new NotSupportedException("Bu column bir view'a ait.");
            }
        }

        public IView View
        {
            get 
            {
                if (tableOrView is IView)
                {
                    return (IView)tableOrView;
                }
                throw new NotSupportedException("Bu column bir tabloya ait.");
            }
        }



        private bool? isComputed = null;
        public bool IsComputed
        {
            get 
            {
                if (!isComputed.HasValue)
                {
                    String computeVal = ColumnValuesInDatabase["VIRTUAL_COLUMN"].ToString();
                    if (computeVal == "YES")
                    {
                        isComputed = true;
                    }
                    else
                    {
                        isComputed = false;
                    }
                }
                return isComputed.Value; 
            }
        }

        public string DbTargetType
        {

            get
            {
                string lowerDataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
                if (
                    lowerDataTypeInDatabase == "number"
                    
                    )
                {

                    return "DbType.Decimal";
                }
                if (
                    lowerDataTypeInDatabase == "nchar"
                    ||
                    lowerDataTypeInDatabase == "nvarchar"
                    ||
                    lowerDataTypeInDatabase == "char"
                    ||
                    lowerDataTypeInDatabase == "varchar"
                    )
                {
                    return "DbType.String";
                }
                if (lowerDataTypeInDatabase == "date")
                {
                    return "DbType.DateTime";
                }
                if (lowerDataTypeInDatabase.StartsWith("timestamp"))
                {
                    return "DbType.DateTime";
                }
                if (lowerDataTypeInDatabase == "binary_float" || lowerDataTypeInDatabase == "binary_double")
                {
                    return "DbType.Decimal";
                }
                return "Unknown";

            }
        
        }

        public string DataTypeName
        {
            get 
            {
                return sqlTypeToDotnetCommonDbType(dataTypeInDatabase);
            }
        }


        private int? characterMaxLenth = null;
        public int CharacterMaxLength
        {
            get 
            { 
                if (!characterMaxLenth.HasValue)
                {
                    if (ColumnValuesInDatabase["DATA_LENGTH"] == DBNull.Value)
                    {
                        characterMaxLenth = 0;
                    }
                    else
                    {
                        characterMaxLenth = Convert.ToInt32(ColumnValuesInDatabase["DATA_LENGTH"]);
                    }

                    
                }

                return characterMaxLenth.Value; 
            }
        }

        public bool isStringType
        {
            get 
            {
                if (LanguageType == "string")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isStringTypeWithoutLength
        {
            get 
            {
                if (
                    dataTypeInDatabase == "CLOB"
                    ||
                    dataTypeInDatabase == "LONG"
                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isNumericType
        {
            get 
            {
                if (dataTypeInDatabase == "NUMBER")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Helper functions

        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {

            pSqlTypeName = pSqlTypeName.ToLowerInvariant();
            if (
                    pSqlTypeName.Equals("varchar") ||
                    pSqlTypeName.Equals("nvarchar") ||
                    pSqlTypeName.Equals("varchar2") ||
                    pSqlTypeName.Equals("clob") ||
                    pSqlTypeName.Equals("nclob") ||
                    pSqlTypeName.Equals("char") ||
                    pSqlTypeName.Equals("nchar") ||
                    pSqlTypeName.Equals("ntext") ||
                    pSqlTypeName.Equals("Xml") ||
                    pSqlTypeName.Equals("text")

                )
            {

                return "string";
            }
            if (pSqlTypeName.Equals("uniqueidentifier"))
            {
                return "Guid";
            }
            if (pSqlTypeName.Equals("int"))
            {
                return "int";
            }
            if (pSqlTypeName.Equals("tinyint"))
            {
                return "byte";
            }
            if (pSqlTypeName.Equals("smallint"))
            {
                return "short";
            }
            if (pSqlTypeName.Equals("bigint"))
            {
                return "long";
            }
            if (
                pSqlTypeName.Equals("date") ||
                pSqlTypeName.Equals("datetime") ||
                pSqlTypeName.Equals("smalldatetime") ||
                pSqlTypeName.Contains("timestamp")
                )
            {
                return "DateTime";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }



            if (
                pSqlTypeName.Equals("number") ||
                pSqlTypeName.Equals("numeric") ||
                pSqlTypeName.Equals("decimal") ||
                pSqlTypeName.Equals("money") ||
                pSqlTypeName.Equals("smallmoney") ||
                pSqlTypeName.Equals("binary_float") ||
                pSqlTypeName.Equals("binary_double")
                )
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

        private string sqlTypeToDotnetCommonDbType(string dataTypeInDatabase)
        {
            dataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
            if (
                    dataTypeInDatabase.Equals("varchar") ||
                    dataTypeInDatabase.Equals("varchar2") ||
                    dataTypeInDatabase.Equals("nvarchar") ||
                    dataTypeInDatabase.Equals("char") ||
                    dataTypeInDatabase.Equals("nchar") ||
                    dataTypeInDatabase.Equals("ntext") ||
                    dataTypeInDatabase.Equals("text")

                )
            {

                return "DbType.String";
            }
            if (dataTypeInDatabase.Equals("uniqueidentifier"))
            {
                return "Guid";
            }
            if (dataTypeInDatabase.Equals("int"))
            {
                return "int";
            }
            if (dataTypeInDatabase.Equals("tinyint"))
            {
                return "byte";
            }
            if (dataTypeInDatabase.Equals("smallint"))
            {
                return "short";
            }
            if (dataTypeInDatabase.Equals("bigint"))
            {
                return "long";
            }
            if (
                dataTypeInDatabase.Equals("datetime") ||
                dataTypeInDatabase.Equals("smalldatetime")
                )
            {
                return "DateTime";
            }
            if (dataTypeInDatabase.Equals("bit"))
            {
                return "bool";
            }
            if (dataTypeInDatabase.Equals("bit"))
            {
                return "bool";
            }



            if (
                dataTypeInDatabase.Equals("numeric") ||
                dataTypeInDatabase.Equals("decimal") ||
                dataTypeInDatabase.Equals("money") ||
                dataTypeInDatabase.Equals("smallmoney")
                )
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




        public string ContainerName
        {
            get { return tableOrView.Name; }
        }

        public string ContainerSchemaName
        {
            get { return tableOrView.Schema; }
        }


        private bool? isIdentity;
        public bool IsIdentity
        {
            get
            {
                if (!isIdentity.HasValue)
                {
                    isIdentity = false;
                    string valIdentityColumn = ColumnValuesInDatabase["IDENTITY_COLUMN"].ToString();
                    if (valIdentityColumn == "YES")
                    {
                        isIdentity = true;
                    }


                }
                return isIdentity.Value;
            }
        }
    }
}
