

using Karkas.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karkas.Data.Exceptions;



namespace Karkas.Data.Sqlite;

public class AdoTemplateSqlite : BaseAdoTemplate<ParameterBuilderSqlite>
{
    private ExceptionChanger exceptionChanger = new ExceptionChangerSqlite();        
    public AdoTemplateSqlite(): base("Microsoft.Data.Sqlite")
    {

    }

    public override bool ExecuteAsExists(String pSql, DbParameter[] pParamList)
    {
        string sqlToExecute = string.Format(@"select exists
                                    (  
                                    {0}
                                    );", pSql);
        object val = this.GetOneValue(sqlToExecute,pParamList);
        int value = Convert.ToInt32(val);
        return value > 0;
    }

    public override bool ExecuteAsExists(string pSql)
    {
        string sqlToExecute = string.Format(@"select exists
                                    (  
                                    {0}
                                    );", pSql);
        object val = this.GetOneValue(sqlToExecute);
        int value = Convert.ToInt32(val);
        return value > 0;
    }


    public override DbDataAdapter getDatabaseAdapter(DbCommand cmd)
    {
        // TODO
        //return null;
        throw new NotImplementedException("Microsoft.Data.Sqlite does not implement DataAdapters.");
    }


    protected override string getSqlForTopRows(string pSql, int count)
    {
        string sqlToExecute = string.Format(@"
            WITH TOPROWS AS
            ( 
            {0}
            )
            SELECT * FROM TOPROWS LIMIT {1}", pSql, count);
        return sqlToExecute;
    }

    protected override ExceptionChanger CurrentExceptionChanger
    {
        get
        {
            return exceptionChanger;
        }
    }

}

