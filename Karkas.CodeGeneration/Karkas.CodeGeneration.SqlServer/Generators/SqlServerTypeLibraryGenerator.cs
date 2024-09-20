using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;

namespace Karkas.CodeGeneration.SqlServer.Generators
{
    public class SqlServerTypeLibraryGenerator : TypeLibraryGenerator
    {



        public SqlServerTypeLibraryGenerator(CodeGenerationConfig pCodeGenerationConfig) 
            : base(pCodeGenerationConfig)
        {
        }

    }
}
