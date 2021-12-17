using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IParameter
    {
        object[] DataTypeNameComplete { get; set; }

        string Name { get; set; }

        ParamDirection Direction { get; set; }
        int CharacterMaxLength { get; set; }

        object[] DbTargetType { get; set; }

        string LanguageType { get; set; }
    }
}
