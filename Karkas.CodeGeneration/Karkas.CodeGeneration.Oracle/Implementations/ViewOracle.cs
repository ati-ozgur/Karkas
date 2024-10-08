﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.Data;
using System.Data;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class ViewOracle : IView
    {
        public ViewOracle(CodeGenerationOracle database, IAdoTemplate<IParameterBuilder> template, string viewName, string schemaName)
        {
            this.database = database;
            this.template = template;
            this.viewName = viewName;
            this.schemaName = schemaName;
        }
        CodeGenerationOracle database;
        IAdoTemplate<IParameterBuilder> template;
        string viewName;
        string schemaName;

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public CodeGenerationConfig CodeGenerationConfig
        {
            get
            {
                return database.CodeGenerationConfig;
            }
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
                    IParameterBuilder builder = template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, Name);
                    builder.AddParameter("schemaName", DbType.String, Schema);

                    DataTable dtColumnList = template.CreateDataTable(SQL_FOR_COLUMN_LIST, builder.GetParameterArray());
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
