using System.Data;
using System.Data.Common;

namespace Karkas.Data;

public interface IAdoTemplate<IParameterBuilder>
{
    bool AutomaticConnectionManagement { get; set; }
    DbConnection Connection { get; set; }
    string ConnectionString { get; set; }
    DbTransaction CurrentTransaction { get; set; }
    string DbProviderName { get; set; }

    object GetOneValue(DbCommand cmd);
    object GetOneValue(string cmdText);
    object GetOneValue(string cmdText, CommandType cmdType, DbParameter[] parameters);
    object GetOneValue(string cmdText, DbParameter[] parameters);
    void FillDataTable(DataTable dataTable, string sql);
    void FillDataTable(DataTable dataTable, string sql, CommandType commandType);
    void FillDataTable(DataTable dataTable, string sql, CommandType commandType, DbParameter[] parameters);
    void FillDataTable(DataTable dataTable, string sql, DbParameter[] parameters);
    void FillDataTableWithPaging(DataTable dataTable, string sql, int pPageSize, int pStartRowIndex, string pOrderBy);
    void FillDataTableWithPaging(DataTable dataTable, string sql, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters);
    DataTable CreateDataTable(DbCommand cmd);
    DataTable CreateDataTable(string sql);
    DataTable CreateDataTable(string sql, CommandType commandType);
    DataTable CreateDataTable(string sql, CommandType commandType, DbParameter[] parameters);
    DataTable CreateDataTable(string sql, DbParameter[] parameters);
    DataTable CreateDataTableWithPaging(string sql, int pPageSize, int pStartRowIndex, string pOrderBy);
    DataTable CreateDataTableWithPaging(string sql, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters);
    bool ExecuteAsExists(string pSql);
    bool ExecuteAsExists(string pSql, DbParameter[] pParamListesi);
    int ExecuteNonQueryCommand(DbCommand cmd);
    int ExecuteNonQueryCommand(string cmdText);
    int ExecuteNonQueryCommand(string sql, DbParameter[] prmListesi);
    DbDataAdapter getDatabaseAdapter(DbCommand cmd);
    DbCommand getDatabaseCommand(DbConnection conn);
    DbCommand getDatabaseCommand(string sql, DbConnection conn);

    List<Dictionary<string, object>> GetTopRows(string sql, int count);
    List<Dictionary<string, object>> GetTopRows(string sql, DbParameter[] parameters, int count);

    Dictionary<string, object> GetOneRow(string sql);
    Dictionary<string, object> GetOneRow(string sql, DbParameter[] parameters);


    List<Dictionary<string, object>> GetRows(DbCommand cmd);
    List<Dictionary<string, object>> GetRows(string sql);
    List<Dictionary<string, object>> GetRows(string sql, CommandType commandType);
    List<Dictionary<string, object>> GetRows(string sql, CommandType commandType, DbParameter[] parameters);
    List<Dictionary<string, object>> GetRows(string sql, DbParameter[] parameters, int? timeout = null);


    IParameterBuilder getParameterBuilder();


    string ParameterSymbol
    {
        get;
    }
}
