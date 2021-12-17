using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Karkas.CodeGenerationHelper.Generators;
using System.IO;
using System.Globalization;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper
{
    public partial class Utils
    {

        public Utils(IDatabase pHelper)
        {
            helper = pHelper;
        }


        private IDatabase helper;





        #region "Parser Helper Fonksiyonlari"

        public string ProjeNamespaceIsminiAl(IDatabase database)
        {
            return database.ProjectNameSpace;
        }

        internal string NamespaceIniAlSchemaIle(IDatabase database, string p)
        {
            return ProjeNamespaceIsminiAl(database);
        }




        #endregion



        public string PrimaryKeyAdiniBul(IContainer container)
        {
            string adi = "";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    adi = column.Name;
                }
            }
            return adi;
        }
        public IColumn PrimaryKeyColumnTekIseBul(IContainer container)
        {
            IColumn pkColon = null;
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    pkColon = column;
                }
            }
            return pkColon;
        }

        public List<IColumn> PrimaryKeyColumnlariniBul(IContainer container)
        {
            List<IColumn> pkColonListesi = new List<IColumn>();
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    pkColonListesi.Add(column);
                }
            }
            return pkColonListesi;
        }

        public string PrimaryKeyTipiniBul(IContainer container)
        {
            string tip = "";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    tip = column.LanguageType;
                }
            }
            return tip;
        }

        public bool IdentityVarMi(IContainer container)
        {
            bool sonuc = false;
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    sonuc = true;
                    break;
                }
            }
            return sonuc;
        }

        public string IdentityVarMiAsString(IContainer container)
        {
            string sonuc = "false";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    sonuc = "true";
                    break;
                }
            }
            return sonuc;
        }

        public string GetCSharpTypeFromDotNetType(string pDotNetType)
        {
            string sonuc = "";
            switch (pDotNetType)
            {
                case "System.Int16":
                    sonuc = "short";
                    break;

                case "System.Int32":
                    sonuc = "int";
                    break;
                case "System.Int64":
                    sonuc = "long";
                    break;
                case "System.Byte":
                    sonuc = "byte";
                    break;
            }
            return sonuc;
        }

        public bool ColumnNullDegeriAlabilirMi(IColumn pColumn)
        {
            if (pColumn.IsNullable)
            {
                return true;
            }
            else if (ColumnValueTypeMi(pColumn))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool ArgumentValueTypeMi(string pLanguageType)
        {
            if (
                    pLanguageType == "Guid"
                    || pLanguageType == "int"
                    || pLanguageType == "byte"
                    || pLanguageType == "bool"
                    || pLanguageType == "DateTime"
                    || pLanguageType == "short"
                    || pLanguageType == "long"
                    || pLanguageType == "decimal"
                    || pLanguageType == "double"
                    || pLanguageType == "float"
                    )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool ColumnValueTypeMi(IColumn column)
        {
            return ArgumentValueTypeMi(column.LanguageType);
        }

        public string GetConvertToSyntax(string tipi, string degiskenDegeri)
        {
            string sonuc = string.Format("({0}) {1}", tipi, degiskenDegeri);
            switch (tipi)
            {
                case "byte":
                    sonuc = string.Format("Convert.ToByte({0});", degiskenDegeri);
                    break;
                case "int":
                    sonuc = string.Format("Convert.ToInt32({0});", degiskenDegeri);
                    break;
                case "long":
                    sonuc = string.Format("Convert.ToInt64({0});", degiskenDegeri);
                    break;
                case "decimal":
                    sonuc = string.Format("Convert.ToDecimal({0});", degiskenDegeri);
                    break;
            }
            return sonuc;
        }


        public string[] GetConvertToSyntax(IColumn column, string propertyName)
        {
            string degerDegiskenAdi = "value";
            string araDegiskenAdi = "_a";
            int araDegiskenYeri = 2;
            string[] sonucListesi = new string[]{
                    "try"
                    ,"{"
                    ,""
                    ,string.Format("{0} = {1};", propertyName,araDegiskenAdi)
                    ,"}"
                    ,"catch(Exception)"
                    ,"{"
                    ,string.Format("\tthis.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,\"{0}\",string.Format(CEVIRI_YAZISI,\"{0}\",\"{1}\")));"
                                ,propertyName
                                ,column.LanguageType)
                    ,"}"
                    };
            if (column.LanguageType == "Guid")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tGuid {0} = new Guid({1});", araDegiskenAdi, degerDegiskenAdi); ;
                return sonucListesi;
            }
            else if (column.LanguageType == "int")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tint {0} = Convert.ToInt32({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "byte")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tbyte {0} = Convert.ToByte({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "bool")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tbool {0} = Convert.ToBoolean({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "DateTime")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tDateTime {0} = Convert.ToDateTime({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "string")
            {
                return new string[] { String.Format("{0} = {1};", propertyName, degerDegiskenAdi) };
            }
            else if (column.LanguageType == "short")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tshort {0} = Convert.ToInt16({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "long")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tlong {0} = Convert.ToInt64({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "decimal")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tdecimal {0} = Convert.ToDecimal({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "byte[]")
            {
                return new string[] { "throw new ArgumentException(\"String'ten byte[] array'e cevirim desteklenmemektedir\");" };
            }
            else if (column.LanguageType == "double")
            {

                sonucListesi[araDegiskenYeri] = string.Format("\tdouble {0} = Convert.ToDouble({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "float")
            {
                sonucListesi[araDegiskenYeri] = string.Format("\tfloat {0} = Convert.ToSingle({1});", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            else if (column.LanguageType == "object")
            {
                sonucListesi[araDegiskenYeri] = string.Format("object {0} =(object) {1};", araDegiskenAdi, degerDegiskenAdi);
                return sonucListesi;
            }
            return new string[] { "throw new ArgumentException(\"string'ten degisken tipine cevirim desteklenmemektedir\");" };

        }


        public string GetDataReaderSyntax(IColumn column)
        {
            //            return column.LanguageType;
            if (column.LanguageType == "Guid")
            {
                return "dr.GetGuid";
            }
            else if (column.LanguageType == "int")
            {
                return "dr.GetInt32";
            }
            else if (column.LanguageType == "byte")
            {
                return "dr.GetByte";
            }
            else if (column.LanguageType == "bool")
            {
                return "dr.GetBoolean";
            }
            else if (column.LanguageType == "DateTime")
            {
                return "dr.GetDateTime";
            }
            else if (column.LanguageType == "string")
            {
                return "dr.GetString";
            }
            else if (column.LanguageType == "short")
            {
                return "dr.GetInt16";
            }
            else if (column.LanguageType == "long")
            {
                return "dr.GetInt64";
            }
            else if (column.LanguageType == "decimal")
            {
                return "dr.GetDecimal";
            }
            else if (column.LanguageType == "byte[]")
            {
                return "(Byte[])dr.GetValue";
            }
            else if (column.LanguageType == "double")
            {
                return "dr.GetDouble";
            }
            else if (column.LanguageType == "float")
            {
                return "dr.GetFloat";
            }
            else if (column.LanguageType == "object")
            {
                return "dr.GetValue";
            }
            else if (column.LanguageType == "Unknown")
            {
                return "dr.GetString";
            }



            return column.LanguageType;
        }


        public string getClassNameForTypeLibrary(string tableName, List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            if (listDatabaseAbbreviations != null)
            {
                foreach (DatabaseAbbreviations abbr in listDatabaseAbbreviations)
                {
                    if (tableName.Contains(abbr.Abbreviation)
                        && abbr.useAsModuleName == "N"
                        )
                    {
                        tableName = tableName.Replace(abbr.Abbreviation, abbr.FullNameReplacement);
                    }
                }
            }


            return GetPascalCase(tableName);
        }

        public string GetCamelCase(string name)
        {
            return new NameChecker().SetCamelCase(name);
        }

        public string GetPascalCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "";
            }
            else
            {
                return new NameChecker().SetPascalCase(name);
            }
        }

        public string getPropertyVariableName(IColumn pColumn)
        {

                if (

                    (pColumn.Name.Equals(pColumn.ContainerName, StringComparison.CurrentCultureIgnoreCase))
                ||
                    (pColumn.Name.Equals(pColumn.ContainerName, StringComparison.InvariantCultureIgnoreCase))
                ||
                    (pColumn.Name.Equals(pColumn.ContainerName, StringComparison.OrdinalIgnoreCase))
                    )
                {
                    return GetPascalCase(pColumn.Name) + "Property";
                }
            return GetPascalCase(pColumn.Name);
        }

        public string GetLanguageType(IColumn column)
        {
            if (IsValueType(column) && column.IsNullable)
            {
                return "Nullable<" + column.LanguageType + ">";
            }
            else if (column.LanguageType == "Unknown" && column.DataTypeName == "sysname")
            {
                return "string";
            }
            else
            {
                return column.LanguageType;
            }
        }

        public bool IsValueType(IColumn column)
        {
            // Array is always reference type
            if (column.LanguageType.IndexOf("[]") > -1)
                return false;

            // scan value types
            switch (column.LanguageType)
            {
                case "DateTime":
                case "decimal":
                case "bool":
                case "byte":
                case "double":
                case "Guid":
                case "int":
                case "float":
                case "short":
                case "TimeSpan":
                case "long":
                    return true;
                    break;

                default:
                    return false;
            }
        }





        public bool PkGuidMi(IContainer container)
        {
            bool sonuc = false;
            foreach (IColumn column in container.Columns)
            {
                if ((column.IsInPrimaryKey) && (column.LanguageType == "Guid"))
                {
                    sonuc = true;
                }
            }
            return sonuc;
        }




        public string getIdentityColumnName(IContainer container)
        {
            string adi = "";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    adi = column.Name;
                }
            }
            return adi;
        }

        public string getIdentityColumnNameAsPascalCase(IContainer container)
        {
            string adi = GetPascalCase(getIdentityColumnName(container));
           return adi;
        }



        public string getIdentityType(IContainer container)
        {
            string typeToReturn = "";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    typeToReturn = column.LanguageType;
                }
            }
            return typeToReturn;
        }

    }
}

