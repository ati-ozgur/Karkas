using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql
{
    public class SqlParameterSource
    {
        public const int TYPE_UNKNOWN = -1; 
        internal virtual object GetValue(string var)
        {
            throw new NotImplementedException();
        }

        internal virtual bool hasValue(string var)
        {
            throw new NotImplementedException();
        }
        internal virtual String getTypeName(String field)
        {
            throw new NotImplementedException();
        }

    }
}
