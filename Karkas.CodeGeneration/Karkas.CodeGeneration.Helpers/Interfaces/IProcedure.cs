using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IProcedure
    {

        string ProcedureText { get; set; }
        string Name { get; set; }

        string Schema { get; set; }
        IDatabase Database { get; set; }

        


        List<IParameter> Parameters { get; set; }

        List<IColumn> ResultColumns { get; set; }

    }
}
