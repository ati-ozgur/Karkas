using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Karkas.Data;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class TableSqlServer : ITable
    {
        private string tableName;
        private string schemaName;

        CodeGenerationSqlServer database;

        public TableSqlServer(CodeGenerationSqlServer database, IAdoTemplate<IParameterBuilder> template,  string pTableName,string pSchemaName)
        {
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
            this.database = database;
        }

        private IAdoTemplate<IParameterBuilder> template;

        public IAdoTemplate<IParameterBuilder> Template
        {
            get { return template; }
        }


		private const String SQL_INDEX_COLUMNS = @"WITH T AS
(
SELECT
s.name as SCHEMA_NAME,
t.name As TABLE_NAME,
ind.name AS INDEX_NAME,
COL_NAME(ic.object_id,ic.column_id) AS ""name""
FROM
 sys.indexes ind
 INNER JOIN sys.index_columns AS ic
    ON ind.object_id = ic.object_id AND ind.index_id = ic.index_id
 INNER JOIN
 sys.tables t ON ind.object_id = t.object_id
INNER JOIN
sys.schemas s ON t.schema_id  = s.schema_id
)
SELECT * FROM T WHERE
T.INDEX_NAME = '{0}' AND
T.TABLE_NAME = '{1}' AND
T.SCHEMA_NAME = '{2}'
";


		public string getSQL_Index_Columns(string indexName)
		{
			return string.Format(SQL_INDEX_COLUMNS, indexName, Name, Schema);
		}
		private const String SQL_INDEX_NAMES = @"WITH T AS
(
SELECT
s.name as SCHEMA_NAME,
t.name As TABLE_NAME,
ind.name AS INDEX_NAME,
ind.is_unique
FROM
 sys.indexes ind
 INNER JOIN
 sys.tables t ON ind.object_id = t.object_id
INNER JOIN
sys.schemas s ON t.schema_id  = s.schema_id
)
SELECT INDEX_NAME as ""name"", is_unique as ""unique"" FROM T WHERE TABLE_NAME = '{0}' AND SCHEMA_NAME = '{1}'  ";
		public string getSQL_Index_Names()
		{
			return string.Format(SQL_INDEX_NAMES, Name,Schema);
		}
		public CodeGenerationConfig CodeGenerationConfig
		{
			get
			{
				return database.CodeGenerationConfig;
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
