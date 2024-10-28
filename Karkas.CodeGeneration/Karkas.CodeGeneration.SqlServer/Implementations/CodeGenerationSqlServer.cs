using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Karkas.Data;
using System.Data;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;

using Karkas.CodeGeneration.SqlServer.Generators;

namespace Karkas.CodeGeneration.SqlServer.Implementations
{
    public class CodeGenerationSqlServer : BaseCodeGenerationDatabase
    {

        public CodeGenerationSqlServer(IAdoTemplate<IParameterBuilder> pTemplate,CodeGenerationConfig pCodeGenerationConfig)
        : base(pTemplate,pCodeGenerationConfig)
        {

        }

        List<ITable> _tableList;

        public override List<ITable> Tables
        {

            get
            {
                if (_tableList == null || _tableList.Count == 0)
                {
                    _tableList = new List<ITable>();
                    IParameterBuilder builder = Template.getParameterBuilder();
                    builder.AddParameter("@TABLE_SCHEMA", DbType.AnsiString, "__TUM_SCHEMALAR__");
                    var dtTableList = Template.GetRows(SQL_FOR_TABLE_LIST,builder.GetParameterArray());

                    foreach (var row in dtTableList)
                    {
                        string schemaName = row[SCHEMA_NAME_IN_TABLE_SQL_QUERIES].ToString();
                        string tableName = row[TABLE_NAME_IN_TABLE_SQL_QUERIES].ToString();
                        ITable t = new TableSqlServer(this,Template, tableName, schemaName);
                        _tableList.Add(t);
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

                    List<Dictionary<string,object>>  dtViews = GetViewListFromSchema(null);
                    foreach (var row in dtViews)
                    {
                        IView t = new ViewSqlServer(this, Template, row["TABLE_NAME"].ToString(), row["TABLE_SCHEMA"].ToString());
                        _viewList.Add(t);
                    }
                }
                return _viewList;

            }
        }


        public override string ToString()
        {
            return this.CodeGenerationConfig.ConnectionName;
        }


        public override ITable GetTable(string pTableName, string pSchemaName)
        {
            ITable t = new TableSqlServer(this, Template, pTableName, pSchemaName);
            return t;
        }







        private const string SQL_FOR_SCHEMA_LIST = @"
SELECT '__TUM_SCHEMALAR__' AS SCHEMA_NAME FROM INFORMATION_SCHEMA.TABLES
UNION
SELECT DISTINCT T.TABLE_SCHEMA AS SCHEMA_NAME FROM INFORMATION_SCHEMA.TABLES T
";



        private const string SQL_FOR_TABLE_LIST = @"
SELECT TABLE_SCHEMA,TABLE_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
AND
TABLE_TYPE = 'BASE TABLE'
ORDER BY FULL_TABLE_NAME
";

        private const string SQL_FOR_DATABASE_NAME = @"
SELECT DISTINCT TABLE_CATALOG FROM INFORMATION_SCHEMA.TABLES
";


        public override List<Dictionary<string,object>>  GetTableListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter("@TABLE_SCHEMA", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_TABLE_LIST, builder.GetParameterArray());
            return dtTableList;
        }

        private const string SQL_FOR_VIEW_LIST = @"
SELECT TABLE_SCHEMA AS VIEW_SCHEMA,TABLE_NAME AS VIEW_NAME, TABLE_SCHEMA + '.' + TABLE_NAME AS FULL_VIEW_NAME
 FROM INFORMATION_SCHEMA.VIEWS
WHERE
( (@TABLE_SCHEMA IS NULL) OR (@TABLE_SCHEMA = '__TUM_SCHEMALAR__') OR ( TABLE_SCHEMA = @TABLE_SCHEMA))
ORDER BY FULL_VIEW_NAME
";


        public override List<Dictionary<string,object>>  GetViewListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter("@TABLE_SCHEMA", DbType.String, schemaName);
            var dtTableList = Template.GetRows(SQL_FOR_VIEW_LIST, builder.GetParameterArray());
            return dtTableList;
        }



        private const string SQL_FOR_STORED_PROCEDURE_LIST = @"
SELECT
      ROUTINE_SCHEMA AS SP_SCHEMA_NAME
      ,ROUTINE_NAME  AS STORED_PROCEDURE_NAME
  FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_TYPE = 'PROCEDURE'
AND
( (@SP_SCHEMA_NAME IS NULL) OR (@SP_SCHEMA_NAME = '__TUM_SCHEMALAR__') OR ( ROUTINE_SCHEMA = @SP_SCHEMA_NAME))
ORDER BY STORED_PROCEDURE_NAME
";


        public override List<Dictionary<string,object>>  GetStoredProcedureListFromSchema(string schemaName)
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter("@SP_SCHEMA_NAME", DbType.String, schemaName);
            var dtStoredProcedures = Template.GetRows(SQL_FOR_STORED_PROCEDURE_LIST, builder.GetParameterArray());
            return dtStoredProcedures;
        }

        private const string SQL_FOR_SEQUENCES_LIST = @"
SELECT
SCHEMA_NAME(seq.schema_id) AS SEQ_SCHEMA_NAME
,seq.name AS SEQUENCE_NAME
FROM
sys.sequences AS seq
WHERE
1 = 1
AND
( (@SEQ_SCHEMA_NAME IS NULL) OR (@SEQ_SCHEMA_NAME = '__TUM_SCHEMALAR__') OR ( SCHEMA_NAME(seq.schema_id) = @SEQ_SCHEMA_NAME))
ORDER BY SEQUENCE_NAME
";
        // TODO Test 2012

        private bool? isSequenceSupported;

        public override List<Dictionary<string,object>>  GetSequenceListFromSchema(string schemaName)
        {
            List<Dictionary<string,object>>  dt = new List<Dictionary<string,object>>();
            if (!isSequenceSupported.HasValue)
            {
                try
                {
                    dt = findSequenceDataTable(schemaName);
                    isSequenceSupported = true;
                }
                catch
                {
                    isSequenceSupported = false;
                    // sql server 2000-2008 does not support sequences but 2012 do.
                    // sql server 2000-2008 arasında sequences yok ama 2012'de var.
                    // exception yut.
                }

            }
            else if (isSequenceSupported.Value)
            {
                dt = findSequenceDataTable(schemaName);
            }
            return dt;
        }


        private const string SQL_SERVER_VERSION = "Select @@version";
        private string sqlServerVersion;

        public string SqlServerVersion
        {
            get
            {
                if (sqlServerVersion == null)
                {
                    sqlServerVersion = (string)Template.GetOneValue(SQL_SERVER_VERSION);
                }

                return sqlServerVersion;
            }
            set { sqlServerVersion = value; }
        }



        private List<Dictionary<string,object>>  findSequenceDataTable(string schemaName)
        {
            if (SqlServerVersion.Contains("SQL Server 2012"))
            {
                IParameterBuilder builder = Template.getParameterBuilder();
                builder.AddParameter("@SEQ_SCHEMA_NAME", DbType.String, schemaName);
                List<Dictionary<string,object>> dt = Template.GetRows(SQL_FOR_SEQUENCES_LIST, builder.GetParameterArray());
                return dt;
            }
            else
            {
                return new List<Dictionary<string,object>> ();
            }


        }


        public override string[] GetSchemaList()
        {
            List<Dictionary<string,object>>  dt = Template.GetRows(SQL_FOR_SCHEMA_LIST);
            string[] schemaList = new string[dt.Count];
            for (int i = 0; i < dt.Count; i++)
            {
                var row = dt[i];
                schemaList[i] = row["SCHEMA_NAME"].ToString();
            }
            return schemaList;
        }



        public override void CodeGenerateOneSequence(string sequenceName, string schemaName)
        {
            // TODO
            throw new NotImplementedException();
        }



        public override IView GetView(string pViewName, string pSchemaName)
        {
            return new ViewSqlServer(this, Template, pViewName, pSchemaName);
        }


        public override DalGenerator DalGenerator
        {
            get { return new SqlServerDalGenerator(this.CodeGenerationConfig); }
        }

        public override TypeLibraryGenerator TypeLibraryGenerator
        {
            get { return new SqlServerTypeLibraryGenerator(this.CodeGenerationConfig); }
        }

        public override BsGenerator BsGenerator
        {
            get { return new SqlServerBsGenerator(this.CodeGenerationConfig); }
        }


        public override string getDefaultSchema()
        {
            return "dbo";
        }
        private string[] sqlserverSystemTableList = { "sysdiagrams" };

        public override bool CheckIfCodeShouldBeGenerated(string pTableName, string pSchemaName)
        {
            if (CodeGenerationConfig.IgnoreSystemTables)
            {
                if (sqlserverSystemTableList.Contains(pTableName))
                {
                    return false;

                }
            }
            return true;

        }

    }
}
