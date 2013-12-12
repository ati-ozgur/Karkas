using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    /**
     * Representation of OFFSETFETCH.
     * <p>
     * This outputs an OFFSET-FETCH type clauses.
     */
    public class OffsetFetchSqlFragment : ContainerSqlFragment
    {

        /**
         * The offset variable.
         */
        private String _offsetVariable;
        /**
         * The fetch variable or numeric amount.
         */
        private String _fetchVariable;

        /**
         * Creates an instance.
         * 
         * @param fetchVariable  the fetch variable, not null
         */
        internal OffsetFetchSqlFragment(String fetchVariable)
        {
            _offsetVariable = null;
            _fetchVariable = fetchVariable;
        }

        /**
         * Creates an instance.
         * 
         * @param offsetVariable  the offset variable, not null
         * @param fetchVariable  the fetch variable, not null
         */
        internal OffsetFetchSqlFragment(String offsetVariable, String fetchVariable)
        {
            _offsetVariable = offsetVariable;
            _fetchVariable = fetchVariable;
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            int offset = 0;
            int fetchLimit = 0;
            if (_offsetVariable != null && paramSource.hasValue(_offsetVariable))
            {
                offset = ((int)paramSource.GetValue(_offsetVariable));
            }
            if (paramSource.hasValue(_fetchVariable))
            {
                fetchLimit = ((int)paramSource.GetValue(_fetchVariable));
            }
            else if (Regex.IsMatch(_fetchVariable, "[0-9]+"))
            {
                fetchLimit = Convert.ToInt32(_fetchVariable);
            }
            buf.Append(bundle.getConfig().getPaging(offset, fetchLimit == int.MaxValue ? 0 : fetchLimit));
        }

        //-------------------------------------------------------------------------
        public String ToString()
        {
            return GetType().Name + " " + getFragments();
        }

    }

}
