using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karkas.Extensions;
namespace Karkas.Core.ElSql.SqlFragments
{
    public abstract class ConditionalSqlFragment : ContainerSqlFragment
    {

        /**
         * The variable.
         */
        private String _variable;
        /**
         * The value to match against.
         */
        private String _matchValue;

        /**
         * Creates an instance.
         * 
         * @param variable  the variable to determine whether to include the AND on, not null
         * @param matchValue  the value to match, null to match on existence
         */
        ConditionalSqlFragment(String variable, String matchValue)
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
            _matchValue = matchValue;
        }

        //-------------------------------------------------------------------------
        /**
         * Gets the variable.
         * 
         * @return the variable, not null
         */
        String getVariable()
        {
            return _variable;
        }

        /**
         * Gets the match value.
         * 
         * @return the match value, not null
         */
        String getMatchValue()
        {
            return _matchValue;
        }

        //-------------------------------------------------------------------------
        protected bool isMatch(SqlParameterSource paramSource, int loopIndex)
        {
            String var = applyLoopIndex(_variable, loopIndex);
            if (paramSource.hasValue(var) == false)
            {
                return false;
            }
            Object value = paramSource.GetValue(var);
            if (_matchValue != null)
            {
                return _matchValue.EqualsIgnoreCase(value.ToString());
            }
            if (value is Boolean)
            {
                return (Boolean)value;
            }
            return true;
        }

        protected bool endsWith(StringBuilder buf, String match)
        {
            String str = (buf.Length >= match.Length ? buf.ToString().Substring(buf.Length - match.Length) : "");
            return str.Equals(match);
        }

        //-------------------------------------------------------------------------

        public override String ToString()
        {
            return GetType().Name + ":" + _variable + " " + getFragments();
        }
    }
}