using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
    public class TextSqlFragment : SqlFragment
    {

        /**
         * The text of the fragment.
         */
        private String _text;

        /**
         * Creates an instance with text.
         * 
         * @param text  the text of the fragment, not null
         */
        internal TextSqlFragment(String text, bool endOfLine)
        {
            if (text == null)
            {
                throw new ArgumentException("Text must be specified");
            }
            if (endOfLine)
            {
                text = text.Trim();
                if (text.Length == 0)
                {
                    _text = "";
                }
                else
                {
                    _text = text + " ";
                }
            }
            else
            {
                _text = text;
            }
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            String text = applyLoopIndex(_text, loopIndex);
            buf.Append(text);
        }

        //-------------------------------------------------------------------------

        public override String ToString()
        {
            return GetType().Name + ":" + _text;
        }

    }
}
