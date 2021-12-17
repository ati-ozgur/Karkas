using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class TypeLibraryGenerator : BaseGenerator
    {
        public TypeLibraryGenerator(IDatabase databaseHelper)
        {
            utils = new Utils(databaseHelper);

        }
        Utils utils = null;

        public void Render(IOutput output
            , IContainer container
            , bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {

            IDatabase database = container.Database;
            output.tabLevel = 0;

            string baseNameSpace = database.ProjectNameSpace;
            string baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            string className = utils.getClassNameForTypeLibrary(container.Name,listDatabaseAbbreviations);
            string schemaName = utils.GetPascalCase(container.Schema);
            string classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }
            
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForTypeLibrary(database, schemaName, className,semaIsminiDizinlerdeKullan); 
            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForTypeLibraryGenerated(database, schemaName,className, semaIsminiDizinlerdeKullan);
            //output.setPreserveSource(outputFullFileNameGenerated, "//::", ":://");


            usingNamespaceleriYaz(output, classNameSpace);

            ClassIsmiYaz(output, className, container);

            output.autoTabLn("{");

            MemberVariablesYaz(output, container);

            PropertiesYaz(output, container);

            ShallowCopyYaz(output, container, className);

            PropertyIsimleriYaz(output, container, className);


            output.writeLine("");

            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();




            if (!File.Exists(outputFullFileName) || database.AnaSinifiTekrarUret  )
            {
                generateMainClassFile(output,  database, className, classNameSpace, outputFullFileName);
            }


        }

        private void generateMainClassFile(IOutput output, IDatabase database,string className, string classNameSpace, string outputFullFileName)
        {
            usingNamespaceleriYaz(output, classNameSpace);
            //output.increaseTab();
            string classNameValidation = className + "Validation";
            writeMainClass(output, className, classNameValidation);
            writeValidationClass(output, database, className, classNameValidation);
            BitisSusluParentezVeTabAzalt(output);
            output.save(outputFullFileName, database.AnaSinifiTekrarUret);
            output.clear();
        }

        private void writeMainClass(IOutput output, string className, string classNameValidation)
        {
            string metadataAttribute = string.Format("[MetadataType(typeof({0}))]",classNameValidation);
            output.autoTabLn(metadataAttribute);
            output.autoTab("public partial class ");
            output.autoTabLn(className);
            BaslangicSusluParentezVeTabArtir(output);
            BitisSusluParentezVeTabAzalt(output);
        }
        private void writeValidationClass(IOutput output, IDatabase database, string className, string classNameValidation)
        {
            output.autoTab("public class ");
            output.autoTabLn(classNameValidation);
            BaslangicSusluParentezVeTabArtir(output);
            string mainArticleHelpImage = "http://weblogs.asp.net/blogs/scottgu/image_5F336E46.png";
            string mainArticleUrl  = "http://weblogs.asp.net/scottgu/archive/2010/01/15/asp-net-mvc-2-model-validation.aspx";
            string msDataAnnotationsHelpUrl = "http://msdn.microsoft.com/en-us/library/system.componentmodel.dataannotations.aspx";

            if (database.AnaSinifOnaylamaOrnekleriUret)
            {
                output.autoTabLn("// Onaylama kodlarının kullanımı için aşağıdaki makaleye bakabilirsiniz");
                output.autoTabLn("// " + mainArticleUrl);
                output.autoTabLn("// " + mainArticleHelpImage);
                output.autoTabLn("// " + msDataAnnotationsHelpUrl);
                output.autoTabLn("// Örnekler)");
                output.autoTabLn("// [DataType(DataType.EmailAddress)]");
                output.autoTabLn("// public string eposta  { get; set; }");
                output.autoTabLn("");
                output.autoTabLn("// [DataType(DataType.Url)]");
                output.autoTabLn("// public string homePageUrl  { get; set; }");
                output.autoTabLn("");
                output.autoTabLn("// [Range(18,65,ErrorMessage=\"18 ve 65 yas aralığındakiler başvurabilir\")");
                output.autoTabLn("// public int Yasi { get; set; }");
                output.autoTabLn("");
            }
            BitisSusluParentezVeTabAzalt(output);
        }




        protected virtual void usingNamespaceleriYaz(IOutput output, string classNameSpace)
        {
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using System.Configuration;");
            output.autoTabLn("using System.Diagnostics;");
            output.autoTabLn("using System.Xml.Serialization;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using Karkas.Core.TypeLibrary;");
            output.autoTabLn("using System.ComponentModel.DataAnnotations;");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTabLn(classNameSpace);
            output.write("");
            BaslangicSusluParentezVeTabArtir(output);
        }

        private void ClassIsmiYaz(IOutput output, string className, IContainer container)
        {
            output.increaseTab();
            output.autoTabLn("[Serializable]");
            DebuggerDisplayYaz(output, container);
            output.autoTab("public partial class ");
            output.autoTab(className + ": BaseTypeLibrary");
            output.writeLine("");


        }

        private void DebuggerDisplayYaz(IOutput output, IContainer container)
        {
            if (container is ITable)
            {
                string yazi = "";
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsInPrimaryKey || column.IsAutoKey || column.IsInForeignKey)
                    {
                        yazi += utils.getPropertyVariableName(column) + " = {" + utils.getPropertyVariableName(column) + "}";
                    }

                }
                output.autoTabLn(string.Format("[DebuggerDisplay(\"{0}\")]", yazi));
            }

        }




        private void PropertyIsimleriYaz(IOutput output, IContainer container, string className)
        {
            output.autoTabLn("public class PropertyIsimleri");
            BaslangicSusluParentezVeTabArtir(output);
            string propertyName = "";
            foreach (IColumn column in container.Columns)
            {
                propertyName = utils.getPropertyVariableName(column);
                string yazi = string.Format("public const string {0} = \"{1}\";", propertyName, column.Name);
                output.autoTabLn(yazi);
            }
            BitisSusluParentezVeTabAzalt(output);

        }

        private void PropertiesYaz(IOutput output, IContainer container)
        {
            output.increaseTab();
            foreach (IColumn column in container.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.getPropertyVariableName(column);

                DataAnnotationEkle(output, column);
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
        private static void DataAnnotationEkle(IOutput output, IColumn column)
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

        private void PropertiesAsStringYaz(IOutput output, IContainer container)
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
                ToStringDegeriDondur(column, output, memberVariableName);
                output.autoTabLn("}");
                output.autoTabLn("[DebuggerStepThrough]");
                output.autoTabLn("set");
                output.autoTabLn("{");
                output.increaseTab();
                string[] yaziListesi = utils.GetConvertToSyntax(column, propertyVariableName);
                foreach (string str in yaziListesi)
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

        private void ToStringDegeriDondur(IColumn column, IOutput output, string memberVariableName)
        {
            if (utils.ColumnNullDegeriAlabilirMi(column))
            {
                output.autoTabLn(string.Format("\t return {0} != null ? {0}.ToString() : \"\"; ", memberVariableName));
            }
            else
            {
                output.autoTabLn(string.Format("\t return {0}.ToString(); ", memberVariableName));
            }
        }



        private void ShallowCopyYaz(IOutput output, IContainer container, string pTypeName)
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


        private void MemberVariablesYaz(IOutput output, IContainer container)
        {
            output.increaseTab();
            foreach (IColumn column in container.Columns)
            {
                output.autoTabLn(String.Format("private {0} {1};", utils.GetLanguageType(column), utils.GetCamelCase(column.Name)));
            }
            output.decreaseTab();
            output.writeLine("");
        }


        private void EtiketIsimleriYaz(IOutput output, IContainer pTable, string pNamespace)
        {
            output.autoTabLn("public static class EtiketIsimleri");
            BaslangicSusluParentezVeTabArtir(output);

            output.autoTabLn(string.Format("const string namespaceVeClass = \"{0}\";", pNamespace));
            foreach (IColumn column in pTable.Columns)
            {
                string memberVariableName = utils.GetCamelCase(column.Name);
                string propertyVariableName = utils.GetPascalCase(column.Name);
                output.autoTabLn("public static string " + propertyVariableName);
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("get");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn(string.Format("string s = ConfigurationManager.AppSettings[namespaceVeClass + \".{0}\"];", propertyVariableName));
                output.autoTabLn("if (s != null)");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("return s;");
                BitisSusluParentezVeTabAzalt(output);
                output.autoTabLn("else");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn(string.Format("return \"{0}\";", propertyVariableName));
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
            }
            BitisSusluParentezVeTabAzalt(output);
        }




    }




}




