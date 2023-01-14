using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGenerationHelper.Generators;
using Karkas.CodeGenerationHelper.Interfaces;

namespace Karkas.CodeGeneration.Oracle.Generators
{
    public class OracleDalGenerator : DalGenerator
    {


        public OracleDalGenerator(IDatabase databaseHelper) : base(databaseHelper)
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

        protected override void WriteUsingsAdditional(IOutput output)
        {
            output.write("using Karkas.Core.Data.Oracle;");
        }

        protected override void ClassWrite(IOutput output, string classNameTypeLibrary, bool identityVarmi, string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalOracle<");
            output.write(classNameTypeLibrary);
            output.write(", AdoTemplateOracle, ParameterBuilderOracle");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab(output);
        }

        protected override void WriteUsingDatabaseClient(IOutput output)
        {
            output.autoTabLn("using Oracle.ManagedDataAccess;");

        }

        public override void InsertCommandParametersAddWrite(IOutput output, IContainer container, string classNameTypeLibrary)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" satir)");
            AtStartCurlyBraceletIncreaseTab(output);
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
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
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
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
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
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

        private static string[] reservedKeyWordsArray = {  "ACCESS", "ADD", "ALL", "ALTER", "AND", 
            "ANY", "AS", "ASC", "AUDIT", "BETWEEN", "BY", "CHAR", "CHECK", "CLUSTER", "COLUMN", 
            "COLUMN_VALUE", "COMMENT", "COMPRESS", "CONNECT", "CREATE", "CURRENT", "DATE", 
            "DECIMAL", "DEFAULT", "DELETE", "DESC", "DISTINCT", "DROP", "ELSE", "EXCLUSIVE", 
            "EXISTS", "FILE", "FLOAT", "FOR", "FROM", "GRANT", "GROUP", "HAVING", "IDENTIFIED",
            "IMMEDIATE", "IN", "INCREMENT", "INDEX", "INITIAL", "INSERT", "INTEGER", "INTERSECT", 
            "INTO", "IS", "LEVEL", "LIKE", "LOCK", "LONG", "MAXEXTENTS", "MINUS", "MLSLABEL", 
            "MODE", "MODIFY", "NESTED_TABLE_ID", "NOAUDIT", "NOCOMPRESS", "NOT", "NOWAIT",
            "NULL", "NUMBER", "OF", "OFFLINE", "ON", "ONLINE", "OPTION", "OR", "ORDER", 
            "PCTFREE", "PRIOR", "PUBLIC", "RAW", "RENAME", "RESOURCE", "REVOKE", "ROW", 
            "ROWID ", "ROWNUM", "ROWS", "SELECT", "SESSION", "SET", "SHARE", "SIZE", "SMALLINT", 
            "START", "SUCCESSFUL", "SYNONYM", "SYSDATE", "TABLE", "THEN", "TO", "TRIGGER", "UID", 
            "UNION", "UNIQUE", "UPDATE", "USER", "VALIDATE", "VALUES", "VARCHAR", "VARCHAR2", 
            "VIEW", "WHENEVER", "WHERE", "WITH",
            "access", "add", "all", "alter", "and", "any", "as", "asc", "audit", "between", 
            "by", "char", "check", "cluster", "column", "column_value", "comment", "compress", 
            "connect", "create", "current", "date", "decimal", "default", "delete", "desc", 
            "distinct", "drop", "else", "exclusive", "exists", "file", "float", "for", "from", 
            "grant", "group", "having", "identified", "immediate", "in", "increment", "index",
            "initial", "insert", "integer", "intersect", "into", "is", "level", "like", "lock",
            "long", "maxextents", "minus", "mlslabel", "mode", "modify", "nested_table_id", 
            "noaudit", "nocompress", "not", "nowait", "null", "number", "of", "offline", "on", 
            "online", "option", "or", "order", "pctfree", "prior", "public", "raw", "rename", 
            "resource", "revoke", "row", "rowid ", "rownum", "rows", "select", "session", "set", 
            "share", "size", "smallint", "start", "successful", "synonym", "sysdate", "table", 
            "then", "to", "trigger", "uid", "union", "unique", "update", "user", "validate", 
            "values", "varchar", "varchar2", "view", "whenever", "where", "with"  };

        private static List<string> reservedKeyWordsList = new List<string>(reservedKeyWordsArray);
        public override List<string> GetReservedKeywords()
        {
            return reservedKeyWordsList;
        }

        public override string StringEscapeCharacterStart => "{";
        public override string StringEscapeCharacterEnd => "}";
    }

}

