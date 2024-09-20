using System;
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

        public void Render(IOutput output
            , IContainer container)
        {

            List<DatabaseAbbreviations> listDatabaseAbbreviations = null;


            IDatabase database = container.Database;
            output.tabLevel = 0;
            string baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            string schemaName = utils.GetPascalCase(container.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }

            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForTypeLibrary(CodeGenerationConfig, schemaName, className, CodeGenerationConfig.UseSchemaNameInFolders);
            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForTypeLibraryGenerated(CodeGenerationConfig, schemaName, className, CodeGenerationConfig.UseSchemaNameInFolders);


            Write_UsingNamespaces(output, classNameSpace);

            Write_Namespacestart(output, classNameSpace);

            Write_ClassName(output, className, container);

            output.autoTabLn("{");

            Write_MemberVariables(output, container);

            Write_Properties(output, container);

            Write_ShallowCopy(output, container, className);

            Write_ColumnNames(output, container, className);


            output.writeLine("");

            AtEndCurlyBraceletDecreaseTab(output);
            Write_NamespaceEndCurlyBracelet(output);

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();




            if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
            {
                generateMainClassFile(output, database, className, classNameSpace, outputFullFileName);
            }


        }

        private void generateMainClassFile(IOutput output, IDatabase database,string className, string classNameSpace, string outputFullFileName)
        {
            Write_UsingNamespaces(output, classNameSpace);
            Write_Namespacestart(output, classNameSpace);
            //output.increaseTab();
            string classNameValidation = className + "Validation";
            writeMainClass(output, className, classNameValidation);
            writeValidationClass(output, database, className, classNameValidation);
            AtEndCurlyBraceletDecreaseTab(output);
            output.Save(outputFullFileName, CodeGenerationConfig.GenerateNormalClassAgain);
            output.Clear();
        }

        private void writeMainClass(IOutput output, string className, string classNameValidation)
        {
            string metadataAttribute = string.Format("[MetadataType(typeof({0}))]",classNameValidation);
            output.autoTabLn(metadataAttribute);
            output.autoTab("public partial class ");
            output.autoTabLn(className);
            AtStartCurlyBraceletIncreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }
        private void writeValidationClass(IOutput output, IDatabase database, string className, string classNameValidation)
        {
            output.autoTab("public class ");
            output.autoTabLn(classNameValidation);
            AtStartCurlyBraceletIncreaseTab(output);
            string mainArticleHelpImage = "http://weblogs.asp.net/blogs/scottgu/image_5F336E46.png";
            string mainArticleUrl  = "http://weblogs.asp.net/scottgu/archive/2010/01/15/asp-net-mvc-2-model-validation.aspx";
            string msDataAnnotationsHelpUrl = "http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx";

            if (CodeGenerationConfig.GenerateNormalClassValidationExamples)
            {
                output.autoTabLn("// For Usage of Validation codes, see the following links: ");
                output.autoTabLn("// " + mainArticleUrl);
                output.autoTabLn("// " + mainArticleHelpImage);
                output.autoTabLn("// " + msDataAnnotationsHelpUrl);
                output.autoTabLn("// Examples)");
                output.autoTabLn("// [DataType(DataType.EmailAddress)]");
                output.autoTabLn("// public string email  { get; set; }");
                output.autoTabLn("");
                output.autoTabLn("// [DataType(DataType.Url)]");
                output.autoTabLn("// public string homePageUrl  { get; set; }");
                output.autoTabLn("");
                output.autoTabLn("// [Range(18,65,ErrorMessage=\"Only ages between 18 and 65 could apply\")");
                output.autoTabLn("// public int Age { get; set; }");
                output.autoTabLn("");
            }
            AtEndCurlyBraceletDecreaseTab(output);
        }




        protected virtual void Write_UsingNamespaces(IOutput output, string classNameSpace)
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.autoTabLn("using System;");
                output.autoTabLn("using System.Data;");
                output.autoTabLn("using System.Text;");
                output.autoTabLn("using System.Configuration;");
                output.autoTabLn("using System.Diagnostics;");
                output.autoTabLn("using System.Xml.Serialization;");
                output.autoTabLn("using System.Collections.Generic;");
                output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
                output.autoTabLn("using System.ComponentModel.DataAnnotations;");
                output.autoTabLn("");
            }
        }

        private void Write_Namespacestart(IOutput output, string classNameSpace)
        {

            output.autoTab("namespace ");
            output.autoTabLn(classNameSpace);
            output.write("");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        private void Write_ClassName(IOutput output, string className, IContainer container)
        {
            output.increaseTab();
            output.autoTabLn("[Serializable]");
            DebuggerDisplayWrite(output, container);
            output.autoTab("public partial class ");
            output.autoTab(className + ": BaseTypeLibrary");
            output.writeLine("");


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
                output.autoTabLn(string.Format("[DebuggerDisplay(\"{0}\")]", sentence));
            }

        }




        private void Write_ColumnNames(IOutput output, IContainer container, string className)
        {
            output.autoTabLn("public class ColumnNames");
            AtStartCurlyBraceletIncreaseTab(output);
            string columnName = "";
            foreach (IColumn column in container.Columns)
            {
                columnName = utils.getPropertyVariableName(column);
                string sentence = string.Format("public const string {0} = \"{1}\";", columnName, column.Name);
                output.autoTabLn(sentence);
            }
            AtEndCurlyBraceletDecreaseTab(output);

        }

        private void Write_Properties(IOutput output, IContainer container)
        {
            output.increaseTab();
            foreach (IColumn column in container.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);

                AddDataAnnotations(output, column);
                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn(string.Format("public {0} {1}", utils.GetLanguageType(column), propertyVariableName));
                output.autoTabLn("{");
                output.increaseTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                output.autoTabLn(string.Format("\treturn {0};", memberVariableName));
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.increaseTab();
                output.autoTabLn(string.Format("if ((this.RowState == DataRowState.Unchanged) && ({0}!= value))", memberVariableName));
                output.autoTabLn("{");
                output.autoTabLn("\tthis.RowState = DataRowState.Modified;");
                output.autoTabLn("}");
                output.autoTabLn(string.Format("{0} = value;", memberVariableName));
                output.decreaseTab();
                output.autoTabLn("}");
                output.decreaseTab();
                output.autoTabLn("}");
                output.writeLine("");
            }
            output.decreaseTab();
        }

        private const int CHARACTER_MAX_LENGTH_IN_DATABASE = 8000;
        private static void AddDataAnnotations(IOutput output, IColumn column)
        {
            if (column.IsInPrimaryKey)
            {
                output.autoTabLn("[Key]");
            }
            if (column.isStringType && column.CharacterMaxLength < CHARACTER_MAX_LENGTH_IN_DATABASE && column.CharacterMaxLength > 0)
            {
                string annotationString = string.Format("[StringLength({0})]", column.CharacterMaxLength);
                output.autoTabLn(annotationString);
            }
            if (column.IsRequired)
            {
                output.autoTabLn("[Required]");
            }
            //if (!column.IsNullable && !column.isNumericType)
            //{
            //    output.autoTabLn("[Required]");
            //}

        }

        // TODO Do I need it? Think. If not remove it. Was is for i18n?
        private void PropertiesAsStringWrite(IOutput output, IContainer container)
        {
            output.increaseTab();
            foreach (IColumn column in container.Columns)
            {
                string tipi = utils.GetLanguageType(column);
                if (tipi == "string")
                {
                    continue;
                }
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);
                output.autoTabLn("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                output.autoTabLn("[XmlIgnore, SoapIgnore]");
                output.autoTabLn("[ScaffoldColumn(false)]");
                output.autoTabLn(string.Format("public string {0}AsString", propertyVariableName));
                output.autoTabLn("{");
                output.increaseTab();
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("get");
                output.autoTabLn("{");
                Write_ReturnToStringValue(column, output, memberVariableName);
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.increaseTab();
                string[] sentenceList = utils.GetConvertToSyntax(column, propertyVariableName);
                foreach (string str in sentenceList)
                {
                    output.autoTabLn(str);
                }
                output.decreaseTab();
                output.autoTabLn("}");
                output.decreaseTab();
                output.autoTabLn("}");
                output.writeLine("");
            }
            output.decreaseTab();
        }

        private void Write_ReturnToStringValue(IColumn column, IOutput output, string memberVariableName)
        {
            if (utils.IsColumnNullable(column))
            {
                output.autoTabLn(string.Format("\t return {0} != null ? {0}.ToString() : \"\"; ", memberVariableName));
            }
            else
            {
                output.autoTabLn(string.Format("\t return {0}.ToString(); ", memberVariableName));
            }
        }



        private void Write_ShallowCopy(IOutput output, IContainer container, string pTypeName)
        {
            output.increaseTab();
            output.autoTabLn(string.Format("public {0} ShallowCopy()", pTypeName));
            output.autoTabLn("{");
            output.increaseTab();
            output.autoTabLn(string.Format("{0} obj = new {0}();", pTypeName));
            foreach (IColumn column in container.Columns)
            {
                output.autoTabLn(string.Format("obj.{0} = {0};", utils.GetCamelCase(column.Name)));
            }
            output.autoTabLn("return obj;");
            output.decreaseTab();
            output.autoTabLn("}");
            output.autoTabLn("");

        }


        private void Write_MemberVariables(IOutput output, IContainer container)
        {
            output.increaseTab();
            foreach (IColumn column in container.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decreaseTab();
            output.writeLine("");
        }




    }




}




