using Karkas.Core.DataUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Sqlite
{
    public class ParameterBuilderSqlite : ParameterBuilder
    {

        public ParameterBuilderSqlite() : this("System.Data.SQLite")
        {

        }

        public ParameterBuilderSqlite(string providerName) : base(providerName)
        {
        }
    }
}
