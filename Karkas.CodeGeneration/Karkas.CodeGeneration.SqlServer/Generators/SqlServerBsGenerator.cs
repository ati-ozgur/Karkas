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
        public SqlServerBsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig) 
            : base(pDatabaseHelper,pCodeGenerationConfig)
        {
        }

        protected override void Write_ClassNormal(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
        }


        protected override void Write_ClassGenerated(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary, bool identityExists, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            if (identityExists)
            {
                output.write(" : BaseBsForIdentity<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateSqlServer,ParameterBuilderSqlServer," + identityType);

            }
            else
            {
                output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateSqlServer,ParameterBuilderSqlServer");
            }
            output.writeLine(">");
        }



        protected override void Write_UsingsDatabaseSpecific(IOutput output)
        {
            output.autoTabLn("using Karkas.Core.Data.SqlServer;");
            output.autoTabLn("using System.Data.SqlClient;");


        }
    }
}
