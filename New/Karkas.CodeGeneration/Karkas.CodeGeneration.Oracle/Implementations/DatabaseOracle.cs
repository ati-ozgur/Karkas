using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.Oracle.Generators;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class DatabaseOracle : BaseDatabase
    {

        public DatabaseOracle(AdoTemplate template) : base(template)
        {
        }


        public DatabaseOracle(AdoTemplate template
            ,string connectionString
            , string pDatabaseName
            , string pProjectNameSpace
            , string pProjectFolder
            , string dbProviderName
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , bool sysTablolariniAtla
            , List<DatabaseAbbreviations> listDatabaseAbbreviations

            )
            : base(template)
        {
            this.Template = template;

            this.ConnectionString = connectionString;

            this.ProjectNameSpace = pProjectNameSpace;
            this.CodeGenerationDirectory = pProjectFolder;
            this.LogicalDatabaseName = pDatabaseName;
            this.ConnectionDbProviderName = dbProviderName;

            this.UseSchemaNameInSqlQueries = semaIsminiSorgulardaKullan;
            this.UseSchemaNameInFolders = semaIsminiDizinlerdeKullan;
            this.ListDatabaseAbbreviations = listDatabaseAbbreviations;
            this.IgnoreSystemTables = sysTablolariniAtla;

        }


        public string LogicalDatabaseName { get; set; }

        List<ITable> _tables;
        public override List<ITable> Tables
        {
            get 
            {
                if (_tables == null)
                {
                    _tables = new List<ITable>();
                    string userName = getUserNameFromConnection(ConnectionString);

                    ParameterBuilder builder = Template.getParameterBuilder();
                    builder.parameterEkle("TABLE_SCHEMA", DbType.String, userName);

                    DataTable dtTables = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
                    foreach (DataRow row in dtTables.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        string tableSchema = row["TABLE_SCHEMA"].ToString();

                        ITable table = new TableOracle(this, Template, tableName, tableSchema);
                    }


                }
                return _tables;
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
                        IView t = new ViewOracle(this, Template, row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString());
                        _viewList.Add(t);
                    }
                }
                return _viewList;

            }
        }




        public override ITable getTable(string pTableName, string pSchemaName)
        {
            return new TableOracle(this,Template, pTableName, pSchemaName);
        }




        private const string SQL_FOR_DATABASE_NAME = "select sys_context('userenv','db_name') from dual";
        private const string SQL_FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS SCHEMA_NAME FROM DUAL
UNION
select username from ALL_users
ORDER BY SCHEMA_NAME";
        private const string SQL_FOR_TABLE_LIST = @"
SELECT OWNER AS TABLE_SCHEMA, TABLE_NAME,OWNER || '.' || TABLE_NAME  AS FULL_TABLE_NAME  FROM  ALL_TABLES T
WHERE  
(:TABLE_SCHEMA IS NULL) OR ( lower(OWNER) = lower(:TABLE_SCHEMA))

ORDER BY FULL_TABLE_NAME
";

        private string databaseNamePhysical;

        public string DatabaseNamePhysical
        {
            get
            {
                if (String.IsNullOrEmpty(databaseNamePhysical))
                {
                    databaseNamePhysical = (string)Template.TekDegerGetir(SQL_FOR_DATABASE_NAME);
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }
        }



        public override DataTable getTableListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle(":TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_VIEW_LIST = @"
SELECT OWNER AS VIEW_SCHEMA, VIEW_NAME,OWNER || '.' || VIEW_NAME  AS FULL_VIEW_NAME
FROM  ALL_VIEWS V
WHERE  
(:TABLE_SCHEMA IS NULL) OR ( lower(OWNER) = lower(:TABLE_SCHEMA))
ORDER BY FULL_VIEW_NAME
";
        public override DataTable getViewListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle(":TABLE_SCHEMA", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_VIEW_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_STORED_PROCEDURE_LIST = @"
SELECT AO.owner AS SP_SCHEMA_NAME, AO.object_name AS STORED_PROCEDURE_NAME
FROM all_objects AO
WHERE object_type = 'PROCEDURE'
AND  
( (:SP_SCHEMA_NAME IS NULL) OR ( lower(OWNER) = lower(:SP_SCHEMA_NAME)))
ORDER BY STORED_PROCEDURE_NAME
";
        public override DataTable getStoredProcedureListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle(":SP_SCHEMA_NAME", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_STORED_PROCEDURE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_SEQUENCES_LIST = @"
SELECT AO.owner AS SEQ_SCHEMA_NAME, AO.object_name AS SEQUENCE_NAME
FROM all_objects AO
WHERE 
 object_type = 'SEQUENCE'
 AND  
( (:SEQ_SCHEMA_NAME IS NULL) OR ( lower(OWNER) = lower(:SEQ_SCHEMA_NAME)))
ORDER BY SEQUENCE_NAME
";
        public override DataTable getSequenceListFromSchema(string schemaName)
        {
            ParameterBuilder builder = Template.getParameterBuilder();
            builder.parameterEkle(":SEQ_SCHEMA_NAME", DbType.String, schemaName);
            DataTable dtTableList = Template.DataTableOlustur(SQL_FOR_SEQUENCES_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        

        public override DataTable getSchemaList()
        {
            return Template.DataTableOlustur(SQL_FOR_SCHEMA_LIST);
        }




        private  string getUserNameFromConnection(string pConnectionString)
        {
            string userName = null;
            string[] list = pConnectionString.ToUpperInvariant().Split(';');
            foreach (string item in list)
            {

                if (item.Contains("USER ID"))
                {
                    userName = item.Replace("USER ID", "");
                    userName = userName.Replace("=", "");
                    userName = userName.Trim();
                    break;
                }
            }
            return userName;
        }




        IOutput output = new OracleOutput();

        public override IOutput Output
        {
            get 
            {
                return output;
            }
        }

        public override IView GetView(string pViewName, string pSchemaName)
        {
            return new ViewOracle(this, Template, pViewName, pSchemaName);
        }


        public override DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new TypeLibraryGenerator(this); }
        }


        string defaultSchema;
        public override string getDefaultSchema()
        {
            if (string.IsNullOrEmpty(defaultSchema))
            {
                defaultSchema = getUserNameFromConnection(ConnectionString);
            }
            return defaultSchema;

        }



    }
}
