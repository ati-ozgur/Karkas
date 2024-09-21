using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.Helpers;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    class ColumnSqlite : IColumn
    {


        public ColumnSqlite(IAdoTemplate<IParameterBuilder> template, IContainer pTableOrView, string columnName, string columnType, bool columnNotNull, string columnDefaultValue, bool columnPK,bool isColumnAutoIncrement)
        {
            // TODO: Complete member initialization
            this.template = template;
            this.tableOrView = pTableOrView;
            this.name = columnName;
            this.dataTypeInDatabase = columnType;
            this.isNullable = !columnNotNull;
            this.defaultValue = columnDefaultValue;
            this.isInPrimaryKey = columnPK;
            this.isAutoKey = isColumnAutoIncrement;
        }

        private IAdoTemplate<IParameterBuilder> template;

        private IContainer tableOrView;

        


        private string name;

        private bool isAutoKey;

        public bool IsAutoKey
        {
            get 
            {
                // TODO fix this one later
                return isAutoKey;
            }
        }

        public bool IsIdentity
        {
            get { return isAutoKey; }
        }


        public string Name
        {
            get { return name; }
        }



        public bool IsInPrimaryKey
        {
            get
            {
                return isInPrimaryKey;
            }
        }

        string SQL_FOREIGN_KEY_CHECK = @"SELECT * FROM pragma_foreign_key_list('{0}')
                WHERE ""from"" = '{1}'";
        private bool? isInForeignKey = null;
        public bool IsInForeignKey
        {
            get
            {
                if (!isInForeignKey.HasValue)
                {
                    string sql = string.Format(SQL_FOREIGN_KEY_CHECK, this.Table.Name, this.Name);
                    bool result = template.ExecuteAsExists(sql);
                    isInForeignKey = result;
                }
                return isInForeignKey.Value;

            }
        }
        public ForeignKeyInformation ForeignKeyInformation
        {
            get
            {
                string sql = string.Format(SQL_FOREIGN_KEY_CHECK, this.Table.Name, this.Name);
                var result = template.GetRows(sql);
                

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
                    return false;

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







        public string LanguageType
        {
            get 
            {
                if (languageType == null)
                {

                    languageType = sqlTypeToDotnetCSharpType(DataTypeInDatabase);
                }
                return languageType;
            }
        }



        private bool? isComputed = false;
        public bool IsComputed
        {
            get 
            {
                return isComputed.Value; 
            }
        }

        public string DbTargetType
        {

            get
            {
                string lowerDataTypeInDatabase = DataTypeInDatabase.ToLowerInvariant();
                if (lowerDataTypeInDatabase == "integer")
                {
                    return "DbType.Int64";
                }
                if (lowerDataTypeInDatabase == "real")
                {
                    return "double";
                }

                if (lowerDataTypeInDatabase.Equals("blob"))
                {
                    return "DbType.String";
                }
                return "DbType.String";
            }
        
        }

        public string DataTypeName
        {
            get 
            {
                return sqlTypeToDotnetCommonDbType(DataTypeInDatabase);
            }
        }

        // TODO Fix this one later
        //private int? characterMaxLength;
        private string defaultValue;
        private bool isInPrimaryKey;
        public int CharacterMaxLength
        {
            get 
            {
                return 0;
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
                // Sql lite string types all without length
                return true;

            }
        }

        public bool isNumericType
        {
            get 
            {
                return !isStringType;
            }
        }

        // Helper functions

        public string sqlTypeToDotnetCSharpType(string pSqlTypeName)
        {
            //INTEGER - a signed integer
            //REAL - a floating point value
            //TEXT - a text string
            //BLOB - a blob of data
            pSqlTypeName = pSqlTypeName.ToLowerInvariant();

            if (
                    pSqlTypeName.Equals("text")
                    || pSqlTypeName.Equals("varchar")
                    || pSqlTypeName.Contains("varchar")
                )
            {

                return "string";
            }

            if (pSqlTypeName.Equals("integer"))
            {
                return "long";
            }
            if (pSqlTypeName.Equals("datetime"))
            {
                return "DateTime";
            }
            if (pSqlTypeName.Equals("real"))
            {
                return "double";
            }
            // TODO check if numeric is equal to decimal
            if (pSqlTypeName.Contains("numeric"))
            {
                return "decimal";
            }
            if ( pSqlTypeName.Equals("blob") )
            {
                return "byte[]";
            }
            return "Unknown";
        }

        private string sqlTypeToDotnetCommonDbType(string dataTypeInDatabase)
        {
            dataTypeInDatabase = dataTypeInDatabase.ToLowerInvariant();
            if (
                    dataTypeInDatabase.Equals("text")
                )
            {

                return "DbType.String";
            }

            if (dataTypeInDatabase.Equals("integer"))
            {
                return "int";
            }

            if (dataTypeInDatabase.Equals("real"))
            {
                return "double";
            }
            if ( dataTypeInDatabase.Equals("blob"))
            {
                return "byte[]";
            }
            return "Unknown";
        }

        public string GetColumnInformationSchemaProperty(string propertyName)
        {
            // TODO Implement it later, not needed right now.
            throw new NotImplementedException();
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
                throw new NotSupportedException("This column belongs to a Table.");
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

        public string DataTypeInDatabase { get => dataTypeInDatabase; }
    }
}
