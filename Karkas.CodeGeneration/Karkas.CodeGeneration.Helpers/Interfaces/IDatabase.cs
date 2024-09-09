using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.Core.DataUtil;
using System.Data;
using Karkas.CodeGeneration.Helpers.Generators;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface IDatabase : ICodeGenerationPersistanceValues
    {


        List<DatabaseAbbreviations> ListDatabaseAbbreviations { get; set; }


        string[] getSchemaList();

        string getDefaultSchema();

        IAdoTemplate<IParameterBuilder> Template
        {
            get;
            set;
        }

        List<ITable> Tables { get; }
        List<IView> Views { get; }


        List<Dictionary<string,object>>  getTableListFromSchema(string schemaName);
        List<Dictionary<string,object>>  getViewListFromSchema(string schemaName);



        List<Dictionary<string,object>>  getStoredProcedureListFromSchema(string schemaName);
        List<Dictionary<string,object>>  getSequenceListFromSchema(string schemaName);

        ITable getTable(string pTableName, string pSchemaName);


        DalGenerator DalGenerator
        {
            get;
        }


        string CodeGenerateAllTablesInSchema(string pSchemaName);
        string CodeGenerateAllTables();
        void CodeGenerateOneTable(string pTableName, string pSchemaName);

        void CodeGenerateOneView(string pViewName, string pSchemaName);
        string CodeGenerateAllViewsInSchema(string pSchemaName);
        string CodeGenerateAllViews();

        void CodeGenerateOneSequence(string sequenceName, string schemaName);
        string CodeGenerateAllSequencesInSchema(string pSchemaName);
    }
}
