using System;
using System.Collections;
using Karkas.CodeGenerationHelper;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;
using System.Collections.Generic;
using Karkas.CodeGenerationHelper.BaseClasses;

namespace Karkas.CodeGenerationHelper.Generators
{
    public class BsGenerator : BaseGenerator
    {
        string classNameTypeLibrary = "";
        string classNameDal = "";
        string classNameBs = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";
        string pkAdi = "";
        string pkAdiPascalCase = "";
        string pkType = "";



        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";
        string baseNameSpaceDal = "";
        string baseNameSpaceBs = "";

        public BsGenerator(IDatabase databaseHelper)
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
           
            output.tabLevel = 0;
            IDatabase database = container.Database;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";
            baseNameSpaceDal = baseNameSpace + ".Dal";
            baseNameSpaceBs = baseNameSpace + ".Bs";

            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            classNameDal = classNameTypeLibrary + "Dal";
            classNameBs = classNameTypeLibrary + "Bs";

            schemaName = utils.GetPascalCase(container.Schema);
            classNameSpace = baseNameSpace + "." + schemaName;
            bool identityVarmi;
            string pkcumlesi = "";

            string baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
            string baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;

            pkType = utils.PrimaryKeyTipiniBul(container);
            pkAdi = utils.PrimaryKeyAdiniBul(container);
            pkAdiPascalCase = utils.GetPascalCase(pkAdi);


            usingNamespaceleriYaz(output, schemaName, baseNameSpace, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
            output.increaseTab();
            BaslangicSusluParentezVeTabArtir(output);
            classYaz(output, classNameBs, classNameDal, classNameTypeLibrary);
            BaslangicSusluParentez(output);
            OverrideDatabaseNameYaz(output, container);

            if (container is ITable && (!string.IsNullOrEmpty(pkAdi)))
            {
                SilKomutuYazPkIle(output, container);

                sorgulaPkAdiIleYaz(output, container, classNameTypeLibrary, pkType, pkAdiPascalCase);
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForBsGenerated(database, schemaName, classNameTypeLibrary,semaIsminiDizinlerdeKullan);
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForBs(database, schemaName, classNameTypeLibrary, semaIsminiDizinlerdeKullan); 
            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();

            if (!File.Exists(outputFullFileName))
            {
                usingNamespaceleriYaz(output, schemaName,baseNameSpace, baseNameSpaceTypeLibrary, baseNameSpaceBsWithSchema, baseNameSpaceDalWithSchema);
                BaslangicSusluParentezVeTabArtir(output);
                classYaz(output, classNameBs, classNameDal, classNameTypeLibrary);
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEncoding(outputFullFileName, "o", "utf8");
                output.clear();
            }
        }

        private void OverrideDatabaseNameYaz(IOutput output, IContainer container)
        {
            output.autoTabLn("public override string DatabaseName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", container.Database.ConnectionName));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private static void sorgulaPkAdiIleYaz(IOutput output, IContainer container, string classNameTypeLibrary, string pkType, string pkAdi)
        {
            ITable table = container as ITable;
            if (table != null)
            {
                if (table.PrimaryKeyColumnCount == 1)
                {

                    string classSatiri = "public " + classNameTypeLibrary + " Sorgula"
                                    + pkAdi + "Ile(" + pkType
                                    + " p1)";
                    output.autoTabLn(classSatiri);
                    output.autoTabLn("{");
                    output.increaseTab();
                    output.autoTabLn("return dal.Sorgula" + pkAdi + "Ile(p1);");
                    output.decreaseTab();
                    output.autoTabLn("}");
                }
            }
        }

        private void SilKomutuYazPkIle(IOutput output, IContainer container)
        {
            ITable table = container as ITable;
            if (table != null)
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.PrimaryKeyColumnTekIseBul(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public void Sil({0} p{1})", pkType, pkPropertyName));
                    BaslangicSusluParentezVeTabArtir(output);
                    // output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));

                    output.autoTabLn(string.Format("dal.Sil( p{0});",pkPropertyName));
                    BitisSusluParentezVeTabAzalt(output);
                }
            }

        }

        private static void classYaz(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
            output.writeLine(classNameDal + ">");
        }

        public void usingNamespaceleriYaz(IOutput output, string schemaName, string baseNameSpace, string baseNameSpaceTypeLibrary, string baseNameSpaceBsWithSchema, string baseNameSpaceDalWithSchema)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTabLn(";");
            if (!string.IsNullOrWhiteSpace(schemaName))
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



