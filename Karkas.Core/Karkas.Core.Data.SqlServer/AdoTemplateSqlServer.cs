using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;


namespace Karkas.Core.Data.SqlServer
{
    public class AdoTemplateSqlServer : BaseAdoTemplate<ParameterBuilderSqlServer>
    {

        private string getSqlForExecuteAsExists(string pSql)
        {
            string sqlToExecute = string.Format(@"IF EXISTS
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
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

            return (bool)this.GetOneValue(getSqlForExecuteAsExists(pSql)
            , pParamList);
        }
        public override bool ExecuteAsExists(String pSql)
        {
            return (bool)this.GetOneValue(getSqlForExecuteAsExists(pSql));
        }


        private string getSqlForTopRows(string pSql)
        {
            string sqlToExecute = string.Format(@"SELECT 
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
            return sqlToExecute;
        }
        public override List<Dictionary<string, object>> GetTopRows(string sql, int count)
        {
            throw new NotImplementedException();
        }

        public override List<Dictionary<string, object>> GetTopRows(string sql, DbParameter[] parameters, int count)
        {
            throw new NotImplementedException();
        }

    }
}
