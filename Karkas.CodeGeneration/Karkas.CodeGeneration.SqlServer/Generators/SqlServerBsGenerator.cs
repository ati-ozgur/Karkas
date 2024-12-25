using System;
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
        public SqlServerBsGenerator(CodeGenerationConfig pCodeGenerationConfig) 
            : base(pCodeGenerationConfig)
        {
        }



        protected override void Write_ClassGeneratedDatabaseSpecific()
        {
            output.AutoTab("public partial class ");
            output.Write(classNameBs);
            if (identityExists)
            {
                output.Write(" : BaseBsForIdentity<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateSqlServer,ParameterBuilderSqlServer," + identityType);

            }
            else
            {
                output.Write(" : BaseBs<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateSqlServer,ParameterBuilderSqlServer");
            }
            output.writeLine(">");
        }



        protected override void Write_UsingsDatabaseSpecific()
        {
            output.AutoTabLine("using Karkas.Data.SqlServer;");
            output.AutoTabLine("using Microsoft.Data.SqlClient;");


        }
    }
}
