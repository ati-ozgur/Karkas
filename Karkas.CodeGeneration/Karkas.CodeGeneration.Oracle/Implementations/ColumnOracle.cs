using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.Data;
using System.Data;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        CodeGenerationConfig codeGenerationConfig;
        public ColumnOracle(IAdoTemplate<IParameterBuilder> pTemplate, IContainer pTableOrView,string pColumnName)
        {

            template = pTemplate;
            tableOrView = pTableOrView;
            this.columnName = pColumnName;

            codeGenerationConfig = this.tableOrView.CodeGenerationConfig;
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
        private const string SQL_FOREIGN_KEY_FROM = @"
FROM ALL_CONS_COLUMNS a
JOIN ALL_CONSTRAINTS c ON a.owner = c.owner
                      AND a.constraint_name = c.constraint_name
JOIN ALL_CONSTRAINTS c_pk ON c.r_owner = c_pk.owner
                         AND c.r_constraint_name = c_pk.constraint_name
WHERE c.constraint_type = 'R'
AND a.table_name = :tableName
AND a.OWNER = :schemaName
AND a.COLUMN_NAME =  :columnName
";
        private const string SQL_FOREIGN_KEY_EXISTS = " SELECT COUNT(*) " + SQL_FOREIGN_KEY_FROM;
        private const string SQL_FOREIGN_KEY_INFO = @"SELECT a.table_name,
       a.column_name,
       a.constraint_name,
       c.owner,
       c.r_owner,
       c_pk.table_name PK_TABLE,
       c_pk.constraint_name PK_COLUMN"  + SQL_FOREIGN_KEY_FROM;

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
                    Object objResult = template.GetOneValue(SQL_FOREIGN_KEY_EXISTS, builder.GetParameterArray());
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
                IParameterBuilder builder = template.getParameterBuilder();
                builder.AddParameter("tableName", DbType.String, tableOrView.Name);
                builder.AddParameter("schemaName", DbType.String, tableOrView.Schema);
                builder.AddParameter("columnName", DbType.String, Name);
                var result = template.GetOneRow(SQL_FOREIGN_KEY_INFO, builder.GetParameterArray());
                ForeignKeyInformation fk = new ForeignKeyInformation();
                fk.SourceColumn = this.Name;
                fk.SourceTable = this.Table.Name;
                fk.TargetColumn = result["PK_COLUMN"].ToString();
                fk.TargetTable = result["PK_TABLE"].ToString();
                return fk;
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
DATA_TYPE,0
COALESCE(DATA_PRECISION,38),
DATA_SCALE,
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
		            int dataPrecision = 38;
					string strDataPrecision = ColumnValuesInDatabase["DATA_PRECISION"].ToString();
					if (!string.IsNullOrEmpty(strDataPrecision))
					{
						dataPrecision = Convert.ToInt32(strDataPrecision);
					}

		            string strDataScale = ColumnValuesInDatabase["DATA_SCALE"].ToString();
		            int dataScale = 0;
		            if (!string.IsNullOrEmpty( strDataScale))
		            {
			            dataScale = Convert.ToInt32(strDataScale);
		            }
		            languageType = HelperOracleDataTypes.GetDotNetType(DataTypeInDatabase, dataPrecision, dataScale, codeGenerationConfig.OracleChangeNumericToLong);
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
                throw new NotSupportedException("This column belongs to a View.");
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
                throw new NotSupportedException("This column belongs to a Table.");
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
                return dataTypeInDatabase;
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

        public bool IsStringType
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

        public bool IsStringTypeWithoutLength
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

        public bool IsNumericType
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


        // List of from
        // SELECT DISTINCT DATA_TYPE from ALL_TAB_COLS WHERE (NOT DATA_TYPE LIKE '%$%') ORDER BY 1
        // ANYDATA
        // BINARY_DOUBLE
        // BLOB
        // FLOAT
        // INTERVAL DAY(3) TO SECOND(0)
        // LONG
        // LONG RAW
        // NUMBER
        // RAW
        // ROWID
        // TIMESTAMP(0)
        // TIMESTAMP(0) WITH TIME ZONE
        // UNDEFINED






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
