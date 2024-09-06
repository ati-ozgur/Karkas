using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface INameChecker
    {
        string SetPascalCase(string name);
        string SetCamelCase(string name);
    }
}

