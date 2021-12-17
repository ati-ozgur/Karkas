using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    // TODO bundan inherit edenleri internal protected yapmayı incele

    public abstract class SqlFragment
    {

        /**
         * Convert this fragment to SQL, appending it to the specified buffer.
         * 
         * @param buf  the buffer to append to, not null
         * @param bundle  the elsql bundle for context, not null
         * @param paramSource  the SQL parameters, not null
         * @param loopIndex  the current loopIndex
         */
        // TODO protected internal???
        public abstract void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex);

        /**
         * Applies the loop index to the string.
         * 
         * @param text  the text to apply to, not null
         * @param loopIndex  the loop index
         * @return the applied text, not null
         */
        protected String applyLoopIndex(String text, int loopIndex)
        {
            return text.Replace("@LOOPINDEX", loopIndex.ToString());
        }
    }
}
