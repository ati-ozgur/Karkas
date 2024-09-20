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

        protected string classNameTypeLibrary = "";
        protected string baseNameSpaceTypeLibrary = "";
        protected string pkName = "";
        protected string pkNamePascalCase = "";
        protected string pkType = "";

        public DalGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)
        {
            utils = new Utils(pCodeGenerationConfig);
        }
        protected Utils utils;





        public string GetIdentityColumnName(IContainer container)
        {
            return utils.GetIdentityColumnName(container);
        }



        protected string listType = "";

        protected string pkSentence = "";

        protected string baseNameSpaceDal;
        public string Render(IContainer container)
        {
            List<DatabaseAbbreviations> listDatabaseAbbreviations = null;


            output.Clear();
            output.tabLevel = 0;
            SetFields(container, listDatabaseAbbreviations);

            Create_GeneratedClass(container);

            Create_NormalClass();
            
            return "";


        }

        private void Create_GeneratedClass(IContainer container)
        {
            Write_Usings();

            Write_NamespaceStart();

            Write_ClassGenerated(container);
            output.autoTabLn("");

            Write_OverrideDatabaseName(container);

            Write_SetIdentityColumnValue(container);


            Write_SelectCount(container);

            Write_SelectString(container);

            Write_DeleteString(container);

            Write_UpdateString(container, ref pkSentence);


            Write_InsertString(container);


            Write_QueryByPk(container, classNameTypeLibrary, pkName, pkNamePascalCase, pkType);

            Write_IdentityExists(utils.IdentityExists(container));

            Write_IfPkGuid(container);

            Write_PrimaryKey(container);

            Write_DeleteByPK(container);

            Write_ProcessRow(container);

            Write_InsertCommandParametersAdd(container);
            Write_UpdateCommandParametersAdd(container);
            Write_DeleteCommandParametersAdd(container);

            Write_OverrideDbProviderName(container);


            AtEndCurlyBraceletDecreaseTab();
            Write_NamespaceEndCurlyBracelet();

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
        }

        private void SetFields(IContainer container, List<DatabaseAbbreviations> listDatabaseAbbreviations)
        {
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkName = utils.FindPrimaryKeyColumnName(container);
            pkNamePascalCase = utils.GetPascalCase(pkName);

            if (container is ITable && (!((ITable)container).HasPrimaryKey))
            {
                string warningMessage =
                 "Chosen Table " + container.Name + " has NO Primary Key. Code Generation (DAL) only works with tables who has primaryKey.";
                throw new Exception(warningMessage);
            }


            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            schemaName = utils.GetPascalCase(container.Schema);

            classNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                classNameSpace = classNameSpace + "." + schemaName;
            }

            pkSentence = "";

            baseNameSpaceDal = baseNameSpace + ".Dal";
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                baseNameSpaceDal = baseNameSpaceDal + "." + schemaName;
            }



            pkType = utils.FindPrimaryKeyType(container);

            listType = "List<" + classNameTypeLibrary + ">";

            outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForDalGenerated(schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);
            outputFullFileName = utils.FileUtilsHelper.getBaseNameForDal(schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInSqlQueries);
        }

        private void Create_NormalClass()
        {
            if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
            {
                Write_Usings();
                Write_NamespaceStart();
                Write_ClassNormal();

                Write_NamespaceEndCurlyBracelet();
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();
            }
        }



        private void Write_OverrideDbProviderName(IContainer container)
        {
            output.autoTabLn("public override string DbProviderName");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn(string.Format("return \"{0}\";",  CodeGenerationConfig.ConnectionDbProviderName));
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }


        private void Write_PrimaryKey(IContainer container)
        {
            output.autoTabLn("");
            output.autoTabLn("public override string PrimaryKey");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn(string.Format("return \"{0}\";", pkName));
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
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

        private void Write_DeleteByPK(IContainer container)
        {
            ITable table = container as ITable;
            if (table != null )
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
                    string pkPropertyName = utils.getPropertyVariableName(pkColumn);
                    output.autoTabLn(string.Format("public virtual void Delete({0} {1})", pkType, pkPropertyName));
                    AtStartCurlyBraceletIncreaseTab();
                    output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));
                    output.autoTabLn(string.Format("row.{0} = {0};", pkPropertyName));
                    output.autoTabLn("base.Delete(row);");
                    AtEndCurlyBraceletDecreaseTab();
                }
            }
        }




        protected virtual void Write_SetIdentityColumnValue(IContainer container)
        {
            bool identityExists = utils.IdentityExists(container);
            if(identityExists)
            {
                string identityType = utils.GetIdentityType(container);

                string methodSignature = $"protected override void setIdentityColumnValue({classNameTypeLibrary} pTypeLibrary,{identityType} pIdentityColumnValue)";
                output.autoTabLn(methodSignature);
                AtStartCurlyBraceletIncreaseTab();
                if (utils.IdentityExists(container))
                {
                    string identityColumnName = utils.getIdentityColumnNameAsPascalCase(container);
                    string propertySetSignature = $"pTypeLibrary.{identityColumnName} = ({identityType} )pIdentityColumnValue;";
                    output.autoTabLn(propertySetSignature);
                }
                AtEndCurlyBraceletDecreaseTab();

            }


        }


        private void Write_OverrideDatabaseName(IContainer container)
        {
            if (CodeGenerationConfig.UseMultipleDatabaseNames)
            {
                output.autoTabLn("public override string DatabaseName");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("get");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionName));
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();
            }
        }

        protected abstract void Write_UsingDatabaseClient();
        protected virtual void Write_UsingsAdditional()
        {

        }

        private void Write_Usings()
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.autoTabLn("");
                output.autoTabLn("using System;");
                output.autoTabLn("using System.Collections.Generic;");
                output.autoTabLn("using System.Data;");
                output.autoTabLn("using System.Data.Common;");
                Write_UsingDatabaseClient();
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
                Write_UsingsAdditional();
            }


        }
        private void Write_NamespaceStart()
        { 
            output.autoTabLn("");
            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTab(baseNameSpaceDal);
            output.autoTabLn("");
            AtStartCurlyBraceletIncreaseTab();

        }


        protected virtual void Write_ClassGenerated(IContainer container)
        {
            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDal<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab();
        }

        protected virtual void Write_ClassNormal()
        {
            output.autoTab("public partial class ");
            output.writeLine(classNameTypeLibrary + "Dal");
            AtStartCurlyBraceletIncreaseTab();
            AtEndCurlyBraceletDecreaseTab();

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

        private void Write_SelectCount( IContainer container)
        {

            output.autoTabLn("protected override string SelectCountString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab();
            string sentence = "return @\"SELECT COUNT(*) FROM " 
                            + GetSchemaNameForQueries(container) 
                            + getTableName(container) + "\";";
            output.autoTabLn(sentence);
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }


        private void Write_SelectString( IContainer container)
        {
            output.autoTabLn("protected override string SelectString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab();
            string sentence = "return @\"SELECT ";
            foreach (IColumn column in container.Columns)
            {
                sentence += getColumnName(column) + ",";
            }
            sentence = sentence.Remove(sentence.Length - 1);
            sentence += " FROM ";
            sentence +=  GetSchemaNameForQueries(container)  + getTableName(container) + "\";";
            output.autoTabLn(sentence);
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }

        private void Write_DeleteString( IContainer container)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string DeleteString");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();
                
                return;
            }
            string sentence = "";
            output.autoTabLn("protected override string DeleteString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab();
            sentence += "return @\"DELETE ";

            string whereClause = "";

            if (container is ITable)
            {
                foreach (IColumn column in container.Columns)
                {
                    if (column.IsInPrimaryKey)
                    {
                        string deleteColumnName = column.Name;
                        if(CodeGenerationConfig.UseQuotesInQueries)
                        {
                            deleteColumnName = "\"\"" + deleteColumnName + "\"\"";
                        }
                        whereClause += deleteColumnName + " = " + parameterSymbol + column.Name + " AND ";
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
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }

        public bool shouldBeInUpdateWhereSentence(IColumn column)
        {
            return ((column.IsInPrimaryKey) || isColumnVersionTime(column));
        }


        protected abstract string parameterSymbol
        {
            get;
        }


        private void Write_UpdateString( IContainer container, ref string pkLine)
        {
            if (container is IView)
            {
                output.autoTabLn("protected override string UpdateString");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("get ");
                AtStartCurlyBraceletIncreaseTab();
                output.autoTabLn("return null;");
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();

                return;
            }

            string line = "";
            output.autoTabLn("protected override string UpdateString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab();
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
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
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



        protected virtual void Write_InsertString( IContainer container)
        {

            string schemaNameForQueries = GetSchemaNameForQueries(container);
            string tableName = getTableName(container);
            output.autoTabLn("protected override string InsertString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab();
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
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
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

        private void Write_QueryByPk( IContainer container, string classNameTypeLibrary,  string pkName, string pkNamePascalCase, string pkType)
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
                AtStartCurlyBraceletIncreaseTab();
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
                AtEndCurlyBraceletDecreaseTab();
                }
        }

        private void Write_IdentityExists( bool identityExists)
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
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("return " + identityResult + ";");
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }
        private void Write_IfPkGuid( IContainer container)
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
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("return " + IsPkGuidResult + ";");
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
            output.autoTabLn("");
        }

        private void Write_ProcessRow(IContainer container)
        {
            string propertyVariableName = "";
            output.autoTab("protected override void ProcessRow(IDataReader dr, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
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
                    AtStartCurlyBraceletIncreaseTab();
                    output.autoTabLn(line);
                    AtEndCurlyBraceletDecreaseTab();
                }
                else
                {
                    output.autoTabLn(line);
                }
            }
            AtEndCurlyBraceletDecreaseTab();
        }

        public abstract void Write_InsertCommandParametersAdd(IContainer container);


        public bool shouldAddColumnToParameters(IColumn column)
        {
            return ((column.IsAutoKey) || (column.IsComputed));
        }

        public bool isColumnVersionTime(IColumn column)
        {
            return (column.Name == "VersionTime");
        }

        public virtual void builderParameterAdd(IColumn column)
        {
            if (!column.isStringTypeWithoutLength && column.isStringType)
            {
                builderParameterAddStringDbType(column);
            }
            else
            {
                builderParameterAddNormal(column);
            }
        }

        private void builderParameterAddStringDbType(IColumn column)
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
        


        private void builderParameterAddNormal(IColumn column)
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
        public abstract void Write_UpdateCommandParametersAdd(IContainer container);
        public abstract void Write_DeleteCommandParametersAdd(IContainer container);



        public abstract List<string> GetReservedKeywords();

        public virtual string StringEscapeCharacterStart => "\"\"";
        public virtual string StringEscapeCharacterEnd => "\"\"";









    }
}

