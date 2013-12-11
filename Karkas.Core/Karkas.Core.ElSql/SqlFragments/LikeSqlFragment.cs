using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    /**
     * Representation of LIKE(variable).
     * <p>
     * This handles switching between LIKE and = based on the presence of wildcards.
     */
    public class LikeSqlFragment : ContainerSqlFragment
    {

        /**
         * The variable.
         */
        private String _variable;

        /**
         * Creates an instance.
         * 
         * @param variable  the variable to base the LIKE on, not null
         */
        LikeSqlFragment(String variable)
        {
            if (variable == null)
            {
                throw new ArgumentException("Variable must be specified");
            }
            if (variable.StartsWith(":") == false || variable.Length < 2)
            {
                throw new ArgumentException("Argument is not a variable (starting with a colon)");
            }
            _variable = variable.Substring(1);
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            String var = applyLoopIndex(_variable, loopIndex);
            Object val = paramSource.GetValue(var);
            String value = (val == null ? "" : val.ToString());
            if (bundle.getConfig().isLikeWildcard(value))
            {
                buf.Append("LIKE ");
                base.toSQL(buf, bundle, paramSource, loopIndex);
                buf.Append(bundle.getConfig().getLikeSuffix());
            }
            else
            {
                buf.Append("= ");
                base.toSQL(buf, bundle, paramSource, loopIndex);
            }
        }

        //-------------------------------------------------------------------------

        public String ToString()
        {
            return GetType().Name + ":" + _variable + " " + getFragments();
        }

    }
}
