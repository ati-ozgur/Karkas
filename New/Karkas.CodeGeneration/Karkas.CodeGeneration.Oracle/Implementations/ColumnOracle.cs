using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    class ColumnOracle : IColumn
    {
        public ColumnOracle(AdoTemplate pTemplate, IContainer pTableOrView,string pColumnName)
        {

            template = pTemplate;
            tableOrView = pTableOrView;
            this.columnName = pColumnName;
        }

        private string columnName;
        private AdoTemplate template;

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
                        ParameterBuilder builder = template.getParameterBuilder();
                        builder.parameterEkle("tableName", DbType.String, Table.Name);
                        Object objSonuc = template.TekDegerGetir(SQL_SEQUENCE_EXISTS, builder.GetParameterArray());
                        Decimal sonuc = (Decimal)objSonuc;
                        if (sonuc > 0)
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

        public bool IsAutoKey
        {
            get 
            {
                // TODO Bunua daha sonra yap
                return false;
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
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, tableOrView.Name);
                    builder.parameterEkle("schemaName", DbType.String, tableOrView.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    Object objSonuc = template.TekDegerGetir(SQL_PRIMARY_KEY, builder.GetParameterArray());
                    Decimal sonuc = (Decimal)objSonuc;
                    if (sonuc > 0)
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
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, tableOrView.Name);
                    builder.parameterEkle("schemaName", DbType.String, tableOrView.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    Object objSonuc = template.TekDegerGetir(SQL_FOREIGN_KEY, builder.GetParameterArray());
                    Decimal sonuc = (Decimal)objSonuc;
                    if (sonuc > 0)
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




        private const string SQL_COLUMN_VALUES = @"select * from ALL_TAB_COLS  C 
   WHERE
   1 = 1
AND
        C.table_name = :tableName
         AND C.OWNER = :schemaName
         AND C.COLUMN_NAME =  :columnName
";




        private DataRow columnValuesInDatabase = null;


        private DataRow ColumnValuesInDatabase
        {
            get
            {
                if (columnValuesInDatabase == null)
                {
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, tableOrView.Name);
                    builder.parameterEkle("schemaName", DbType.String, tableOrView.Schema);
                    builder.parameterEkle("columnName", DbType.String, Name);
                    DataTable dtColumnValues = template.DataTableOlustur(SQL_COLUMN_VALUES, builder.GetParameterArray());
                    if (dtColumnValues.Rows.Count > 0)
                    {
                        columnValuesInDatabase = dtColumnValues.Rows[0];
                    }
                }
                return columnValuesInDatabase;
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


        public bool IsIdentity
        {
            get { return false; }
        }
    }
}
