using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using System.Data;
using Karkas.Core.DataUtil;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class TableSqlServer : ITable
    {
        private string tableName;
        private string schemaName;



        public TableSqlServer(IAdoTemplate<IParameterBuilder> template,  string pTableName,string pSchemaName)
        {
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        private IAdoTemplate<IParameterBuilder> template;

        public IAdoTemplate<IParameterBuilder> Template
        {
            get { return template; }
            set { template = value; }
        }

        public int FindIndexFromName(string name)
        {
            throw new NotImplementedException();
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

                IParameterBuilder builder = Template.getParameterBuilder();
                builder.AddParameter("@TABLE_NAME",DbType.AnsiString,tableName );
                builder.AddParameter("@TABLE_SCHEMA", DbType.AnsiString, schemaName);



                var dtColumns = Template.GetRows(SQL_COLUMN_LIST, builder.GetParameterArray());


                foreach (var row in dtColumns)
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
