using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    public class LoopSqlFragment : ContainerSqlFragment
    {

        /**
         * The size variable.
         */
        private String _sizeVariable;

        /**
         * Creates an instance.
         * 
         * @param variable  the variable to determine the loop size, not null
         */
        internal LoopSqlFragment(String variable)
        {
            _sizeVariable = variable;
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            // find loop size
            Object sizeObj = paramSource.GetValue(_sizeVariable);
            int size;
            if (sizeObj is Int32)
            {
                size = ((Int32)sizeObj);
            }
            else if (sizeObj is String)
            {
                size = Convert.ToInt32((String)sizeObj);
            }
            else
            {
                throw new ArgumentException("Loop size variable must be Number or String: " + _sizeVariable);
            }
            // loop
            for (int i = 0; i < size; i++)
            {
                // index
                StringBuilder part = new StringBuilder();
                base.toSQL(part, bundle, paramSource, i);
                int joinIndex = part.ToString().IndexOf("@LOOPJOIN ");
                if (joinIndex >= 0)
                {
                    // TODO
                    throw new NotImplementedException();
                    //if (i >= (size - 1)) {
                    //  part.setLength(joinIndex);
                    //} else {
                    //  part.Delete(joinIndex, joinIndex + 10);
                    //}
                }
                buf.Append(part);
            }
        }

        //-------------------------------------------------------------------------

        public override String ToString()
        {
            return GetType().Name + " " + getFragments();
        }

    }
}
