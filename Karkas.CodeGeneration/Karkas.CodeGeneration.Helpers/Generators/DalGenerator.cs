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

        public DalGenerator(CodeGenerationConfig pCodeGenerationConfig) : base(pCodeGenerationConfig)
        {
            utils = new Utils(pCodeGenerationConfig);
        }
        protected Utils utils;


        protected string baseNameSpaceTypeLibrary = "";
        protected string pkName = "";
        protected string pkNamePascalCase = "";
        protected string pkType = "";

        public string GetIdentityColumnName()
        {
            return utils.GetIdentityColumnName(container);
        }



        protected string listType = "";

        protected string pkSentence = "";

        protected string baseNameSpaceDal;

        protected IContainer container;
        public string Render(IContainer pContainer)
        {

            container = pContainer;

			checkPKExits(container);

			SetFields();

            Write_GeneratedClass();

            Write_NotGeneratedClass();

            return "";


        }

        private void Write_GeneratedClass()
        {

            output.Clear();
            output.TabLevel = 0;

            Write_Usings();

            Write_NamespaceStart("Dal");

            Write_ClassGenerated();
            output.AutoTabLine("");

            Write_OverrideDatabaseName();

            Write_SetIdentityColumnValue();


            Write_SelectCount();

            Write_SelectString();

            Write_DeleteString();

            Write_UpdateString();


            Write_InsertString();


            Write_QueryByPk();

            Write_IdentityExists();

            Write_IfPkGuid();

            Write_PrimaryKey();

            Write_DeleteByPK();

            Write_ProcessRow();

            Write_InsertCommandParametersAdd();
            Write_UpdateCommandParametersAdd();
            Write_DeleteCommandParametersAdd();


            Write_ForeignKeyQueries();

			Write_IndexQueries();


			AtEndCurlyBraceletDecreaseTab();
            Write_NamespaceEndCurlyBracelet();

            output.SaveEncoding(outputFullFileNameGenerated, "o", "utf8");
            output.Clear();
        }

        private void SetFields()
        {
            baseNameSpace = CodeGenerationConfig.ProjectNameSpace;
            baseNameSpaceTypeLibrary = baseNameSpace + ".TypeLibrary";

            pkName = utils.FindPrimaryKeyColumnName(container);
            pkNamePascalCase = utils.GetPascalCase(pkName);



            classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
            schemaName = utils.GetPascalCase(container.Schema);

            classNameTypeLibraryNameSpace = baseNameSpaceTypeLibrary;
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                classNameTypeLibraryNameSpace = classNameTypeLibraryNameSpace + "." + schemaName;
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

        private void Write_NotGeneratedClass()
        {
            if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
            {
                Write_Usings();
                Write_NamespaceStart("Dal");
                Write_ClassNormal();

                Write_NamespaceEndCurlyBracelet();
                output.SaveEncoding(outputFullFileName, "o", "utf8");
                output.Clear();
            }
        }

		private string getQueryNameByColumn(string columnName)
		{
			string variableName = utils.GetPascalCase(columnName);
			string queryName = $"QueryBy{variableName}";
			return queryName;
		}
		private string getQueryNameByColumnList(string[] columnNameList)
		{
			string queryName = "QueryBy";
			foreach (var columnName in columnNameList)
			{
				string variableName = utils.GetPascalCase(columnName);
				queryName = $"{queryName}{variableName}";
			}
			return queryName;

		}

		private void write_QueryByForeignKey(string columnName)
		{
			string variableName = utils.GetPascalCase(columnName);
			string queryName = getQueryNameByColumn(columnName);
			string toWrite1 = $"public List<{classNameTypeLibrary}> {queryName}(int p{variableName})";
			string toWrite2 = $"\treturn this.QueryUsingColumnName({classNameTypeLibrary}.ColumnNames.{variableName},p{variableName});";
			output.AutoTabLine(toWrite1);
			output.AutoTabLine("{");
			output.AutoTabLine(toWrite2);
			output.AutoTabLine("}");
		}
		Dictionary<string, bool> generatedFKIndexQueries = new Dictionary<string, bool>();

		public void Write_ForeignKeyQueries()
		{
			if (CodeGenerationConfig.GenerateForeignKeyQueries)
			{

				foreach (IColumn column in container.Columns)
				{
					if (column.IsInForeignKey && !column.IsInPrimaryKey)
					{
						string queryName = getQueryNameByColumn(column.Name);
						if (!generatedFKIndexQueries.ContainsKey(queryName))
						{
							ForeignKeyInformation info = column.ForeignKeyInformation;
							write_QueryByForeignKey(info.SourceColumn);
							generatedFKIndexQueries[queryName] = true;
						}

					}
				}
			}
		}

		private void write_QueryByIndexes(IIndex index)
		{
			string[] columnNameList = index.IndexColumns;
			string queryName = getQueryNameByColumnList(columnNameList);
			if(generatedFKIndexQueries.ContainsKey(queryName))
			{
				return;
			}
			generatedFKIndexQueries[queryName] = true;
			string variableNameList = "";
			string queryByColumnNameList = "new string[] { ";
			string queryByColumnValueList = "new object[] { ";
			foreach (var columnName in columnNameList)
			{
				string variableName = utils.GetPascalCase(columnName);
				string variableType = container.GetColumnLanguageType(columnName);
				variableNameList += $"{variableType} p{variableName},";
				queryByColumnNameList += $"\"{columnName}\",";
				queryByColumnValueList += $"p{variableName},";
			}
			variableNameList = variableNameList.TrimEnd(',');
			queryByColumnNameList = queryByColumnNameList.TrimEnd(',') + " }";
			queryByColumnValueList = queryByColumnValueList.TrimEnd(',') + " }";
			string toWrite1 = $"public List<{classNameTypeLibrary}> {queryName}({variableNameList})";
			string toWrite2 = $"\treturn this.QueryUsingColumnName({queryByColumnNameList},{queryByColumnValueList});";
			output.AutoTabLine(toWrite1);
			output.AutoTabLine("{");
			output.AutoTabLine(toWrite2);
			output.AutoTabLine("}");
		}

		public void Write_IndexQueries()
		{
			ITable table = container as ITable;
			if (CodeGenerationConfig.GenerateIndexQueries)
			{
				var indexList = table.FindIndexList();
				foreach (var index in indexList)
				{
					write_QueryByIndexes(index);
				}
				// TODO: index queries
			}
		}





        private void Write_PrimaryKey()
        {
            output.AutoTabLine("");
            output.AutoTabLine("public override string PrimaryKey");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine(string.Format("return \"{0}\";", pkName));
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
            output.AutoTabLine("");

        }


        protected IColumn GetAutoNumberColumn()
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

        private void Write_DeleteByPK()
        {
            ITable table = container as ITable;
            if (table != null )
            {
                if (table.PrimaryKeyColumnCount == 1)
                {
                    IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
                    string pkPropertyName = utils.GetPropertyVariableName(pkColumn);
                    output.AutoTabLine(string.Format("public virtual void Delete({0} {1})", pkType, pkPropertyName));
                    AtStartCurlyBraceletIncreaseTab();
                    output.AutoTabLine(string.Format("{0} row = new {0}();", classNameTypeLibrary));
                    output.AutoTabLine(string.Format("row.{0} = {0};", pkPropertyName));
                    output.AutoTabLine("base.Delete(row);");
                    AtEndCurlyBraceletDecreaseTab();
                }
            }
        }




        protected virtual void Write_SetIdentityColumnValue()
        {
            bool identityExists = utils.IdentityExists(container);
            if(identityExists)
            {
                string identityType = utils.GetIdentityType(container);

                string methodSignature = $"protected override void setIdentityColumnValue({classNameTypeLibrary} pTypeLibrary,{identityType} pIdentityColumnValue)";
                output.AutoTabLine(methodSignature);
                AtStartCurlyBraceletIncreaseTab();
                if (utils.IdentityExists(container))
                {
                    string identityColumnName = utils.getIdentityColumnNameAsPascalCase(container);
                    string propertySetSignature = $"pTypeLibrary.{identityColumnName} = ({identityType} )pIdentityColumnValue;";
                    output.AutoTabLine(propertySetSignature);
                }
                AtEndCurlyBraceletDecreaseTab();

            }


        }


        private void Write_OverrideDatabaseName()
        {
            if (CodeGenerationConfig.UseMultipleDatabaseNames)
            {
                output.AutoTabLine("public override string DatabaseName");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine("get");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine(string.Format("return \"{0}\";", CodeGenerationConfig.ConnectionName));
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();
            }
        }

        protected abstract void Write_UsingDatabaseClient();
        protected virtual void Write_UsingsAdditional()
        {

        }

        protected void Write_Usings()
        {
            if (!CodeGenerationConfig.UseGlobalUsings)
            {
                output.AutoTabLine("");
                output.AutoTabLine("using System;");
                output.AutoTabLine("using System.Collections.Generic;");
                output.AutoTabLine("using System.Data;");
                output.AutoTabLine("using System.Data.Common;");
                Write_UsingDatabaseClient();
                output.AutoTabLine("using System.Text;");
                output.AutoTabLine("using Karkas.Data;");
                Write_UsingsAdditional();
                output.AutoTabLine("");
                output.AutoTabLine("");
                output.AutoTabLine($"using {baseNameSpaceTypeLibrary};");
            }
            if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
            {
                output.AutoTab($"using {baseNameSpaceTypeLibrary}.{schemaName};");
            }

        }



        protected virtual void Write_ClassGenerated()
        {
            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);
            output.AutoTab("public partial class ");
            output.Write(classNameTypeLibrary);
            output.Write("Dal : BaseDal<");
            output.Write(classNameTypeLibrary);
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab();
        }

        protected virtual void Write_ClassNormal()
        {
            output.AutoTabLine($"public partial class {classNameTypeLibrary}Dal");
            AtStartCurlyBraceletIncreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }


        protected string GetSchemaNameForQueries()
        {
            string result = "";
            if (CodeGenerationConfig.UseSchemaNameInSqlQueries)
            {
                result = container.Schema + ".";
            }
            return result;
        }

        protected string getTableName()
        {
            string tableName = container.Name;
            if (CodeGenerationConfig.UseQuotesInQueries)
            {
                tableName = "\"\"" + tableName + "\"\"";
            }
            return tableName;
        }

        private void Write_SelectCount()
        {

            output.AutoTabLine("protected override string SelectCountString");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get");
            AtStartCurlyBraceletIncreaseTab();
            string sentence = "return @\"SELECT COUNT(*) FROM "
                            + GetSchemaNameForQueries()
                            + getTableName() + "\";";
            output.AutoTabLine(sentence);
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }


        private void Write_SelectString()
        {
            output.AutoTabLine("protected override string SelectString");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get ");
            AtStartCurlyBraceletIncreaseTab();
            string sentence = "return @\"SELECT ";
            foreach (IColumn column in container.Columns)
            {
                sentence += getColumnName(column) + ",";
            }
            sentence = sentence.Remove(sentence.Length - 1);
            sentence += " FROM ";
            sentence +=  GetSchemaNameForQueries()  + getTableName() + "\";";
            output.AutoTabLine(sentence);
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }

        private void Write_DeleteString()
        {
            if (container is IView)
            {
                output.AutoTabLine("protected override string DeleteString");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine("get ");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine("return null;");
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();

                return;
            }
            string sentence = "";
            output.AutoTabLine("protected override string DeleteString");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get ");
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
                        + GetSchemaNameForQueries()
                        + getTableName() + " WHERE ";
            }
            else
            {

                sentence = "throw new NotSupportedException(\"Insert/Update/Delete on VIEWs are not supported.\")";
            }

            output.AutoTabLine(sentence + whereClause + ";");
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


        private void Write_UpdateString()
        {
            if (container is IView)
            {
                output.AutoTabLine("protected override string UpdateString");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine("get ");
                AtStartCurlyBraceletIncreaseTab();
                output.AutoTabLine("return null;");
                AtEndCurlyBraceletDecreaseTab();
                AtEndCurlyBraceletDecreaseTab();

                return;
            }
            string pkLine = "";
            string line = "";
            output.AutoTabLine("protected override string UpdateString");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get ");
            AtStartCurlyBraceletIncreaseTab();
            if (container is ITable)
            {
                string firstLine = "return @\"UPDATE "
                    + GetSchemaNameForQueries()
                    + getTableName();
                output.AutoTabLine(firstLine);
                output.AutoTabLine(" SET ");

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


                output.AutoTab(line);
                output.AutoTabLine("");
                output.AutoTabLine("WHERE ");
                output.AutoTabLine(pkLine + "\";");
            }
            else
            {
                output.AutoTabLine("throw new NotSupportedException(\"Insert/Update/Delete on VIEWs are not supported.\");");
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



        protected virtual void Write_InsertString()
        {

            string schemaNameForQueries = GetSchemaNameForQueries();
            string tableName = getTableName();
            output.AutoTabLine("protected override string InsertString");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get ");
            AtStartCurlyBraceletIncreaseTab();
            if (container is ITable)
            {
                string sentence = $"return @\"INSERT INTO {schemaNameForQueries}{tableName}\n";
                sentence += getInsertString();
                sentence += "\";";
                output.AutoTabLine(sentence);
            }
            else
            {
                output.AutoTabLine("throw new NotSupportedException(\" Insert/Update/Delete is not supported for VIEWs \");");
            }
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }


        private string getColumnNamesForInsertString()
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

        private string getColumnNamesForInsertStringAsParams()
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

        protected virtual string getInsertString()
        {
            string insertSentence = getColumnNamesForInsertString();
            insertSentence += "VALUES \n";
            insertSentence += getColumnNamesForInsertStringAsParams();

            if (utils.IdentityExists(container))
            {
                insertSentence += getAutoIncrementKeySql();
            }

            return insertSentence;
        }

        protected abstract string getAutoIncrementKeySql();

        private void defineList(IOutput output)
        {
            output.AutoTabLine(listType + " list = new " + listType + "();");
        }

        private void Write_QueryByPk()
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
                output.AutoTabLine(methodLine);
                AtStartCurlyBraceletIncreaseTab();
                defineList(output);
                if(CodeGenerationConfig.UseQuotesInQueries)
                {
                    pkName = "\\\"" + pkName + "\\\"";
                }
                output.AutoTab("ExecuteQuery(list,String.Format(\" " + pkName + " = '{0}'\"," +variableName+ "));");
                output.AutoTabLine("");
                output.AutoTabLine("if (list.Count > 0)");
                output.AutoTabLine("{");
                output.AutoTabLine("\treturn list[0];");
                output.AutoTabLine("}");
                output.AutoTabLine("else");
                output.AutoTabLine("{");
                output.AutoTabLine("\treturn null;");
                output.AutoTabLine("}");
                AtEndCurlyBraceletDecreaseTab();
                }
        }

        private void Write_IdentityExists( )
        {
            bool identityExists = utils.IdentityExists(container);
            string identityResult = "";
            if (identityExists)
            {
                identityResult = "true";
            }
            else
            {
                identityResult = "false";
            }

            output.AutoTabLine("");
            output.AutoTabLine("protected override bool IdentityExists");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("return " + identityResult + ";");
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }
        private void Write_IfPkGuid()
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


            output.AutoTabLine("");
            output.AutoTabLine("protected override bool IsPkGuid");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("get");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("return " + IsPkGuidResult + ";");
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
            output.AutoTabLine("");
        }

        private void Write_ProcessRow()
        {
            string propertyVariableName = "";
            output.AutoTab("protected override void ProcessRow(IDataReader dr, ");
            output.Write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            for (int i = 0; i < container.Columns.Count; i++)
            {
                IColumn column = container.Columns[i];
                propertyVariableName = utils.GetPropertyVariableName(column);
                string drGetSyntax = utils.GetDataReaderSyntax(column,i);
                string line = $"row.{propertyVariableName}  = {drGetSyntax};";

                if (column.IsNullable)
                {
                    output.AutoTabLine("if (!dr.IsDBNull(" + i + "))");
                    AtStartCurlyBraceletIncreaseTab();
                    output.AutoTabLine(line);
                    AtEndCurlyBraceletDecreaseTab();
                }
                else
                {
                    output.AutoTabLine(line);
                }
            }
            AtEndCurlyBraceletDecreaseTab();
        }

        public abstract void Write_InsertCommandParametersAdd();


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
            if (!column.IsStringTypeWithoutLength && column.IsStringType)
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
                        + utils.GetPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.AutoTabLine(s);
        }
        protected abstract string getDbTargetType(IColumn column);



        private void builderParameterAddNormal(IColumn column)
        {
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.GetPropertyVariableName(column)
                        + ");";
            output.AutoTabLine(s);
        }
        public abstract void Write_UpdateCommandParametersAdd();
        public abstract void Write_DeleteCommandParametersAdd();



        public abstract List<string> GetReservedKeywords();

        public virtual string StringEscapeCharacterStart => "\"\"";
        public virtual string StringEscapeCharacterEnd => "\"\"";









    }
}

