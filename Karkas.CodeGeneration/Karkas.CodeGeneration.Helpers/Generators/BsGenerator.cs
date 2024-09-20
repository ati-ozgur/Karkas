﻿using System;
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
        protected string baseNameSpace = "";
        protected string baseNameSpaceTypeLibrary = "";

        protected string baseNameSpaceBsWithSchema;
        protected string baseNameSpaceDalWithSchema;

        protected bool identityExists;

        protected string identityType;

        protected string outputFullFileNameGenerated;
        protected string outputFullFileName;


        public BsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)
        {
            utils = new Utils(pDatabaseHelper, pCodeGenerationConfig);
        }
        Utils utils = null;


        public void Render(IOutput output
            , IContainer container)
        {

            List<DatabaseAbbreviations> listDatabaseAbbreviations = null;




            output.tabLevel = 0;
            IDatabase database = container.Database;

            SetFields(container, listDatabaseAbbreviations);

            Write_Usings(output);
            Write_NamespaceStart(output);
            AtStartCurlyBraceletIncreaseTab(output);

            Write_ClassGenerated(output, classNameBs, classNameDal, classNameTypeLibrary, identityExists, identityType);
            AtStartCurlyBracelet(output);
            Write_OverrideDatabaseName(output, container);

            if (container is ITable && (!string.IsNullOrEmpty(pkName)))
            {
                Write_DeleteCommandWithPK(output, container);

                Write_QueryByPkName(output, container, classNameTypeLibrary, pkType, pkNamePascalCase);
            }
            AtEndCurlyBraceletDecreaseTab(output);
            Write_NamespaceEndCurlyBracelet(output);

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();

            Write_MainClass(output, outputFullFileName);
        }

        private void SetFields(IContainer container, List<DatabaseAbbreviations> listDatabaseAbbreviations)
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

        private void Write_MainClass(IOutput output, string outputFullFileName)
        {
            if (!File.Exists(outputFullFileName))
            {
                Write_Usings(output);
                Write_NamespaceStart(output);
                AtStartCurlyBraceletIncreaseTab(output);
                Write_ClassNormal(output, classNameBs, classNameDal, classNameTypeLibrary);
                AtStartCurlyBraceletIncreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                Write_NamespaceEndCurlyBracelet(output);
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();
            }
        }

        private void Write_NamespaceEndCurlyBracelet(IOutput output)
        {
            AtEndCurlyBraceletDecreaseTab(output);
        }

        private void Write_OverrideDatabaseName(IOutput output, IContainer container)
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


        private static void Write_QueryByPkName(IOutput output, IContainer container, string classNameTypeLibrary, string pkType, string pkName)
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

        private void Write_DeleteCommandWithPK(IOutput output, IContainer container)
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

        protected abstract void Write_ClassNormal(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary);
        protected abstract void Write_ClassGenerated(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary, bool identityExists, string identityType);

        protected abstract void Write_UsingsDatabaseSpecific(IOutput output);

        public void Write_Usings(IOutput output)
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.autoTabLn("");
                output.autoTabLn("using System;");
                output.autoTabLn("using System.Collections.Generic;");
                output.autoTabLn("using System.Data;");
                Write_UsingsDatabaseSpecific(output);
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

        private void Write_NamespaceStart(IOutput output)
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
            output.increaseTab();
        }
    }




}



