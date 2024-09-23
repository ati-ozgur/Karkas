using Karkas.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Data.Oracle
{
    public class ParameterBuilderOracle : ParameterBuilder
    {

        public ParameterBuilderOracle() : this("Oracle.ManagedDataAccess.Client")
        {
            
        }
        public ParameterBuilderOracle(string providerName) : base(providerName)
        {
        }

        private OracleParameter getParameterValue(string parameterName, OracleDbType dbType)
        {
            OracleParameter prm = new OracleParameter();
            prm.ParameterName = parameterName;
            prm.OracleDbType = dbType;
            return prm;
        }
        public void AddParameterOutput(string parameterName, OracleDbType dbType)
        {
            OracleParameter prm = getParameterValue(parameterName, dbType);
            prm.Direction = ParameterDirection.Output;
            AddParameterToCommandOrList(prm);
        }
    }
}
