using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Oracle
{
    public class ParameterBuilderOracle : ParameterBuilder
    {

        public ParameterBuilderOracle() : this("Oracle.ManagedDataAccess.Client")
        {
            
        }
        public ParameterBuilderOracle(string providerName) : base(providerName)
        {
        }
    }
}
