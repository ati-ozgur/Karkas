
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
        public SqliteBsGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)        
        {
        }


        protected override void Write_ClassGeneratedDatabaseSpecific()
        {
            output.AutoTab("public partial class ");
            output.Write(classNameBs);
            if (identityExists)
            {
                output.Write(" : BaseBsForIdentity<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateSqlite,ParameterBuilderSqlite," + identityType);

            }
            else
            {
                output.Write(" : BaseBs<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateSqlite,ParameterBuilderSqlite");
            }
            output.writeLine(">");
        }


        protected override void Write_UsingsDatabaseSpecific()
        {
            output.AutoTabLine("using Microsoft.Data.Sqlite;");
            output.AutoTabLine("using Karkas.Data.Sqlite;");
        }
    }
}
