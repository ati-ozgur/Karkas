using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class ViewOracle : IView
    {
        public ViewOracle(DatabaseOracle database, AdoTemplate template, string viewName, string schemaName)
        {
            this.database = database;
            this.template = template;
            this.viewName = viewName;
            this.schemaName = schemaName;
        }
        DatabaseOracle database;
        AdoTemplate template;
        string viewName;
        string schemaName;

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> columns = null;


        private const string SQL_FOR_COLUMN_LIST = @"select owner, column_name from all_tab_columns 
where 
table_name = :tableName
AND
OWNER = :schemaName
";

        public List<IColumn> Columns
        {
            get
            {
                if (columns == null)
                {
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Name);
                    builder.parameterEkle("schemaName", DbType.String, Schema);

                    DataTable dtColumnList = template.DataTableOlustur(SQL_FOR_COLUMN_LIST, builder.GetParameterArray());
                    columns = new List<IColumn>();
                    foreach (DataRow row in dtColumnList.Rows)
                    {
                        string columnName = row["column_name"].ToString();
                        IColumn column = new ColumnOracle(template, this,columnName);
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
            get
            {
                return viewName;
            }
        }

        public string Schema
        {
            get
            {
                return schemaName;
            }
        }
    }
}
