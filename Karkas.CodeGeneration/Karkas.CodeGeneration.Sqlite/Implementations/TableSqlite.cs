﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Data;
using System.Data;

using System.Text.RegularExpressions;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class TableSqlite : ITable
    {

        public TableSqlite(CodeGenerationSqlite pDatabase, IAdoTemplate<IParameterBuilder> template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        CodeGenerationSqlite database;

        IAdoTemplate<IParameterBuilder> template;
        String tableName;
        String schemaName;


        public CodeGenerationConfig CodeGenerationConfig
        {
            get
            {
                return database.CodeGenerationConfig;
            }
        }

        public int FindIndexFromName(string name)
        {
            throw new NotImplementedException();
        }


        private Decimal? primaryKeyColumnCount = null;
        public int PrimaryKeyColumnCount
        {
            get 
            {
                if (!primaryKeyColumnCount.HasValue)
                {
                    primaryKeyColumnCount = 0;
                    foreach (IColumn column in columns)
                    {
                        if (column.IsInPrimaryKey)
                        {
                            primaryKeyColumnCount++;
                        }

                    }

                }
                return (int) primaryKeyColumnCount.Value;

            }
        }

        public bool HasPrimaryKey
        {
            get { return PrimaryKeyColumnCount > 0; }
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> columns = null;



        private const String COLUMN_SQL = "Pragma table_info({0});";



        public List<IColumn> Columns
        {
            get 
            {
                if (columns == null)
                {
                    columns = new List<IColumn>();
                    string columnSql = string.Format(COLUMN_SQL, tableName);

                    List<Dictionary<string,object>>  dtColumns = template.GetRows(columnSql);

                    
                    foreach (var rowColumn in dtColumns)
                    {
                        // cid|name|type|notnull|dflt_value|pk
                        string columnName = rowColumn["name"].ToString();

                        string columnType = rowColumn["type"].ToString();
                        if( !string.IsNullOrWhiteSpace(CodeGenerationConfig.DateRegex) )
                        {
                            bool isMatch = Regex.IsMatch(columnName, CodeGenerationConfig.DateRegex);
                            if(isMatch)
                            {
                                columnType = "DateOnly";
                            }
                        }
                        if( !string.IsNullOrWhiteSpace(CodeGenerationConfig.DateTimeRegex) )
                        {
                            bool isMatch = Regex.IsMatch(columnName, CodeGenerationConfig.DateTimeRegex);
                            if(isMatch)
                            {
                                columnType = "DateTime";
                            }
                        }

                        bool isColumnInteger = columnType.ToLowerInvariant() == "integer";
                        bool isColumnPK = Convert.ToInt32(rowColumn["pk"]) > 0;
                        bool isColumnNotNull = isColumnPK || Convert.ToInt32(rowColumn["notnull"]) != 0;
                        String columnDefaultValue = rowColumn["dflt_value"].ToString();

                        // http://www.sqlite.org/faq.html#q1
                        // Short answer: A column declared INTEGER PRIMARY KEY will autoincrement.
                        bool isAutoIncrement = isColumnInteger && isColumnPK;

                        IColumn columnSqlite = new ColumnSqlite(template, this, columnName, columnType, isColumnNotNull, columnDefaultValue, isColumnPK, isAutoIncrement);
                        columns.Add(columnSqlite);
                    }

                }
                return columns;
            }
        }



        public DateTime DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DateModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return tableName; }
        }

        public string Schema
        {
            get { return schemaName; }
        }

        public override string ToString()
        {
            return "SqliteTable: " + Name;
        }

        bool? identityVarmi;

        public bool IdentityExists
        {
            get
            {
                if (!identityVarmi.HasValue)
                {
                    identityVarmi = false;
                    foreach (IColumn column in this.Columns)
                    {
                        if (column.IsComputed)
                        {
                            continue;
                        }
                        if (column.IsAutoKey)
                        {
                            identityVarmi = true;
                        }
                    }
                }
                return identityVarmi.Value;
            }
        }
    }
}
