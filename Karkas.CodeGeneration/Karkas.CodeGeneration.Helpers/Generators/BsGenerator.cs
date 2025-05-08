using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers.Generators;

public abstract class BsGenerator : BaseGenerator
{
	protected string classNameDal = "";
	protected string classNameBs = "";
	protected string pkName = "";
	protected string pkNamePascalCase = "";
	protected string pkType = "";
	protected string baseNameSpaceTypeLibrary = "";

	protected string baseNameSpaceBsWithSchema;
	protected string baseNameSpaceDalWithSchema;

	protected bool identityExists;

	protected string identityType;



	public BsGenerator(CodeGenerationConfig pCodeGenerationConfig) : base(pCodeGenerationConfig)
	{

	}

	IContainer container;

	public void Render(IContainer pContainer)
	{
		container = pContainer;

		checkPKExits(container);




		output.TabLevel = 0;

		SetFields();

		Write_ClassGenerated();

		Write_NotGeneratedClass();
	}

	private void Write_ClassGenerated()
	{
		Write_Usings();
		Write_NamespaceStart("Bs");

		Write_ClassGeneratedDatabaseSpecific();

		AtStartCurlyBraceletIncreaseTab();

		Write_OverrideDatabaseName();
		if (container is ITable && (!string.IsNullOrEmpty(pkName)))
		{
			Write_DeleteCommandWithPK();

			Write_QueryByPkName();
		}

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

		classNameTypeLibrary = utils.getClassNameForTypeLibrary(container.Name, listDatabaseAbbreviations);
		classNameDal = classNameTypeLibrary + "Dal";
		classNameBs = classNameTypeLibrary + "Bs";

		schemaName = utils.GetPascalCase(container.Schema);

		baseNameSpaceBsWithSchema = baseNameSpace + ".Bs";
		baseNameSpaceDalWithSchema = baseNameSpace + ".Dal";

		if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
		{
			baseNameSpaceBsWithSchema = baseNameSpace + ".Bs." + schemaName;
			baseNameSpaceDalWithSchema = baseNameSpace + ".Dal." + schemaName;
		}

		pkType = utils.FindPrimaryKeyType(container);
		pkName = utils.FindPrimaryKeyColumnName(container);
		pkNamePascalCase = utils.GetPascalCase(pkName);

		identityExists = utils.IdentityExists(container);
		identityType = utils.GetIdentityType(container);
		outputFullFileNameGenerated = utils.FileUtilsHelper.getBaseNameForBsGenerated(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);
		outputFullFileName = utils.FileUtilsHelper.getBaseNameForBs(CodeGenerationConfig, schemaName, classNameTypeLibrary, CodeGenerationConfig.UseSchemaNameInFolders);

	}

	private void Write_NotGeneratedClass()
	{
		if (!File.Exists(outputFullFileName) || CodeGenerationConfig.GenerateNormalClassAgain)
		{
			Write_Usings();
			Write_NamespaceStart("Bs");
			Write_ClassNormalDatabaseSpecific();
			Write_NamespaceEndCurlyBracelet();
			output.SaveEncoding(outputFullFileName, "o", "utf8");
			output.Clear();
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


	private void Write_QueryByPkName()
	{
		ITable table = container as ITable;
		string variableName = "p" + pkNamePascalCase;
		if (table != null)
		{
			if (table.PrimaryKeyColumnCount == 1)
			{
				string queryName = "QueryBy" + pkNamePascalCase;
				generatedQueries[queryName] = true;


				string classLine = "public " + classNameTypeLibrary + " "
								+ queryName + "(" + pkType
								+ " " + variableName + ")";
				output.AutoTabLine(classLine);
				output.AutoTabLine("{");
				output.IncreaseTab();
				output.AutoTabLine("return dal.QueryBy" + pkNamePascalCase + "(" + variableName + ");");
				output.DecreaseTab();
				output.AutoTabLine("}");
			}
		}
	}

	private void Write_DeleteCommandWithPK()
	{
		ITable table = container as ITable;
		if (table != null)
		{
			if (table.PrimaryKeyColumnCount == 1)
			{
				IColumn pkColumn = utils.FindPrimaryKeyColumnNameIfOneColumn(container);
				string pkPropertyName = utils.GetPropertyVariableName(pkColumn);
				output.AutoTabLine(string.Format("public void Delete({0} p{1})", pkType, pkPropertyName));
				AtStartCurlyBraceletIncreaseTab();
				// output.autoTabLn(string.Format("{0} row = new {0}();", classNameTypeLibrary));

				output.AutoTabLine(string.Format("dal.Delete( p{0});", pkPropertyName));
				AtEndCurlyBraceletDecreaseTab();
			}
		}

	}

	protected virtual void Write_ClassNormalDatabaseSpecific()
	{
		output.AutoTab("public partial class ");
		output.writeLine(classNameBs);
		Write_ClassStartCurlyBracelet();
		Write_ClassEndCurlyBracelet();
	}


	protected abstract void Write_ClassGeneratedDatabaseSpecific();

	protected abstract void Write_UsingsDatabaseSpecific();

	public void Write_Usings()
	{
		if (!CodeGenerationConfig.UseGlobalUsings)
		{
			output.AutoTabLine("");
			output.AutoTabLine("using System;");
			output.AutoTabLine("using System.Collections.Generic;");
			output.AutoTabLine("using System.Data;");
			Write_UsingsDatabaseSpecific();
			output.AutoTabLine("using System.Text;");
			output.AutoTabLine("using Karkas.Data;");
			output.AutoTab("using ");
			output.AutoTab(baseNameSpaceTypeLibrary);
			output.AutoTabLine(";");
		}
		if (!string.IsNullOrWhiteSpace(schemaName) && CodeGenerationConfig.UseSchemaNameInNamespaces)
		{
			output.AutoTab("using ");
			output.AutoTab(baseNameSpaceTypeLibrary);
			output.AutoTab(".");
			output.AutoTab(schemaName);
			output.AutoTabLine(";");
			output.AutoTab("using ");
			output.AutoTab(baseNameSpaceDalWithSchema);
			output.AutoTabLine(";");
		}
		else
		{
			output.AutoTab("using ");
			output.AutoTab(baseNameSpace + ".Dal");
			output.AutoTabLine(";");
		}
		output.AutoTabLine("");
		output.AutoTabLine("");
	}

	private void write_QueryByForeignKey(string columnName)
	{
		string variableName = utils.GetPascalCase(columnName);
		string methodName = $"QueryBy{variableName}";
		string toWrite1 = $"public List<{classNameTypeLibrary}> {methodName}(int p{variableName})";
		string toWrite2 = $"\treturn dal.{methodName}(p{variableName});";
		output.AutoTabLine(toWrite1);
		output.AutoTabLine("{");
		output.AutoTabLine(toWrite2);
		output.AutoTabLine("}");
	}

	Dictionary<string, bool> generatedQueries = new Dictionary<string, bool>();

	public void Write_ForeignKeyQueries()
	{
		if (CodeGenerationConfig.GenerateForeignKeyQueries)
		{
			foreach (IColumn column in container.Columns)
			{
				if (column.IsInForeignKey && !column.IsInPrimaryKey)
				{
					if (!generatedQueries.ContainsKey(column.Name))
					{
						ForeignKeyInformation info = column.ForeignKeyInformation;
						write_QueryByForeignKey(info.SourceColumn);
						generatedQueries[column.Name] = true;
					}

				}
			}
		}
	}


	private void write_QueryByIndexes(IIndex index)
	{
		string[] columnNameList = index.IndexColumns;
		string queryName = getQueryNameByColumnList(columnNameList);
		if (generatedQueries.ContainsKey(queryName))
		{
			return;
		}
		string returnType = "List<" + classNameTypeLibrary + ">";
		if (index.IsUnique)
		{
			returnType = classNameTypeLibrary;
		}

		generatedQueries[queryName] = true;
		string variableNameList = "";
		string queryByColumnValueList = "";
		foreach (var columnName in columnNameList)
		{
			if (columnName.Contains("$"))
			{
				return;
			}
			string variableName = utils.GetPascalCase(columnName);
			string variableType = container.GetColumnLanguageType(columnName);
			variableNameList += $"{variableType} p{variableName},";
			queryByColumnValueList += $"p{variableName},";
		}
		variableNameList = variableNameList.TrimEnd(',');
		queryByColumnValueList = queryByColumnValueList.TrimEnd(',') ;
		string toWrite1 = $"public {returnType} {queryName}({variableNameList})";
		string toWrite2 = $"\treturn dal.{queryName}({queryByColumnValueList});";
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
		}
	}


}



