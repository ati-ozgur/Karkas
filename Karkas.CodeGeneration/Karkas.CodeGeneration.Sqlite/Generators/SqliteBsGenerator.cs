﻿
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
            output.autoTab("public partial class ");
            output.write(classNameBs);
            if (identityExists)
            {
                output.write(" : BaseBsForIdentity<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateSqlite,ParameterBuilderSqlite," + identityType);

            }
            else
            {
                output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateSqlite,ParameterBuilderSqlite");
            }
            output.writeLine(">");
        }


        protected override void Write_UsingsDatabaseSpecific()
        {
            output.autoTabLn("using Microsoft.Data.Sqlite;");
            output.autoTabLn("using Karkas.Core.Data.Sqlite;");
        }
    }
}
