using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using System.Data;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class TableSqlServer : ITable
    {
        private IDatabase database;

        private string tableName;
        private string schemaName;



        public TableSqlServer(DatabaseSqlServer pDatabase,AdoTemplate template,  string pTableName,string pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        private AdoTemplate template;

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }

        public int findIndexFromName(string name)
        {
            throw new NotImplementedException();
        }

        public IDatabase Database
        {
            get
            {
                return database;
            }
        }

        public string Schema
        {
            get
            {
                return schemaName;
            }
        }

        public string Name
        {
            get
            {
                return tableName;
            }
        }

        private const string SQL_COLUMN_LIST = @"SELECT * FROM 
INFORMATION_SCHEMA.COLUMNS
WHERE
TABLE_SCHEMA = @TABLE_SCHEMA
AND
TABLE_NAME = @TABLE_NAME
";



        private List<IColumn> _Columns = null;
        public List<IColumn> Columns
        {
            get
            {
                if (_Columns != null)
                {
                    return _Columns;
                }
                _Columns = new List<IColumn>();

                ParameterBuilder builder = Template.getParameterBuilder();
                builder.parameterEkle("@TABLE_NAME",DbType.AnsiString,tableName );
                builder.parameterEkle("@TABLE_SCHEMA", DbType.AnsiString, schemaName);



                DataTable dtColumns = Template.DataTableOlustur(SQL_COLUMN_LIST, builder.GetParameterArray());


                foreach (DataRow row in dtColumns.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();
                    IColumn column = new ColumnSqlServer(this,template, columnName, row);



                    _Columns.Add(column);
                }
                return _Columns;
            }

        }

        public DateTime DateCreated
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateModified
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Alias
        {
            get
            {
                return Name;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}", Schema,Name);
        }


        int? _primaryKeyColumnCount;
        public int PrimaryKeyColumnCount
        {
            get 
            {
                if (_primaryKeyColumnCount.HasValue)
                {
                    return _primaryKeyColumnCount.Value;
                }
                int count = 0;
                foreach (var item in this.Columns)
                {
                    if (item.IsInPrimaryKey)
                    {
                        count++;
                    }
                }
                _primaryKeyColumnCount = count;
                return count;
            }
        }


        public bool HasPrimaryKey
        {
            get 
            {
                if (PrimaryKeyColumnCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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
