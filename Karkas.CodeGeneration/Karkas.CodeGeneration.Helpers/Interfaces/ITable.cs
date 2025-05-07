using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface ITable : IContainer
    {
        string[] FindIndexNames();
        int PrimaryKeyColumnCount { get; }
        bool HasPrimaryKey { get; }
        bool IdentityExists { get; }

    }
}
