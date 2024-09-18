
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Sqlite.Generators
{


    public class SqliteBsGenerator : BsGenerator
    {
        public SqliteBsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)        
        {
        }

        protected override void Write_ClassGenerated(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
            output.write(classNameDal + ",  AdoTemplateSqlite, ParameterBuilderSqlite");
            output.writeLine(">");
        }
        protected override void Write_ClassNormal(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
        }

        protected override void Write_UsingsDatabaseSpecific(IOutput output)
        {
            output.autoTabLn("using Microsoft.Data.Sqlite;");
            output.autoTabLn("using Karkas.Core.Data.Sqlite;");
        }
    }
}
