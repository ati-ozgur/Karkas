using Karkas.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Data.SqlServer
{
    public class ParameterBuilderSqlServer : ParameterBuilder
    {
        
        public ParameterBuilderSqlServer() : base(ConstantsSqlServer.DbProviderName)
        {
        }

        private SqlParameter setParameterValue(string parameterName, SqlDbType dbType, object value)
        {
            SqlParameter prm = getSqlClientDbParamater();
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
            AddParameterToCommandOrList(prm);
        }

        public void AddParameter(string parameterName, SqlDbType dbType, object value, int size)
        { 
            DbParameter prm = setParameterValue(parameterName, dbType, value);
            prm.Size = size;
            AddParameterToCommandOrList(prm);
        }


        private SqlParameter getSqlClientDbParamater()
        {
            SqlParameter prm = new SqlParameter();
            //SqlParameter prm = SqlClientFactory.Instance.CreateParameter()

            return prm;
        }
    }
}
