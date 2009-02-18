using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Karkas.Core.TypeLibrary;
using log4net;
using Karkas.Core.DataUtil.Exceptions;

namespace Karkas.Core.DataUtil
{
    /// <summary>
    /// T TypeLibrary Class
    /// M Type of Primary Key of T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDal<T> where T : BaseTypeLibrary, new()
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
                this.Template.OtomatikConnectionYonetimi = value;
            }
        }


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





        private SqlConnection connection = null;

        public SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    if (string.IsNullOrEmpty(DatabaseName))
                    {
                        connection = new SqlConnection(ConnectionSingleton.Instance.ConnectionString);
                    }
                    else
                    {
                        connection = new SqlConnection(ConnectionSingleton.Instance.getConnectionString(DatabaseName));
                    }
                }
                return connection;
            }
            set { connection = value; }
        }

        private SqlTransaction currentTransaction;

        public SqlTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }

        public virtual string DatabaseName
        {
            get
            {
                return "";
            }
        }

        private AdoTemplate template;
        public AdoTemplate Template
        {
            get
            {
                template = getNewAdoTemplate();
                return template;
            }
        }

        private AdoTemplate getNewAdoTemplate()
        {
            AdoTemplate t = new AdoTemplate();
            t.Connection = Connection;
            t.CurrentTransaction = currentTransaction;
            t.OtomatikConnectionYonetimi = otomatikConnectionYonetimi;
            return t;
        }



        public virtual int TablodakiSatirSayisi
        {
            get
            {
                object o = getNewAdoTemplate().TekDegerGetir(SelectCountString);
                return Convert.ToInt32(o);
            }
        }


        public virtual void Guncelle(T row)
        {
            SorguHariciKomutCalistirUpdate(UpdateString, row);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }
        public virtual void Sil(T row)
        {
            SorguHariciKomutCalistirDelete(DeleteString, row);
            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
        }


        public virtual void TopluEkleGuncelleVeyaSil(List<T> liste)
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

        public virtual void DurumaGoreEkleGuncelleVeyaSil(T t)
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
        protected int SorguHariciKomutCalistirInternal(SqlCommand cmd)
        {
            int sonucRowSayisi = 0;
            try
            {
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                else if (currentTransaction != null)
                {
                    cmd.Transaction = currentTransaction;
                }
                logger.Info(new LoggingInfo(komutuCalistiranKullaniciKisiKey, cmd));

                sonucRowSayisi = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (currentTransaction != null)
                {
                    currentTransaction.Rollback();
                }
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
            }
            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    Connection.Close();
                }
            }
            return sonucRowSayisi;
        }

        protected bool ConnectionKapatilacakMi()
        {
            return Connection.State != ConnectionState.Closed && OtomatikConnectionYonetimi;
        }

        protected bool ConnectionAcilacakMi()
        {
            return (Connection.State != ConnectionState.Open) && (OtomatikConnectionYonetimi);
        }

        public virtual List<T> SorgulaHepsiniGetir()
        {
            List<T> liste = new List<T>();
            SorguCalistir(liste);
            return liste;
        }
        public virtual List<T> SorgulaForeingKeyIle(string filtre , object oDegeri)
        {
            List<T> liste = new List<T>();
            SorguCalistir(liste,string.Format("{0} = '{1}'",filtre,oDegeri));
            return liste;
        }


        public virtual List<T> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            List<T> liste = new List<T>();
            SorguYardimcisi sy = new SorguYardimcisi();
            int listeUzunluk = pSiraListesi.Length;
            for (int i = 0; i < listeUzunluk; i++)
            {
                if (i + 1 < listeUzunluk)
                {
                    sy.OrderByEkle(pSiraListesi[i], pSiraListesi[i + 1]);
                    i++;
                }
                else
                {
                    sy.OrderByEkle(pSiraListesi[i]);
                }
            }
            // HACK buna daha duzgun bir cozum lazim;
            SorguCalistir(liste, " 1 = 1 " + sy.KriterSonucunuWhereOlmadanGetir());
            return liste;
        }

        protected abstract void identityKolonDegeriniSetle(T pTypeLibrary, long pIdentityKolonValue);

        private long EkleIdentity(T row)
        {
            long sonuc = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = InsertString;
            cmd.Connection = Connection;
            InsertCommandParametersAdd(cmd, row);


            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;

            try
            {
                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                if (CurrentTransaction != null)
                {
                    cmd.Transaction = CurrentTransaction;
                }
                if (IdentityVarMi)
                {
                    logger.Info(new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd));
                    object id_degeri = cmd.ExecuteScalar();
                    sonuc = Convert.ToInt64(id_degeri);
                    identityKolonDegeriniSetle(row, sonuc);
                }
                else
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
            }
            catch (Exception ex)
            {
                logger.Info(ex);
            }

            finally
            {
                if (ConnectionKapatilacakMi())
                {
                    Connection.Close();
                }
            }

            return sonuc;
        }




        public long Ekle(T row)
        {
            if (IdentityVarMi)
            {
                return EkleIdentity(row);
            }
            else
            {
                return EkleNormal(row);
            }
        }


        private long EkleNormal(T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = InsertString;
            cmd.Connection = Connection;
            InsertCommandParametersAdd(cmd, row);
            int sonuc = SorguHariciKomutCalistirInternal(cmd);

            //rowstate'i unchanged yapiyoruz
            row.RowState = DataRowState.Unchanged;
            return sonuc;
        }
        protected void SorguHariciKomutCalistirUpdate(string cmdText, T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            UpdateCommandParametersAdd(cmd, row);
            int kayitSayisi = SorguHariciKomutCalistirInternal(cmd);

            bool updateSonucuBasarisiz = (kayitSayisi == 0);
            // Bu kod TopluEkleGuncelle icinde patlamaya yol acacak,
            // bunu kabul ederek birakiyoruz. Bu tur durumlar icin
            // gerekirse yazilimci kendisi kod yazsin.

            if (updateSonucuBasarisiz)
            {
                throw new AyniAndaKullanimHatasi("Guncellemeye calıstıgınız kayıt daha önce başkası tarafından güncellenmiştir");
            }
        }

        protected void SorguHariciKomutCalistirDelete(string cmdText, T row)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.Connection = Connection;
            DeleteCommandParametersAdd(cmd, row);
            SorguHariciKomutCalistirInternal(cmd);
        }
        public T SorguCalistirTekSatirGetir(String pFilterString)
        {
            List<T> liste = new List<T>();
            SorguCalistir(liste, pFilterString);
            if (liste.Count > 0)
            {
                return liste[0];
            }
            else
            {
                return null;
            }
        }
        public T SorguCalistirTekSatirGetir(String pFilterString, SqlParameter[] parameterArray)
        {
            List<T> liste = new List<T>();
            SorguCalistir(liste, pFilterString, parameterArray);
            if (liste.Count > 0)
            {
                return liste[0];
            }
            else
            {
                return null;
            }
        }

        public void SorguCalistir(List<T> liste)
        {
            SorguCalistir(liste, "");
        }
        public void SorguCalistir(List<T> liste, String pFilterString, SqlParameter[] parameterArray)
        {
            SorguCalistir(liste, pFilterString, parameterArray, true);
        }
        public void SorguCalistir(List<T> liste, String pFilterString, SqlParameter[] parameterArray, bool otomatikWhereEkle)
        {
            SqlCommand cmd = new SqlCommand();
            filreStringiniSetle(pFilterString, otomatikWhereEkle, cmd);
            cmd.Connection = Connection;
            foreach (SqlParameter prm in parameterArray)
            {
                cmd.Parameters.Add(prm);
            }
            sorguCalistirInternal(liste, cmd);

        }

        public void SorguCalistir(List<T> liste, String pFilterString, bool otomatikWhereEkle)
        {
            SqlCommand cmd = new SqlCommand();
            filreStringiniSetle(pFilterString, otomatikWhereEkle, cmd);
            cmd.Connection = Connection;
            sorguCalistirInternal(liste, cmd);
        }

        private void filreStringiniSetle(String pFilterString, bool otomatikWhereEkle, SqlCommand cmd)
        {
            if (String.IsNullOrEmpty(pFilterString))
            {
                cmd.CommandText = SelectString;
            }
            else
            {
                if (otomatikWhereEkle)
                {
                    cmd.CommandText = String.Format("{0}  WHERE  {1}", SelectString, pFilterString);
                }
                else
                {
                    cmd.CommandText = String.Format("{0} {1}", SelectString, pFilterString);
                }
            }
        }

        public void SorguCalistir(List<T> liste, String pFilterString)
        {
            SorguCalistir(liste, pFilterString, true);
        }

        private void sorguCalistirInternal(List<T> liste, SqlCommand cmd)
        {
            SqlDataReader reader = null;
            try
            {

                if (ConnectionAcilacakMi())
                {
                    Connection.Open();
                }
                if (CurrentTransaction != null)
                {
                    cmd.Transaction = CurrentTransaction;
                }
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
                ExceptionDegistirici.Degistir(ex, new LoggingInfo(KomutuCalistiranKullaniciKisiKey, cmd).ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (ConnectionKapatilacakMi())
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


        public class Siralama
        {
            public const string Azalarak = "DESC";
            public const string Artarak = "ASC";
            public const string Ascending = "ASC";
            public const string Descending = "DESC";
        }



    }
}

