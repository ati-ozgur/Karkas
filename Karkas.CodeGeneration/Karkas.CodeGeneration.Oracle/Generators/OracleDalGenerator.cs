using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Oracle.Generators
{
    public class OracleDalGenerator : DalGenerator
    {


       public OracleDalGenerator(IDatabase databaseHelper): base(databaseHelper)
        {
        }

        protected override string parameterSymbol
        {
            get { return ":"; }
        }

        protected override string getDbTargetType(IColumn column)
        {
            if (column.DbTargetType == "Unknown")
            {
                return "DbType.String";
            }
            else
            {
                return column.DbTargetType;
            }
        }

        protected override string getAutoIncrementKeySql()
        {
            throw new NotImplementedException();
        }

        protected override void ClassYaz(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalOracle<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            BaslangicSusluParentezVeTabArtir(output);
        }


    }
}
