using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.CodeGeneration.Helpers;
using Karkas.CodeGeneration.Helpers.BaseClasses;
using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.Generators;
using Karkas.CodeGeneration.Helpers.PersistenceService;


namespace Karkas.CodeGeneration.Oracle.Generators
{
    public class OracleDalGenerator : DalGenerator
    {


        public OracleDalGenerator(CodeGenerationConfig pCodeGenerationConfig): base(pCodeGenerationConfig)        
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

        protected override string getAutoIncrementKeySql(IContainer container)
        {
            return "";
        }

        protected override void Write_UsingsAdditional()
        {
            output.write("using Karkas.Core.Data.Oracle;");
        }

        protected override void Write_ClassGenerated(IContainer container)
        {
            bool identityExists = utils.IdentityExists(container);
            string identityType = utils.GetIdentityType(container);
            if (identityExists)
            {
                ClassWriteIdentity(identityType);
            }
            else
            {
                ClassWriteNormal();
            }
        }

        protected void ClassWriteNormal()
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalOracle<");
            output.write(classNameTypeLibrary);
            output.write(", AdoTemplateOracle, ParameterBuilderOracle");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab();
        }
        protected void ClassWriteIdentity(string identityType)
        {
            output.autoTab("public partial class ");
            output.write(classNameTypeLibrary);
            output.write("Dal : BaseDalForIdentityOracle<");
            output.write(classNameTypeLibrary + ", ");
            output.write(identityType);
            output.write(", AdoTemplateOracle, ParameterBuilderOracle");
            output.writeLine(">");
            AtStartCurlyBraceletIncreaseTab();
        }

        protected override void Write_UsingDatabaseClient()
        {
            output.autoTabLn("using Oracle.ManagedDataAccess;");

        }

        protected override void Write_SetIdentityColumnValue(IContainer container)
        {
            base.Write_SetIdentityColumnValue( container);
            bool identityExists = utils.IdentityExists(container);
            if (identityExists)
            {
                string identityColumnName = GetIdentityColumnName(container);
                string value = $"public override string IdentityParameterName {{ get {{return \":{identityColumnName}\"; }} }}";
                output.autoTabLn(value);
            }


        }


        protected override void Write_InsertString(IContainer container)
        {

            output.autoTabLn("protected override string InsertString");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("get ");
            AtStartCurlyBraceletIncreaseTab();
            if (container is ITable)
            {

                string schemaNameForQueries = GetSchemaNameForQueries(container);
                string tableName = getTableName(container);

                string identityColumnName = utils.GetIdentityColumnName(container);
                string identityReturnVariableName = identityColumnName.ToLowerInvariant();
                if(CodeGenerationConfig.UseQuotesInQueries)
                {
                    identityColumnName = "\"\"" + identityColumnName + "\"\"";
                }
                string insertString = getInsertString(container);
                if(string.IsNullOrEmpty(identityColumnName))
                {
                    string insert;
                    if(CodeGenerationConfig.UseSchemaNameInSqlQueries)
                    {
                        insert = "return  @\"" + $"INSERT INTO {schemaNameForQueries}.{tableName} {insertString}\";";
                    } 
                    else
                    {
                        insert = "return  @\"" + $"INSERT INTO {tableName} {insertString}\";";
                    }
                    output.autoTabLn(insert);
                }
                else
                {
                    string sentenceInner = $"{insertString}  returning {identityColumnName} into :{identityReturnVariableName};";
                    string sentence = $"return @\" begin" + Environment.NewLine;
                    sentence = sentence +   $"INSERT INTO {schemaNameForQueries}{tableName}" + Environment.NewLine;
                    sentence += sentenceInner + Environment.NewLine;
                    sentence = sentence + "end; ";
                    sentence +=  "\";";
                    output.autoTabLn(sentence);
                }
            }
            else
            {
                output.autoTabLn("throw new NotSupportedException(\" Insert/Update/Delete is not supported for VIEWs \");");
            }
            AtEndCurlyBraceletDecreaseTab();
            AtEndCurlyBraceletDecreaseTab();
        }

        public override void Write_InsertCommandParametersAdd(IContainer container)
        {
            output.autoTab("protected override void InsertCommandParametersAdd(DbCommand cmd, ");
            output.write(classNameTypeLibrary);
            output.writeLine(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (!shouldAddColumnToParameters(column))
                {
                    builderParameterAdd( column);
                }
                else if (column.IsIdentity)
                {
                    builderParameterAddOutputForIdentity( column);
                }
            }

            AtEndCurlyBraceletDecreaseTab();
        }
        public override void builderParameterAdd(IColumn column)
        {
            if (!column.isStringTypeWithoutLength && column.isStringType)
            {
                builderParameterAddStringDbType( column);
            }
            else
            {
                builderParameterAddNormal( column);
            }
        }

        private void builderParameterAddStringDbType(IColumn column)
        {
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ","
                        + Convert.ToString(column.CharacterMaxLength)
                        + ");";
            output.autoTabLn(s);
        }

        private void builderParameterAddOutputForIdentity(IColumn column)
        {
            string variableName = column.Name.ToLowerInvariant();

            string s = "builder.AddParameterOutput(\"" + parameterSymbol
                        + variableName
                        + "\","
                        + getDbTargetType(column)
                        + ");";
            output.autoTabLn(s);
        }

        private void builderParameterAddOutput(IColumn column)
        {
            string s = "builder.AddParameterOutput(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ");";
            output.autoTabLn(s);
        }
        private void builderParameterAddNormal(IColumn column)
        {
            string s = "builder.AddParameter(\"" + parameterSymbol
                        + column.Name
                        + "\","
                        + getDbTargetType(column)
                        + ", row."
                        + utils.getPropertyVariableName(column)
                        + ");";
            output.autoTabLn(s);
        }

        public override void Write_DeleteCommandParametersAdd(IContainer container)
        {
            output.autoTab("protected override void DeleteCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    builderParameterAdd( column);
                }
            }

            AtEndCurlyBraceletDecreaseTab();
        }

        public override void Write_UpdateCommandParametersAdd(IContainer container)
        {
            output.autoTab("protected override void UpdateCommandParametersAdd(DbCommand cmd, ");
            output.autoTab(classNameTypeLibrary);
            output.autoTabLn(" row)");
            AtStartCurlyBraceletIncreaseTab();
            output.autoTabLn("ParameterBuilderOracle builder = (ParameterBuilderOracle)Template.getParameterBuilder();");
            output.autoTabLn("builder.Command = cmd;");

            foreach (IColumn column in container.Columns)
            {
                if (column.IsInPrimaryKey || !shouldAddColumnToParameters(column))
                {
                    builderParameterAdd( column);
                }
                if (isColumnVersionTime(column))
                {
                    builderParameterAdd( column);
                }
            }
            AtEndCurlyBraceletDecreaseTab();
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


    }

}

