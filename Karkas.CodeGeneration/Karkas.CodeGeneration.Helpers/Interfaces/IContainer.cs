using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Helpers
{
	public interface IContainer
	{
		string Alias { get; }
		List<IColumn> Columns { get; }
		DateTime DateCreated { get; }
		DateTime DateModified { get; }
		string Description { get; }
		string Name { get; }
		string Schema { get; }

		CodeGenerationConfig CodeGenerationConfig { get; }

		string GetColumnLanguageType(string columnName)
		{
			string LanguageType = "";
			foreach (IColumn column in Columns)
			{
				if (column.Name == columnName)
				{
					LanguageType = column.LanguageType;
					break;
				}
			}
			return LanguageType;
		}


    }
}
