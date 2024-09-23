using Karkas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.Data.Sqlite
{
    public class ParameterBuilderSqlite : ParameterBuilder
    {

        public ParameterBuilderSqlite() : this("Microsoft.Data.Sqlite")
        {

        }

        public ParameterBuilderSqlite(string providerName) : base(providerName)
        {
        }
    }
}
