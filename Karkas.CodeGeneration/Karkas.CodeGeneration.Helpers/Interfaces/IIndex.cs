using System;

namespace Karkas.CodeGeneration.Helpers.Interfaces;

public interface IIndex
{
	public string Name { get; set; }
	public string TableName { get; set; }
	public string[] IndexColumns { get; set; }
	public bool IsUnique { get; set; }
}
