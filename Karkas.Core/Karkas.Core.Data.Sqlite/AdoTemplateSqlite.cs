

using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Sqlite
{
    public class AdoTemplateSqlite : AdoTemplate<ParameterBuilderSqlite>
    {
        public AdoTemplateSqlite()
        {
            this.DbProviderName = "Microsoft.Data.Sqlite";


        }

        public override DbDataAdapter getDatabaseAdapter(DbCommand cmd)
        {
            // TODO
            //return null;
            throw new NotImplementedException("Microsoft.Data.Sqlite does not implement DataAdapters.");
        }


    }
}
