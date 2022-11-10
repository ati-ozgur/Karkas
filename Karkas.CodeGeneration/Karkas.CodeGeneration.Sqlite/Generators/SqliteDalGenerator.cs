using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
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

        protected override void ClassWrite(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalSqlite<");
            output.write(classNameTypeLibrary);
            output.write(", AdoTemplateSqlite, ParameterBuilderSqlite");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
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

        protected override void WriteUsingDatabaseClient(IOutput output)
        {
            output.autoTabLn("using System.Data.SQLite;");
        }

        public override void InsertCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" satir)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (!columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }

            AtEndCurlyBraceletDescreaseTab(output);
        }

        public override void DeleteCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" satir)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterEkle(output, column);
                }
            }

            AtEndCurlyBraceletDescreaseTab(output);
        }

        public override void UpdateCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" satir)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey || !columnParametreOlmaliMi(column))
                {
                    builderParameterEkle(output, column);
                }
                if (columnVersiyonZamaniMi(column))
                {
                    builderParameterEkle(output, column);
                }
            }
            AtEndCurlyBraceletDescreaseTab(output);
        }
    }
}

