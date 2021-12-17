using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    /**
     * Representation of paging over an SQL clause.
     */
    public class PagingSqlFragment : ContainerSqlFragment
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
         * @param offsetVariable  the offset variable, not null
         * @param fetchVariable  the fetch variable, not null
         */
        internal PagingSqlFragment(String offsetVariable, String fetchVariable)
        {
            _offsetVariable = offsetVariable;
            _fetchVariable = fetchVariable;
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            int oldLen = buf.Length;
            base.toSQL(buf, bundle, paramSource, loopIndex);
            int newLen = buf.Length;
            String select = buf.ToString().Substring(oldLen, newLen);
            if (select.StartsWith("SELECT "))
            {
                buf.Length = oldLen;
                buf.Append(applyPaging(select, bundle, paramSource));
            }
        }

        /**
         * Applies the paging.
         * 
         * @param selectToPage  the contents of the enclosed block, not null
         * @param bundle  the elsql bundle for context, not null
         * @param paramSource  the SQL parameters, not null
         */
        protected String applyPaging(String selectToPage, ElSqlBundle bundle, SqlParameterSource paramSource)
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
                fetchLimit = int.Parse(_fetchVariable);
            }
            return bundle.getConfig().addPaging(selectToPage, offset, fetchLimit == int.MaxValue ? 0 : fetchLimit);
        }

        //-------------------------------------------------------------------------
        public String ToString()
        {
            return GetType().Name + " " + getFragments();
        }

    }

}
