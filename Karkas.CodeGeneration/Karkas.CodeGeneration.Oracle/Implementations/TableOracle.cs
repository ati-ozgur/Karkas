using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.Core.DataUtil;
using System.Data;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class TableOracle : ITable
    {

        public TableOracle(DatabaseOracle pDatabase, AdoTemplate template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this.template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        DatabaseOracle database;

        AdoTemplate template;
        String tableName;
        String schemaName;

        public int findIndexFromName(string name)
        {
            throw new NotImplementedException();
        }
        private const string SQL_PRIMARY_KEY = @" SELECT
  COUNT(*)
    FROM all_constraints cons
    INNER JOIN 
    all_cons_columns cols
ON
   cons.constraint_name = cols.constraint_name
AND cons.owner = cols.owner
   WHERE     cols.table_name = :tableName
         AND COLS.OWNER = :schemaName
         AND cons.constraint_type = 'P'
         ";

        private Decimal? primaryKeyColumnCount = null;
        public int PrimaryKeyColumnCount
        {
            get 
            {
                if (!primaryKeyColumnCount.HasValue)
                {
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Name);
                    builder.parameterEkle("schemaName", DbType.String, Schema);
                    Object objSonuc = template.TekDegerGetir(SQL_PRIMARY_KEY, builder.GetParameterArray());
                     primaryKeyColumnCount = (Decimal)objSonuc;

                }
                return (int) primaryKeyColumnCount.Value;

            }
        }

        public bool HasPrimaryKey
        {
            get { return PrimaryKeyColumnCount > 0; }
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public List<IColumn> columns = null;


        private const string SQL_FOR_COLUMN_LIST = @"select owner, column_name from all_tab_columns 
where 
table_name = :tableName
AND
OWNER = :schemaName
";

        public List<IColumn> Columns
        {
            get 
            {
                if (columns == null)
                {
                    ParameterBuilder builder = template.getParameterBuilder();
                    builder.parameterEkle("tableName", DbType.String, Name);
                    builder.parameterEkle("schemaName",DbType.String,Schema);

                    DataTable dtColumnList = template.DataTableOlustur(SQL_FOR_COLUMN_LIST, builder.GetParameterArray());
                    columns = new List<IColumn>();
                    foreach (DataRow row in dtColumnList.Rows)
                    {
                        string columnName = row["column_name"].ToString();
                        IColumn column = new ColumnOracle(template,this,columnName);
                        columns.Add(column);
                    }
                }
                return columns;
            }
        }

        public IDatabase Database
        {
            get 
            {
                return database;
            
            }
        }

        public DateTime DateCreated
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime DateModified
        {
            get { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return tableName; }
        }

        public string Schema
        {
            get { return schemaName; }
        }

        public bool IdentityVarmi
        {
            get
            {
                // There is no identity in Oracle
                return false;
            }
        }

    }
}
