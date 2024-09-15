using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Sqlite.Generators
{
    public class SqliteDalGenerator : DalGenerator
    {
        public SqliteDalGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig)
            : base(pDatabaseHelper,pCodeGenerationConfig)
        {
        }



        protected override void ClassWrite(IOutput output, string classNameTypeLibrary, bool isIdentity, string identityType)
        {
            if(isIdentity)
            {
                output.autoTab("public partial class ");
                output.write(classNameTypeLibrary);
                output.write("Dal : BaseDalForIdentitySqlite<");
                output.write(classNameTypeLibrary);
                output.write(",");
                output.write(identityType);
                output.write(", AdoTemplateSqlite, ParameterBuilderSqlite");
                output.writeLine(">");
                AtStartCurlyBraceletIncreaseTab(output);
            }
            else
            {
                output.autoTab("public partial class ");
                output.write(classNameTypeLibrary);
                output.write("Dal : BaseDalSqlite<");
                output.write(classNameTypeLibrary);
                output.write(", AdoTemplateSqlite, ParameterBuilderSqlite");
                output.writeLine(">");
                AtStartCurlyBraceletIncreaseTab(output);

            }
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

        protected override string getAutoIncrementKeySql(IContainer container)
        {
            return ";select last_insert_rowid();";
        }
        protected override void WriteUsingDatabaseClient(IOutput output)
        {
            output.autoTabLn("using Microsoft.Data.Sqlite;");
            output.autoTabLn("using Karkas.Core.Data.Sqlite;");

        }


        public override void InsertCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (!shouldAddcolumnToParameters(column))
                {
                    builderParameterAdd(output, column);
                }
            }

            AtEndCurlyBraceletDecreaseTab(output);
        }

        public override void DeleteCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterAdd(output, column);
                }
            }

            AtEndCurlyBraceletDecreaseTab(output);
        }

        protected override void write_SetIdentityColumnValue(IOutput output, IContainer container)
        {
            base.write_SetIdentityColumnValue(output, container);
            bool identityExists = getIdentityVarmi(utils, container);
            if(identityExists)
            {
                string identityColumnName = getIdentityColumnName(utils, container);
                string value = $"public override string IdentityParameterName {{ get {{return \"{identityColumnName}\"; }} }}";
                output.autoTabLn(value);
            }


        }


        public override void UpdateCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey || !shouldAddcolumnToParameters(column))
                {
                    builderParameterAdd(output, column);
                }
                if (columnVersiyonZamaniMi(column))
                {
                    builderParameterAdd(output, column);
                }
            }
            AtEndCurlyBraceletDecreaseTab(output);
        }


        private static string[] reservedKeyWordsArray = {"ABORT", "ACTION", "ADD", "AFTER", "ALL", 
            "ALTER", "ALWAYS", "ANALYZE", "AND", "AS", "ASC", "ATTACH", "AUTOINCREMENT", "BEFORE",
            "BEGIN", "BETWEEN", "BY", "CASCADE", "CASE", "CAST", "CHECK", "COLLATE", "COLUMN",
            "COMMIT", "CONFLICT", "CONSTRAINT", "CREATE", "CROSS", "CURRENT", "CURRENT_DATE", 
            "CURRENT_TIME", "CURRENT_TIMESTAMP", "DATABASE", "DEFAULT", "DEFERRABLE",
            "DEFERRED", "DELETE", "DESC", "DETACH", "DISTINCT", "DO", "DROP", "EACH",
            "ELSE", "END", "ESCAPE", "EXCEPT", "EXCLUDE", "EXCLUSIVE", "EXISTS", "EXPLAIN", 
            "FAIL", "FILTER", "FIRST", "FOLLOWING", "FOR", "FOREIGN", "FROM", "FULL", 
            "GENERATED", "GLOB", "GROUP", "GROUPS", "HAVING", "IF", "IGNORE", "IMMEDIATE", 
            "IN", "INDEX", "INDEXED", "INITIALLY", "INNER", "INSERT", 
            "INSTEAD", "INTERSECT", "INTO", "IS", "ISNULL", "JOIN", "KEY", "LAST",
            "LEFT", "LIKE", "LIMIT", "MATCH", "MATERIALIZED", "NATURAL", "NO", "NOT",
            "NOTHING", "NOTNULL", "NULL", "NULLS", "OF", "OFFSET", "ON", "OR", "ORDER",
            "OTHERS", "OUTER", "OVER", "PARTITION", "PLAN", "PRAGMA", "PRECEDING", "PRIMARY",
            "QUERY", "RAISE", "RANGE", "RECURSIVE", "REFERENCES", "REGEXP", "REINDEX", "RELEASE",
            "RENAME", "REPLACE", "RESTRICT", "RETURNING", "RIGHT", "ROLLBACK", "ROW", "ROWS",
            "SAVEPOINT", "SELECT", "SET", "TABLE", "TEMP", "TEMPORARY", "THEN", "TIES", "TO", 
            "TRANSACTION", "TRIGGER", "UNBOUNDED", "UNION", "UNIQUE", "UPDATE", "USING", "VACUUM", 
            "VALUES", "VIEW", "VIRTUAL", "WHEN", "WHERE", "WINDOW", "WITH", "WITHOUT",
"abort",    "action", "add", "after", "all", "alter", "always", "analyze", "and", "as", "asc", 
            "attach", "autoincrement", "before", "begin", "between", "by", "cascade", "case", 
            "cast", "check", "collate", "column", "commit", "conflict", "constraint", "create", 
            "cross", "current", "current_date", "current_time", "current_timestamp", "database",
            "default", "deferrable", "deferred", "delete", "desc", "detach", "distinct", "do", 
            "drop", "each", "else", "end", "escape", "except", "exclude", "exclusive", "exists", 
            "explain", "fail", "filter", "first", "following", "for", "foreign", "from", "full",
            "generated", "glob", "group", "groups", "having", "if", "ignore", "immediate", "in", 
            "index", "indexed", "initially", "inner", "insert", "instead", "intersect", "into", "is", 
            "isnull", "join", "key", "last", "left", "like", "limit", "match", "materialized",
            "natural", "no", "not", "nothing", "notnull", "null", "nulls", "of", "offset", "on", 
            "or", "order", "others", "outer", "over", "partition", "plan", "pragma", "preceding", 
            "primary", "query", "raise", "range", "recursive", "references", "regexp", "reindex", 
            "release", "rename", "replace", "restrict", "returning", "right", "rollback", "row",
            "rows", "savepoint", "select", "set", "table", "temp", "temporary", "then", "ties",
            "to", "transaction", "trigger", "unbounded", "union", "unique", "update", "using",
            "vacuum", "values", "view", "virtual", "when", "where", "window", "with", "without"};

        private static List<string> reservedKeyWordsList = new List<string>(reservedKeyWordsArray);
        public override List<string> GetReservedKeywords()
        {
            return reservedKeyWordsList;
        }
        public override string StringEscapeCharacterStart => "\"\"";
        public override string StringEscapeCharacterEnd => "\"\"";

    }
}

