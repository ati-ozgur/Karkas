using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface INameChecker
    {
        string SetPascalCase(string name);
        string SetCamelCase(string name);
    }
}

