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
        private Guid komutuCalistiranKullaniciKisiKey;


        private bool otomatikConnectionYonetimi = true;
        /// <summary>
        /// Eger varsayýlan deger, true býrakýlýrsa, connection yonetimi 
        /// BaseDal tarafýndan yapýlýr. Komutlar cagrýlmadan once, connection getirme
        /// Connection'u acma ve kapama BaseDal kontrolundedir.
        /// Eger false ise connection olusturma, acma Kapama Kullanýcýya aittir.
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
        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        public Guid KomutuCalistiranKullaniciKisiKey
        {
            get { return komutuCalistiranKullaniciKisiKey; }
            set { komutuCalistiranKullaniciKisiKey = value; }
        }
        private static ILog logger = LogManager.GetLogger("Dal");

        private SqlConnection connection = null;
        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SqlConnection(ConnectionSingleton.Instance.ConnectionString);
                }
                return connection;
            }
            set { connection = value; }
        }

        public AdoTemplate()
        {

        }

        private HelperFunctions _helper;
        private HelperFunctions helper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new HelperFunctions(Connection, KomutuCalistiranKullaniciKisiKey);
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
                    _pagingHelper = new PagingHelper(Connection, KomutuCalistiranKullaniciKisiKey);
                }
                return _pagingHelper;
            }
        }

        private object SorguHariciKomutCalistirSonucGetirInternal(SqlCommand cmd)
        {
            object son = 0;
            try
            {
                logger.Info(new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd));
                if (OtomatikConnectionYonetimi)
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
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
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
                logger.Info(new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd));
                if (OtomatikConnectionYonetimi)
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
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
            }
            finally
            {
                if (OtomatikConnectionYonetimi)
                {
                    Connection.Close();
                }
            }
        }
        public object TekDegerGetir(SqlCommand cmd)
        {
            cmd.Connection = Connection;
            object sonuc = 0;
            sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }

        public Object TekDegerGetir(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            object sonuc = 0;
            sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }

        public Object TekDegerGetir(string cmdText, CommandType cmdType, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            cmd.Connection = Connection;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }


        public Object TekDegerGetir(string cmdText, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            foreach (SqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            object sonuc = SorguHariciKomutCalistirSonucGetirInternal(cmd);
            return sonuc;
        }

        public void SorguHariciKomutCalistir(String cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            SorguHariciKomutCalistirInternal(cmd);
        }



        public void SorguHariciKomutCalistir(SqlCommand cmd)
        {
            cmd.Connection = Connection;
            SorguHariciKomutCalistirInternal(cmd);
        }



        public void SorguHariciKomutCalistir(string sql, SqlParameter[] prmListesi)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.CommandType = CommandType.Text;
            foreach (SqlParameter p in prmListesi)
            {
                cmd.Parameters.Add(p);
            }

            SorguHariciKomutCalistirInternal(cmd);

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