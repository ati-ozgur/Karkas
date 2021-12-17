using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGenerationHelper.Generators;

namespace Karkas.CodeGenerationHelper.BaseClasses
{
    public abstract class BaseDatabase : IDatabase
    {
        public BaseDatabase(AdoTemplate template)
	    {
            Template = template;
	    }


        bool sysTablolariniAtla;

        public bool IgnoreSystemTables
        {
            get { return sysTablolariniAtla; }
            set { sysTablolariniAtla = value; }
        }

        string connectionDatabaseType;

        public string ConnectionDatabaseType
        {
            get
            {
                return connectionDatabaseType;
            }
            set
            {
                connectionDatabaseType = value;
            }
        }

        string dbProviderName;

        public string ConnectionDbProviderName
        {
            get { return dbProviderName; }
            set { dbProviderName = value; }
        }


        bool semaIsminiSorgulardaKullan;

        public bool UseSchemaNameInSqlQueries
        {
            get { return semaIsminiSorgulardaKullan; }
            set { semaIsminiSorgulardaKullan = value; }
        }
        bool semaIsminiDizinlerdeKullan;

        public bool UseSchemaNameInFolders
        {
            get { return semaIsminiDizinlerdeKullan; }
            set { semaIsminiDizinlerdeKullan = value; }
        }
        List<DatabaseAbbreviations> listDatabaseAbbreviations;

        public List<DatabaseAbbreviations> ListDatabaseAbbreviations
        {
            get { return listDatabaseAbbreviations; }
            set { listDatabaseAbbreviations = value; }
        }


        private AdoTemplate template;
        string projectNameSpace;
        string codeGenerationDirectory;
        string connectionName;


        string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public string ConnectionName
        {
            get
            {
                return connectionName;
            }
            set
            {
                connectionName = value;
            }
        }

        public string ProjectNameSpace
        {
            get { return projectNameSpace; }
            set { projectNameSpace = value; }

        }

        public string CodeGenerationDirectory
        {
            get { return codeGenerationDirectory; }
            set { codeGenerationDirectory = value; }
        }

        bool viewCodeGenerateEtsinMi;

        public bool ViewCodeGenerate
        {
            get { return viewCodeGenerateEtsinMi; }
            set { viewCodeGenerateEtsinMi = value; }
        }
        bool storedProcedureCodeGenerateEtsinMi;

        public bool StoredProcedureCodeGenerate
        {
            get { return storedProcedureCodeGenerateEtsinMi; }
            set { storedProcedureCodeGenerateEtsinMi = value; }
        }
        bool sequenceCodeGenerate;
        public bool SequenceCodeGenerate
        {
            get { return sequenceCodeGenerate; }
            set { sequenceCodeGenerate = value; }
        }


        string ignoredSchemaList;

        public string IgnoredSchemaList
        {
            get { return ignoredSchemaList; }
            set { ignoredSchemaList = value; }
        }



        string databaseAbbreviations;

        public string DatabaseAbbreviations
        {
            get { return databaseAbbreviations; }
            set { databaseAbbreviations = value; }
        }

        public AdoTemplate Template
        {
            get { return template; }
            set { template = value; }
        }
        string databaseName;

        public virtual string DatabaseNameLogical
        {
            get { return databaseName; }
            set { databaseName = value; }
        }



        private string databaseNamePhysical;

        public virtual string DatabaseNamePhysical
        {
            get
            {
                if (String.IsNullOrEmpty(databaseNamePhysical))
                {
                    databaseNamePhysical = template.Connection.Database; ;
                }
                return databaseNamePhysical;
            }
            set
            {
                databaseNamePhysical = value;
            }

        }

        public abstract List<ITable> Tables { get; }
        public abstract List<IView> Views { get; }

        public abstract DataTable getTableListFromSchema(string schemaName);
        public abstract DataTable getViewListFromSchema(string schemaName);
        public abstract DataTable getStoredProcedureListFromSchema(string schemaName);
        public abstract DataTable getSequenceListFromSchema(string schemaName);
        

        public abstract ITable getTable(string pTableName, string pSchemaName);

        public string CodeGenerateAllTables()
        {
            StringBuilder exceptionMessages = new StringBuilder();
            foreach (var item in Tables)
            {
                try
                {
                    if (ignoredSchemaList.Contains(item.Schema))
                    {
                        continue;
                    }
                    CodeGenerateOneTable(item.Name, item.Schema);
                }
                catch(Exception ex)
                {
                    exceptionMessages.Append(ex.Message);
                }
            }
            return exceptionMessages.ToString();
        }

        public string CodeGenerateAllTablesInSchema(string pSchemaName)
        {
            StringBuilder exceptionMessages = new StringBuilder();
            if (ignoredSchemaList.Contains(pSchemaName))
            {
                exceptionMessages.Append("Your choosen schema is in ignore list");

            }
            else
            {
                DataTable dtTables = getTableListFromSchema(pSchemaName);

                foreach (DataRow item in dtTables.Rows)
                {
                    try
                    {
                        CodeGenerateOneTable(item["TABLE_NAME"].ToString(), pSchemaName);
                    }
                    catch (Exception ex)
                    {
                        exceptionMessages.Append(ex.Message);
                    }
                }
            }
            return exceptionMessages.ToString();
        }

        public string CodeGenerateAllViewsInSchema(string pSchemaName)
        {
            StringBuilder exceptionMessages = new StringBuilder();
            DataTable dtViews = getViewListFromSchema(pSchemaName);
            foreach (DataRow item in dtViews.Rows )
            {
                try
                {

                    CodeGenerateOneView(item["VIEW_NAME"].ToString(), pSchemaName);
                }
                catch (Exception ex)
                {
                    exceptionMessages.Append(ex.Message);
                }
            }
            return exceptionMessages.ToString();
        }


        public string CodeGenerateAllViews()
        {
            StringBuilder exceptionMessages = new StringBuilder();
            foreach (var item in Views)
            {
                try
                {

                    CodeGenerateOneView(item.Name, item.Schema );
                }
                catch (Exception ex)
                {
                    exceptionMessages.Append(ex.Message);
                }
            }
            return exceptionMessages.ToString();
        }


        public abstract IOutput Output { get; }
        public abstract IView GetView(string pViewName, string pSchemaName);



        public void CodeGenerateOneTable(string pTableName, string pSchemaName)
        {
            // TODO ignore table name suffix . Make this generic
            if (pTableName.StartsWith("sqlite_"))
            {
                return;
            }

            TypeLibraryGenerator typeGen = this.TypeLibraryGenerator;
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);

            ITable table = this.getTable(pTableName, pSchemaName);


            typeGen.Render(Output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            dalGen.Render(Output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            bsGen.Render(Output, table, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
        }



        public void CodeGenerateOneView(string pViewName, string pSchemaName)
        {
            TypeLibraryGenerator typeGen = new TypeLibraryGenerator(this);
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = new BsGenerator(this);

            IView view = GetView( pViewName, pSchemaName);


            typeGen.Render(Output, view, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            dalGen.Render(Output, view, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
            bsGen.Render(Output, view, UseSchemaNameInSqlQueries, UseSchemaNameInFolders, ListDatabaseAbbreviations);
        }


        public virtual void CodeGenerateOneSequence(string sequenceName, string schemaName)
        {
            SequenceGenerator seqGen = new SequenceGenerator(this);
            seqGen.Render(Output, schemaName, sequenceName);
        }
        public string CodeGenerateAllSequencesInSchema(string schemaName)
        {
            StringBuilder exceptionMessages = new StringBuilder();
            DataTable dtSequenceList = getSequenceListFromSchema(schemaName);
            foreach (DataRow row in dtSequenceList.Rows)
            {
                try
                {
                    string sequenceName = row["SEQUENCE_NAME"].ToString();
                    string seqSchemaName = row["SEQ_SCHEMA_NAME"].ToString();
                    CodeGenerateOneSequence(seqSchemaName, seqSchemaName);
                }
                catch (Exception ex)
                {
                    exceptionMessages.Append(ex.Message);
                }
            }
            return exceptionMessages.ToString();
        }

        public string CodeGenerateAllSequences()
        {
            StringBuilder exceptionMessages = new StringBuilder();
            DataTable dtSequenceList = getSequenceListFromSchema(getDefaultSchema());
            foreach (DataRow row in dtSequenceList.Rows)
            {
                try
                {
                    string sequenceName =row["SEQUENCE_NAME"].ToString();
                    string seqSchemaName = row["SEQ_SCHEMA_NAME"].ToString();
                    CodeGenerateOneSequence(seqSchemaName, seqSchemaName);
                }
                catch (Exception ex)
                {
                    exceptionMessages.Append(ex.Message);
                }
            }
            return exceptionMessages.ToString();
        }

        public  abstract DalGenerator DalGenerator
        {
            get;
        }
        public abstract TypeLibraryGenerator TypeLibraryGenerator 
        { 
            get; 
        }



        public abstract DataTable getSchemaList();

        public abstract string getDefaultSchema();


        public const string SCHEMA_NAME_IN_TABLE_SQL_QUERIES = "TABLE_SCHEMA";
        public const string TABLE_NAME_IN_TABLE_SQL_QUERIES = "TABLE_NAME";



        #region "Not Persisted Values"
        public bool AnaSinifiTekrarUret { get; set; }
        public bool AnaSinifOnaylamaOrnekleriUret { get; set; }

        #endregion

    }
}
