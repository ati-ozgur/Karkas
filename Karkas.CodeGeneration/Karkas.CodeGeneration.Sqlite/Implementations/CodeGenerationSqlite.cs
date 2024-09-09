﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Sqlite.Generators;
using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class CodeGenerationSqlite : BaseCodeGenerationDatabase
    {


        public CodeGenerationSqlite(IAdoTemplate<IParameterBuilder> template) : base(template)
        {

        }
        public CodeGenerationSqlite(IAdoTemplate<IParameterBuilder> template
            , String connectionString
            , string connectionName
            , string projectNameSpace
            , string codeGenerationDirectory
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool ignoreSystemTables
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            ) : base(template)

        {
 
            this.ConnectionString = connectionString;

            this.ProjectNameSpace = projectNameSpace;
            this.CodeGenerationDirectory = codeGenerationDirectory;
            this.ConnectionName = connectionName;

            this.ConnectionDbProviderName = dbProviderName;
            this.UseSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.UseSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.ListDatabaseAbbreviations = listDatabaseAbbreviations;

            this.IgnoreSystemTables = ignoreSystemTables;

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
                        TableSqlite table = new TableSqlite(this, Template, tableName, this.ConnectionName);
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

                    var dtViews = getViewListFromSchema(null);
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
            var dtTables = Template.GetListOfDictionary(TABLE_LIST_SQL);
            return dtTables;
        }
        public List<Dictionary<string,object>> getViewList()
        {
            var dtTables = Template.GetListOfDictionary(TABLE_LIST_SQL);
            return dtTables;
        }


        public override ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableSqlite(this, Template, pTableName, pSchemaName);
        }

        public override string ToString()
        {
            return string.Format("SqliteDatabase : {0}, ConnectionString: {1}", ConnectionName, ConnectionString);
        }



        public override string getDefaultSchema()
        {
            return "";
        }

        public override List<Dictionary<string,object>>  getTableListFromSchema(string schemaName)
        {
            return getTableList();
        }

        public override List<Dictionary<string,object>>  getViewListFromSchema(string schemaName)
        {
            List<Dictionary<string,object>>  dtView = Template.GetListOfDictionary(TABLE_LIST_SQL);
            return dtView;

        }

        public override List<Dictionary<string,object>> getStoredProcedureListFromSchema(string schemaName)
        {
            // sqlite does not support stored procedures
            return new List<Dictionary<string,object>>();
        }

        public override List<Dictionary<string,object>> getSequenceListFromSchema(string schemaName)
        {
            // sqlite does not support sequences
            return new List<Dictionary<string,object>>();
        }


        public override string[] getSchemaList()
        {
            return new string[] { "main"};
        }




        public override void CodeGenerateOneSequence(string sequenceName, string schemaName)
        {
            // sqlite does not support sequences
            throw new NotSupportedException();
        }


        IOutput output = new SqliteOutput();
        public override IOutput Output
        {
            get
            {
                return output;
            }
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
            get { return new SqliteDalGenerator(this); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new TypeLibraryGenerator(this); }
        }

        public override BsGenerator BsGenerator
        {
            get { return new SqliteBsGenerator(this); }
        }

    }
}