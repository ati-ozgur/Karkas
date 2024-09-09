﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;



namespace Karkas.CodeGeneration.SqlServer.Generators
{
    public class SqlServerBsGenerator : BsGenerator
    {
        public SqlServerBsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig) 
            : base(pDatabaseHelper,pCodeGenerationConfig)
        {
        }

        protected override void classWrite(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
            output.write(classNameDal + ",  AdoTemplateSqlServer,ParameterBuilderSqlServer");
            output.writeLine(">");
        }

        protected override void WriteUsingsDatabaseSpecific(IOutput output)
        {
            output.autoTabLn("using Karkas.Core.Data.SqlServer;");
            output.autoTabLn("using System.Data.SqlClient;");


        }
    }
}
