﻿using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers.Generators
{
    public class TypeLibraryGenerator : BaseGenerator
    {
        public TypeLibraryGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)
        {
            utils = new Utils(pCodeGenerationConfig);
        }
        Utils utils = null;

        protected string baseNameSpaceTypeLibrary;

        public void Render(IContainer container)
        {


            output.Clear();
            output.TabLevel = 0;
            SetFields(container);

            Create_GeneratedClassFile(container);

            if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
            {
                Create_NormalClassFile();
            }


        }

        private void Create_GeneratedClassFile(IContainer container)
        {
            Write_UsingNamespaces();

            Write_Namespacestart();

            Write_ClassName(container);



            Write_MemberVariables(container);

            Write_Properties(container);

            Write_ShallowCopy(container);

            Write_ColumnNames(container);


            output.writeLine("");


            Write_ClassEndCurlyBracelet();
            Write_NamespaceEndCurlyBracelet();

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
        }

        private void SetFields(IContainer container)
        {
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            className = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            schemaName = utils.GetPascalCase(container.Schema);
            classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }

            outputFullFileName = utils.FileUtilsHelper.getBaseNameForTypeLibrary(CodeGenerationConfig, schemaName, className, CodeGenerationConfig.UseSchemaNameInFolders);
            outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForTypeLibraryGenerated(CodeGenerationConfig, schemaName, className, CodeGenerationConfig.UseSchemaNameInFolders);
        }

        private void Create_NormalClassFile()
        {
            output.Clear();
            output.TabLevel = 0;
            Write_UsingNamespaces();
            Write_Namespacestart();
            output.IncreaseTab();
            string classNameValidation = className + "Validation";
            Write_NormalClassLines(className, classNameValidation);
            Write_ValidationClass(classNameValidation);
            AtEndCurlyBraceletDecreaseTab();
            output.Save(outputFullFileName, CodeGenerationConfig.GenerateNormalClassAgain);
            output.Clear();
        }

        protected void Write_NormalClassLines(string className, string classNameValidation)
        {
            string metadataAttribute = string.Format("[MetadataType(typeof({0}))]",classNameValidation);
            output.AutoTabLine(metadataAttribute);
            output.AutoTab("public partial class ");
            output.AutoTabLine(className);
            AtStartCurlyBraceletIncreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }
        protected void Write_ValidationClass(string classNameValidation)
        {
            output.AutoTab("public class ");
            output.AutoTabLine(classNameValidation);
            AtStartCurlyBraceletIncreaseTab();
            string mainArticleHelpImage = "http://weblogs.asp.net/blogs/scottgu/image_5F336E46.png";
            string mainArticleUrl  = "http://weblogs.asp.net/scottgu/archive/2010/01/15/asp-net-mvc-2-model-validation.aspx";
            string msDataAnnotationsHelpUrl = "http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx";

            if (CodeGenerationConfig.GenerateNormalClassValidationExamples)
            {
                output.AutoTabLine("// For Usage of Validation codes, see the following links: ");
                output.AutoTabLine("// " + mainArticleUrl);
                output.AutoTabLine("// " + mainArticleHelpImage);
                output.AutoTabLine("// " + msDataAnnotationsHelpUrl);
                output.AutoTabLine("// Examples)");
                output.AutoTabLine("// [DataType(DataType.EmailAddress)]");
                output.AutoTabLine("// public string email  { get; set; }");
                output.AutoTabLine("");
                output.AutoTabLine("// [DataType(DataType.Url)]");
                output.AutoTabLine("// public string homePageUrl  { get; set; }");
                output.AutoTabLine("");
                output.AutoTabLine("// [Range(18,65,ErrorMessage=\"Only ages between 18 and 65 could apply\")");
                output.AutoTabLine("// public int Age { get; set; }");
                output.AutoTabLine("");
            }
            AtEndCurlyBraceletDecreaseTab();
        }




        protected virtual void Write_UsingNamespaces()
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.AutoTabLine("using System;");
                output.AutoTabLine("using System.Data;");
                output.AutoTabLine("using System.Text;");
                output.AutoTabLine("using System.Configuration;");
                output.AutoTabLine("using System.Diagnostics;");
                output.AutoTabLine("using System.Xml.Serialization;");
                output.AutoTabLine("using System.Collections.Generic;");
                output.AutoTabLine("using Karkas.Core.DataUtil.BaseClasses;");
                output.AutoTabLine("using System.ComponentModel.DataAnnotations;");
                output.AutoTabLine("");
            }
        }

        private void Write_Namespacestart()
        {

            output.AutoTab("namespace ");
            output.AutoTabLine(classNameSpace);
            output.write("");
            AtStartCurlyBraceletIncreaseTab();
        }

        private void Write_ClassName(IContainer container)
        {
            output.IncreaseTab();
            output.AutoTabLine("[Serializable]");
            DebuggerDisplayWrite(output, container);
            output.AutoTab("public partial class ");
            output.AutoTab(className + ": BaseTypeLibrary");
            output.writeLine("");
            AtStartCurlyBraceletIncreaseTab();

        }

        private void DebuggerDisplayWrite(IOutput output, IContainer container)
        {
            if (container is ITable)
            {
                string sentence = "";
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsInPrimaryKey || column.IsAutoKey || column.IsInForeignKey)
                    {
                        sentence += utils.getPropertyVariableName(column) + " = {" + utils.getPropertyVariableName(column) + "}";
                    }

                }
                output.AutoTabLine(string.Format("[DebuggerDisplay(\"{0}\")]", sentence));
            }

        }




        private void Write_ColumnNames(IContainer container)
        {
            output.AutoTabLine("public class ColumnNames");
            AtStartCurlyBraceletIncreaseTab();
            string columnName = "";
            foreach (IColumn column in container.Columns)
            {
                columnName = utils.getPropertyVariableName(column);
                string sentence = string.Format("public const string {0} = \"{1}\";", columnName, column.Name);
                output.AutoTabLine(sentence);
            }
            AtEndCurlyBraceletDecreaseTab();

        }

        private void Write_Properties(IContainer container)
        {
            foreach (IColumn column in container.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);

                AddDataAnnotations(output, column);
                output.AutoTabLine("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.AutoTabLine(string.Format("public {0} {1}", utils.GetLanguageType(column), propertyVariableName));
                output.AutoTabLine("{");
                output.IncreaseTab();
                output.AutoTabLine("[DebuggerStepThrough]");
                output.AutoTabLine("get");
                output.AutoTabLine("{");
                output.AutoTabLine(string.Format("\treturn {0};", memberVariableName));
                output.AutoTabLine("}");
                output.AutoTabLine("[DebuggerStepThrough]");
                output.AutoTabLine("set");
                output.AutoTabLine("{");
                output.IncreaseTab();
                output.AutoTabLine(string.Format("if ((this.RowState == DataRowState.Unchanged) && ({0}!= value))", memberVariableName));
                output.AutoTabLine("{");
                output.AutoTabLine("\tthis.RowState = DataRowState.Modified;");
                output.AutoTabLine("}");
                output.AutoTabLine(string.Format("{0} = value;", memberVariableName));
                output.DecreaseTab();
                output.AutoTabLine("}");
                output.DecreaseTab();
                output.AutoTabLine("}");
                output.writeLine("");
            }
        }

        private const int CHARACTER_MAX_LENGTH_IN_DATABASE = 8000;
        private static void AddDataAnnotations(IOutput output, IColumn column)
        {
            if (column.IsInPrimaryKey)
            {
                output.AutoTabLine("[Key]");
            }
            if (column.isStringType && column.CharacterMaxLength < CHARACTER_MAX_LENGTH_IN_DATABASE && column.CharacterMaxLength > 0)
            {
                string annotationString = string.Format("[StringLength({0})]", column.CharacterMaxLength);
                output.AutoTabLine(annotationString);
            }
            if (column.IsRequired)
            {
                output.AutoTabLine("[Required]");
            }
            //if (!column.IsNullable && !column.isNumericType)
            //{
            //    output.autoTabLn("[Required]");
            //}

        }

        // TODO Do I need it? Think. If not remove it. Was is for i18n?
        private void PropertiesAsStringWrite(IOutput output, IContainer container)
        {
            foreach (IColumn column in container.Columns)
            {
                string tipi = utils.GetLanguageType(column);
                if (tipi == "string")
                {
                    continue;
                }
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);
                output.AutoTabLine("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.AutoTabLine("[XmlIgnore, SoapIgnore]");
                output.AutoTabLine("[ScaffoldColumn(false)]");
                output.AutoTabLine(string.Format("public string {0}AsString", propertyVariableName));
                output.AutoTabLine("{");
                output.IncreaseTab();
                output.AutoTabLine("[DebuggerStepThrough]");
                output.AutoTabLine("get");
                output.AutoTabLine("{");
                Write_ReturnToStringValue(column, output, memberVariableName);
                output.AutoTabLine("}");
                output.AutoTabLine("[DebuggerStepThrough]");
                output.AutoTabLine("set");
                output.AutoTabLine("{");
                output.IncreaseTab();
                string[] sentenceList = utils.GetConvertToSyntax(column, propertyVariableName);
                foreach (string str in sentenceList)
                {
                    output.AutoTabLine(str);
                }
                output.DecreaseTab();
                output.AutoTabLine("}");
                output.DecreaseTab();
                output.AutoTabLine("}");
                output.writeLine("");
            }
        }

        private void Write_ReturnToStringValue(IColumn column, IOutput output, string memberVariableName)
        {
            if (utils.IsColumnNullable(column))
            {
                output.AutoTabLine(string.Format("\t return {0} != null ? {0}.ToString() : \"\"; ", memberVariableName));
            }
            else
            {
                output.AutoTabLine(string.Format("\t return {0}.ToString(); ", memberVariableName));
            }
        }



        private void Write_ShallowCopy(IContainer container)
        {
            output.AutoTabLine(string.Format("public {0} ShallowCopy()", className));
            output.AutoTabLine("{");
            output.IncreaseTab();
            output.AutoTabLine(string.Format("{0} obj = new {0}();", className));
            foreach (IColumn column in container.Columns)
            {
                output.AutoTabLine(string.Format("obj.{0} = {0};", utils.GetCamelCase(column.Name)));
            }
            output.AutoTabLine("return obj;");
            output.DecreaseTab();
            output.AutoTabLine("}");
            output.AutoTabLine("");

        }


        private void Write_MemberVariables(IContainer container)
        {
            foreach (IColumn column in container.Columns)
            {
                output.AutoTabLine(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.writeLine("");
        }




    }




}




