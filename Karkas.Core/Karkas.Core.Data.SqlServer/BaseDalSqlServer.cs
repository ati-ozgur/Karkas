using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Karkas.Core.Data.SqlServer
{
    public abstract class BaseDalSqlServer<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER> : 
        BaseDal<TYPE_LIBRARY_TYPE, ADOTEMPLATE_DB_TYPE, PARAMETER_BUILDER>
        where TYPE_LIBRARY_TYPE : BaseTypeLibrary, new ()
        where ADOTEMPLATE_DB_TYPE : IAdoTemplate<IParameterBuilder>, new()
        where PARAMETER_BUILDER : IParameterBuilder, new()
    {

        private ADOTEMPLATE_DB_TYPE templateSqlServer;
        public override ADOTEMPLATE_DB_TYPE Template
        {
            get
            {
                templateSqlServer = getNewAdoTemplateSqlServer();
                return templateSqlServer;
            }
        }

        protected ADOTEMPLATE_DB_TYPE getNewAdoTemplateSqlServer()
        {
            ADOTEMPLATE_DB_TYPE t = new ADOTEMPLATE_DB_TYPE();
            t.Connection = Connection;
            t.CurrentTransaction = CurrentTransaction;
            t.AutomaticConnectionManagement = AutomaticConnectionManagement;
            t.DbProviderName = DbProviderName;
            return t;
        }


        private SqlParameter getSqlParameter()
        {
            SqlParameter prm = new SqlParameter();
            return prm;
        }
        private DbParameter setParameterValue(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter prm = getSqlParameter();
            prm.ParameterName = parameterName;
            prm.SqlDbType = dbType;
            if (value == null)
            {
                prm.Value = DBNull.Value;
            }
            else
            {
                prm.Value = value;
            }
            return prm;
        }

        public void AddParameter(string parameterName, SqlDbType dbType, object value)
        {
            DbParameter prm = setParameterValue(parameterName, dbType, value);
        }


        public virtual string IdentityParameterName { get;  }

        public override string ParameterCharacter
        {
            get
            {
                return "@";
            }
        }


    }
}