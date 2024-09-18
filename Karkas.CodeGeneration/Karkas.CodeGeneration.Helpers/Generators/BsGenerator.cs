using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers.Generators
{
    public abstract class BsGenerator : BaseGenerator
    {
        string classNameTypeLibrary = "";
        string classNameDal = "";
        string classNameBs = "";
        string schemaName = "";
        string pkName = "";
        string pkNamePascalCase = "";
        string pkType = "";



        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";

        public BsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)
        {
            utils = new Utils(pDatabaseHelper);

        }
        Utils utils = null;


        public void Render(IOutput output
            , IContainer container)
        {
           
            List<DatabaseAbbreviations> listDatabaseAbbreviations = null;

            


            output.tabLevel = 0;
            IDatabase database = container.Database;
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            classNameDal = classNameTypeLibrary + "Dal";
            classNameBs = classNameTypeLibrary + "Bs";

            schemaName = utils.GetPascalCase(container.Schema);

            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs";
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal";

            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                 baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
                 baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;
            }

            pkType = utils.FindPrimaryKeyType(container);
            pkName = utils.FindPrimaryKeyColumnName(container);
            pkNamePascalCase = utils.GetPascalCase(pkName);


            WriteUsings(output, schemaName, baseNameSpace, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
            output.increaseTab();
            AtStartCurlyBraceletIncreaseTab(output);
            classWrite(output, classNameBs, classNameDal, classNameTypeLibrary);
            AtStartCurlyBracelet(output);
            OverrideDatabaseNameWrite(output, container);

            if (container is ITable && (!string.IsNullOrEmpty(pkName)))
            {
                Write_DeleteCommmandWithPK(output, container);

                QueryByPkNameWrite(output, container, classNameTypeLibrary, pkType, pkNamePascalCase);
            }
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForBsGenerated(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForBs(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders); 
            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();

            if (!File.Exists(outputFullFileName))
            {
                WriteUsings(output, schemaName,baseNameSpace, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
                AtStartCurlyBraceletIncreaseTab(output);
                classWrite(output, classNameBs, classNameDal, classNameTypeLibrary);
                AtStartCurlyBraceletIncreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();
            }
        }

        private void OverrideDatabaseNameWrite(IOutput output, IContainer container)
        {
            if(CodeGenerationConfig.UseMultipleDatabaseNames)
            {
                output.autoTabLn("public override string DatabaseName");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("get");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionName));
                AtEndCurlyBraceletDecreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
            }
        }


        private static void QueryByPkNameWrite(IOutput output, IContainer container, string classNameTypeLibrary, string pkType, string pkName)
        {
            ITable table = container as ITable;
            string variableName = "p" + pkName;
            if (table != null)
            {
                if (table.PrimaryKeyColumnCount == 1)
                {

                    string classLine = "public " + classNameTypeLibrary + " QueryBy"
                                    + pkName + "(" + pkType
                                    + " " + variableName +  ")";
                    output.autoTabLn(classLine);
                    output.autoTabLn("{");
                    output.increaseTab();
                    output.autoTabLn("return dal.QueryBy" + pkName + "("+ variableName + ");");
                    output.decreaseTab();
                    output.autoTabLn("}");
                }
            }
        }

        private void Write_DeleteCommmandWithPK(IOutput output, IContainer container)
        {
            ITable table = container as ITable;
            if (table != null)
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public void Delete({0} p{1})", pkType, pkPropertyName));
                    AtStartCurlyBraceletIncreaseTab(output);
                    // output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));

                    output.autoTabLn(string.Format("dal.Delete( p{0});",pkPropertyName));
                    AtEndCurlyBraceletDecreaseTab(output);
                }
            }

        }

        protected abstract void classWrite(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary);

        protected abstract void WriteUsingsDatabaseSpecific(IOutput output);

        public void WriteUsings(IOutput output, string schemaName, string baseNameSpace, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema, string baseNameSpaceDalWithSchema)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            WriteUsingsDatabaseSpecific(output);
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTabLn(";");
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                output.autoTab("using ");
                output.autoTab(baseNameSpaceTypeLibrary);
                output.autoTab(".");
                output.autoTab(schemaName);
                output.autoTabLn(";");
                output.autoTab("using ");
                output.autoTab(baseNameSpaceDalWithSchema);
                output.autoTabLn(";");
            }
            else
            {
                output.autoTab("using ");
                output.autoTab(baseNameSpace + ".Dal");
                output.autoTabLn(";");
            }
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                output.autoTab(baseNameSpaceBsWithSchema);
            }
            else
            {
                output.autoTab(baseNameSpace + ".Bs");
            }
            output.autoTabLn("");
        }




    }




}



