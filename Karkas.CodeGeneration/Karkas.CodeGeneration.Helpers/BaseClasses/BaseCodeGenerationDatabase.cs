using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Data;
using System.Data;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public abstract class BaseCodeGenerationDatabase : BaseGenerator
    {
        IAdoTemplate<IParameterBuilder> template;



		public BaseCodeGenerationDatabase(IAdoTemplate<IParameterBuilder> pTemplate, CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)
        {
            this.template = pTemplate;
			this.codeGenerationConfig = pCodeGenerationConfig;

		}



		public IAdoTemplate<IParameterBuilder> Template
        {
            get
            {
                return template;
            }
            set
            {
                template = value;
            }
        }





        public abstract List<ITable> Tables { get; }
        public abstract List<IView> Views { get; }

        public abstract List<Dictionary<string,object>>  GetTableListFromSchema(string schemaName);
        public abstract List<Dictionary<string,object>>  GetViewListFromSchema(string schemaName);
        public abstract List<Dictionary<string,object>>  GetStoredProcedureListFromSchema(string schemaName);
        public abstract List<Dictionary<string,object>>  GetSequenceListFromSchema(string schemaName);


        public abstract ITable GetTable(string pTableName, string pSchemaName);

        public string CodeGenerateAllTables()
        {
            StringBuilder exceptionMessages = new StringBuilder();
            foreach (var item in Tables)
            {
                try
                {
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
            if (CodeGenerationConfig.IgnoredSchemaList.Contains(pSchemaName))
            {
                exceptionMessages.Append("Your choosen schema is in ignore list");

            }
            else
            {
                var dtTables = GetTableListFromSchema(pSchemaName);

                foreach (var item in dtTables)
                {
                    try
                    {
						string tableName = item["TABLE_NAME"].ToString();
						CodeGenerateOneTable(tableName, pSchemaName);
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
            var dtViews = GetViewListFromSchema(pSchemaName);
            foreach (var item in dtViews )
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



        public abstract IView GetView(string pViewName, string pSchemaName);

        public abstract bool CheckIfCodeShouldBeGenerated(string pTableName, string pSchemaName);




        public void CodeGenerateOneTable(string pTableName, string pSchemaName)
        {
            if(CheckIfCodeShouldBeGenerated(pTableName,pSchemaName))
            {
                TypeLibraryGenerator typeGen = this.TypeLibraryGenerator;
                DalGenerator dalGen = this.DalGenerator;
                BsGenerator bsGen =  this.BsGenerator;

                ITable table = this.GetTable(pTableName, pSchemaName);


                typeGen.Render(table);
                dalGen.Render(table);
                bsGen.Render(table);

            }

        }



        public void CodeGenerateOneView(string pViewName, string pSchemaName)
        {
            TypeLibraryGenerator typeGen = this.TypeLibraryGenerator;
            DalGenerator dalGen = this.DalGenerator;
            BsGenerator bsGen = this.BsGenerator;

            IView view = GetView( pViewName, pSchemaName);


            typeGen.Render(view);
            dalGen.Render(view);
            bsGen.Render(view);
        }


        public virtual void CodeGenerateOneSequence(string schemaName, string sequenceName)
        {
            SequenceGenerator seqGen = new SequenceGenerator(this.CodeGenerationConfig);
            seqGen.Render(schemaName, sequenceName);
        }
        public string CodeGenerateAllSequencesInSchema(string schemaName)
        {
            StringBuilder exceptionMessages = new StringBuilder();
            var dtSequenceList = GetSequenceListFromSchema(schemaName);
            foreach (var row in dtSequenceList)
            {
                try
                {
                    string sequenceName = row["SEQUENCE_NAME"].ToString();
                    string seqSchemaName = row["SEQ_SCHEMA_NAME"].ToString();
                    CodeGenerateOneSequence(seqSchemaName, sequenceName);
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
            var dtSequenceList = GetSequenceListFromSchema(getDefaultSchema());
            foreach (var row in dtSequenceList)
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
        public abstract BsGenerator BsGenerator
        {
            get;
        }
        public  abstract DalGenerator DalGenerator
        {
            get;
        }
        public abstract TypeLibraryGenerator TypeLibraryGenerator
        {
            get;
        }



        public abstract string[] GetSchemaList();

        public abstract string getDefaultSchema();


        public const string SCHEMA_NAME_IN_TABLE_SQL_QUERIES = "TABLE_SCHEMA";
        public const string TABLE_NAME_IN_TABLE_SQL_QUERIES = "TABLE_NAME";



    }
}
