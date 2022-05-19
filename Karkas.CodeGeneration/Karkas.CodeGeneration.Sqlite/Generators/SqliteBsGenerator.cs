using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.CodeGeneration.Sqlite.Generators
{


    public class SqliteBsGenerator : BsGenerator
    {
        public SqliteBsGenerator(IDatabase databaseHelper) : base(databaseHelper)
        {
        }

        protected override void classWrite(IOutput output, string classNameBs, string classNameDal, string classNameTypeLibrary)
        {
            output.autoTab("public partial class ");
            output.write(classNameBs);
            output.write(" : BaseBs<" + classNameTypeLibrary + ", ");
            output.write(classNameDal + ",  AdoTemplateSqlite");
            output.writeLine(">");
        }
    }
}
