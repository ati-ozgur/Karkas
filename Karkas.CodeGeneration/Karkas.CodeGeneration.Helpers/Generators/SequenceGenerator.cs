using System;
using System.Collections;
using System.Text;
using Karkas.CodeGeneration.Helpers;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers.Generators
{
    public class SequenceGenerator : BaseGenerator
    {

        string baseNameSpaceTypeLibrary = "";

        public SequenceGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)
        {
            utils = new Utils(pCodeGenerationConfig);
        }
        Utils utils = null;


        public string Render(string schemaName
            , string sequenceName)
        {
            
            output.TabLevel = 0;
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;

            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string schemaNamepascalCase = utils.GetPascalCase(schemaName);
            string sequenceNamePascalCase = utils.GetPascalCase(sequenceName);

            string baseNameSpaceSequencesDal = baseNameSpace + ".Dal." + schemaNamepascalCase + ".Sequences";

            string sequenceDalName = sequenceNamePascalCase + "Dal";

            string outputFullFileNameGenerated = "TODO-SEQUENCE.txt";//utils.FileUtilsHelper.getBaseNameForSequenceDalGenerated(this.DatabaseHelper, schemaNamepascalCase, sequenceNamePascalCase, CodeGenerationConfig.UseSchemaNameInFolders);

            Write_Usings(baseNameSpaceSequencesDal);
            Write_Class(sequenceDalName);

            Write_OverrideDbProviderName();



            Write_SelectSequenceStrings(schemaName, sequenceName);
            Write_GetNextSequenceValue();
            Write_GetCurrentSequenceValue();
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
            return "";


        }

        private void Write_GetNextSequenceValue()
        {
            output.AutoTabLine("");
            output.AutoTabLine("public decimal GetNextSequenceValue()");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("return (decimal) Template.GetOneValue(selectNextSequenceString);");
            AtEndCurlyBraceletDecreaseTab();
        }
        private void Write_GetCurrentSequenceValue()
        {
            output.AutoTabLine("");
            output.AutoTabLine("public decimal GetCurrentSequenceValue()");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("return (decimal) Template.GetOneValue(selectCurrentSequenceString);");
            AtEndCurlyBraceletDecreaseTab();
        }

        private void Write_SelectSequenceStrings(string schemaName, string sequenceName)
        {
            string selectNextSequenceString = "";
            string selectCurrentSequenceString = $"private const string selectCurrentSequenceString = \"SELECT last_number FROM all_sequences WHERE sequence_owner = '{schemaName}' AND sequence_name = '{sequenceName}'\";";
            if (CodeGenerationConfig.UseSchemaNameInSqlQueries)
            {
                selectNextSequenceString = $"private const string selectNextSequenceString = \"SELECT {schemaName}.{sequenceName}.NEXTVAL FROM DUAL\";";
            }
            else
            {
                selectNextSequenceString = $"private const string selectNextSequenceString = \"SELECT {sequenceName}.NEXTVAL FROM DUAL\";";
            }
            output.AutoTabLine(selectNextSequenceString);
            output.AutoTabLine(selectCurrentSequenceString);


        }

        private void Write_Usings(string baseNameSpaceSequencesDal)
        {
            output.AutoTabLine("");
            output.AutoTabLine("using System;");
            output.AutoTabLine("using System.Collections.Generic;");
            output.AutoTabLine("using System.Data;");
            output.AutoTabLine("using System.Data.Common;");
            output.AutoTabLine("using Microsoft.Data.SqlClient;");
            output.AutoTabLine("using System.Text;");
            output.AutoTabLine("using Karkas.Data;");
            output.AutoTabLine("using Karkas.Data.Oracle;");
            output.AutoTabLine("");
            output.AutoTab("namespace ");
            output.AutoTab(baseNameSpaceSequencesDal);
            output.AutoTabLine("");
            AtStartCurlyBraceletIncreaseTab();
        }


        private void Write_Class(string className)
        {
            output.IncreaseTab();
            output.AutoTab($"public partial class {className} : BaseDalWithoutEntityOracle");
            AtStartCurlyBraceletIncreaseTab();
        }

        private void Write_OverrideDbProviderName()
        {
            output.AutoTabLine("public override string DbProviderName");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionDbProviderName));
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }

    }
}

