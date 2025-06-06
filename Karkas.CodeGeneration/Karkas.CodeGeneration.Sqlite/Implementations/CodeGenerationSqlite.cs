﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Data;


using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;

using Karkas.CodeGeneration.Sqlite.Generators;


namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class CodeGenerationSqlite : BaseCodeGenerationDatabase
    {


        public CodeGenerationSqlite(IAdoTemplate<IParameterBuilder> template,CodeGenerationConfig pCodeGenerationConfig): base(template,pCodeGenerationConfig)
        {

        }


        private const string TABLE_LIST_SQL = @"SELECT '' AS TABLE_SCHEMA,
                                                name AS TABLE_NAME,
                                                name AS FULL_TABLE_NAME
                                                 FROM sqlite_master
                                                WHERE type='table'
                                                 ORDER BY name;";


        private const string VIEW_LIST_SQL = @"SELECT '' AS TABLE_SCHEMA,
                                                name AS VIEW_NAME,
                                                name AS FULL_VIEW_NAME
                                                FROM sqlite_master
                                                WHERE type='view'
                                                ORDER BY name;";


        List<ITable> _tableList = null;

        public override List<ITable> Tables
        {
            get
            {
                if (_tableList == null)
                {
                    var dtTables = getTableList();
                    _tableList = new List<ITable>();
                    foreach (var rowTable in dtTables)
                    {
                        string tableName = rowTable["TABLE_NAME"].ToString();
                        TableSqlite table = new TableSqlite(this, Template, tableName, this.CodeGenerationConfig.ConnectionName);
                        _tableList.Add(table);
                    }
                }
                return _tableList;

            }
        }
        List<IView> _viewList;
        public override List<IView> Views
        {

            get
            {
                if (_viewList == null)
                {
                    _viewList = new List<IView>();

                    var dtViews = GetViewListFromSchema(null);
                    foreach (var row in dtViews)
                    {
                        IView t = new ViewSqlite(this, Template, row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString());
                        _viewList.Add(t);
                    }
                }
                return _viewList;

            }
        }


        public List<Dictionary<string,object>> getTableList()
        {
            var dtTables = Template.GetRows(TABLE_LIST_SQL);
            return dtTables;
        }
        public List<Dictionary<string,object>> getViewList()
        {
            var dtTables = Template.GetRows(TABLE_LIST_SQL);
            return dtTables;
        }


        public override ITable GetTable(string pTableName, string pSchemaName)
        {
            return new TableSqlite(this, Template, pTableName, pSchemaName);
        }

        public override string ToString()
        {
            return string.Format("SqliteDatabase : {0}, ConnectionString: {1}", this.CodeGenerationConfig.ConnectionName, this.CodeGenerationConfig.ConnectionString);
        }



        public override string getDefaultSchema()
        {
            return "";
        }

        public override List<Dictionary<string,object>>  GetTableListFromSchema(string schemaName)
        {
            return getTableList();
        }

        public override List<Dictionary<string,object>>  GetViewListFromSchema(string schemaName)
        {
            List<Dictionary<string,object>>  dtView = Template.GetRows(TABLE_LIST_SQL);
            return dtView;

        }

        public override List<Dictionary<string,object>> GetStoredProcedureListFromSchema(string schemaName)
        {
            // sqlite does not support stored procedures
            return new List<Dictionary<string,object>>();
        }

        public override List<Dictionary<string,object>> GetSequenceListFromSchema(string schemaName)
        {
            // sqlite does not support sequences
            return new List<Dictionary<string,object>>();
        }


        public override string[] GetSchemaList()
        {
            return new string[] { "main"};
        }




        public override void CodeGenerateOneSequence(string sequenceName, string schemaName)
        {
            throw new NotSupportedException("sqlite does not support sequences");
        }



        public override IView GetView(string pViewName, string pSchemaName)
        {
            return new ViewSqlite(this, Template, pViewName, pSchemaName);
        }

        public override bool CheckIfCodeShouldBeGenerated(string pTableName, string pSchemaName)
        {
            // TODO ignore table name suffix . Make this generic
            if (pTableName.StartsWith("sqlite_"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public override DalGenerator DalGenerator
        {
            get { return new SqliteDalGenerator(this.CodeGenerationConfig); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new TypeLibraryGenerator(this.CodeGenerationConfig); }
        }

        public override BsGenerator BsGenerator
        {
            get { return new SqliteBsGenerator(this.CodeGenerationConfig); }
        }

    }
}
