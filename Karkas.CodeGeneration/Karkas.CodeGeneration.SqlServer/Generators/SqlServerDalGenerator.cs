﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.SqlServer.Generators
{
    public class SqlServerDalGenerator : DalGenerator
    {
        public SqlServerDalGenerator(IDatabase databaseHelper)
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
            else if (column.DataTypeName == "date")
            {
                return "SqlDbType.Date";
            }
            else 
            {
                return column.DbTargetType;
            }
        }

        protected override void WriteUsingDatabaseClient(IOutput output)
        {
            output.autoTabLn("using System.Data.SqlClient;");
        }


        protected override string getAutoIncrementKeySql()
        {
            return ";SELECT scope_identity();";
        }


        protected override void ClassWrite(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalSqlServer<");
            output.write(classNameTypeLibrary);
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
        }

    }
}
