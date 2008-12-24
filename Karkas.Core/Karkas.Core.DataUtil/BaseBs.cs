using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.Core.DataUtil
{
    public abstract class BaseBs<TYPE_LIBRARY_TIPI, DAL_TIPI>
        where TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DAL_TIPI : BaseDal<TYPE_LIBRARY_TIPI>, new()
    {

        private bool isInTransaction = false;
        public bool IsInTransaction
        {
            get
            {
                return isInTransaction;
            }
            set
            {
                isInTransaction = value;
                if (value)
                {
                    this.dal.OtomatikConnectionYonetimi = false;
                    dal.CurrentTransaction = transaction;

                }
            }
        }



        public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI>, new()
        {
            DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
            di.Connection = connection;
            if (isInTransaction)
            {
                di.OtomatikConnectionYonetimi = false;
                di.CurrentTransaction = transaction;
            }
            return di;
        }


        private SqlTransaction transaction;
        public void BeginTransaction()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                transaction = connection.BeginTransaction();
            }
            IsInTransaction = true;
        }
        public void CommitTransaction()
        {
            transaction.Commit();
        }
        public void ClearTransactionInformation()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            IsInTransaction = false;
            this.dal.OtomatikConnectionYonetimi = true;
        }

        private SqlConnection connection;
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

        public BaseBs()
        {
            dal = new DAL_TIPI();
            dal.Connection = Connection;
        }

        public virtual string DatabaseName
        {
            get
            {
                return "";
            }
        }


        protected DAL_TIPI dal = new DAL_TIPI();
        public long Ekle(TYPE_LIBRARY_TIPI k)
        {
            return dal.Ekle(k);
        }
        public void Guncelle(TYPE_LIBRARY_TIPI k)
        {
            dal.Guncelle(k);
        }
        public void Sil(TYPE_LIBRARY_TIPI k)
        {
            dal.Sil(k);
        }
        public void DurumaGoreEkleGuncelleVeyaSil(TYPE_LIBRARY_TIPI k)
        {
            dal.DurumaGoreEkleGuncelleVeyaSil(k);
        }
        public List<TYPE_LIBRARY_TIPI> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }
        public List<TYPE_LIBRARY_TIPI> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
        }
        public void TopluEkleGuncelleVeyaSil(List<TYPE_LIBRARY_TIPI> liste)
        {
            dal.TopluEkleGuncelleVeyaSil(liste);
        }
        public int TablodakiSatirSayisi
        {
            get
            {
                return dal.TablodakiSatirSayisi;
            }
        }
        public Guid KomutuCalistiranKullaniciKisiKey
        {
            get
            {
                return dal.KomutuCalistiranKullaniciKisiKey;
            }
            set
            {
                dal.KomutuCalistiranKullaniciKisiKey = value;
            }
        }
    }

}
