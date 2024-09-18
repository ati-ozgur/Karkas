using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.PersistenceService;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;


namespace Karkas.CodeGeneration.SqlServer.Generators
{
    public class SqlServerDalGenerator : DalGenerator
    {


        public SqlServerDalGenerator(IDatabase pDatabaseHelper,CodeGenerationConfig pCodeGenerationConfig) 
            : base(pDatabaseHelper,pCodeGenerationConfig)
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
            output.autoTabLn("using Karkas.Core.Data.SqlServer;");
            
        }


        protected override string getAutoIncrementKeySql(IContainer container)
        {
            return ";SELECT scope_identity();";
        }


        protected override void Write_ClassGenerated(IOutput output, string classNameTypeLibrary, bool identityExists, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : ");
            if(identityExists)
            {
                output.write("BaseDalForIdentitySqlServer<");
                output.write(classNameTypeLibrary);
                output.write( ","+ identityType);
            }
            else
            {
                output.write("BaseDalSqlServer<");
                output.write(classNameTypeLibrary);
            }
            
            output.write(", AdoTemplateSqlServer, ParameterBuilderSqlServer");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        public override void WriteInsertCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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
        public override void WriteDeleteCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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

        public override void WriteUpdateCommandParametersAdd(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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

        private static string[] reservedKeyWordsArray = { "ADD", "EXTERNAL", "PROCEDURE", "ALL",
            "FETCH", "PUBLIC", "ALTER", "FILE", "RAISERROR", "AND", "FILLFACTOR", "READ", "ANY",
            "FOR", "READTEXT", "AS", "FOREIGN", "RECONFIGURE", "ASC", "FREETEXT", "REFERENCES", 
            "AUTHORIZATION", "FREETEXTTABLE", "REPLICATION", "BACKUP", "FROM", "RESTORE", "BEGIN",
            "FULL", "RESTRICT", "BETWEEN", "FUNCTION", "RETURN", "BREAK", "GOTO", "REVERT", "BROWSE",
            "GRANT", "REVOKE", "BULK", "GROUP", "RIGHT", "BY", "HAVING", "ROLLBACK", "CASCADE",
            "HOLDLOCK", "ROWCOUNT", "CASE", "IDENTITY", "ROWGUIDCOL", "CHECK", "IDENTITY_INSERT", 
            "RULE", "CHECKPOINT", "IDENTITYCOL", "SAVE", "CLOSE", "IF", "SCHEMA", "CLUSTERED", 
            "IN", "SECURITYAUDIT", "COALESCE", "INDEX", "SELECT", "COLLATE", "INNER", 
            "SEMANTICKEYPHRASETABLE", "COLUMN", "INSERT", "SEMANTICSIMILARITYDETAILSTABLE",
            "COMMIT", "INTERSECT", "SEMANTICSIMILARITYTABLE", "COMPUTE", "INTO", "SESSION_USER",
            "CONSTRAINT", "IS", "SET", "CONTAINS", "JOIN", "SETUSER", "CONTAINSTABLE", "KEY",
            "SHUTDOWN", "CONTINUE", "KILL", "SOME", "CONVERT", "LEFT", "STATISTICS", "CREATE",
            "LIKE", "SYSTEM_USER", "CROSS", "LINENO", "TABLE", "CURRENT", "LOAD", "TABLESAMPLE",
            "CURRENT_DATE", "MERGE", "TEXTSIZE", "CURRENT_TIME", "NATIONAL", "THEN",
            "CURRENT_TIMESTAMP", "NOCHECK", "TO", "CURRENT_USER", "NONCLUSTERED", "TOP", "CURSOR",
            "NOT", "TRAN", "DATABASE", "NULL", "TRANSACTION", "DBCC", "NULLIF", "TRIGGER",
            "DEALLOCATE", "OF", "TRUNCATE", "DECLARE", "OFF", "TRY_CONVERT", "DEFAULT", "OFFSETS", 
            "TSEQUAL", "DELETE", "ON", "UNION", "DENY", "OPEN", "UNIQUE", "DESC", "OPENDATASOURCE",
            "UNPIVOT", "DISK", "OPENQUERY", "UPDATE", "DISTINCT", "OPENROWSET", "UPDATETEXT", 
            "DISTRIBUTED", "OPENXML", "USE", "DOUBLE", "OPTION", "USER", "DROP", "OR", "VALUES",
            "DUMP", "ORDER", "VARYING", "ELSE", "OUTER", "VIEW", "END", "OVER", "WAITFOR", "ERRLVL",
            "PERCENT", "WHEN", "ESCAPE", "PIVOT", "WHERE", "EXCEPT", "PLAN", "WHILE", "EXEC",
            "PRECISION", "WITH", "EXECUTE", "PRIMARY", "WITHIN GROUP", "EXISTS", "PRINT", "WRITETEXT", "EXIT", "PROC",
            "add", "external", "procedure", "all", "fetch", "public", "alter", "file", "raiserror",
            "and", "fillfactor", "read", "any", "for", "readtext", "as", "foreign", "reconfigure", 
            "asc", "freetext", "references", "authorization", "freetexttable", "replication", 
            "backup", "from", "restore", "begin", "full", "restrict", "between", "function", 
            "return", "break", "goto", "revert", "browse", "grant", "revoke", "bulk", "group", 
            "right", "by", "having", "rollback", "cascade", "holdlock", "rowcount", "case", 
            "identity", "rowguidcol", "check", "identity_insert", "rule", "checkpoint", 
            "identitycol", "save", "close", "if", "schema", "clustered", "in", "securityaudit", 
            "coalesce", "index", "select", "collate", "inner", "semantickeyphrasetable", 
            "column", "insert", "semanticsimilaritydetailstable", "commit", "intersect", 
            "semanticsimilaritytable", "compute", "into", "session_user", "constraint", "is",
            "set", "contains", "join", "setuser", "containstable", "key", "shutdown", "continue", 
            "kill", "some", "convert", "left", "statistics", "create", "like", "system_user", 
            "cross", "lineno", "table", "current", "load", "tablesample", "current_date", "merge",
            "textsize", "current_time", "national", "then", "current_timestamp", "nocheck", "to", 
            "current_user", "nonclustered", "top", "cursor", "not", "tran", "database", "null", 
            "transaction", "dbcc", "nullif", "trigger", "deallocate", "of", "truncate", "declare",
            "off", "try_convert", "default", "offsets", "tsequal", "delete", "on", "union", 
            "deny", "open", "unique", "desc", "opendatasource", "unpivot", "disk", "openquery",
            "update", "distinct", "openrowset", "updatetext", "distributed", "openxml", "use", 
            "double", "option", "user", "drop", "or", "values", "dump", "order", "varying",
            "else", "outer", "view", "end", "over", "waitfor", "errlvl", "percent", "when", 
            "escape", "pivot", "where", "except", "plan", "while", "exec", "precision", 
            "with", "execute", "primary", "within group", "exists", "print", "writetext", 
            "exit", "proc"
 };


        private static List<string> reservedKeyWordsList = new List<string>(reservedKeyWordsArray);
        public override List<string> GetReservedKeywords()
        {
            return reservedKeyWordsList;
        }
        public override string StringEscapeCharacterStart => "\'\'";
        public override string StringEscapeCharacterEnd => "\'\'";

    }
}
