using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Data;


using Karkas.Data;


namespace Karkas.Data.Oracle;

public class AdoTemplateOracle : BaseAdoTemplate<ParameterBuilderOracle>
{
    private const string DB_PROVIDER_ORACLE = "Oracle.ManagedDataAccess.Client";
    public AdoTemplateOracle() : base(DB_PROVIDER_ORACLE)
    {
    }

    public AdoTemplateOracle(string dbProviderName) : base(dbProviderName)
    {
    }

    private string getSqlForExecuteAsExists(string pSql)
    {
        string sqlToExecute = string.Format(@"select count(*) 
                                    from dual 
                                    where exists({0})", pSql);
        return sqlToExecute;
    }
    /// <summary>
    /// Execute given sql statement inside IF EXISTS
    /// If we have value, it return true otherwise false
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="prmListesi"></param>
    /// <returns></returns>
    public override bool ExecuteAsExists(String pSql, DbParameter[] pParamList)
    {

        object o = GetOneValue(getSqlForExecuteAsExists(pSql),pParamList);
        int value = Convert.ToInt32(o);
        return value > 0;
    }
    public override bool ExecuteAsExists(String pSql)
    {
        object o = GetOneValue(getSqlForExecuteAsExists(pSql));
        int value = Convert.ToInt32(o);
        return value > 0;
    }

    public override DbCommand getDatabaseCommand(DbConnection conn)
    {
        DbCommand command = conn.CreateCommand();
        setBindByName(command);
        return command;
    }

    // TODO look if I could move this one to OracleAdoTemplate
    private void setBindByName(DbCommand command)
    {
        if (command.GetType().GetProperty("BindByName") != null)
        {
            command.GetType().GetProperty("BindByName").SetValue(command, true, null);
        }
    }


    public override string ParameterSymbol
    {
        get { return ":"; }
    }


}

