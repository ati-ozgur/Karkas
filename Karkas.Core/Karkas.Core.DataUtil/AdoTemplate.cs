using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using log4net;

namespace Karkas.Core.DataUtil
{
    public class AdoTemplate
    {


        private bool otomatikConnectionYonetimi = true;
        /// <summary>
        /// Eger varsayılan deger, true bırakılırsa, connection yonetimi 
        /// BaseDal tarafından yapılır. Komutlar cagrılmadan once, connection getirme
        /// Connection'u acma ve kapama BaseDal kontrolundedir.
        /// Eger false ise connection olusturma, acma Kapama Kullanıcıya aittir.
        /// </summary>
        public bool OtomatikConnectionYonetimi
        {
            get
            {
                return otomatikConnectionYonetimi;
            }
            set
            {
                otomatikConnectionYonetimi = value;
                this.helper.OtomatikConnectionYonetimi = value;
            }
        }

        private bool ConnectionKapatilacakMi()
        {
            return Connection.State != ConnectionState.Closed && OtomatikConnectionYonetimi;
        }

        private bool ConnectionAcilacakMi()
        {
            return (Connection.State != ConnectionState.Open) && (OtomatikConnectionYonetimi);
        }

        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
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


        private SqlConnection connection = null;
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = ConnectionSingleton.Instance.Connection;
                }
                return connection;
            }
            set { connection = value; }
        }

        public AdoTemplate()
        {

        }

        public AdoTemplate(SqlConnection pConnection)
        {
            this.Connection = pConnection;
        }

        public AdoTemplate(string pConnectionString) : this(new SqlConnection(pConnectionString))
        {
            
        }


        private HelperFunctions _helper;
        private HelperFunctions helper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new HelperFunctions(Connection,currentTransaction);
                    _helper.OtomatikConnectionYonetimi = OtomatikConnectionYonetimi;
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
                    _pagingHelper = new PagingHelper(Connection,currentTransaction);
                }
                return _pagingHelper;
            }
        }

        private object SorguHariciKomutCalistirSonucGetirInternal(SqlCommand cmd)
        {
            object son = 0;
            try
            {
                new LoggingInfo( cmd).LogInfo(this.GetType());
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }
                son = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo( cmd).ToString());
            }
            finally
            {
                if (OtomatikConnectionYonetimi)
                {
                    Connection.Close();
                }
            }
            return son;
        }
        private void SorguHariciKomutCalistirInternal(SqlCommand cmd)
        {
            try
            {
                new LoggingInfo(cmd).LogInfo(this.GetType());
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(cmd).ToString());
            }
            finally
            {
                if (OtomatikConnectionYonetimi)
                {
                    Connection.Close();
                }
            }
        }
        /// <summary>
        /// Bu komut Ado.Net'a ait ExecuteScalar komutudur. Eğer sorgu sonucu sadece
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
        public object TekDegerGetir(SqlCommand cmd)
        {
            cmd.Connection = Connection;
            object sonuc = 0;
            sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }



        public Object TekDegerGetir(string cmdText)
        {
            SqlCommand cmd = HelperFunctions.getSqlCommand(cmdText, Connection);
            object sonuc = 0;
            sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }

        public Object TekDegerGetir(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            SqlCommand cmd = HelperFunctions.getSqlCommand(cmdText, Connection);
            cmd.CommandType = cmdType;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }


        public Object TekDegerGetir(string cmdText, SqlParameter[] parameters)
        {
            SqlCommand cmd = HelperFunctions.getSqlCommand(cmdText, Connection);
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }

        public void SorguHariciKomutCalistir(String cmdText)
        {
            SqlCommand cmd = HelperFunctions.getSqlCommand(cmdText, Connection);
            SorguHariciKomutCalistirInternal(cmd);
        }



        public void SorguHariciKomutCalistir(SqlCommand cmd)
        {
            cmd.Connection = Connection;
            SorguHariciKomutCalistirInternal(cmd);
        }



        public void SorguHariciKomutCalistir(string sql, SqlParameter[] prmListesi)
        {
            SqlCommand cmd = HelperFunctions.getSqlCommand(sql, Connection);
            cmd.CommandType = CommandType.Text;
            foreach (SqlParameter p in prmListesi)
            {
                cmd.Parameters.Add(p);
            }

            SorguHariciKomutCalistirInternal(cmd);

        }

        /// <summary>
        /// verilen sql cumlesini IF EXISTS icinde calıstırır, eğer sonuc listesi varsa
        /// true diğer durumda false dondurur.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prmListesi"></param>
        /// <returns></returns>
        public bool VarMiIfExists(String pSql, SqlParameter[] pParamListesi)
        {
            string calistirilacakSql = string.Format(@"IF EXISTS
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
            return (bool)this.TekDegerGetir(calistirilacakSql, pParamListesi);
        }
        /// <summary>
        /// verilen sql cumlesini IF EXISTS icinde calıstırır, eğer sonuc listesi varsa
        /// true diğer durumda false dondurur.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="prmListesi"></param>
        /// <returns></returns>
        public bool VarMiIfExists(String pSql)
        {
            string calistirilacakSql = string.Format(@"IF EXISTS
                                        (  
                                        {0}
                                        )
                                        SELECT cast( 1 as bit)
                                        else
                                        SELECT cast( 0 as bit)
                                        ", pSql);
            return (bool)this.TekDegerGetir(calistirilacakSql);
        }



        #region "DataTable Olusturma Methods"
        public DataTable DataTableOlustur(SqlCommand cmd)
        {
            DataTable dataTable = CreateDataTable();
            cmd.Connection = Connection;
            if (currentTransaction != null)
            {
                cmd.Transaction = currentTransaction;
            }
            helper.SorguCalistir(dataTable, cmd);
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

        public DataTable DataTableOlustur(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable dataTable = CreateDataTable();
            DataTableDoldur(dataTable, sql, commandType, parameters);
            return dataTable;
        }
        public DataTable DataTableOlustur(string sql, SqlParameter[] parameters)
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
            helper.SorguCalistir(dataTable, sql, commandType);
        }
        public void DataTableDoldur(DataTable dataTable, string sql)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text);
        }
        public void DataTableDoldur(DataTable dataTable, string sql, CommandType commandType
                , SqlParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, commandType, parameters);
        }
        public void DataTableDoldur(DataTable dataTable, string sql
                , SqlParameter[] parameters)
        {
            helper.ValidateFillArguments(dataTable, sql);
            helper.SorguCalistir(dataTable, sql, CommandType.Text, parameters);
        }

        #endregion

        #region "DataTable Olustur Sayfalama Yap"

        public DataTable DataTableOlusturSayfalamaYap(string sql
, int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
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
        , int pPageSize, int pStartRowIndex, string pOrderBy, SqlParameter[] parameters)
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

