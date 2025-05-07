using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.Data;

namespace Karkas.CodeGeneration.Helpers.Interfaces;

public interface ITable : IContainer
{
	IIndex[] FindIndexList();
	int PrimaryKeyColumnCount { get; }
	bool HasPrimaryKey { get; }
	bool IdentityExists { get; }
	IAdoTemplate<IParameterBuilder> Template { get; }
}

