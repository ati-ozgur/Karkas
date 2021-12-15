using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface ITable : IContainer
    {
        int findIndexFromName(string name);
        int PrimaryKeyColumnCount { get; }
        bool HasPrimaryKey { get; }
        bool IdentityVarmi { get; }

    }
}
