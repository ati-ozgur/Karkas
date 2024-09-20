using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public abstract class BaseGenerator
    {

        protected string baseNameSpace;
        protected string classNameSpace;
        protected string className;

        protected string schemaName;


        protected string outputFullFileName;

        protected string outputFullFileNameGenerated;
        protected List<DatabaseAbbreviations> listDatabaseAbbreviations = null;

        CodeGenerationConfig codeGenerationConfig;

        public CodeGenerationConfig CodeGenerationConfig { get => codeGenerationConfig; set => codeGenerationConfig = value; }


        protected BaseOutput output;

        public BaseGenerator(CodeGenerationConfig pCodeGenerationConfig)
        {

            codeGenerationConfig = pCodeGenerationConfig;
            output = new BaseOutput();

        }


        

        protected void AtStartCurlyBraceletIncreaseTab()
        {
            output.AutoTabLine("{");
            output.IncreaseTab();
        }
        protected void AtEndCurlyBraceletDecreaseTab()
        {
            output.DecreaseTab();
            output.AutoTabLine("}");
        }
        protected void AtStartCurlyBracelet()
        {
            output.AutoTabLine("{");            
        }
        protected void AtEndCurlyBracelet()
        {
            output.AutoTabLine("}");
        }

        protected void Write_ClassStartCurlyBracelet()
        {
            AtStartCurlyBraceletIncreaseTab();
        }

        protected void Write_ClassEndCurlyBracelet()
        {
            AtEndCurlyBraceletDecreaseTab();
        }
        protected void Write_NamespaceStartCurlyBracelet()
        {
            AtStartCurlyBraceletIncreaseTab();
        }
        protected void Write_NamespaceEndCurlyBracelet()
        {
            AtEndCurlyBraceletDecreaseTab();
        }
    }
}

