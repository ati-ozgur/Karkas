using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers.BaseClasses
{
    public abstract class BaseGenerator
    {

        IDatabase databaseHelper;
        CodeGenerationConfig codeGenerationConfig;

        public IDatabase DatabaseHelper { get => databaseHelper; set => databaseHelper = value; }
        public CodeGenerationConfig CodeGenerationConfig { get => codeGenerationConfig; set => codeGenerationConfig = value; }

        public BaseGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig)
        {
            this.DatabaseHelper = pDatabaseHelper;
            this.CodeGenerationConfig = pCodeGenerationConfig;

        }


        

        protected void AtStartCurlyBraceletIncreaseTab(IOutput output)
        {
            output.autoTabLn("{");
            output.increaseTab();
        }
        protected void AtEndCurlyBraceletDecreaseTab(IOutput output)
        {
            output.decreaseTab();
            output.autoTabLn("}");
        }
        protected void AtStartCurlyBracelet(IOutput output)
        {
            output.autoTabLn("{");            
        }
        protected void AtEndCurlyBracelet(IOutput output)
        {
            output.autoTabLn("}");
        }
        protected void Write_EndOfClassCurlyBracelet(IOutput output)
        {
            output.autoTabLn("}");
            output.decreaseTab();
        }
        protected void Write_NamespaceEndCurlyBracelet(IOutput output)
        {
            AtEndCurlyBraceletDecreaseTab(output);
        }
    }
}

