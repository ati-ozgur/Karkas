using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using System.Collections;
using Karkas.Data;
using System.Data;
using Karkas.CodeGeneration.Helpers;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class ColumnSqlServer : IColumn
    {
        IContainer tableOrView;
        string columnName;
        Dictionary<string,object>  columnValuesFromInformationSchema;
        Dictionary<string,object> columnValuesFromSysViews;
        IAdoTemplate<IParameterBuilder> template;

        public IAdoTemplate<IParameterBuilder> Template
        {
            get { return template; }
        }

        public ColumnSqlServer(IContainer pTableOrView, IAdoTemplate<IParameterBuilder> template, string columnName, Dictionary<string,object> columnValues)
        {
            tableOrView = pTableOrView;
            this.template = template;
            this.columnName = columnName;
            this.columnValuesFromInformationSchema = columnValues;

            IParameterBuilder defaultParameterBuilder = getBuilderWithDefaultValues();

            var dt = template.GetRows(SQL_COLUMN_VALUES_FROM_SYS, defaultParameterBuilder.GetParameterArray());
            columnValuesFromSysViews = dt[0];



        }

        private IParameterBuilder getBuilderWithDefaultValues()
        {
            IParameterBuilder builder = template.getParameterBuilder();
            builder.AddParameter("@TABLE_NAME", DbType.AnsiString, tableOrView.Name);
            builder.AddParameter("@TABLE_SCHEMA", DbType.AnsiString, tableOrView.Schema);
            builder.AddParameter("@COLUMN_NAME", DbType.AnsiString, columnName);
            return builder;
        }

        private const string SQL_COLUMN_VALUES_FROM_SYS = @"SELECT object_id
      ,name
      ,column_id
      ,system_type_id
      ,user_type_id
      ,max_length
      ,precision
      ,scale
      ,collation_name
      ,is_nullable
      ,is_ansi_padded
      ,is_rowguidcol
      ,is_identity
      ,is_computed
      ,is_filestream
      ,is_replicated
      ,is_non_sql_subscribed
      ,is_merge_published
      ,is_dts_replicated
      ,is_xml_document
      ,xml_collection_id
      ,default_object_id
      ,rule_object_id
      ,is_sparse
      ,is_column_set
  FROM sys.columns sc
  WHERE sc.object_id  = 
  (
  SELECT so.object_id FROM sys.objects so
WHERE name = @TABLE_NAME
AND schema_id = 
    (SELECT schema_id 
    FROM sys.schemas
    WHERE name = @TABLE_SCHEMA)
   ) 
   and
   name =  @COLUMN_NAME
";


        public bool IsAutoKey
        {
            get
            {
                if (columnValuesFromSysViews["is_identity"].ToString() == "1")
                {
                    return true;
                }
                if (columnValuesFromSysViews["is_rowguidcol"].ToString() == "1")
                {
                    return true;
                }
                return false;
            }
        }

        public string Name
        {
            get
            {
                return columnName;
            }
        }

        private const string SQL_PRIMARY_KEY_EXISTS = @"SELECT COUNT(*)
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS C
JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS K
ON C.TABLE_NAME = K.TABLE_NAME
AND C.CONSTRAINT_CATALOG = K.CONSTRAINT_CATALOG
AND C.CONSTRAINT_SCHEMA = K.CONSTRAINT_SCHEMA
AND C.CONSTRAINT_NAME = K.CONSTRAINT_NAME
WHERE C.CONSTRAINT_TYPE = 'PRIMARY KEY'
AND K.COLUMN_NAME = @COLUMN_NAME
AND K.TABLE_NAME = @TABLE_NAME
AND K.TABLE_SCHEMA = @TABLE_SCHEMA";

        private const string SQL_FOREIGN_KEY_FROM = @"
FROM 
    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
    JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU1 
        ON KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG 
        AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA
        AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
    JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU2
        ON KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG 
        AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA
        AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
        AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION
WHERE 1 = 1
AND KCU1.CONSTRAINT_SCHEMA = @TABLE_SCHEMA         
AND KCU1.TABLE_NAME = @TABLE_NAME
AND KCU1.COLUMN_NAME = @COLUMN_NAME
";
        private const string SQL_FOREIGN_KEY_EXISTS = "SELECT COUNT(*) " + SQL_FOREIGN_KEY_FROM;
        private const string SQL_FOREIGN_KEY_INFO = @"SELECT 
    RC.CONSTRAINT_NAME AS FK_Name,
    KCU1.TABLE_NAME AS FK_Table,
    KCU1.COLUMN_NAME AS FK_Column,
    KCU2.TABLE_NAME AS PK_Table,
    KCU2.COLUMN_NAME AS PK_Column,
    RC.UPDATE_RULE,
    RC.DELETE_RULE        
        " + SQL_FOREIGN_KEY_FROM;


        bool? isInPrimaryKey;

        public bool IsInPrimaryKey
        {
            get
            {
                if (isInPrimaryKey.HasValue)
                {
                    return isInPrimaryKey.Value;
                }
                else
                {
                    int result = (int)template.GetOneValue(SQL_PRIMARY_KEY_EXISTS, getBuilderWithDefaultValues().GetParameterArray());
                    isInPrimaryKey = result > 0;
                    return isInPrimaryKey.Value;
                }
            }
        }
        bool? isInForeignKey;

        public bool IsInForeignKey
        {

            get
            {
                if (isInForeignKey.HasValue)
                {
                    return isInForeignKey.Value;
                }
                else
                {
                    int result = (int)template.GetOneValue(SQL_FOREIGN_KEY_EXISTS, getBuilderWithDefaultValues().GetParameterArray());
                    isInForeignKey = result > 0;
                    return isInForeignKey.Value;
                }
            }
        }
        public ForeignKeyInformation ForeignKeyInformation
        {
            get
            {
                var result = template.GetOneRow(SQL_FOREIGN_KEY_INFO, getBuilderWithDefaultValues().GetParameterArray());
                ForeignKeyInformation f = new ForeignKeyInformation();
                f.SourceColumn = Name;
                f.TargetColumn = result["PK_Column"].ToString();
                f.SourceTable = Table.Name;
                f.TargetTable = result["PK_Table"].ToString();
                return f;
            }
        }

        private bool? isNullable;

        public bool IsNullable
        {
            get
            {
                if (!isNullable.HasValue)
                {
                    string isNullableValue = columnValuesFromInformationSchema["IS_NULLABLE"].ToString();
                    if (isNullableValue == "NO")
                    {
                        isNullable = false;
                    }
                    if (isNullableValue == "YES")
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


        string _LanguageType;
        public string LanguageType
        {
            get
            {
                if (String.IsNullOrEmpty(_LanguageType))
                {

                    string result;
                    if (SqlDataTypeName == "UserDefinedDataType")
                    {
                        throw new NotImplementedException("UserDefinedDataType is not supported yet");
                    }
                    else
                    {
                        result = sqlTypeToDotnetCSharpType(DataTypeName);

                    }
                    if (result.Equals("Unknown"))
                    {
                        Console.WriteLine("TableName : {0}, Name : {1} , DataType : {2} ", TableFullName, Name, DataTypeName);
                    }
                    _LanguageType = result;
                }
                return _LanguageType;
            }
        }
        public string TableFullName
        {
            get
            {
                return String.Format("{0}.{1}", Table.Schema, Table.Name);
            }
        }

        public string TableName
        {
            get
            {
                return Table.Name;
            }
        }

        public bool IsIdentity
        {
            get { return Convert.ToInt32(columnValuesFromSysViews["is_identity"]) > 0; }
        }

        public bool IsComputedNormal
        {
            get { return Convert.ToInt32(columnValuesFromSysViews["is_computed"]) > 0;  }
        }


        public bool IsRowGuidCol
        {
            get { return Convert.ToInt32(columnValuesFromSysViews["is_rowguidcol"]) > 0; }
        }

        public bool IsTimestamp
        {
            get { return (SqlDataTypeName == "timestamp"); }
        }

        public bool IsComputed
        {
            get
            {

                return IsIdentity || IsComputedNormal || IsRowGuidCol || IsTimestamp;

            }
        }

        static Dictionary<string, string> userDefinedTypes = new Dictionary<string, string>();

        private string getUnderlyingTypeOfUserDefinedType(string pUserDefinedTypeName)
        {
            string underlyingType;

            string sql = @"SELECT name FROM sys.types
 WHERE system_type_id =
( SELECT system_type_id from  sys.types
 where name = @UserDefinedTypeName)
 and is_user_defined = 0
";

            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter("@UserDefinedTypeName", DbType.String, pUserDefinedTypeName);
            underlyingType = (string)template.GetOneValue(sql, builder.GetParameterArray());

            return underlyingType;


        }

        public string sqlTypeToDotnetSqlDbType(string pSqlTypeName)
        {
            if (pSqlTypeName == "char")
            {
                return "SqlDbType.Char";
            }
            return "Unknown";
        }
        /// <summary>
        /// Maps Sql Server types to C# types according to table provided by microsoft
        /// see http://msdn.microsoft.com/en-us/library/cc716729.aspx
        /// </summary>
        /// <param name="pSqlTypeName"></param>
        /// <returns></returns>
        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {
            if (
                    pSqlTypeName.Equals("varchar") ||
                    pSqlTypeName.Equals("nvarchar") ||
                    pSqlTypeName.Equals("char") ||
                    pSqlTypeName.Equals("nchar") ||
                    pSqlTypeName.Equals("ntext") ||
                    pSqlTypeName.Equals("xml") ||
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
                pSqlTypeName.Equals("datetime2") ||
                pSqlTypeName.Equals("smalldatetime")
                )
            {
                return "DateTime";
            }
            if (pSqlTypeName.Equals("datetimeoffset"))
            {
                return "DateTimeOffset";
            }
            if (pSqlTypeName.Equals("bit"))
            {
                return "bool";
            }


            if (
                pSqlTypeName.Equals("numeric") ||
                pSqlTypeName.Equals("decimal") ||
                pSqlTypeName.Equals("money") ||
                pSqlTypeName.Equals("smallmoney")
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
            if (pSqlTypeName.Equals("time"))
            {
                return "TimeSpan";
            }

            if (
                pSqlTypeName.Equals("image") ||
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

            if (pSqlTypeName.Equals("geography"))
            {
                return "SqlGeography";
            }
            if (pSqlTypeName.Equals("geometry"))
            {
                return "SqlGeometry";
            }
            if (pSqlTypeName.Equals("hierarchyid"))
            {
                return "SqlHierarchyId";
            }

            

            



            return "Unknown";
        }

        public string GetColumnInformationSchemaProperty(string propertyName)
        {
            // TODO Implement it later, not needed right now.
            throw new NotImplementedException();
        }

        public bool isNewSqlServerCLRType
        {
            get
            {
                if (
                    this.LanguageType == "SqlGeography" ||
                    this.LanguageType == "SqlGeometry" ||
                    this.LanguageType == "SqlHierarchyId"
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


        string _DbTargetType = null;
        public string DbTargetType
        {
            get
            {
                if (_DbTargetType == null)
                {
                    string lowerCaseSqlDataTypeName = SqlDataTypeName.ToLowerInvariant();
                    switch (lowerCaseSqlDataTypeName)
                    {
                        case "int":
                            _DbTargetType = "SqlDbType.Int";
                            break;
                        case "bigint":
                            _DbTargetType = "SqlDbType.BigInt";
                            break;

                        case "bit":
                            _DbTargetType = "SqlDbType.Bit";
                            break;
                        case "binary":
                            _DbTargetType = "SqlDbType.Binary";
                            break;
                        case "char":
                            _DbTargetType = "SqlDbType.Char";
                            break;
                        case "nchar":
                            _DbTargetType = "SqlDbType.NChar";
                            break;
                        case "float":
                            _DbTargetType = "SqlDbType.Float";
                            break;
                        case "real":
                            _DbTargetType = "SqlDbType.Real";
                            break;

                        case "varcharmax":
                        case "varchar":

                            _DbTargetType = "SqlDbType.VarChar";
                            break;
                        case "uniqueidentifier":
                            _DbTargetType = "SqlDbType.UniqueIdentifier";
                            break;
                        case "smalldatetime":
                            _DbTargetType = "SqlDbType.SmallDateTime";
                            break;
                        case "datetime":
                            _DbTargetType = "SqlDbType.DateTime";
                            break;

                        case "tinyint":
                            _DbTargetType = "SqlDbType.TinyInt";
                            break;
                        case "smallint":
                            _DbTargetType = "SqlDbType.SmallInt";
                            break;


                        case "numeric":
                        case "decimal":
                            _DbTargetType = "SqlDbType.Decimal";
                            break;

                        case "nvarcharmax":
                        case "nvarchar":
                            _DbTargetType = "SqlDbType.NVarChar";
                            break;
                        case "varbinarymax":
                        case "varbinary":
                            _DbTargetType = "SqlDbType.VarBinary";
                            break;

                        case "xml":
                            _DbTargetType = "SqlDbType.Xml";
                            break;
                        case "image":
                            _DbTargetType = "SqlDbType.Image";
                            break;
                        case "money":
                            _DbTargetType = "SqlDbType.Money";
                            break;
                        case "smallmoney":
                            _DbTargetType = "SqlDbType.SmallMoney";
                            break;
                        case "sql_variant":
                            _DbTargetType = "SqlDbType.Variant";
                            break;
                            
                        case "text":
                            _DbTargetType = "SqlDbType.Text";
                            break;
                        case "ntext":
                            _DbTargetType = "SqlDbType.NText";
                            break;
                        case "timestamp":
                            _DbTargetType = "SqlDbType.Timestamp";
                            break;
                            
                        case "UserDefinedDataType":
                            string sqlTypeName = getUnderlyingTypeOfUserDefinedType(SqlDataTypeName);
                            _DbTargetType = sqlTypeToDotnetSqlDbType(sqlTypeName);
                            break;
                        default:
                        _DbTargetType = "SqlDbType." + SqlDataTypeName;
                            break;
                    }
                }
                return _DbTargetType;
            }
        }

        private string sqlDataTypeName;

        public string SqlDataTypeName
        {
            get { return DataTypeName; }
        }
        public string DataTypeName
        {
            get
            {
                if (sqlDataTypeName == null)
                {
                    sqlDataTypeName = columnValuesFromInformationSchema["DATA_TYPE"].ToString();
                }
                return sqlDataTypeName;
            }
        }

        public int CharacterMaxLength
        {
            get
            {

                int charMaxLength = 0;
                if (IsStringType)
                {
                    charMaxLength = Convert.ToInt32(columnValuesFromInformationSchema["CHARACTER_MAXIMUM_LENGTH"]);
                }
                return charMaxLength;
            }
        }

        public bool IsStringTypeWithoutLength
        {
            get
            {
                if (IsStringType)
                {
                    string lowerDataType = this.SqlDataTypeName.ToLowerInvariant();
                    if (
                        lowerDataType.Contains("text")
                        || lowerDataType.Contains("max")
                        )
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsStringType
        {
            get
            {
                string lowerDataType = SqlDataTypeName.ToLowerInvariant();
                if (
                    lowerDataType.Contains("char")
                    ||
                    lowerDataType.Contains("text")

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
                if (
                    SqlDataTypeName == "tinyint" ||
                    SqlDataTypeName == "short" ||
                    SqlDataTypeName == "byte" ||
                    SqlDataTypeName == "int" ||
                    SqlDataTypeName == "numeric" ||
                    SqlDataTypeName == "decimal" ||
                    SqlDataTypeName == "float" ||
                    SqlDataTypeName == "real" ||
                    SqlDataTypeName == "money"
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

        public string ContainerName
        {
            get { return tableOrView.Name; }
        }

        public string ContainerSchemaName
        {
            get { return tableOrView.Schema; }
        }

        public string DataTypeInDatabase { get => SqlDataTypeName; }


    }
}
