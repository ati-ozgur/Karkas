using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    /**
     * Representation of AND(expression).
     * <p>
     * This outputs an AND clause if the expression is true.
     * It also avoids outputting AND if the last thing in the buffer is WHERE.
     */
    public class AndSqlFragment : ConditionalSqlFragment
    {

        /**
         * Creates an instance.
         * 
         * @param variable  the variable to determine whether to include the AND on, not null
         * @param matchValue  the value to match, null to match on existence
         */
        internal AndSqlFragment(String variable, String matchValue)
            : base(variable, matchValue)
        {

        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            if (isMatch(paramSource, loopIndex))
            {
                if (endsWith(buf, " WHERE ") == false && endsWith(buf, " AND ") == false)
                {
                    buf.Append("AND ");
                }
                base.toSQL(buf, bundle, paramSource, loopIndex);
            }
        }

    }
}

