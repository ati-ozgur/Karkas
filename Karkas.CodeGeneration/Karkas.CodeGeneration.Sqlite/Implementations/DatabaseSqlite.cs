using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGeneration.Sqlite.Generators;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGeneration.Sqlite.Implementations
{
    public class DatabaseSqlite : BaseDatabase
    {

        public DatabaseSqlite(AdoTemplate template)
            : base(template)
        {
        }

        public DatabaseSqlite(AdoTemplate template
            , String connectionString
            , string connectionName
            , string projectNameSpace
            , string codeGenerationDirectory
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            )
            : base(template)
        {

            this.ConnectionString = connectionString;

            this.ProjectNameSpace = projectNameSpace;
            this.CodeGenerationDirectory = codeGenerationDirectory;
            this.ConnectionName = connectionName;

            this.ConnectionDbProviderName = dbProviderName;
            this.UseSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.UseSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.ListDatabaseAbbreviations = listDatabaseAbbreviations;

            this.IgnoreSystemTables = sysTablolariniAtla;

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
                    DataTable dtTables = getTableList();
                    _tableList = new List<ITable>();
                    foreach (DataRow rowTable in dtTables.Rows)
                    {
                        String tableName = rowTable["TABLE_NAME"].ToString();
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

                    DataTable dtViews = getViewListFromSchema(null);
                    foreach (DataRow row in dtViews.Rows)
                    {
                        IView t = new ViewSqlite(this, Template, row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString());
                        _viewList.Add(t);
                    }
                }
                return _viewList;

            }
        }


        public DataTable getTableList()
        {
            DataTable dtTables = Template.DataTableOlustur(TABLE_LIST_SQL);
            return dtTables;
        }
        public DataTable getViewList()
        {
            DataTable dtTables = Template.DataTableOlustur(TABLE_LIST_SQL);
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

        public override DataTable getTableListFromSchema(string schemaName)
        {
            return getTableList();
        }

        public override DataTable getViewListFromSchema(string schemaName)
        {
            DataTable dtView = Template.DataTableOlustur(TABLE_LIST_SQL);
            return dtView;

        }

        public override DataTable getStoredProcedureListFromSchema(string schemaName)
        {
            // sqlite does not support stored procedures
            DataTable dt = new DataTable();
            return dt;
        }

        public override DataTable getSequenceListFromSchema(string schemaName)
        {
            // sqlite does not support sequences
            DataTable dt = new DataTable();
            return dt;
        }


        public override DataTable getSchemaList()
        {
            return new DataTable();
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



        public override DalGenerator DalGenerator
        {
            get { return new SqliteDalGenerator(this); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new TypeLibraryGenerator(this); }
        }

    }
}
