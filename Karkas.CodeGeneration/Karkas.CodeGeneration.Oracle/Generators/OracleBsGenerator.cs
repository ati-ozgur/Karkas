

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Oracle.Generators
{
     
   public class OracleBsGenerator : BsGenerator
    {
        public OracleBsGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig): base(pDatabaseHelper,pCodeGenerationConfig)        
        {

        }

        protected override void Write_ClassNormalDatabaseSpecific(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
        }


        protected override void Write_ClassGeneratedDatabaseSpecific(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary, bool identityExists, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            if (identityExists)
            {
                output.write(" : BaseBsOracleForIdentity<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateOracle,ParameterBuilderOracle," + identityType );

            }
            else
            {
                output.write(" : BaseBsOracle<" + classNameTypeLibrary + ", ");
                output.write(classNameDal + ", AdoTemplateOracle,ParameterBuilderOracle");
            }
            output.writeLine(">");
        }

        protected override void Write_UsingsDatabaseSpecific(IOutput output)
        {
            output.autoTabLn("using Karkas.Core.Data.Oracle;");
            output.autoTabLn("using Oracle.ManagedDataAccess.Client;");
        }
    }
}
