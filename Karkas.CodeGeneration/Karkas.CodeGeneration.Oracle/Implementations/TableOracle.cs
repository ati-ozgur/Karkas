using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Karkas.Data;
using System.Data;

using Karkas.CodeGeneration.Helpers.Interfaces;
using Karkas.CodeGeneration.Helpers.PersistenceService;

namespace Karkas.CodeGeneration.Oracle.Implementations
{
    public class TableOracle : ITable
    {

        public TableOracle(CodeGenerationOracle pDatabase, IAdoTemplate<IParameterBuilder> template, String pTableName, String pSchemaName)
        {
            this.database = pDatabase;
            this._template = template;
            this.tableName = pTableName;
            this.schemaName = pSchemaName;
        }

        protected CodeGenerationOracle database;

        public CodeGenerationConfig CodeGenerationConfig
        {
            get
            {
                return database.CodeGenerationConfig;
            }
        }


        IAdoTemplate<IParameterBuilder> _template;
		public IAdoTemplate<IParameterBuilder> Template { get => _template;}


		String tableName;
        String schemaName;


		public IIndex[] FindIndexList()
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
                    IParameterBuilder builder = Template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, Name);
                    builder.AddParameter("schemaName", DbType.String, Schema);
                    Object objResult = Template.GetOneValue(SQL_PRIMARY_KEY, builder.GetParameterArray());
                     primaryKeyColumnCount = (Decimal)objResult;

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
                    columns = new List<IColumn>();
                    IParameterBuilder builder = Template.getParameterBuilder();
                    builder.AddParameter("tableName", DbType.String, Name);
                    builder.AddParameter("schemaName",DbType.String,Schema);

                    var dtColumnList = Template.GetRows(SQL_FOR_COLUMN_LIST, builder.GetParameterArray());
                    foreach (var row in dtColumnList)
                    {
                        string columnName = row["COLUMN_NAME"].ToString();
                        IColumn column = new ColumnOracle(Template,this,columnName);
                        columns.Add(column);
                    }
                }
                return columns;
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


        private const string SQL_FOR_IDENTITY = @"
select COUNT(*) from ALL_TAB_COLS  C
   WHERE
   1 = 1
AND
        C.table_name = :tableName
         AND C.OWNER = :schemaName
         AND C.IDENTITY_COLUMN =  'YES'
";

        private int getIdentityColumnCount()
        {
            IParameterBuilder builder = Template.getParameterBuilder();
            builder.AddParameter("tableName", DbType.String, Name);
            builder.AddParameter("schemaName", DbType.String, Schema);

            int count = (int) Template.GetOneValue(SQL_FOR_IDENTITY, builder.GetParameterArray());
            return count;

        }


        private bool? identityValue;
        public bool IdentityExists
        {
            get
            {
                if(!identityValue.HasValue)
                {
                    identityValue = getIdentityColumnCount() > 0;
                    return identityValue.Value;

                }
                return identityValue.Value;
            }
        }

	}
}
