

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
        public OracleBsGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)        
        {

        }



        protected override void Write_ClassGeneratedDatabaseSpecific()
        {
            output.AutoTab("public partial class ");
            output.Write(classNameBs);
            if (identityExists)
            {
                output.Write(" : BaseBsOracleForIdentity<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateOracle,ParameterBuilderOracle," + identityType );

            }
            else
            {
                output.Write(" : BaseBsOracle<" + classNameTypeLibrary + ", ");
                output.Write(classNameDal + ", AdoTemplateOracle,ParameterBuilderOracle");
            }
            output.writeLine(">");
        }

        protected override void Write_UsingsDatabaseSpecific()
        {
            output.AutoTabLine("using Karkas.Data.Oracle;");
            output.AutoTabLine("using Oracle.ManagedDataAccess.Client;");
        }
    }
}
