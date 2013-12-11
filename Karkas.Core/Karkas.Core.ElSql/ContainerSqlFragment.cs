using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql
{
    /**
     * Representation of a list of child units.
     */
    public class ContainerSqlFragment : SqlFragment
    {

        /**
         * The fragments.
         */
        private List<SqlFragment> _fragments = new List<SqlFragment>();

        /**
         * Creates an empty container.
         */
        public ContainerSqlFragment()
        {
        }

        //-------------------------------------------------------------------------
        /**
         * Adds a fragment to the list in the container.
         * 
         * @param childFragment  the child fragment, not null
         */
        public void addFragment(SqlFragment childFragment)
        {
            _fragments.Add(childFragment);
        }

        /**
         * Gets the list of fragments.
         * 
         * @return the unmodifiable list of fragments, not null
         */
        public IList<SqlFragment> getFragments()
        {
            return _fragments.AsReadOnly();
        }

        //-------------------------------------------------------------------------

        public override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex)
        {
            foreach (SqlFragment fragment in _fragments)
            {
                fragment.toSQL(buf, bundle, paramSource, loopIndex);
            }
        }

        //-------------------------------------------------------------------------
        public String toString()
        {
            return getFragments().ToString();
        }

    }
}
