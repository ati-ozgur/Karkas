using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karkas.Extensions;

namespace Karkas.Core.ElSql
{

/**
 * Configuration that provides support for differences between databases.
 * <p>
 * The class provides SQL fragments that the tags use to build the complete SQL.
 * Some standard implementations have been provided, but subclasses may be added.
 * <p>
 * Implementations must be thread-safe.
 */
public class ElSqlConfig {

  /**
   * A constant for the standard set of config, based on ANSI SQL.
   */
    public static readonly ElSqlConfig DEFAULT = new ElSqlConfig("Default");
  /**
   * A constant for the config needed for Postgres, the same as {@code DEFAULT}.
   */
  public static readonly  ElSqlConfig POSTGRES = new PostgresElSqlConfig();
  /**
   * A constant for the config needed for HSQL, which escapes the LIKE clause.
   */
  public  static readonly ElSqlConfig HSQL = new HsqlElSqlConfig();
  /**
   * A constant for the config needed for MySQL, which uses LIMIT-OFFSET instead
   * of FETCH-OFFSET.
   */
  public  static readonly  ElSqlConfig MYSQL = new MySqlElSqlConfig();
  /**
   * A constant for the config needed for Oracle RDBMS.
   */
  public  static readonly  ElSqlConfig ORACLE = new OracleElSqlConfig();
  /**
   * A constant for the config needed for SQL Server 2008, which pages in a different way.
   */
  public  static readonly  ElSqlConfig SQL_SERVER_2008 = new SqlServer2008ElSqlConfig();
  /**
   * A constant for the config needed for Vertica, the same as {@code DEFAULT}.
   */
  public static readonly ElSqlConfig VERTICA = new VerticaElSqlConfig();

  /**
   * The descriptive name.
   */
  private String _name;

  /**
   * Creates an instance.
   * 
   * @param name  a descriptive name for the config, not null
   */
  public ElSqlConfig(String name) {
    _name = name;
  }

  /**
   * Gets the config name.
   * 
   * @return the config name, not null
   */
  public String getName() {
    return _name;
  }

  //-------------------------------------------------------------------------
  /**
   * Checks if the value contains a wildcard.
   * <p>
   * The default implementation matches % and _, using backslash as an escape character.
   * This matches Postgres and other databases.
   * 
   * @param value  the value to check, not null
   * @return true if the value contains wildcards
   */
  public bool isLikeWildcard(String value) {
    bool escape = false;
    for (int i = 0; i < value.Length; i++) {
      char ch = value[i];
      if (escape) {
        escape = false;
      } else {
        if (ch == '\\') {
          escape = true;
        } else if (ch == '%' || ch == '_') {
          return true;
        }
      }
    }
    return false;
  }

  /**
   * Gets the suffix to add after LIKE, which would typically be an ESCAPE clause.
   * <p>
   * The default implementation returns an empty string.
   * This matches Postgres and other databases.
   * <p>
   * The returned SQL must be end in a space if non-empty.
   * 
   * @return the suffix to add after LIKE, not null
   */
  public String getLikeSuffix() {
    return "";
  }

  //-------------------------------------------------------------------------
  /**
   * Alters the supplied SQL to add paging, such as OFFSET-FETCH.
   * <p>
   * The default implementation calls {@link #getPaging(int, int)}.
   * <p>
   * The returned SQL must be end in a space if non-empty.
   * 
   * @param selectToPage  the SELECT statement to page, not null
   * @param offset  the OFFSET amount, zero to start from the beginning
   * @param fetchLimit  the FETCH/LIMIT amount, zero to fetch all
   * @return the updated SELECT, not null
   */
  public String addPaging(String selectToPage, int offset, int fetchLimit) {
    return selectToPage + (selectToPage.EndsWith(" ") ? "" : " ") + getPaging(offset, fetchLimit);
  }

  /**
   * Gets the paging SQL, such as OFFSET-FETCH.
   * <p>
   * The default implementation uses 'FETCH FIRST n ROWS ONLY' or
   * 'OFFSET n ROWS FETCH NEXT n ROWS ONLY'.
   * This matches Postgres, HSQL and other databases.
   * <p>
   * The returned SQL must be end in a space if non-empty.
   * 
   * @param offset  the OFFSET amount, zero to start from the beginning
   * @param fetchLimit  the FETCH/LIMIT amount, zero to fetch all
   * @return the SQL to use, not null
   */
  public String getPaging(int offset, int fetchLimit) {
    if (fetchLimit == 0 && offset == 0) {
      return "";
    }
    if (fetchLimit == 0) {
      return "OFFSET " + offset + " ROWS ";
    }
    if (offset == 0) {
      return "FETCH FIRST " + fetchLimit + " ROWS ONLY ";
    }
    return "OFFSET " + offset + " ROWS FETCH NEXT " + fetchLimit + " ROWS ONLY ";
  }

  //-------------------------------------------------------------------------
  public String toString() {
    return "ElSqlConfig[" + _name + "]";
  }

  //-------------------------------------------------------------------------
  /**
   * Class for Postgres.
   */
  private class PostgresElSqlConfig : ElSqlConfig {
    public PostgresElSqlConfig() : base("Postgres") {
    }
  }

  //-------------------------------------------------------------------------
  /**
   * Class for HSQL.
   */
  private class HsqlElSqlConfig : ElSqlConfig {
    public HsqlElSqlConfig():  base("HSQL"){
    }
    public String getLikeSuffix() {
      return "ESCAPE '\\' ";
    }
  }

  //-------------------------------------------------------------------------
  /**
   * Class for MySQL.
   */
  private class MySqlElSqlConfig : ElSqlConfig {
    public MySqlElSqlConfig() :base("MySql") {
    }
    public String getPaging(int offset, int fetchLimit) {
      if (fetchLimit == 0 && offset == 0) {
        return "";
      }
      if (fetchLimit == 0) {
        return "OFFSET " + offset + " ";
      }
      if (offset == 0) {
        return "LIMIT " + fetchLimit + " ";
      }
      return "LIMIT " + fetchLimit + " OFFSET " + offset + " ";
    }
  }

  //-------------------------------------------------------------------------
  /**
   * Class for Oracle RDBMS.
   * Oracle 12c can use the SQL standard verbose OFFSET/FETCH
   * http://www.oracle-base.com/articles/12c/row-limiting-clause-for-top-n-queries-12cr1.php
   */
  private class OracleElSqlConfig : ElSqlConfig {
    public OracleElSqlConfig() :base("Oracle") {
    }
    public String addPaging(String selectToPage, int offset, int fetchLimit) {
      if (fetchLimit == 0 && offset == 0) {
        return selectToPage;
      }
      if (offset == 0 && fetchLimit > 0) {
        return "SELECT * FROM ( " + selectToPage + " ) where rownum <= " + fetchLimit;
      }
      int start = offset;
      int end = offset + fetchLimit;
      return "SELECT * FROM (SELECT  row_.*,rownum rownum_ FROM ( " + selectToPage +
          " ) row_ where rownum <= "+ end +")  WHERE rownum_  > " + start;
    }
    public String getPaging(int offset, int fetchLimit) {
      throw new NotSupportedException();
    }
  }

  //-------------------------------------------------------------------------
  /**
   * Class for SQL server 2008.
   */
  private class SqlServer2008ElSqlConfig : ElSqlConfig {
    public SqlServer2008ElSqlConfig() : base("SqlServer2008") {
    }
    public String addPaging(String selectToPage, int offset, int fetchLimit) {
      if (fetchLimit == 0 && offset == 0) {
        // SQL Server needs a SELECT TOP with ORDER BY in an inner query, otherwise it complains
        return selectToPage.ReplaceFirstOccurance("SELECT ", "SELECT TOP " + Int32.MaxValue + " ");
      }
      int start = offset + 1;
      int end = offset + fetchLimit;
      String columns = selectToPage.Substring(selectToPage.IndexOf("SELECT ") + 7, selectToPage.IndexOf(" FROM "));
      String from = selectToPage.Substring(selectToPage.IndexOf(" FROM ") + 6, selectToPage.IndexOf(" ORDER BY "));
      String order = selectToPage.Substring(selectToPage.IndexOf(" ORDER BY ") + 10);
      String inner = "SELECT " + columns + ", ROW_NUMBER() OVER (ORDER BY " + order.Trim() + ") AS ROW_NUM FROM " + from;
      return "SELECT * FROM (" + inner + ") AS ROW_TABLE WHERE ROW_NUM >= " + start + " AND ROW_NUM <= " + end;
    }
    public String getPaging(int offset, int fetchLimit) {
      throw new NotSupportedException();
    }
  }

  //-------------------------------------------------------------------------
  /**
   * Class for Vertica.
   */
  private class VerticaElSqlConfig : ElSqlConfig {
      public VerticaElSqlConfig()
          : base("Vertica")
      {
    }
  }

}

}
