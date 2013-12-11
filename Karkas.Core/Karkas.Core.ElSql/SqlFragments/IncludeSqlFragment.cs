using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkas.Core.ElSql.SqlFragments
{
public class IncludeSqlFragment : SqlFragment {

  /**
   * The include key.
   */
  private  String _includeKey;

  /**
   * Creates an instance.
   * 
   * @param includeKey  the include key, not null
   */
  IncludeSqlFragment(String includeKey) {
    if (includeKey == null) {
      throw new ArgumentException("Include key must be specified");
    }
    _includeKey = includeKey;
  }

  //-------------------------------------------------------------------------
  /**
   * Gets the include key.
   * 
   * @return the include key, not null
   */
  String getIncludeKey() {
    return _includeKey;
  }

  //-------------------------------------------------------------------------
  
  protected override void toSQL(StringBuilder buf, ElSqlBundle bundle, SqlParameterSource paramSource, int loopIndex) {
    String key = _includeKey;
    if (key.StartsWith(":")) {
      key = paramSource.GetValue(_includeKey.Substring(1)).ToString();
    }
    NameSqlFragment unit = bundle.getFragment(key);
    unit.toSQL(buf, bundle, paramSource, loopIndex);
  }

  //-------------------------------------------------------------------------
  public override String toString() {
    return GetType().Name  + ":" + _includeKey;
  }
}
