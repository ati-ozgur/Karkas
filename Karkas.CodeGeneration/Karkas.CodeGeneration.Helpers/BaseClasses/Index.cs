using System;
using Karkas.CodeGeneration.Helpers.Interfaces;

namespace Karkas.CodeGeneration.Helpers.Interfaces;

public class IndexInformation : IIndex
{
	public IndexInformation(string Name, string TableName, bool IsUnique)
	{
		this.Name = Name;
		this.TableName = TableName;
		this.IsUnique = IsUnique;
	}

	public string Name { get; set; }
	public string TableName { get; set; }
	public string[] IndexColumns { get; set; }
	public bool IsUnique { get; set; }

}
