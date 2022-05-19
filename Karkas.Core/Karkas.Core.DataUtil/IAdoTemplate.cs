using System.Data;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public interface IAdoTemplate
    {
        bool AutomaticConnectionManagement { get; set; }
        DbConnection Connection { get; set; }
        string ConnectionString { get; set; }
        DbTransaction CurrentTransaction { get; set; }
        string DbProviderName { get; set; }

        object BringOneValue(DbCommand cmd);
        object BringOneValue(string cmdText);
        object BringOneValue(string cmdText, CommandType cmdType, DbParameter[] parameters);
        object BringOneValue(string cmdText, DbParameter[] parameters);
        void DataTableDoldur(DataTable dataTable, string sql);
        void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType);
        void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType, DbParameter[] parameters);
        void DataTableDoldur(DataTable dataTable, string sql, DbParameter[] parameters);
        void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql, int pPageSize, int pStartRowIndex, string pOrderBy);
        void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters);
        DataTable DataTableOlustur(DbCommand cmd);
        DataTable DataTableOlustur(string sql);
        DataTable DataTableOlustur(string sql, CommandType commandType);
        DataTable DataTableOlustur(string sql, CommandType commandType, DbParameter[] parameters);
        DataTable DataTableOlustur(string sql, DbParameter[] parameters);
        DataTable DataTableOlusturSayfalamaYap(string sql, int pPageSize, int pStartRowIndex, string pOrderBy);
        DataTable DataTableOlusturSayfalamaYap(string sql, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters);
        bool ExecuteAsIfExists(string pSql);
        bool ExecuteAsIfExists(string pSql, DbParameter[] pParamListesi);
        void ExecuteNonQueryCommand(DbCommand cmd);
        void ExecuteNonQueryCommand(string cmdText);
        void ExecuteNonQueryCommand(string sql, DbParameter[] prmListesi);
        DbDataAdapter getDatabaseAdapter(DbCommand cmd);
        DbCommand getDatabaseCommand(DbConnection conn);
        DbCommand getDatabaseCommand(string sql, DbConnection conn);
        List<Dictionary<string, object>> GetListOfDictionary(DbCommand cmd);
        List<Dictionary<string, object>> GetListOfDictionary(string sql);
        List<Dictionary<string, object>> GetListOfDictionary(string sql, CommandType commandType);
        List<Dictionary<string, object>> GetListOfDictionary(string sql, CommandType commandType, DbParameter[] parameters);
        List<Dictionary<string, object>> GetListOfDictionary(string sql, DbParameter[] parameters);
        ParameterBuilder getParameterBuilder();
    }
}