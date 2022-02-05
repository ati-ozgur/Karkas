using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class AdoTemplate
    {
        private string dbProviderName;
        private string connectionString;
        private bool useConnectionSingleton = true;


        public AdoTemplate()
        {

        }
        public AdoTemplate(string dbProviderName)
        {
            this.dbProviderName = dbProviderName;
        }
        public AdoTemplate(string connectionString, string dbProviderName)
        {
            this.connectionString = connectionString;
            this.dbProviderName = dbProviderName;
            this.useConnectionSingleton = false;
        }

        public ParameterBuilder getParameterBuilder()
        {
            return new ParameterBuilder(dbProviderName);

        }


        public DbDataAdapter getDatabaseAdapter(DbCommand cmd)
        {
            DbDataAdapter adapter = DbProviderFactoryHelper.Create(dbProviderName).Factory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter;
        }

        public DbCommand getDatabaseCommand(DbConnection conn)
        {
            DbCommand command = conn.CreateCommand();
            setBindByNameForOracle(command);
            return command;
        }


        public DbCommand getDatabaseCommand(string sql, DbConnection conn)
        {
            DbCommand command = conn.CreateCommand();
            setBindByNameForOracle(command);
            command.CommandText = sql;
            return command;
        }

        private static void setBindByNameForOracle(DbCommand command)
        {
            if (command.GetType().GetProperty("BindByName") != null)
            {
                command.GetType().GetProperty("BindByName").SetValue(command, true, null);
            }
        }




        public String DbProviderName
        {
            get
            {
                return dbProviderName;
            }
            set
            {
                dbProviderName = value;
            }
        }

        private bool automaticConnectionManagement = true;
        /// <summary>
        /// Eger varsayılan deger, true bırakılırsa, connection yonetimi 
        /// BaseDal tarafından yapılır. Komutlar cagrılmadan once, connection getirme
        /// Connection'u acma ve kapama BaseDal kontrolundedir.
        /// Eger false ise connection olusturma, acma Kapama Kullanıcıya aittir.
        /// </summary>
        public bool AutomaticConnectionManagement
        {
            get
            {
                return automaticConnectionManagement;
            }
            set
            {
                automaticConnectionManagement = value;
                this.helper.AutomaticConnectionManagement = value;
            }
        }

        private bool ShouldCloseConnection()
        {
            return Connection.State != ConnectionState.Closed && AutomaticConnectionManagement;
        }

        private bool ShouldOpenConnection()
        {
            return (Connection.State != ConnectionState.Open) && (AutomaticConnectionManagement);
        }

        private DbTransaction currentTransaction;

        public DbTransaction CurrentTransaction
        {
            get
            {
                return currentTransaction;
            }
            set
            {
                currentTransaction = value;
                _helper = null;
                _pagingHelper = null;

            }
        }


        private DbConnection connection = null;
        public DbConnection Connection
        {
            get
            {
                if (this.useConnectionSingleton && connection == null)
                {
                    connection = ConnectionSingleton.Instance.getConnection("Main");
                }
                else if(connectionString != null && dbProviderName!= null)
                {
                    connection = DbProviderFactoryHelper.Create(dbProviderName).Factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                return connection;
            }
            set { connection = value; }
        }


        public string ConnectionString 
        { 
            get
            {
                return connectionString;
            }
            set
            {
                this.connectionString = value;
                this.useConnectionSingleton = false;                
            }
        }



        private HelperFunctions _helper;
        private HelperFunctions helper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new HelperFunctions(this);
                    _helper.AutomaticConnectionManagement = AutomaticConnectionManagement;
                }
                return _helper;
            }
        }

        private PagingHelper _pagingHelper;

        private PagingHelper pagingHelper
        {
            get
            {
                if (_pagingHelper == null)
                {
                    _pagingHelper = new PagingHelper(this);
                }
                return _pagingHelper;
            }
        }

        private object ExecuteNonQueryCommandSonucGetirInternal(DbCommand cmd)
        {
            object son = 0;
            try
            {
                new LoggingInfo(cmd).LogInfo(this.GetType());
                if (ShouldOpenConnection())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }
                son = cmd.ExecuteScalar();
            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (AutomaticConnectionManagement)
                {
                    Connection.Close();
                }
            }
            return son;
        }
        private void ExecuteNonQueryCommandInternal(DbCommand cmd)
        {
            try
            {
                new LoggingInfo(cmd).LogInfo(this.GetType());
                if (ShouldOpenConnection())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }

                cmd.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (AutomaticConnectionManagement)
                {
                    Connection.Close();
                }
            }
        }
        /// <summary>
        /// Bu komut Ado.Net'a ait ExecuteScalar komutudur. Eğer sorgu resultu sadece
        /// tek bir değer dönmesini bekliyorsanız. Örneğin
        /// SELECT COUNT(*) FROM ORTAK.KISI
        /// Bu komutu kullanabilirsiniz. Gelen nesne (object) olarak döndüğü için
        /// cast işlemi yapmanız gerekmektedir.
        /// </summary>
        /// <example>
        /// 
        /// 
        /// </example>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public object BringOneValue(DbCommand cmd)
        {
            cmd.Connection = Connection;
            object result = 0;
            result = ExecuteNonQueryCommandSonucGetirInternal(cmd);
            return result;
        }



        public Object BringOneValue(string cmdText)
        {
            DbCommand cmd = getDatabaseCommand(cmdText, Connection);
            object result;
            result = ExecuteNonQueryCommandSonucGetirInternal(cmd);
            return result;
        }

        public Object BringOneValue(string cmdText, CommandType cmdType, DbParameter[] parameters)
        {
            DbCommand cmd = getDatabaseCommand(cmdText, Connection);
            cmd.CommandType = cmdType;
            foreach (DbParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object result = ExecuteNonQueryCommandSonucGetirInternal(cmd);
            return result;
        }


        public Object BringOneValue(string cmdText, DbParameter[] parameters)
        {
            DbCommand cmd = getDatabaseCommand(cmdText, Connection);
            foreach (DbParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object result = ExecuteNonQueryCommandSonucGetirInternal(cmd);
            return result;
        }

        public void ExecuteNonQueryCommand(String cmdText)
        {
            DbCommand cmd = getDatabaseCommand(cmdText, Connection);
            ExecuteNonQueryCommandInternal(cmd);
        }



        public void ExecuteNonQueryCommand(DbCommand cmd)
        {
            cmd.Connection = Connection;
            ExecuteNonQueryCommandInternal(cmd);
        }



        public void ExecuteNonQueryCommand(string sql, DbParameter[] prmListesi)
        {
            DbCommand cmd = getDatabaseCommand(sql, Connection);
            cmd.CommandType = CommandType.Text;
            foreach (DbParameter p in prmListesi)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteNonQueryCommandInternal(cmd);

        }

        /// <summary>
        /// Execute given sql statement inside IF EXISTS
        /// If we have value, it return true otherwise false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prmListesi"></param>
        /// <returns></returns>
        public bool ExecuteAsIfExists(String pSql, DbParameter[] pParamListesi)
        {
            string sqlToExecute = string.Format(@"IF EXISTS
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
            return (bool)this.BringOneValue(sqlToExecute, pParamListesi);
        }
        /// <summary>
        /// Execute given sql statement inside IF EXISTS
        /// If we have value, it return true otherwise false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prmListesi"></param>
        /// <returns></returns>
        public bool ExecuteAsIfExists(String pSql)
        {
            string sqlToExecute = string.Format(@"IF EXISTS
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
            return (bool)this.BringOneValue(sqlToExecute);
        }

        #region "List of Dictionaries Creation"

        public List<Dictionary<String,Object>> GetListOfDictionary(DbCommand cmd)
        {
            List<Dictionary<string, Object>> liste = new List<Dictionary<string, object>>();
            DbDataReader reader = null;
            try
            {

                if (ShouldOpenConnection())
                {
                    cmd.Connection.Open();
                }
                if (CurrentTransaction != null)
                {
                    cmd.Transaction = CurrentTransaction;
                }
                reader = cmd.ExecuteReader();

                Dictionary<string, Object> row;
                while (reader.Read())
                {
                    row = new Dictionary<string, object>();
                    ProcessRow(reader, row);
                    liste.Add(row);
                }

            }
            catch (DbException ex)
            {
                ExceptionChanger.Degistir(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (ShouldCloseConnection())
                {
                    Connection.Close();
                }
            }

            return liste;
        }

        private void ProcessRow(DbDataReader reader, Dictionary<string, object> row)
        {
            for (int i = 0; i < reader.FieldCount; i++)
			{
                string columnName = reader.GetName(i);
                row.Add(columnName,reader.GetValue(i));
			}
        }

        public List<Dictionary<String, Object>> GetListOfDictionary(string sql)
        {
            DbCommand cmd = getDatabaseCommand(sql, Connection);
            return GetListOfDictionary(cmd);
        }


        public List<Dictionary<String, Object>> GetListOfDictionary(string sql, CommandType commandType)
        {
            DbCommand cmd = getDatabaseCommand(sql, Connection);
            cmd.CommandType = commandType;
            return GetListOfDictionary(cmd);
        }

        public List<Dictionary<String, Object>> GetListOfDictionary(string sql, CommandType commandType, DbParameter[] parameters)
        {
            DbCommand cmd = getDatabaseCommand(sql, Connection);
            cmd.CommandType = commandType;
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            return GetListOfDictionary(cmd);
        }
        public List<Dictionary<String, Object>> GetListOfDictionary(string sql, DbParameter[] parameters)
        {
            DbCommand cmd = getDatabaseCommand(sql, Connection);
            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            return GetListOfDictionary(cmd);
        }





        #endregion



        #region "DataTable Olusturma Methods"
        public DataTable DataTableOlustur(DbCommand cmd)
        {
            DataTable dataTable = CreateDataTable();
            cmd.Connection = Connection;
            if (currentTransaction != null)
            {
                cmd.Transaction = currentTransaction;
            }
            helper.ExecuteQuery(dataTable, cmd);
            return dataTable;
        }



        public DataTable DataTableOlustur(string sql, CommandType commandType)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, commandType);
            return dataTable;
        }
        public DataTable DataTableOlustur(string sql)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, CommandType.Text);
            return dataTable;
        }

        public DataTable DataTableOlustur(string sql, CommandType commandType, DbParameter[] parameters)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, commandType, parameters);
            return dataTable;
        }
        public DataTable DataTableOlustur(string sql, DbParameter[] parameters)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, CommandType.Text, parameters);
            return dataTable;
        }





        #endregion

        #region "DataTable Doldurma Methodlari"
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.ExecuteQuery(dataTable, sql, commandType);
        }
        public void DataTableDoldur(DataTable dataTable, string sql)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.ExecuteQuery(dataTable, sql, CommandType.Text);
        }
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType
                , DbParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.ExecuteQuery(dataTable, sql, commandType, parameters);
        }
        public void DataTableDoldur(DataTable dataTable, string sql
                , DbParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.ExecuteQuery(dataTable, sql, CommandType.Text, parameters);
        }

        #endregion

        #region "DataTable Olustur Sayfalama Yap"

        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters)
        {
            return pagingHelper.DataTableOlusturSayfalamaYap(sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
        }


        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            return pagingHelper.DataTableOlusturSayfalamaYap(sql, pPageSize, pStartRowIndex, pOrderBy);
        }




        #endregion

        #region "DataTable Doldur Sayfalama Yap"

        public void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
        , int pPageSize, int pStartRowIndex, string pOrderBy, DbParameter[] parameters)
        {
            pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy, parameters);
        }


        public void DataTableDoldurSayfalamaYap(DataTable dataTable, string sql
                , int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            pagingHelper.DataTableDoldurSayfalamaYap(dataTable, sql, pPageSize, pStartRowIndex, pOrderBy);
        }



        #endregion


        #region "Helpers"


        protected virtual DataTable CreateDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Locale = CultureInfo.InvariantCulture;
            return dataTable;
        }

        protected virtual DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            return dataSet;
        }

        #endregion

    }
}

