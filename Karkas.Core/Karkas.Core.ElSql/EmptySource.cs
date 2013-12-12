using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql
{
  //-------------------------------------------------------------------------
  /**
   * An empty parameter source.
   * Using this reduces coupling with the Spring librray.
   */
  internal  class EmptySource : SqlParameterSource {

      internal bool hasValue(String field)
      {
      return false;
    }


    internal int getSqlType(String field)
    {
      return TYPE_UNKNOWN;
    }


    internal override String getTypeName(String field)
    {
      throw new ArgumentException();
    }


    internal override Object GetValue(String field)
    {
      return null;
    }
  }
}
