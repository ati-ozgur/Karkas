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
        string pkName = "";
        string pkNamePascalCase = "";
        string pkType = "";
        string _identityColumnName = "";
        bool _identityExists = false;
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
             return utils.IdentityExists(container);
        }
        string listType = "";

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
            baseNameSpace = utils.GetProjectNamespaceWithSchema(database, container.Schema);
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkName = utils.FindPrimaryKeyColumnName(container);
            pkNamePascalCase = utils.GetPascalCase(pkName);
            
            if (container is ITable && (!((ITable) container).HasPrimaryKey ))
            {
                string warningMessage = 
                 "Chosen Table " + container.Name  + " has NO Primary Key. Code Generation (DAL) only works with tables who has primaryKey.";
                throw new Exception(warningMessage);
            }


            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            schemaName = utils.GetPascalCase(container.Schema);

            string classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }
      
            bool pkGuidMi = utils.IsPkGuid(container);
            string pkcumlesi = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal";
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                baseNameSpaceDal = baseNameSpaceDal   + "." +schemaName;
            }
            
            

            pkType = utils.FindPrimaryKeyType(container);

            listType = "List<" + classNameTypeLibrary + ">";

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForDalGenerated(database, schemaName, classNameTypeLibrary,semaIsminiDizinlerdeKullan);
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForDal(database, schemaName, classNameTypeLibrary,semaIsminiDizinlerdeKullan);

            WriteUsings(output, schemaName, baseNameSpaceTypeLibrary);

            WriteNamespaceStart(output, baseNameSpaceDal);

            ClassWrite(output, classNameTypeLibrary, getIdentityVarmi(utils, container), getIdentityType(utils, container));
            output.autoTabLn("");

            OverrideDatabaseNameWrite(output, container);

            identityKolonDegeriniSetleWrite(output, container);

            string sorgulardaKullanilanSema = getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan);

            SelectCountWrite(output, container, semaIsminiSorgulardaKullan);

            SelectStringWrite(output, container, semaIsminiSorgulardaKullan);

            DeleteStringWrite(output, container, semaIsminiSorgulardaKullan);

            UpdateStringWrite(output, container, semaIsminiSorgulardaKullan, ref pkcumlesi);


            InsertStringWrite(output, container, sorgulardaKullanilanSema);


            QueryByPkWrite(output, container, classNameTypeLibrary,pkName, pkNamePascalCase, pkType);

            IdentityVarMiWrite(output, getIdentityVarmi(utils, container));

            PkGuidMiWrite(output, container);

            PrimaryKeyWrite(output, container);

            SilKomutuWritePkIle(output, classNameTypeLibrary, container);

            ProcessRowWrite(output, container, classNameTypeLibrary);

            InsertCommandParametersAddWrite(output, container, classNameTypeLibrary);
            UpdateCommandParametersAddWrite(output, container, classNameTypeLibrary);
            DeleteCommandParametersAddWrite(output, container, classNameTypeLibrary);

            OverrideDbProviderNameWrite(output, container);


            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);

            output.saveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.clear();
            if (!File.Exists(outputFullFileName))
            {
                WriteUsings(output, schemaName, baseNameSpaceTypeLibrary);
                WriteNamespaceStart(output, baseNameSpaceDal);
                output.autoTab("public partial class ");
                output.writeLine(classNameTypeLibrary + "Dal");
                AtStartCurlyBraceletIncreaseTab(output);
                AtEndCurlyBraceletDescreaseTab(output);
                AtEndCurlyBraceletDescreaseTab(output);
                output.saveEncoding(outputFullFileName, "o", "utf8");
                output.clear();

            }
            return "";


        }



        private void OverrideDbProviderNameWrite(IOutput output, IContainer container)
        {
            output.autoTabLn("public override string DbProviderName");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", container.Database.ConnectionDbProviderName));
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }


        private void PrimaryKeyWrite(IOutput output, IContainer container)
        {
            output.autoTabLn("");
            output.autoTabLn("public override string PrimaryKey");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", pkName));
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
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

        private void SilKomutuWritePkIle(IOutput output, string classNameTypeLibrary, IContainer container)
        {
            ITable table = container as ITable;
            if (table != null )
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public virtual void Delete({0} {1})", pkType, pkPropertyName));
                    AtStartCurlyBraceletIncreaseTab(output);
                    output.autoTabLn(string.Format("{0} satir = new {0}();", classNameTypeLibrary));
                    output.autoTabLn(string.Format("satir.{0} = {0};", pkPropertyName));
                    output.autoTabLn("base.Delete(satir);");
                    AtEndCurlyBraceletDescreaseTab(output);
                }
            }
        }




        private void identityKolonDegeriniSetleWrite(IOutput output, IContainer container)
        {
            string methodWriteisi = string.Format("protected override void setIdentityColumnValue({0} pTypeLibrary,long pIdentityKolonValue)", classNameTypeLibrary);
            output.autoTabLn(methodWriteisi);
            AtStartCurlyBraceletIncreaseTab(output);
            if (getIdentityVarmi(utils, container))
            {
                string propertySetleWriteisi = string.Format("pTypeLibrary.{0} = ({1} )pIdentityKolonValue;", utils.getIdentityColumnNameAsPascalCase(container), getIdentityType(utils,container));
                output.autoTabLn(propertySetleWriteisi);
            }
            AtEndCurlyBraceletDescreaseTab(output);

        }


        private void OverrideDatabaseNameWrite(IOutput output, IContainer container)
        {
            output.autoTabLn("public override string DatabaseName");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", container.Database.ConnectionName));
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }

        protected abstract void WriteUsingDatabaseClient(IOutput output);
        protected virtual void WriteUsingsAdditional(IOutput output)
        {

        }

        private void WriteUsings(IOutput output, string schemaName, string baseNameSpaceTypeLibrary)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            WriteUsingDatabaseClient(output);
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
            }
            WriteUsingsAdditional(output);
        }
        private void WriteNamespaceStart(IOutput output, string baseNameSpaceDal)
        { 
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            AtStartCurlyBraceletIncreaseTab(output);

        }



        protected virtual void ClassWrite(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
        }


        private string getSqlIcinSemaBilgisi(IContainer container, bool semaIsminiSorgulardaKullan)
        {
            string result = "";
            if (semaIsminiSorgulardaKullan)
            {
                result = container.Schema + ".";
            }
            return result;
        }

        private void SelectCountWrite(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            output.autoTabLn("protected override string SelectCountString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            string cumle = "return @\"SELECT COUNT(*) FROM " 
                            + getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan) 
                            + container.Name + "\";";
            output.autoTabLn(cumle);
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }


        private void SelectStringWrite(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            output.autoTabLn("protected override string SelectString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            string cumle = "return @\"SELECT ";
            foreach (IColumn column in container.Columns)
            {
                cumle += getColumnName(column) + ",";
            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += " FROM ";
            cumle +=  getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan)  + container.Name + "\";";
            output.autoTabLn(cumle);
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }

        private void DeleteStringWrite(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string DeleteString");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDescreaseTab(output);
                AtEndCurlyBraceletDescreaseTab(output);
                
                return;
            }
            string cumle = "";
            output.autoTabLn("protected override string DeleteString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
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

                cumle = "throw new NotSupportedException(\"VIEW ustunden Insert/Update/Delete desteklenmemektedir\")";
            }

            output.autoTabLn(cumle + whereClause + ";");
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }

        public bool updateWhereSatirindaOlmaliMi(IColumn column)
        {
            return ((column.IsInPrimaryKey) || columnVersiyonZamaniMi(column));
        }


        protected abstract string parameterSymbol
        {
            get;
        }


        private void UpdateStringWrite(IOutput output, IContainer container, bool semaIsminiSorgulardaKullan, ref string pkcumlesi)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string UpdateString");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDescreaseTab(output);
                AtEndCurlyBraceletDescreaseTab(output);

                return;
            }

            string cumle = "";
            output.autoTabLn("protected override string UpdateString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"UPDATE " + getSqlIcinSemaBilgisi(container, semaIsminiSorgulardaKullan) + container.Name);
                output.autoTabLn(" SET ");

                foreach (IColumn column in container.Columns)
                {
                    if (updateWhereSatirindaOlmaliMi(column))
                    {
                        pkcumlesi += " " + getColumnName(column) + " = " + parameterSymbol + column.Name + Environment.NewLine + " AND"  ;
                    }
                    if (!columnParametreOlmaliMi(column))
                    {
                        if (!updateWhereSatirindaOlmaliMi(column))
                        {
                            cumle += getColumnName(column) + " = " + parameterSymbol + column.Name +  Environment.NewLine + "," ;
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
                output.autoTabLn("throw new NotSupportedException(\"VIEW ustunden Insert/Update/Delete desteklenmemektedir\");");
            }
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }

        private string getColumnName(IColumn column)
        {
            string lowerName = column.Name.ToLowerInvariant();
            string upperName = column.Name.ToUpperInvariant();

            if(GetReservedKeywords().Contains(lowerName) 
                || GetReservedKeywords().Contains(upperName))
            {
                return StringEscapeCharacterStart 
                    + column.Name
                    + StringEscapeCharacterEnd
                    ;
            }
            return column.Name;
        }



        protected void InsertStringWrite(IOutput output, IContainer container, string schemaNameForQueries)
        {
            string cumle = "";

            output.autoTabLn("protected override string InsertString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            if (container is ITable)
            {
                output.autoTabLn("return @\"INSERT INTO "
                    + schemaNameForQueries
                    + container.Name + " ");
                cumle = getInsertString(output, container, cumle);
                output.autoTabLn(cumle + "\";");
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\" Insert/Update/Delete is not supported for VIEWs \");");
            }
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }

        private string getInsertString(IOutput output, IContainer container, string cumle)
        {
            cumle += " (";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (!column.IsAutoKey)
                {

                    cumle += getColumnName(column) + ",";
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
                    cumle += parameterSymbol + column.Name + ",";
                }
            }
            cumle = cumle.Remove(cumle.Length - 1);
            cumle += ")";
            if (getIdentityVarmi(utils, container))
            {
                cumle = cumle + getAutoIncrementKeySql(container);
            }

            return cumle;
        }

        protected abstract String getAutoIncrementKeySql(IContainer container);

        private void listeTanimla(IOutput output)
        {
            output.autoTabLn(listType + " liste = new " + listType + "();");
        }

        private void QueryByPkWrite(IOutput output, IContainer container, string classNameTypeLibrary,  string pkName, string pkNamePascalCase, string pkType)
        {
            if (container is IView)
            {
                return;
            }
            if (!string.IsNullOrEmpty(pkName))
            {
                string variableName = "p" + pkName;
                string methodLine = "public " + classNameTypeLibrary + " QueryBy"
                            + pkNamePascalCase + "(" + pkType
                                + " " + variableName +" )";
                output.autoTabLn(methodLine);
                AtStartCurlyBraceletIncreaseTab(output);
                listeTanimla(output);
                output.autoTab("ExecuteQuery(liste,String.Format(\" " + pkName + " = '{0}'\"," +variableName+ "));");
                output.autoTabLn("");
                output.autoTabLn("if (liste.Count > 0)");
                output.autoTabLn("{");
                output.autoTabLn("\treturn liste[0];");
                output.autoTabLn("}");
                output.autoTabLn("else");
                output.autoTabLn("{");
                output.autoTabLn("\treturn null;");
                output.autoTabLn("}");
                AtEndCurlyBraceletDescreaseTab(output);
                }
        }

        private void IdentityVarMiWrite(IOutput output, bool identityVarmi)
        {
            string identityResult = "";
            if (identityVarmi)
            {
                identityResult = "true";
            }
            else
            {
                identityResult = "false";
            }

            output.autoTabLn("");
            output.autoTabLn("protected override bool IdentityExists");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("return " + identityResult + ";");
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
        }
        private void PkGuidMiWrite(IOutput output, IContainer container)
        {
            string pkGuidMiResult = "";
            if (utils.IsPkGuid(container))
            {
                pkGuidMiResult = "true";
            }
            else
            {
                pkGuidMiResult = "false";
            }


            output.autoTabLn("");
            output.autoTabLn("protected override bool IsPkGuid");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("return " + pkGuidMiResult + ";");
            AtEndCurlyBraceletDescreaseTab(output);
            AtEndCurlyBraceletDescreaseTab(output);
            output.autoTabLn("");
        }

        private void ProcessRowWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" satir)");
            AtStartCurlyBraceletIncreaseTab(output);
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
                    AtStartCurlyBraceletIncreaseTab(output);
                    output.autoTabLn(yazi);
                    AtEndCurlyBraceletDescreaseTab(output);
                }
                else
                {
                    output.autoTabLn(yazi);
                }
            }
            AtEndCurlyBraceletDescreaseTab(output);
        }

        public abstract void InsertCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary);


        public bool columnParametreOlmaliMi(IColumn column)
        {
            return ((column.IsAutoKey) || (column.IsComputed));
        }

        public bool columnVersiyonZamaniMi(IColumn column)
        {
            return (column.Name == "VersiyonZamani");
        }

        public void builderParameterEkle(IOutput output, IColumn column)
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
            string s = "builder.AddParameter(\"" + parameterSymbol
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
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", satir."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }
        public abstract void UpdateCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary);
        public abstract void DeleteCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary);



        public abstract List<string> GetReservedKeywords();

        public abstract string StringEscapeCharacterStart { get; }
        public abstract string StringEscapeCharacterEnd { get; }









    }
}

