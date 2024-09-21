using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;

namespace Karkas.Core.Data.Oracle
{
    public class AdoTemplateOracle : AdoTemplate<ParameterBuilderOracle>
    {
        public AdoTemplateOracle()
        {

        }

        public AdoTemplateOracle(string dbProviderName) : base(dbProviderName)
        {
        }

        private string getSqlForExecuteAsExists(string pSql)
        {
            string sqlToExecute = string.Format(@"select count(*) 
                                        from dual 
                                        where exists({0})", pSql);
            return sqlToExecute;
        }
        /// <summary>
        /// Execute given sql statement inside IF EXISTS
        /// If we have value, it return true otherwise false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prmListesi"></param>
        /// <returns></returns>
        public override bool ExecuteAsExists(String pSql, DbParameter[] pParamList)
        {

            object o = GetOneValue(getSqlForExecuteAsExists(pSql),pParamList);
            int value = Convert.ToInt32(o);
            return value > 0;
        }
        public override bool ExecuteAsExists(String pSql)
        {
            object o = GetOneValue(getSqlForExecuteAsExists(pSql));
            int value = Convert.ToInt32(o);
            return value > 0;
        }


    }
}
