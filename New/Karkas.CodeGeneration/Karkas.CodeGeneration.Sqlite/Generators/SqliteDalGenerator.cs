using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Sqlite.Generators
{
    public class SqliteDalGenerator : DalGenerator
    {
        public SqliteDalGenerator(IDatabase databaseHelper)
            : base(databaseHelper)
        {
        }

        protected override string parameterSymbol
        {
            get { return "@"; }
        }

        protected override string getDbTargetType(IColumn column)
        {
            if (column.DbTargetType == "Unknown")
            {
                return "SqlDbType.VarChar";
            }
            else
            {
                return column.DbTargetType;
            }
        }

        protected override string getAutoIncrementKeySql()
        {
            return ";select last_insert_rowid();";
        }
    }
}
