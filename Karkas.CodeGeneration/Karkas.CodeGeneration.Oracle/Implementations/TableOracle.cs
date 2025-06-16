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




		private const String SQL_INDEX_COLUMNS = @" SELECT  TABLE_NAME, INDEX_NAME,
		COLUMN_NAME AS ""name""
		, COLUMN_POSITION
FROM   ALL_IND_COLUMNS T
WHERE
T.INDEX_NAME = '{0}'
AND T.TABLE_NAME = '{1}'
AND T.TABLE_OWNER = '{2}'
ORDER BY T.COLUMN_POSITION
";


		public string getSQL_Index_Columns(string indexName)
		{
			return string.Format(SQL_INDEX_COLUMNS, indexName,Name,Schema);
		}

		public string getSQL_Index_Names()
		{
			return string.Format(SQL_INDEX_NAMES, Name, Schema);
		}

		private const String SQL_INDEX_NAMES = @"SELECT INDEX_NAME AS ""name"",(CASE
	WHEN T.UNIQUENESS = 'UNIQUE' THEN 1
	ELSE 0
END
) AS ""unique""
FROM ALL_INDEXES T
WHERE TABLE_NAME = '{0}'
AND TABLE_OWNER = '{1}'
";
		public string SQL_Index_Names { get { return SQL_INDEX_NAMES; } }
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
WITH
FUNCTION GET_VARCHAR_DATA_DEFAULT(p_schema_name IN varchar2,p_table_name IN varchar2,p_column_name IN varchar2) RETURN varchar2 IS s_data_default varchar2(1000);
BEGIN
		select C.data_default into s_data_default
		FROM ALL_TAB_COLS C
		WHERE
		C.table_name = p_table_name
		 AND C.OWNER = p_schema_name
		 AND C.COLUMN_NAME =  p_column_name;
		return s_data_default;
END;
QUERY_DATA_DEFAULT AS
(
SELECT table_name, column_name,
LOWER(GET_VARCHAR_DATA_DEFAULT(C.OWNER,C.table_name,C.column_name)) AS data_default
FROM all_tab_columns C
WHERE
C.table_name = :tableName
AND C.OWNER = :schemaName
AND C.data_default IS NOT NULL
AND C.IDENTITY_COLUMN !=  'YES'
)
SELECT
(SELECT COUNT(*) FROM QUERY_DATA_DEFAULT WHERE DATA_DEFAULT LIKE '%nextval_')
+
(select COUNT(*) from ALL_TAB_COLS  C
   WHERE
   1 = 1
AND
        C.table_name = :tableName
         AND C.OWNER = :schemaName
         AND C.IDENTITY_COLUMN =  'YES')
FROM DUAL;
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
