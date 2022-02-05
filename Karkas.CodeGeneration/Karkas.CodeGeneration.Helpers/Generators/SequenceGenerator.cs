using System;
using System.Collections;
using System.Text;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;
using System.Collections.Generic;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class SequenceGenerator : BaseGenerator
    {

        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";

        public SequenceGenerator(IDatabase databaseHelper)
        {
            utils = new Utils(databaseHelper);
            this.database = databaseHelper;

        }
        Utils utils = null;
        IDatabase database;


        public string Render(IOutput output
            , string schemaName
            , string sequenceName)
        {
            output.tabLevel = 0;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, schemaName);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string schemaNamepascalCase = utils.GetPascalCase(schemaName);
            string sequenceNamePascalCase = utils.GetPascalCase(sequenceName);

            string baseNameSpaceSequencesDal = baseNameSpace + ".Dal." + schemaNamepascalCase + ".Sequences";

            string sequenceDalName = sequenceNamePascalCase + "Dal";

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForSequenceDalGenerated(database, schemaName, sequenceNamePascalCase, database.UseSchemaNameInFolders);

            UsingleriWrite(output,baseNameSpaceSequencesDal);
            ClassWrite(output, sequenceDalName);

            OverrideDbProviderNameWrite(output);



            SelectSequenceStringWrite(output, database, schemaName, sequenceName);
            getNextSequenceValueWrite(output);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            return "";


        }

        private void getNextSequenceValueWrite(IOutput output)
        {
            output.autoTabLn("");
            output.autoTabLn("public decimal getNextSequenceValue()");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("AdoTemplate template = new AdoTemplate(DbProviderName);");
            output.autoTabLn("return (decimal) template.BringOneValue(selectSequenceString);");
            BitisSusluParentezVeTabAzalt(output);
        }

        private void SelectSequenceStringWrite(IOutput output, IDatabase database, string schemaName, string sequenceName)
        {
            string selectSequenceString = "";
            if (database.UseSchemaNameInSqlQueries)
            {
                selectSequenceString = string.Format("private const string selectSequenceString = \"SELECT {0}.{1}.NEXTVAL FROM DUAL\";", schemaName, sequenceName);
            }
            else
            {
                selectSequenceString = string.Format("private const string selectSequenceString = \"SELECT {0}.NEXTVAL FROM DUAL\";",  sequenceName);
            }
            output.autoTabLn(selectSequenceString);


        }

        private void UsingleriWrite(IOutput output, string baseNameSpaceSequencesDal)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceSequencesDal);
            output.autoTabLn("");
            AtStartCurlyBraceletIncreaseTab(output);
        }


        private void ClassWrite(IOutput output, string className)
        {
            output.increaseTab();
            output.autoTab("public partial class ");
            output.write(className);
            output.writeLine("");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        private void OverrideDbProviderNameWrite(IOutput output)
        {
            output.autoTabLn("public string DbProviderName");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", database.ConnectionDbProviderName));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

    }
}

