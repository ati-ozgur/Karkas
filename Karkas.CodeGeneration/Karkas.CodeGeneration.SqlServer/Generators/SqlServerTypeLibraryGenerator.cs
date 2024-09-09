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



        public SqlServerTypeLibraryGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig) 
            : base(pDatabaseHelper,pCodeGenerationConfig)
        {
        }

        protected override void usingNamespaceleriWrite(IOutput output, string classNameSpace)
        {
            output.autoTabLn("using System;");
            output.autoTabLn("using System.Data;");
            output.autoTabLn("using System.Text;");
            output.autoTabLn("using System.Configuration;");
            output.autoTabLn("using System.Diagnostics;");
            output.autoTabLn("using System.Xml.Serialization;");
            output.autoTabLn("using System.Collections.Generic;");
            output.autoTabLn("using Karkas.Core.TypeLibrary;");
            output.autoTabLn("using System.ComponentModel.DataAnnotations;");

            generateClrTypesUsings();            


            output.autoTabLn("");
            output.autoTab("namespace ");
            output.autoTabLn(classNameSpace);
            output.write("");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        private void generateClrTypesUsings()
        {
            // TODO buraya bir sekilde 
            // using Microsoft.SqlServer.Types
            // eklenecek
        }

    }
}
