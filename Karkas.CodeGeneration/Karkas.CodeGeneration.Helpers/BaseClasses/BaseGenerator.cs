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


        BaseOutput output;
        public BaseOutput Output 
        { 
            get
            {
                return output;
            }
        
        }

        public BaseGenerator(CodeGenerationConfig pCodeGenerationConfig)
        {

            codeGenerationConfig = pCodeGenerationConfig;
            output = new BaseOutput();

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

        protected void Write_ClassStartCurlyBracelet(IOutput output)
        {
            AtStartCurlyBraceletIncreaseTab(output);
        }

        protected void Write_ClassEndCurlyBracelet(IOutput output)
        {
            AtEndCurlyBraceletDecreaseTab(output);
        }
        protected void Write_NamespaceStartCurlyBracelet(IOutput output)
        {
            AtStartCurlyBraceletIncreaseTab(output);
        }
        protected void Write_NamespaceEndCurlyBracelet(IOutput output)
        {
            AtEndCurlyBraceletDecreaseTab(output);
        }
    }
}

