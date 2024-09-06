﻿using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.CodeGeneration.Oracle.Generators
{
     
   public class OracleBsGenerator : BsGenerator
    {
        public OracleBsGenerator(IDatabase databaseHelper): base(databaseHelper)
        {
        }


        protected override void classWrite(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
            output.write(classNameDal + ", AdoTemplateOracle,ParameterBuilderOracle");
            output.writeLine(">");
        }

        protected override void WriteUsingsDatabaseSpecific(IOutput output)
        {
            output.autoTabLn("using Karkas.Core.Data.Oracle;");
            output.autoTabLn("using Oracle.ManagedDataAccess.Client;");
        }
    }
}
