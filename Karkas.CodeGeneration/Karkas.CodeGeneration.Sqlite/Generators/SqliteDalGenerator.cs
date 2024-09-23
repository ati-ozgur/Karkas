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
        public SqliteDalGenerator(CodeGenerationConfig pCodeGenerationConfig)
            : base(pCodeGenerationConfig)
        {
        }



        protected override void Write_ClassGenerated()
        {

            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);

            if (identityExists)
            {
                output.AutoTab("public partial class ");
                output.Write(classNameTypeLibrary);
                output.Write("Dal : BaseDalForIdentitySqlite<");
                output.Write(classNameTypeLibrary);
                output.Write(",");
                output.Write(identityType);
                output.Write(", AdoTemplateSqlite, ParameterBuilderSqlite");
                output.writeLine(">");
                AtStartCurlyBraceletIncreaseTab();
            }
            else
            {
                output.AutoTab("public partial class ");
                output.Write(classNameTypeLibrary);
                output.Write("Dal : BaseDalSqlite<");
                output.Write(classNameTypeLibrary);
                output.Write(", AdoTemplateSqlite, ParameterBuilderSqlite");
                output.writeLine(">");
                AtStartCurlyBraceletIncreaseTab();

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

        protected override string getAutoIncrementKeySql()
        {
            return ";select last_insert_rowid();";
        }
        protected override void Write_UsingDatabaseClient()
        {
            output.AutoTabLine("using Microsoft.Data.Sqlite;");
            output.AutoTabLine("using Karkas.Data.Sqlite;");

        }


        public override void Write_InsertCommandParametersAdd()
        {
            output.AutoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.Write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.AutoTabLine("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (!shouldAddColumnToParameters(column))
                {
                    builderParameterAdd(column);
                }
            }

            AtEndCurlyBraceletDecreaseTab();
        }

        public override void Write_DeleteCommandParametersAdd()
        {
            output.AutoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.AutoTab(classNameTypeLibrary);
            output.AutoTabLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.AutoTabLine("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterAdd(column);
                }
            }

            AtEndCurlyBraceletDecreaseTab();
        }

        protected override void Write_SetIdentityColumnValue()
        {
            base.Write_SetIdentityColumnValue();
            bool identityExists = utils.IdentityExists(container);
            if(identityExists)
            {
                string identityColumnName = GetIdentityColumnName();
                string value = $"public override string IdentityParameterName {{ get {{return \"{identityColumnName}\"; }} }}";
                output.AutoTabLine(value);
            }


        }


        public override void Write_UpdateCommandParametersAdd()
        {
            output.AutoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.AutoTab(classNameTypeLibrary);
            output.AutoTabLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("ParameterBuilderSqlite builder = (ParameterBuilderSqlite)Template.getParameterBuilder();");
            output.AutoTabLine("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey || !shouldAddColumnToParameters(column))
                {
                    builderParameterAdd(column);
                }
                if (isColumnVersionTime(column))
                {
                    builderParameterAdd(column);
                }
            }
            AtEndCurlyBraceletDecreaseTab();
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


    }
}

