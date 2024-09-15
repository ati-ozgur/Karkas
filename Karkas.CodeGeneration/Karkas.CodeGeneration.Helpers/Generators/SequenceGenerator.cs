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

        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";

        public SequenceGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)
        {
            utils = new Utils(pDatabaseHelper);

        }
        Utils utils = null;


        public string Render(IOutput output
            , string schemaName
            , string sequenceName)
        {
            
            output.tabLevel = 0;
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;

            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string schemaNamepascalCase = utils.GetPascalCase(schemaName);
            string sequenceNamePascalCase = utils.GetPascalCase(sequenceName);

            string baseNameSpaceSequencesDal = baseNameSpace + ".Dal." + schemaNamepascalCase + ".Sequences";

            string sequenceDalName = sequenceNamePascalCase + "Dal";

            string outputFullFileNameGenerated = "TODO-SEQUENCE.txt";//utils.FileUtilsHelper.getBaseNameForSequenceDalGenerated(this.DatabaseHelper, schemaNamepascalCase, sequenceNamePascalCase, CodeGenerationConfig.UseSchemaNameInFolders);

            writeUsings(output,baseNameSpaceSequencesDal);
            writeClass(output, sequenceDalName);

            writeOverrideDbProviderName(output);



            writeSelectSequenceStrings(output, this.DatabaseHelper, schemaName, sequenceName);
            writeGetNextSequenceValue(output);
            writeGetCurrentSequenceValue(output);
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            return "";


        }

        private void writeGetNextSequenceValue(IOutput output)
        {
            output.autoTabLn("");
            output.autoTabLn("public decimal GetNextSequenceValue()");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("return (decimal) Template.BringOneValue(selectNextSequenceString);");
            AtEndCurlyBraceletDecreaseTab(output);
        }
        private void writeGetCurrentSequenceValue(IOutput output)
        {
            output.autoTabLn("");
            output.autoTabLn("public decimal GetCurrentSequenceValue()");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("return (decimal) Template.BringOneValue(selectCurrentSequenceString);");
            AtEndCurlyBraceletDecreaseTab(output);
        }

        private void writeSelectSequenceStrings(IOutput output, IDatabase database, string schemaName, string sequenceName)
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
            output.autoTabLn(selectNextSequenceString);
            output.autoTabLn(selectCurrentSequenceString);


        }

        private void writeUsings(IOutput output, string baseNameSpaceSequencesDal)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("using Karkas.Core.Data.Oracle;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceSequencesDal);
            output.autoTabLn("");
            AtStartCurlyBraceletIncreaseTab(output);
        }


        private void writeClass(IOutput output, string className)
        {
            output.increaseTab();
            output.autoTab($"public partial class {className} : BaseDalWithoutEntityOracle");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        private void writeOverrideDbProviderName(IOutput output)
        {
            output.autoTabLn("public override string DbProviderName");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionDbProviderName));
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }

    }
}

