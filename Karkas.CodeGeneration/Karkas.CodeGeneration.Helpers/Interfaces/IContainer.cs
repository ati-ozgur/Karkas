using System;
using System.Collections.Generic;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGenerationHelper
{
    public interface IContainer
    {
        string Alias { get;  }
        List<IColumn> Columns { get; }
        IDatabase Database { get; }
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
        string Description { get; }
        string Name { get; }
        string Schema { get; }


    }
}
