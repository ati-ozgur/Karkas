using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.Helpers;

using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;

using Karkas.CodeGeneration.Oracle.Generators;


namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class CodeGenerationOracle : BaseCodeGenerationDatabase
    {

        public CodeGenerationOracle(IAdoTemplate<IParameterBuilder> template, CodeGenerationConfig pCodeGenerationConfig): base(template,pCodeGenerationConfig)        
        {

        }





        List<ITable> _tables;
        public override List<ITable> Tables
        {
            get 
            {
                if (_tables == null)
                {
                    _tables = new List<ITable>();
                    string userName = getUserNameFromConnection(CodeGenerationConfig.ConnectionString);

                    IParameterBuilder builder = Template.getParameterBuilder();
                    builder.AddParameter("TABLE_SCHEMA", DbType.String, userName);

                    var dtTables = Template.GetRows(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
                    foreach (var row in dtTables)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        string tableSchema = row["TABLE_SCHEMA"].ToString();

                        ITable table = new TableOracle(this, Template, tableName, tableSchema);
                        _tables.Add(table);
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

                    List<Dictionary<string,object>>  dtViews = getViewListFromSchema(null);
                    foreach (var row in dtViews)
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



        public override List<Dictionary<string,object>>  getTableListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter(":TABLE_SCHEMA", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_VIEW_LIST = @"
SELECT OWNER AS VIEW_SCHEMA, VIEW_NAME,OWNER || '.' || VIEW_NAME  AS FULL_VIEW_NAME
FROM  ALL_VIEWS V
WHERE  
(:TABLE_SCHEMA IS NULL) OR ( lower(OWNER) = lower(:TABLE_SCHEMA))
ORDER BY FULL_VIEW_NAME
";
        public override List<Dictionary<string,object>>  getViewListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter(":TABLE_SCHEMA", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_VIEW_LIST, builder.GetParameterArray());
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
        public override List<Dictionary<string,object>>  getStoredProcedureListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter(":SP_SCHEMA_NAME", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_STORED_PROCEDURE_LIST, builder.GetParameterArray());
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
        public override List<Dictionary<string,object>>  getSequenceListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter(":SEQ_SCHEMA_NAME", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_SEQUENCES_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        

        public override string[] getSchemaList()
        {
            var dt = Template.GetRows(SQL_FOR_SCHEMA_LIST);
            var schemaList = new List<string>();
            foreach (var item in dt)
            {
                schemaList.Add(item["SCHEMA_NAME"].ToString());
            }
            return schemaList.ToArray<string>();
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





        public override IView GetView(string pViewName, string pSchemaName)
        {
            return new ViewOracle(this, Template, pViewName, pSchemaName);
        }


        public override DalGenerator DalGenerator
        {
            get { return new OracleDalGenerator(this.CodeGenerationConfig); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new TypeLibraryGenerator(this.CodeGenerationConfig); }
        }

        public override BsGenerator BsGenerator
        {
            get { return new OracleBsGenerator(this.CodeGenerationConfig); }
        }



        string defaultSchema;
        public override string getDefaultSchema()
        {
            if (string.IsNullOrEmpty(defaultSchema))
            {
                defaultSchema = getUserNameFromConnection(CodeGenerationConfig.ConnectionString);
            }
            return defaultSchema;

        }

        private string[] oracleSystemSchemaList = { "SYS" };

        public override bool CheckIfCodeShouldBeGenerated(string pTableName, string pSchemaName)
        {
            if(CodeGenerationConfig.IgnoreSystemTables)
            {
                if(oracleSystemSchemaList.Contains(pSchemaName.ToUpper()))
                {
                    return false;

                }
            }
            return true;

        }
    }
}
