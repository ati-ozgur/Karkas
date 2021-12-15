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
    public abstract class DalGenerator : BaseGenerator
    {

        string classNameTypeLibrary = "";
        string schemaName = "";
        string classNameSpace = "";
        string memberVariableName = "";
        string propertyVariableName = "";
        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";
        string pkAdi = "";
        string pkAdiPascalCase = "";
        string pkType = "";
        string _identityColumnAdi = "";
        bool _identityVarmi = false;
        string _identityType = "";

        public string getIdentityType(Utils utils, IContainer container)
        {
            return utils.getIdentityType(container);
        }


        public string getIdentityColumnName(Utils utils, IContainer container)
        {
            return utils.getIdentityColumnName(container);
        }


        public bool getIdentityVarmi(Utils utils,IContainer container)
        {
             return utils.IdentityVarMi(container);
        }
        string listeType = "";

        public DalGenerator(IDatabase databaseHelper)
        {
            utils = new Utils(databaseHelper);

        }
        Utils utils = null;



        public string Render(IOutput output
            , IContainer container
            ,bool semaIsminiSorgulardaKullan
            , bool semaIsminiDizinlerdeKullan
            , List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            output.tabLevel = 0;
            IDatabase database = container.Database;
            baseNameSpace = utils.NamespaceIniAlSchemaIle(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkAdi = utils.PrimaryKeyAdiniBul(container);
            pkAdiPascalCase = utils.GetPascalCase(pkAdi);
            
            if (container is ITable && (!((ITable) container).HasPrimaryKey ))
            {
                string uyari = 
                 "Sectiginiz tablolardan " + container.Name  + " icinde Primary Key yoktur. Code Generation (DAL) sadace primaryKey'i olan tablolarda duzgun calisir.";
                throw new Exception(uyari);
            }


            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            schemaName = utils.GetPascalCase(container.Schema);

            string classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }
      
            bool pkGuidMi = utils.PkGuidMi(container);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal";
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                baseNameSpaceDal = baseNameSpaceDal   + "." +schemaName;
            }
            
            

            pkType = utils.PrimaryKeyTipiniBul(container);

            listeType = "List<" + classNameTypeLibrary + ">";

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForDalGenerated(database, schemaName, classNameTypeLibrary,semaIsminiDizinlerdeKullan);
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForDal(database, schemaName, classNameTypeLibrary,semaIsminiDizinlerdeKullan);

            UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);

            ClassYaz(output, classNameTypeLibrary, getIdentityVarmi(utils, container), getIdentityType(utils, container));
            output.autoTabLn("");

            OverrideDatabaseNameYaz(output, container);

            identityKolonDegeriniSetleYaz(output, container);

            SelectCountYaz(output, container, semaIsminiSorgulardaKullan);

            SelectStringYaz(output, container, semaIsminiSorgulardaKullan);

            DeleteStringYaz(output, container, semaIsminiSorgulardaKullan);

            UpdateStringYaz(output, container, semaIsminiSorgulardaKullan, ref pkcumlesi);

            string sorgulardaKullanilanSema = getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan);

            InsertStringYaz(output, container, sorgulardaKullanilanSema);


            SorgulaPkIleGetirYaz(output, container, classNameTypeLibrary,pkAdi, pkAdiPascalCase, pkType);

            IdentityVarMiYaz(output, getIdentityVarmi(utils, container));

            PkGuidMiYaz(output, container);

            PrimaryKeyYaz(output, container);

            SilKomutuYazPkIle(output, classNameTypeLibrary, container);

            ProcessRowYaz(output, container, classNameTypeLibrary);

            InsertCommandParametersAddYaz(output, container, classNameTypeLibrary);
            UpdateCommandParametersAddYaz(output, container, classNameTypeLibrary);
            DeleteCommandParametersAddYaz(output, container, classNameTypeLibrary);

            OverrideDbProviderNameYaz(output, container);


            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            if (!File.Exists(outputFullFileName))
            {
                UsingleriYaz(output, schemaName, baseNameSpaceTypeLibrary, baseNameSpaceDal);
                output.autoTab("public partial class ");
                output.writeLine(classNameTypeLibrary + "Dal");
                BaslangicSusluParentezVeTabArtir(output);
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                output.saveEncoding(outputFullFileName, "o", "utf8");
                output.clear();

            }
            return "";


        }



        private void OverrideDbProviderNameYaz(IOutput output, IContainer container)
        {
            output.autoTabLn("public override string DbProviderName");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", container.Database.ConnectionDbProviderName));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void PrimaryKeyYaz(IOutput output, IContainer container)
        {
            output.autoTabLn("");
            output.autoTabLn("public override string PrimaryKey");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn(string.Format("return \"{0}\";", pkAdi));
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
            output.autoTabLn("");

        }


        protected IColumn getAutoNumberColumn(IContainer container)
        {
            IColumn result = null;
            foreach (IColumn column in container.Columns)
            {
                if (column.IsAutoKey)
                {
                    result = column;
                    break;
                }
            }
            return result;
        }

        private void SilKomutuYazPkIle(IOutput output, string classNameTypeLibrary, IContainer container)
        {
            ITable table = container as ITable;
            if (table != null )
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.PrimaryKeyColumnTekIseBul(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public virtual void Sil({0} {1})", pkType, pkPropertyName));
                    BaslangicSusluParentezVeTabArtir(output);
                    output.autoTabLn(string.Format("{0} satir = new {0}();", classNameTypeLibrary));
                    output.autoTabLn(string.Format("satir.{0} = {0};", pkPropertyName));
                    output.autoTabLn("base.Sil(satir);");
                    BitisSusluParentezVeTabAzalt(output);
                }
            }
        }




        private void identityKolonDegeriniSetleYaz(IOutput output, IContainer container)
        {
            string methodYazisi = string.Format("protected override void identityKolonDegeriniSetle({0} pTypeLibrary,long pIdentityKolonValue)", classNameTypeLibrary);
            output.autoTabLn(methodYazisi);
            BaslangicSusluParentezVeTabArtir(output);
            if (getIdentityVarmi(utils, container))
            {
                string propertySetleYazisi = string.Format("pTypeLibrary.{0} = ({1} )pIdentityKolonValue;", utils.getIdentityColumnNameAsPascalCase(container), getIdentityType(utils,container));
                output.autoTabLn(propertySetleYazisi);
            }
            BitisSusluParentezVeTabAzalt(output);

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


        private void UsingleriYaz(IOutput output, string schemaName, string baseNameSpaceTypeLibrary, string baseNameSpaceDal)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            output.autoTabLn("using System.Data.SqlClient;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTabLn(";");
            if ( !string.IsNullOrWhiteSpace(schemaName))
            {
                output.autoTab("using ");
                output.autoTab(baseNameSpaceTypeLibrary);
                output.autoTab(".");
                output.autoTab(schemaName);
                output.autoTabLn(";");
            }
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            BaslangicSusluParentezVeTabArtir(output);

        }

        protected virtual void ClassYaz(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            BaslangicSusluParentezVeTabArtir(output);
        }


        private string getSqlIcinSemaBilgisi(IContainer container, bool semaIsminiSorgulardaKullan)
        {
            string sonuc = "";
            if (semaIsminiSorgulardaKullan)
            {
                sonuc = container.Schema + ".";
            }
            return sonuc;
        }

        private void SelectCountYaz(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            output.autoTabLn("protected override string SelectCountString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            string cumle = "return @\"SELECT COUNT(*) FROM " 
                            + getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan) 
                            + container.Name + "\";";
            output.autoTabLn(cumle);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        private void SelectStringYaz(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            output.autoTabLn("protected override string SelectString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            string cumle = "return @\"SELECT ";
            foreach (IColumn column in container.Columns)
            {
                cumle += column.Name + ",";
            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += " FROM ";
            cumle +=  getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan)  + container.Name + "\";";
            output.autoTabLn(cumle);
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private void DeleteStringYaz(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string DeleteString");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("get ");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("return null;");
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);
                
                return;
            }
            string cumle = "";
            output.autoTabLn("protected override string DeleteString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            cumle += "return @\"DELETE ";

            string whereClause = "";

            if (container is ITable)
            {
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsInPrimaryKey)
                    {
                        whereClause += column.Name + " = " + parameterSymbol + column.Name + " AND ";
                    }
                }
                whereClause = whereClause.Remove(whereClause.Length - 4) + "\"";
                cumle += "  FROM " 
                        + getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan) 
                        + container.Name + " WHERE ";
            }
            else
            {

                cumle = "throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\")";
            }

            output.autoTabLn(cumle + whereClause + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }

        private static bool updateWhereSatirindaOlmaliMi(IColumn column)
        {
            return ((column.IsInPrimaryKey) || columnVersiyonZamaniMi(column));
        }


        protected abstract string parameterSymbol
        {
            get;
        }


        private void UpdateStringYaz(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan, ref string pkcumlesi)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string UpdateString");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("get ");
                BaslangicSusluParentezVeTabArtir(output);
                output.autoTabLn("return null;");
                BitisSusluParentezVeTabAzalt(output);
                BitisSusluParentezVeTabAzalt(output);

                return;
            }

            string cumle = "";
            output.autoTabLn("protected override string UpdateString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"UPDATE " + getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan) + container.Name);
                output.autoTabLn(" SET ");

                foreach (IColumn column in container.Columns)
                {
                    if (updateWhereSatirindaOlmaliMi(column))
                    {
                        pkcumlesi += " " + column.Name + " = " + parameterSymbol + column.Name + Environment.NewLine + " AND"  ;
                    }
                    if (!columnParametreOlmaliMi(column))
                    {
                        if (!updateWhereSatirindaOlmaliMi(column))
                        {
                            cumle += column.Name + " = " + parameterSymbol + column.Name +  Environment.NewLine + "," ;
                        }
                    }
                }
                if (cumle.Length > 0)
                {
                    cumle = cumle.Remove(cumle.Length - 1);
                }
                if (pkcumlesi.Length > 0)
                {
                    pkcumlesi = pkcumlesi.Remove(pkcumlesi.Length - 3);
                }


                output.autoTab(cumle);
                output.autoTabLn("");
                output.autoTabLn("WHERE ");
                output.autoTabLn(pkcumlesi + "\";");
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\");");
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }



        protected void InsertStringYaz(IOutput output, IContainer container, string sorgulardaKullanilanSema)
        {
            string cumle = "";

            output.autoTabLn("protected override string InsertString");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get ");
            BaslangicSusluParentezVeTabArtir(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"INSERT INTO "
                    + sorgulardaKullanilanSema
                    + container.Name + " ");
                cumle += " (";
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsComputed)
                    {
                        continue;
                    }
                    if (!column.IsAutoKey)
                    {
                        cumle += column.Name + ",";
                    }
                }
                cumle = cumle.Remove(cumle.Length - 1);
                cumle += ") ";
                output.autoTabLn(cumle);
                output.autoTabLn(" VALUES ");
                cumle = "(";
                output.autoTab("");
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsComputed)
                    {
                        continue;
                    }
                    if (!column.IsAutoKey)
                    {
                        cumle += parameterSymbol  + column.Name + ",";
                    }
                }
                cumle = cumle.Remove(cumle.Length - 1);
                cumle += ")";
                if (getIdentityVarmi(utils, container))
                {
                    cumle = cumle +  getAutoIncrementKeySql();
                }
                output.autoTabLn(cumle + "\";");
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\"VIEW ustunden Ekle/Guncelle/Sil desteklenmemektedir\");");
            }
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }


        protected abstract String getAutoIncrementKeySql();

        private void listeTanimla(IOutput output)
        {
            output.autoTabLn(listeType + " liste = new " + listeType + "();");
        }

        private void SorgulaPkIleGetirYaz(IOutput output, IContainer container, string classNameTypeLibrary,  string pkAdi, string pkAdiPascalCase, string pkType)
        {
            if (container is IView)
            {
                return;
            }
            if (!string.IsNullOrEmpty(pkAdi))
            {
            string classSatiri = "public " + classNameTypeLibrary + " Sorgula"
                            + pkAdiPascalCase + "Ile(" + pkType
                            + " p1)";
            output.autoTabLn(classSatiri);
            BaslangicSusluParentezVeTabArtir(output);
            listeTanimla(output);
            output.autoTab("SorguCalistir(liste,String.Format(\" " + pkAdi + " = '{0}'\", p1));");
            output.autoTabLn("");
            output.autoTabLn("if (liste.Count > 0)");
            output.autoTabLn("{");
            output.autoTabLn("\treturn liste[0];");
            output.autoTabLn("}");
            output.autoTabLn("else");
            output.autoTabLn("{");
            output.autoTabLn("\treturn null;");
            output.autoTabLn("}");
            BitisSusluParentezVeTabAzalt(output);
            }
        }

        private void IdentityVarMiYaz(IOutput output, bool identityVarmi)
        {
            string identitySonuc = "";
            if (identityVarmi)
            {
                identitySonuc = "true";
            }
            else
            {
                identitySonuc = "false";
            }

            output.autoTabLn("");
            output.autoTabLn("protected override bool IdentityVarMi");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return " + identitySonuc + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
        }
        private void PkGuidMiYaz(IOutput output, IContainer container)
        {
            string pkGuidMiSonuc = "";
            if (utils.PkGuidMi(container))
            {
                pkGuidMiSonuc = "true";
            }
            else
            {
                pkGuidMiSonuc = "false";
            }


            output.autoTabLn("");
            output.autoTabLn("protected override bool PkGuidMi");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("get");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("return " + pkGuidMiSonuc + ";");
            BitisSusluParentezVeTabAzalt(output);
            BitisSusluParentezVeTabAzalt(output);
            output.autoTabLn("");
        }

        private void ProcessRowYaz(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" satir)");
            BaslangicSusluParentezVeTabArtir(output);
            for (int i = 0; i < container.Columns.Count; i++)
            {
                IColumn column = container.Columns[i];
                propertyVariableName = utils.getPropertyVariableName(column);
                string yazi = "satir." + propertyVariableName + " = " +
                                utils.GetDataReaderSyntax(column)
                                + "(" + i + ");";
                if (column.IsNullable)
                {
                    output.autoTabLn("if (!dr.IsDBNull(" + i + "))");
                    BaslangicSusluParentezVeTabArtir(output);
                    output.autoTabLn(yazi);
                    BitisSusluParentezVeTabAzalt(output);
                }
                else
                {
                    output.autoTabLn(yazi);
                }
            }
            BitisSusluParentezVeTabAzalt(output);
        }


        private void InsertCommandParametersAddYaz(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" satir)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (!columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }

            BitisSusluParentezVeTabAzalt(output);
        }


        private static bool columnParametreOlmaliMi(IColumn column)
        {
            return ((column.IsAutoKey) || (column.IsComputed));
        }

        private static bool columnVersiyonZamaniMi(IColumn column)
        {
            return (column.Name == "VersiyonZamani");
        }

        private void builderParameterEkle(IOutput output, IColumn column)
        {
            if (!column.isStringTypeWithoutLength && column.isStringType)
            {
                builderParameterEkleString(output, column);

            }
            else
            {
                builderParameterEkleNormal(output, column);
            }
        }

        private void builderParameterEkleString(IOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", satir."
                        + utils.getPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }
        protected abstract string getDbTargetType(IColumn column);
        


        private void builderParameterEkleNormal(IOutput output, IColumn column)
        {
            string s = "builder.parameterEkle(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", satir."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }

        private void DeleteCommandParametersAddYaz(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" satir)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterEkle(output, column);
                }
            }

            BitisSusluParentezVeTabAzalt(output);
        }

        private void UpdateCommandParametersAddYaz(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" satir)");
            BaslangicSusluParentezVeTabArtir(output);
            output.autoTabLn("ParameterBuilder builder = Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey || !columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
                if (columnVersiyonZamaniMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }
            BitisSusluParentezVeTabAzalt(output);
        }















    }
}

