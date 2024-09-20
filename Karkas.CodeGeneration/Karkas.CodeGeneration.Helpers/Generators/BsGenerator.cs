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
        protected string classNameTypeLibrary = "";
        protected string classNameDal = "";
        protected string classNameBs = "";
        protected string pkName = "";
        protected string pkNamePascalCase = "";
        protected string pkType = "";
        protected string baseNameSpaceTypeLibrary = "";

        protected string baseNameSpaceBsWithSchema;
        protected string baseNameSpaceDalWithSchema;

        protected bool identityExists;

        protected string identityType;



        public BsGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)
        {
            utils = new Utils(pCodeGenerationConfig);
        }
        Utils utils = null;


        public void Render(IContainer container)
        {




            output.tabLevel = 0;

            SetFields(container);

            Write_ClassGenerated(container);

            Write_ClassNormal();
        }

        private void Write_ClassGenerated( IContainer container)
        {
            Write_Usings();
            Write_NamespaceStart();

            Write_ClassGeneratedDatabaseSpecific();

            AtStartCurlyBraceletIncreaseTab();
            
            Write_OverrideDatabaseName(container);
            if (container is ITable && (!string.IsNullOrEmpty(pkName)))
            {
                Write_DeleteCommandWithPK(container);

                Write_QueryByPkName(container, classNameTypeLibrary, pkType, pkNamePascalCase);
            }
            AtEndCurlyBraceletDecreaseTab();
            Write_NamespaceEndCurlyBracelet();

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
        }

        private void SetFields(IContainer container)
        {
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            classNameDal = classNameTypeLibrary + "Dal";
            classNameBs = classNameTypeLibrary + "Bs";

            schemaName = utils.GetPascalCase(container.Schema);

            baseNameSpaceBsWithSchema = baseNameSpace + ".Bs";
            baseNameSpaceDalWithSchema = baseNameSpace + ".Dal";

            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
                baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;
            }

            pkType = utils.FindPrimaryKeyType(container);
            pkName = utils.FindPrimaryKeyColumnName(container);
            pkNamePascalCase = utils.GetPascalCase(pkName);

            identityExists = utils.IdentityExists(container);
            identityType = utils.GetIdentityType(container);
            outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForBsGenerated(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);
            outputFullFileName = utils.FileUtilsHelper.getBaseNameForBs(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);

        }

        private void Write_ClassNormal()
        {
            if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
            {
                Write_Usings();
                Write_NamespaceStart();
                Write_ClassNormalDatabaseSpecific();
                Write_NamespaceEndCurlyBracelet();
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();
            }
        }



        private void Write_OverrideDatabaseName( IContainer container)
        {
            if(CodeGenerationConfig.UseMultipleDatabaseNames)
            {
                output.autoTabLn("public override string DatabaseName");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("get");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionName));
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();
            }
        }


        private void Write_QueryByPkName( IContainer container, string classNameTypeLibrary, string pkType, string pkName)
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

        private void Write_DeleteCommandWithPK( IContainer container)
        {
            ITable table = container as ITable;
            if (table != null)
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public void Delete({0} p{1})", pkType, pkPropertyName));
                    AtStartCurlyBraceletIncreaseTab();
                    // output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));

                    output.autoTabLn(string.Format("dal.Delete( p{0});",pkPropertyName));
                    AtEndCurlyBraceletDecreaseTab();
                }
            }

        }

        protected virtual void Write_ClassNormalDatabaseSpecific()
        {
            output.autoTab("public partial class ");
            output.writeLine(classNameBs);
            Write_ClassStartCurlyBracelet();
            Write_ClassEndCurlyBracelet();
        }


        protected abstract void Write_ClassGeneratedDatabaseSpecific();

        protected abstract void Write_UsingsDatabaseSpecific();

        public void Write_Usings()
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.autoTabLn("");
                output.autoTabLn("using System;");
                output.autoTabLn("using System.Collections.Generic;");
                output.autoTabLn("using System.Data;");
                Write_UsingsDatabaseSpecific();
                output.autoTabLn("using System.Text;");
                output.autoTabLn("using Karkas.Core.DataUtil;");
                output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
                output.autoTab("using ");
                output.autoTab(baseNameSpaceTypeLibrary);
                output.autoTabLn(";");
            }
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
        }

        private void Write_NamespaceStart()
        {
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
            AtStartCurlyBraceletIncreaseTab();
        }
    }




}



