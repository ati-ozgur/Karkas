using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    /**
     * Representation of WHERE.
     * <p>
     * This outputs a WHERE clause if at least one child was output.
     */
    public class WhereSqlFragment : ContainerSqlFragment
    {

        /**
         * Creates an instance.
         */
        internal WhereSqlFragment()
        {
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            int oldLen = buf.Length;
            buf.Append("WHERE ");
            int newLen = buf.Length;
            base.toSQL(buf, bundle, paramSource, loopIndex);
            if (buf.Length == newLen)
            {
                buf.Length = oldLen;
            }
        }

        //-------------------------------------------------------------------------
        public String ToString()
        {
            return GetType().Name + " " + getFragments();
        }

    }

}
