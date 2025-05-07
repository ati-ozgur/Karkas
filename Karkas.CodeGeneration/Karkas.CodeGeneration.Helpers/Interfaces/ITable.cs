using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.Data;

namespace Karkas.CodeGeneration.Helpers.Interfaces;

public interface ITable : IContainer
{

	int PrimaryKeyColumnCount { get; }
	bool HasPrimaryKey { get; }
	bool IdentityExists { get; }
	IAdoTemplate<IParameterBuilder> Template { get; }


	string SQL_Index_Columns { get; }

	private string[] findIndexColumns(string indexName)
	{
		string sqlIndexColumns = string.Format(SQL_Index_Columns, indexName);
		List<Dictionary<string, object>> dtIndexColumns = Template.GetRows(sqlIndexColumns);
		string[] columns = new string[dtIndexColumns.Count];
		for (int i = 0; i < dtIndexColumns.Count; i++)
		{
			columns[i] = dtIndexColumns[i]["name"].ToString();
		}
		return columns;

	}

	string getSQL_Index_Names();
	IIndex[] FindIndexList()
	{
		var indexList = new List<IIndex>();
		string tableName = this.Name;

		List<Dictionary<string, object>> dtIndexNames = Template.GetRows(getSQL_Index_Names());
		foreach (var row in dtIndexNames)
		{
			string indexName = row["name"].ToString();
			bool IsUnique = Convert.ToBoolean(row["unique"]);
			var index = new IndexInformation(indexName, tableName, IsUnique);
			index.IndexColumns = findIndexColumns(indexName);
			indexList.Add(index);
		}
		return indexList.ToArray();
	}

}

