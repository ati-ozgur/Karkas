﻿using System;
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


        public SqlServerDalGenerator(CodeGenerationConfig pCodeGenerationConfig) 
            : base(pCodeGenerationConfig)
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

        protected override void Write_UsingDatabaseClient()
        {
            output.AutoTabLine("using Microsoft.Data.SqlClient;");
            output.AutoTabLine("using Karkas.Data.SqlServer;");
            
        }


        protected override string getAutoIncrementKeySql()
        {
            return ";SELECT scope_identity();";
        }


        protected override void Write_ClassGenerated()
        {
            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);
            output.AutoTab("public partial class ");
            output.Write(classNameTypeLibrary);
            output.Write("Dal : ");
            if(identityExists)
            {
                output.Write("BaseDalForIdentitySqlServer<");
                output.Write(classNameTypeLibrary);
                output.Write( ","+ identityType);
            }
            else
            {
                output.Write("BaseDalSqlServer<");
                output.Write(classNameTypeLibrary);
            }
            
            output.Write(", AdoTemplateSqlServer, ParameterBuilderSqlServer");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab();
        }

        public override void Write_InsertCommandParametersAdd()
        {
            output.AutoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.Write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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
            output.AutoTabLine("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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

        public override void Write_UpdateCommandParametersAdd()
        {
            output.AutoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.AutoTab(classNameTypeLibrary);
            output.AutoTabLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.AutoTabLine("ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();");
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


    }
}
