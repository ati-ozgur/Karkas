﻿using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers
{
    public partial class Utils
    {
        private CodeGenerationConfig codeGenerationConfig;

        public Utils(CodeGenerationConfig pCodeGenerationConfig)
        {
            codeGenerationConfig = pCodeGenerationConfig;
        }










        public string FindPrimaryKeyColumnName(IContainer container)
        {
            string name = "";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    name = column.Name;
                }
            }
            return name;
        }
        public IColumn FindPrimaryKeyColumnNameIfOneColumn(IContainer container)
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

        public List<IColumn> FindPrimaryKeyColumns(IContainer container)
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

        public string FindPrimaryKeyType(IContainer container)
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

        public bool IdentityExists(IContainer container)
        {
            bool result = false;
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public string IdentityExistsAsString(IContainer container)
        {
            string result = "false";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsIdentity)
                {
                    result = "true";
                    break;
                }
            }
            return result;
        }


        public bool IsColumnNullable(IColumn pColumn)
        {
            if (pColumn.IsNullable)
            {
                return true;
            }
            else if (IsColumnValueType(pColumn))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool IsArgumentValueType(string pLanguageType)
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

        public bool IsColumnValueType(IColumn column)
        {
            return IsArgumentValueType(column.LanguageType);
        }

        public string GetConvertToSyntax(string pType, string pValue)
        {
            string result = null;
            switch (pType)
            {
                case "string":
                    result = $"{pValue}.ToString()";
                    break;
				case "float":
					result = $"Convert.ToSingle({pValue})";
					break;
				case "double":
					result = $"Convert.ToDouble({pValue})";
					break;
				case "byte":
                    result = $"Convert.ToByte({pValue})";
                    break;
                case "int":
                    result = $"Convert.ToInt32({pValue})";
                    break;
                case "long":
                    result = $"Convert.ToInt64({pValue})";
                    break;
                case "Int128":
	                result =  $"Int128.Parse({pValue}.ToString())";
	                break;
                case "decimal":
                    result = $"Convert.ToDecimal({pValue})";
                    break;
                case "DateOnly":
                    result = $"DateOnly.Parse({pValue}.ToString())";
                    break;
                case "DateTime":
                    result = $"Convert.ToDateTime({pValue})";
                    break;
                case "bool":
	                result = $"Convert.ToBoolean({pValue})";
	                break;
				case "byte[]":
					result = $"(byte[]) {pValue}";
					break;
				case "object":
					result = $"(object){pValue}";
					break;
				case "Guid":
					result = $"new Guid({pValue})";
					break;
				case "Unknown":
					result = $"{pValue}";
					break;
				case "OracleDecimal":
					result = $"OracleDecimal.Parse({pValue}.ToString())";
					break;

                default:
                    throw new Exception($"Not Supported type: {pType} in GetConvertToSyntax value: {pValue}");

            }
            return result;
        }


        public string[] GetConvertToSyntax(IColumn column, string propertyName)
        {
            string degerDegiskenAdi = "value";
            string araDegiskenAdi = "_a";
            int araDegiskenYeri = 2;
            string[] resultListesi = new string[]{
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
                resultListesi[araDegiskenYeri] = string.Format("\tGuid {0} = new Guid({1});", araDegiskenAdi, degerDegiskenAdi); ;
                return resultListesi;
            }
            else if (column.LanguageType == "int")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tint {0} = Convert.ToInt32({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "byte")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tbyte {0} = Convert.ToByte({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "bool")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tbool {0} = Convert.ToBoolean({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "DateTime")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tDateTime {0} = Convert.ToDateTime({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "string")
            {
                return new string[] { String.Format("{0} = {1};", propertyName, degerDegiskenAdi) };
            }
            else if (column.LanguageType == "short")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tshort {0} = Convert.ToInt16({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "long")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tlong {0} = Convert.ToInt64({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "decimal")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tdecimal {0} = Convert.ToDecimal({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "byte[]")
            {
                return new string[] { "throw new ArgumentException(\"String'ten byte[] array'e cevirim desteklenmemektedir\");" };
            }
            else if (column.LanguageType == "double")
            {

                resultListesi[araDegiskenYeri] = string.Format("\tdouble {0} = Convert.ToDouble({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "float")
            {
                resultListesi[araDegiskenYeri] = string.Format("\tfloat {0} = Convert.ToSingle({1});", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            else if (column.LanguageType == "object")
            {
                resultListesi[araDegiskenYeri] = string.Format("object {0} =(object) {1};", araDegiskenAdi, degerDegiskenAdi);
                return resultListesi;
            }
            return new string[] { "throw new ArgumentException(\"string'ten degisken tipine cevirim desteklenmemektedir\");" };

        }


        public string GetDataReaderSyntax(IColumn column, int index)
        {
            //            return column.LanguageType;
            if (column.LanguageType == "Guid")
            {
                return $"dr.GetGuid({index})";
            }
            else if (column.LanguageType == "int")
            {
                return $"dr.GetInt32({index})";
            }
            else if (column.LanguageType == "byte")
            {
                return $"dr.GetByte({index})";
            }
            else if (column.LanguageType == "bool")
            {
                return $"dr.GetBoolean({index})";
            }
            else if (column.LanguageType == "DateOnly")
            {
                return $"DateOnly.FromDateTime(dr.GetDateTime({index}))";
            }
            else if (column.LanguageType == "DateTime")
            {
                return $"dr.GetDateTime({index})";
            }
            else if (column.LanguageType == "string")
            {
                return $"dr.GetString({index})";
            }
            else if (column.LanguageType == "short")
            {
                return $"dr.GetInt16({index})";
            }
            else if (column.LanguageType == "long")
            {
                return $"dr.GetInt64({index})";
            }
			else if (column.LanguageType == "Int128")
			{
				return $"Int128.Parse(dr.GetDecimal({index}).ToString())";

			}
            else if (column.LanguageType == "decimal")
            {
                return $"dr.GetDecimal({index})";
            }
            else if (column.LanguageType == "byte[]")
            {
                return $"(Byte[])dr.GetValue({index})";
            }
            else if (column.LanguageType == "double")
            {
                return $"dr.GetDouble({index})";
            }
            else if (column.LanguageType == "float")
            {
                return $"dr.GetFloat({index})";
            }
            else if (column.LanguageType == "object")
            {
                return $"dr.GetValue({index})";
            }
			else if (column.LanguageType == "OracleDecimal")
			{
				return $"(dr as OracleDataReader).GetOracleDecimal({index})";
			}
			else if (column.LanguageType == "Unknown")
            {
                return $"dr.GetString({index})";
            }
            throw new ArgumentException($"Not known language type {column.LanguageType}");
        }


        // TODO Look at later
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

        public string GetPropertyVariableName(IColumn pColumn)
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
            else if (column.DataTypeInDatabase == "NVARCHAR2")
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
				case "OracleDecimal":
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
                default:
                    return false;
            }
        }





        public bool IsPkGuid(IContainer container)
        {
            bool result = false;
            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey && column.LanguageType == "Guid")
                {
                    result = true;
                }
            }
            return result;
        }




        public string GetIdentityColumnName(IContainer container)
        {
            string name = "";
            foreach (IColumn column in container.Columns)
            {
				if (column.IsIdentity)
				{
					name = column.Name;
					break;
                }
            }
            return name;
        }

        public string getIdentityColumnNameAsPascalCase(IContainer container)
        {
            string name = GetPascalCase(GetIdentityColumnName(container));
           return name;
        }



        public string GetIdentityType(IContainer container)
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

