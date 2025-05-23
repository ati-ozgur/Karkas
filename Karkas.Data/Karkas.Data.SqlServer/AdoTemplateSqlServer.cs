﻿using Karkas.Data;
using Karkas.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

namespace Karkas.Data.SqlServer;
public class AdoTemplateSqlServer : BaseAdoTemplate<ParameterBuilderSqlServer>
{

    private ExceptionChanger exceptionChanger = new ExceptionChangerSqlServer();
    private const string DB_PROVIDER_ORACLE = "Microsoft.Data.SqlClient";
    public AdoTemplateSqlServer() : base(DB_PROVIDER_ORACLE)
    {
    }

    public AdoTemplateSqlServer(string dbProviderName) : base(dbProviderName)
    {
    }




    private string getSqlForExecuteAsExists(string pSql)
    {
        string sqlToExecute = string.Format(@"IF EXISTS
                                    (
                                    {0}
                                    )
                                    SELECT cast( 1 as bit)
                                    else
                                    SELECT cast( 0 as bit)
                                    ", pSql);
        return sqlToExecute;
    }
	/// <summary>
	/// Execute given sql statement inside IF EXISTS
	/// If we have value, it return true otherwise false
	/// </summary>
	/// <param name="pSql"></param>
	/// <param name="pParamList"></param>
	/// <returns></returns>
	public override bool ExecuteAsExists(String pSql, DbParameter[] pParamList)
    {

        return (bool)this.GetOneValue(getSqlForExecuteAsExists(pSql)
        , pParamList);
    }
    public override bool ExecuteAsExists(String pSql)
    {
        return (bool)this.GetOneValue(getSqlForExecuteAsExists(pSql));
    }

    protected override string getSqlForTopRows(string pSql, int count)
    {
        string sqlToExecute = string.Format(@"
            WITH TOPROWS AS
            (
            {0}
            )
            SELECT TOP {1} * FROM TOPROWS", pSql, count);
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

