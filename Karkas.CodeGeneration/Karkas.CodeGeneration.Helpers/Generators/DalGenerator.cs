using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Helpers.Generators
{
    public abstract class DalGenerator : BaseGenerator
    {

        string classNameTypeLibrary = "";
        string schemaName = "";
        string baseNameSpace = "";
        string baseNameSpaceTypeLibrary = "";
        string pkName = "";
        string pkNamePascalCase = "";
        string pkType = "";

        public DalGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)
        {
            utils = new Utils(pDatabaseHelper);

        }
        protected Utils utils;





        public string GetIdentityColumnName(IContainer container)
        {
            return utils.GetIdentityColumnName(container);
        }



        string listType = "";




        public string Render(IOutput output
            , IContainer container)
        {
            List<DatabaseAbbreviations> listDatabaseAbbreviations = null;
            
            

            output.tabLevel = 0;
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
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
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }
      
            string pkSentence = "";

            string baseNameSpaceDal = baseNameSpace + ".Dal";
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                baseNameSpaceDal = baseNameSpaceDal   + "." +schemaName;
            }
            
            

            pkType = utils.FindPrimaryKeyType(container);

            listType = "List<" + classNameTypeLibrary + ">";

            string outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForDalGenerated(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);
            string outputFullFileName = utils.FileUtilsHelper.getBaseNameForDal(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInSqlQueries);

            Write_Usings(output, schemaName, baseNameSpaceTypeLibrary);

            Write_NamespaceStart(output, baseNameSpaceDal);

            Write_ClassGenerated(output, classNameTypeLibrary,container);
            output.autoTabLn("");

            Write_OverrideDatabaseName(output, container);

            Write_SetIdentityColumnValue(output, container);


            Write_SelectCount(output, container);

            Write_SelectString(output, container);

            Write_DeleteString(output, container);

            Write_UpdateString(output, container, ref pkSentence);


            Write_InsertString(output, container);


            Write_QueryByPk(output, container, classNameTypeLibrary,pkName, pkNamePascalCase, pkType);

            Write_IdentityExists(output, utils.IdentityExists(container));

            Write_IfPkGuid(output, container);

            Write_PrimaryKey(output, container);

            Write_DeleteByPK(output, classNameTypeLibrary, container);

            Write_ProcessRow(output, container, classNameTypeLibrary);

            Write_InsertCommandParametersAdd(output, container, classNameTypeLibrary);
            Write_UpdateCommandParametersAdd(output, container, classNameTypeLibrary);
            Write_DeleteCommandParametersAdd(output, container, classNameTypeLibrary);

            Write_OverrideDbProviderName(output, container);


            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
            if (!File.Exists(outputFullFileName))
            {
                Write_Usings(output, schemaName, baseNameSpaceTypeLibrary);
                Write_NamespaceStart(output, baseNameSpaceDal);
                Write_ClassNormal(output, classNameTypeLibrary);
                AtStartCurlyBraceletIncreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();

            }
            return "";


        }



        private void Write_OverrideDbProviderName(IOutput output, IContainer container)
        {
            output.autoTabLn("public override string DbProviderName");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";",  CodeGenerationConfig.ConnectionDbProviderName));
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }


        private void Write_PrimaryKey(IOutput output, IContainer container)
        {
            output.autoTabLn("");
            output.autoTabLn("public override string PrimaryKey");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn(string.Format("return \"{0}\";", pkName));
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
            output.autoTabLn("");

        }


        protected IColumn GetAutoNumberColumn(IContainer container)
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

        private void Write_DeleteByPK(IOutput output, string classNameTypeLibrary, IContainer container)
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
                    output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));
                    output.autoTabLn(string.Format("row.{0} = {0};", pkPropertyName));
                    output.autoTabLn("base.Delete(row);");
                    AtEndCurlyBraceletDecreaseTab(output);
                }
            }
        }




        protected virtual void Write_SetIdentityColumnValue(IOutput output, IContainer container)
        {
            bool identityExists = utils.IdentityExists(container);
            if(identityExists)
            {
                string identityType = utils.GetIdentityType(container);

                string methodSignature = $"protected override void setIdentityColumnValue({classNameTypeLibrary} pTypeLibrary,{identityType} pIdentityColumnValue)";
                output.autoTabLn(methodSignature);
                AtStartCurlyBraceletIncreaseTab(output);
                if (utils.IdentityExists(container))
                {
                    string identityColumnName = utils.getIdentityColumnNameAsPascalCase(container);
                    string propertySetSignature = $"pTypeLibrary.{identityColumnName} = ({identityType} )pIdentityColumnValue;";
                    output.autoTabLn(propertySetSignature);
                }
                AtEndCurlyBraceletDecreaseTab(output);

            }


        }


        private void Write_OverrideDatabaseName(IOutput output, IContainer container)
        {
            if (CodeGenerationConfig.UseMultipleDatabaseNames)
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

        protected abstract void Write_UsingDatabaseClient(IOutput output);
        protected virtual void WriteUsingsAdditional(IOutput output)
        {

        }

        private void Write_Usings(IOutput output, string schemaName, string baseNameSpaceTypeLibrary)
        {
            output.autoTabLn("");
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Data.Common;");
            Write_UsingDatabaseClient(output);
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using Karkas.Core.DataUtil;");
            output.autoTabLn("using Karkas.Core.DataUtil.BaseClasses;");
            output.autoTab("using ");
            output.autoTab(baseNameSpaceTypeLibrary);
            output.autoTabLn(";");
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                output.autoTab("using ");
                output.autoTab(baseNameSpaceTypeLibrary);
                output.autoTab(".");
                output.autoTab(schemaName);
                output.autoTabLn(";");
            }
            WriteUsingsAdditional(output);
        }
        private void Write_NamespaceStart(IOutput output, string baseNameSpaceDal)
        { 
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            AtStartCurlyBraceletIncreaseTab(output);

        }


        protected virtual void Write_ClassGenerated(IOutput output, string classNameTypeLibrary, IContainer container)
        {
            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        protected virtual void Write_ClassNormal(IOutput output, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary + "Dal");
        }


        protected string GetSchemaNameForQueries(IContainer container)
        {
            string result = "";
            if (CodeGenerationConfig.UseSchemaNameInSqlQueries)
            {
                result = container.Schema + ".";
            }
            return result;
        }

        protected string getTableName(IContainer container)
        {
            string tableName = container.Name;
            if (CodeGenerationConfig.UseQuotesInQueries)
            {
                tableName = "\"\"" + tableName + "\"\"";
            }
            return tableName;
        }

        private void Write_SelectCount(IOutput output, IContainer container)
        {

            output.autoTabLn("protected override string SelectCountString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            string sentence = "return @\"SELECT COUNT(*) FROM " 
                            + GetSchemaNameForQueries(container) 
                            + getTableName(container) + "\";";
            output.autoTabLn(sentence);
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }


        private void Write_SelectString(IOutput output, IContainer container)
        {
            output.autoTabLn("protected override string SelectString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            string sentence = "return @\"SELECT ";
            foreach (IColumn column in container.Columns)
            {
                sentence += getColumnName(column) + ",";
            }
            sentence = sentence.Remove(sentence.Length - 1);
            sentence += " FROM ";
            sentence +=  GetSchemaNameForQueries(container)  + getTableName(container) + "\";";
            output.autoTabLn(sentence);
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }

        private void Write_DeleteString(IOutput output, IContainer container)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string DeleteString");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDecreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);
                
                return;
            }
            string sentence = "";
            output.autoTabLn("protected override string DeleteString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            sentence += "return @\"DELETE ";

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
                sentence += "  FROM " 
                        + GetSchemaNameForQueries(container) 
                        + getTableName(container) + " WHERE ";
            }
            else
            {

                sentence = "throw new NotSupportedException(\"Insert/Update/Delete on VIEWs are not supported.\")";
            }

            output.autoTabLn(sentence + whereClause + ";");
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }

        public bool shouldBeInUpdateWhereSentence(IColumn column)
        {
            return ((column.IsInPrimaryKey) || isColumnVersionTime(column));
        }


        protected abstract string parameterSymbol
        {
            get;
        }


        private void Write_UpdateString(IOutput output, IContainer container, ref string pkLine)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string UpdateString");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab(output);
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDecreaseTab(output);
                AtEndCurlyBraceletDecreaseTab(output);

                return;
            }

            string line = "";
            output.autoTabLn("protected override string UpdateString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            if (container is ITable)
            {
                string firstLine = "return @\"UPDATE " 
                    + GetSchemaNameForQueries(container) 
                    + getTableName(container);
                output.autoTabLn(firstLine);
                output.autoTabLn(" SET ");

                foreach (IColumn column in container.Columns)
                {
                    if (shouldBeInUpdateWhereSentence(column))
                    {
                        pkLine += " " + getColumnName(column) + " = " + parameterSymbol + column.Name + Environment.NewLine + " AND"  ;
                    }
                    if (!shouldAddColumnToParameters(column))
                    {
                        if (!shouldBeInUpdateWhereSentence(column))
                        {
                            line += getColumnName(column) + " = " + parameterSymbol + column.Name +  Environment.NewLine + "," ;
                        }
                    }
                }
                if (line.Length > 0)
                {
                    line = line.Remove(line.Length - 1);
                }
                if (pkLine.Length > 0)
                {
                    pkLine = pkLine.Remove(pkLine.Length - 3);
                }


                output.autoTab(line);
                output.autoTabLn("");
                output.autoTabLn("WHERE ");
                output.autoTabLn(pkLine + "\";");
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\"Insert/Update/Delete on VIEWs are not supported.\");");
            }
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }

        private string getColumnName(IColumn column)
        {
            string lowerName = column.Name.ToLowerInvariant();
            string upperName = column.Name.ToUpperInvariant();

            if(GetReservedKeywords().Contains(lowerName) 
                || GetReservedKeywords().Contains(upperName)
                || CodeGenerationConfig.UseQuotesInQueries)
            {
                return StringEscapeCharacterStart 
                    + column.Name
                    + StringEscapeCharacterEnd
                    ;
            }
            return column.Name;
        }



        protected virtual void Write_InsertString(IOutput output, IContainer container)
        {

            string schemaNameForQueries = GetSchemaNameForQueries(container);
            string tableName = getTableName(container);
            output.autoTabLn("protected override string InsertString");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab(output);
            if (container is ITable)
            {
                string sentence = $"return @\"INSERT INTO {schemaNameForQueries}{tableName}\n";
                sentence += getInsertString( container);
                sentence += "\";";
                output.autoTabLn(sentence);
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\" Insert/Update/Delete is not supported for VIEWs \");");
            }
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }


        private string getColumnNamesForInsertString(IContainer container)
        {
            string sentence = " (";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (!column.IsAutoKey)
                {

                    sentence += getColumnName(column) + ",";
                }
            }
            sentence = sentence.Remove(sentence.Length - 1);
            sentence += ") ";
            sentence += Environment.NewLine;
            return sentence;
        }

        private string getColumnNamesForInsertStringAsParams(IContainer container)
        {
            string sentence = "(";
            foreach (IColumn column in container.Columns)
            {
                if (column.IsComputed)
                {
                    continue;
                }
                if (!column.IsAutoKey)
                {
                    sentence += parameterSymbol + column.Name + ",";
                }
            }
            sentence = sentence.Remove(sentence.Length - 1);
            sentence += ")";
            return sentence;

        }

        protected virtual string getInsertString(IContainer container)
        {
            string insertSentence = getColumnNamesForInsertString(container);
            insertSentence += "VALUES \n";
            insertSentence += getColumnNamesForInsertStringAsParams(container);

            if (utils.IdentityExists(container))
            {
                insertSentence += getAutoIncrementKeySql(container);
            }

            return insertSentence;
        }

        protected abstract string getAutoIncrementKeySql(IContainer container);

        private void defineList(IOutput output)
        {
            output.autoTabLn(listType + " list = new " + listType + "();");
        }

        private void Write_QueryByPk(IOutput output, IContainer container, string classNameTypeLibrary,  string pkName, string pkNamePascalCase, string pkType)
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
                defineList(output);
                if(CodeGenerationConfig.UseQuotesInQueries)
                {
                    pkName = "\\\"" + pkName + "\\\"";                    
                }
                output.autoTab("ExecuteQuery(list,String.Format(\" " + pkName + " = '{0}'\"," +variableName+ "));");
                output.autoTabLn("");
                output.autoTabLn("if (list.Count > 0)");
                output.autoTabLn("{");
                output.autoTabLn("\treturn list[0];");
                output.autoTabLn("}");
                output.autoTabLn("else");
                output.autoTabLn("{");
                output.autoTabLn("\treturn null;");
                output.autoTabLn("}");
                AtEndCurlyBraceletDecreaseTab(output);
                }
        }

        private void Write_IdentityExists(IOutput output, bool identityExists)
        {
            string identityResult = "";
            if (identityExists)
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
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
        }
        private void Write_IfPkGuid(IOutput output, IContainer container)
        {
            string IsPkGuidResult = "";
            if (utils.IsPkGuid(container))
            {
                IsPkGuidResult = "true";
            }
            else
            {
                IsPkGuidResult = "false";
            }


            output.autoTabLn("");
            output.autoTabLn("protected override bool IsPkGuid");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("return " + IsPkGuidResult + ";");
            AtEndCurlyBraceletDecreaseTab(output);
            AtEndCurlyBraceletDecreaseTab(output);
            output.autoTabLn("");
        }

        private void Write_ProcessRow(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            for (int i = 0; i < container.Columns.Count; i++)
            {
                IColumn column = container.Columns[i];
                propertyVariableName = utils.getPropertyVariableName(column);
                string line = "row." + propertyVariableName + " = " +
                                utils.GetDataReaderSyntax(column)
                                + "(" + i + ");";
                if (column.IsNullable)
                {
                    output.autoTabLn("if (!dr.IsDBNull(" + i + "))");
                    AtStartCurlyBraceletIncreaseTab(output);
                    output.autoTabLn(line);
                    AtEndCurlyBraceletDecreaseTab(output);
                }
                else
                {
                    output.autoTabLn(line);
                }
            }
            AtEndCurlyBraceletDecreaseTab(output);
        }

        public abstract void Write_InsertCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary);


        public bool shouldAddColumnToParameters(IColumn column)
        {
            return ((column.IsAutoKey) || (column.IsComputed));
        }

        public bool isColumnVersionTime(IColumn column)
        {
            return (column.Name == "VersionTime");
        }

        public virtual void builderParameterAdd(IOutput output, IColumn column)
        {
            if (!column.isStringTypeWithoutLength && column.isStringType)
            {
                builderParameterAddStringDbType(output, column);
            }
            else
            {
                builderParameterAddNormal(output, column);
            }
        }

        private void builderParameterAddStringDbType(IOutput output, IColumn column)
        {
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }
        protected abstract string getDbTargetType(IColumn column);
        


        private void builderParameterAddNormal(IOutput output, IColumn column)
        {
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }
        public abstract void Write_UpdateCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary);
        public abstract void Write_DeleteCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary);



        public abstract List<string> GetReservedKeywords();

        public virtual string StringEscapeCharacterStart => "\"\"";
        public virtual string StringEscapeCharacterEnd => "\"\"";









    }
}

