

using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Sqlite
{
    public class AdoTemplateSqlite : BaseAdoTemplate<ParameterBuilderSqlite>
    {
        public AdoTemplateSqlite()
        {
            this.DbProviderName = "Microsoft.Data.Sqlite";


        }

        public override bool ExecuteAsExists(String pSql, DbParameter[] pParamList)
        {
            string sqlToExecute = string.Format(@"select exists
                                        (  
                                        {0}
                                        );", pSql);
            object val = this.GetOneValue(sqlToExecute,pParamList);
            int value = Convert.ToInt32(val);
            return value > 0;
        }

        public override bool ExecuteAsExists(string pSql)
        {
            string sqlToExecute = string.Format(@"select exists
                                        (  
                                        {0}
                                        );", pSql);
            object val = this.GetOneValue(sqlToExecute);
            int value = Convert.ToInt32(val);
            return value > 0;
        }


        public override DbDataAdapter getDatabaseAdapter(DbCommand cmd)
        {
            // TODO
            //return null;
            throw new NotImplementedException("Microsoft.Data.Sqlite does not implement DataAdapters.");
        }


    }
}
