using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    public class ValueSqlFragment : SqlFragment
    {

        /**
         * The variable to output.
         */
        private String _valueVariable;

        /**
         * Creates an instance.
         * 
         * @param valueVariable  the value variable, not null
         */
        internal ValueSqlFragment(String valueVariable)
        {
            if (valueVariable == null)
            {
                throw new ArgumentException("Variable must be specified");
            }
            _valueVariable = valueVariable;
        }

        //-------------------------------------------------------------------------
        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            String var = applyLoopIndex(_valueVariable, loopIndex);
            Object value = paramSource.GetValue(var);
            buf.Append(value);
        }

        //-------------------------------------------------------------------------
        public String toString()
        {
            return GetType().Name + ":" + _valueVariable;
        }
    }
}
