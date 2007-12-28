using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Simetri.Core.TypeLibrary;
using log4net;

namespace Simetri.Core.DataUtil
{
    /// <summary>
    /// T TypeLibrary Class
    /// M Type of Primary Key of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="M"></typeparam>
    public abstract class BaseDal<T> where T : BaseTypeLibrary, new()
    {
        private static ILog logger = LogManager.GetLogger("Dal");
        public BaseDal()
        {

        }

        private Guid komutuCalistiranKullaniciKisiKey;
        /// <summary>
        /// Dal komutumuzu calistiran kisinin guid olarak key bilgisi.
        /// Login olan kullanicinin Kisi Key'ine setlenmesi gerekir.
        /// Otomatik olarak Bs tarafindan yapilacak
        /// </summary>
        public Guid KomutuCalistiranKullaniciKisiKey
        {
            get { return komutuCalistiranKullaniciKisiKey; }
            set { komutuCalistiranKullaniciKisiKey = value; }
        }



        private SqlConnection connection = new SqlConnection(ConnectionSingleton.Instance.ConnectionString);

        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }


        public int TablodakiSatirSayisi
        {
            get
            {
                AdoTemplate template = new AdoTemplate();
                object o = template.TekDegerGetir(SelectCountString);
                return Convert.ToInt32(o);
            }
        }


        public void Guncelle(T row)
        {
            SorguHariciKomutCalistirUpdate(UpdateString, row);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }
        public void Sil(T row)
        {
            SorguHariciKomutCalistirDelete(DeleteString, row);
            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }

        public void TopluEkleGuncelleVeyaSil(List<T> liste)
        {
            if (liste == null)
            {
                return;
            }
            foreach (T t in liste)
            {
                DurumaGoreEkleGuncelleVeyaSil(t);
            }
        }

        public void DurumaGoreEkleGuncelleVeyaSil(T t)
        {
            switch (t.RowState)
            {
                case DataRowState.Added:
                    Ekle(t);
                    break;
                case DataRowState.Deleted:
                    Sil(t);
                    break;
                case DataRowState.Modified:
                    Guncelle(t);
                    break;
            }
        }
        private void SorguHariciKomutCalistirInternal(SqlCommand cmd)
        {
            try
            {
                Connection.Open();
                logger.Info(new LoggingInfo(komutuCalistiranKullaniciKisiKey, cmd));
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                logger.Info(new LoggingInfo(komutuCalistiranKullaniciKisiKey, cmd), ex);
                ExceptionDegistirici.Degistir(ex, cmd.CommandText);
            }
            finally
            {
                Connection.Close();
            }
        }

        public void Ekle(T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = InsertString;
            cmd.Connection = Connection;
            InsertCommandParametersAdd(cmd, row);
            SorguHariciKomutCalistirInternal(cmd);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }

        protected void SorguHariciKomutCalistirUpdate(string cmdText, T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            UpdateCommandParametersAdd(cmd, row);
            SorguHariciKomutCalistirInternal(cmd);
        }

        protected void SorguHariciKomutCalistirDelete(string cmdText, T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            DeleteCommandParametersAdd(cmd, row);
            SorguHariciKomutCalistirInternal(cmd);
        }

        public void SorguCalistir(List<T> liste)
        {
            SorguCalistir(liste, "");
        }
        public void SorguCalistir(List<T> liste, String pFilterString, SqlParameter[] parameterArray)
        {
            SqlCommand cmd = new SqlCommand();
            if (String.IsNullOrEmpty(pFilterString))
            {
                cmd.CommandText = SelectString;
            }
            else
            {
                cmd.CommandText = String.Format("{0}  WHERE  {1}", SelectString, pFilterString);
            }
            cmd.Connection = Connection;
            foreach (SqlParameter prm in parameterArray)
            {
                cmd.Parameters.Add(prm);
            }
            sorguCalistirInternal(liste, cmd);

        }

        public void SorguCalistir(List<T> liste, String pFilterString)
        {
            SqlCommand cmd = new SqlCommand();
            if (String.IsNullOrEmpty(pFilterString))
            {
                cmd.CommandText = SelectString;
            }
            else
            {
                cmd.CommandText = String.Format("{0}  WHERE  {1}", SelectString, pFilterString);
            }
            cmd.Connection = Connection;
            sorguCalistirInternal(liste, cmd);
        }

        private void sorguCalistirInternal(List<T> liste, SqlCommand cmd)
        {
            SqlDataReader reader = null;
            try
            {
                Connection.Open();
                logger.Debug(new LoggingInfo(komutuCalistiranKullaniciKisiKey, cmd));
                reader = cmd.ExecuteReader();

                T row = default(T);
                while (reader.Read())
                {
                    row = new T();
                    ProcessRow(reader, row);
                    row.RowState = DataRowState.Unchanged;
                    liste.Add(row);
                }

            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, cmd.CommandText);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    Connection.Close();
                }
            }
            return;
        }

        protected abstract string SelectString
        {
            get;
        }
        protected abstract string InsertString
        {
            get;
        }
        protected abstract string UpdateString
        {
            get;
        }
        protected abstract string DeleteString
        {
            get;
        }
        protected abstract string SelectCountString
        {
            get;
        }
        protected abstract bool IdentityVarMi
        {
            get;
        }

        protected abstract bool PkGuidMi
        {
            get;
        }

        protected abstract void ProcessRow(IDataReader dr, T row);
        protected abstract void InsertCommandParametersAdd(SqlCommand Cmd, T row);
        protected abstract void UpdateCommandParametersAdd(SqlCommand Cmd, T row);
        protected abstract void DeleteCommandParametersAdd(SqlCommand Cmd, T row);
    }
}
