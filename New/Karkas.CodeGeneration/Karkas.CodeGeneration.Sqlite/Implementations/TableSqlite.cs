using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class TableSqlite : ITable
    {

        public TableSqlite(DatabaseSqlite pDatabase, AdoTemplate template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        DatabaseSqlite database;

        AdoTemplate template;
        String tableName;
        String schemaName;

        public int findIndexFromName(string name)
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

                    DataTable dtColumns = template.DataTableOlustur(columnSql);

                    IColumn column;
                    foreach (DataRow rowColumn in dtColumns.Rows)
                    {
                        // cid|name|type|notnull|dflt_value|pk
                        String columnName = rowColumn["name"].ToString();
                        String columnType = rowColumn["type"].ToString();
                        bool isColumnInteger = columnType.ToLowerInvariant() == "integer";
                        bool isColumnPK = Convert.ToInt32(rowColumn["pk"]) > 0;
                        bool isColumnNotNull = isColumnPK || Convert.ToInt32(rowColumn["notnull"]) != 0;
                        String columnDefaultValue = rowColumn["dflt_value"].ToString();

                        // http://www.sqlite.org/faq.html#q1
                        // Short answer: A column declared INTEGER PRIMARY KEY will autoincrement.
                        bool isAutoIncrement = isColumnInteger && isColumnPK;

                        column = new ColumnSqlite(template, this, columnName, columnType, isColumnNotNull, columnDefaultValue, isColumnPK, isAutoIncrement);
                        columns.Add(column);
                    }

                }
                return columns;
            }
        }

        public IDatabase Database
        {
            get 
            {
                return database;
            
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

        public bool IdentityVarmi
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
