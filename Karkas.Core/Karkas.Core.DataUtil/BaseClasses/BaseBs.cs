using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using System.Data.SqlClient;
using System.Data;

namespace Karkas.Core.DataUtil
{
    public abstract class BaseBs<TYPE_LIBRARY_TIPI, DAL_TIPI> : BaseBsWithoutEntity
        where TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DAL_TIPI : BaseDal<TYPE_LIBRARY_TIPI>, new()
    {




        public DIGER_DAL_TIPI GetDalInstance<DIGER_DAL_TIPI, DIGER_TYPE_LIBRARY_TIPI>()
            where DIGER_TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
            where DIGER_DAL_TIPI : BaseDal<DIGER_TYPE_LIBRARY_TIPI>, new()
        {
            DIGER_DAL_TIPI di = new DIGER_DAL_TIPI();
            di.Connection = Connection;
            di.IsInTransaction = IsInTransaction;
            if (IsInTransaction)
            {
                di.OtomatikConnectionYonetimi = false;
                di.CurrentTransaction = transaction;
            }
            return di;
        }






        public BaseBs()
        {
            dal = new DAL_TIPI();
            dal.Connection = Connection;
        }




        protected DAL_TIPI dal = new DAL_TIPI();

        protected override BaseDalWithoutEntity Dal
        {
            get { return dal; }
        }

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

        public List<T1> SorgulaDetayTabloGetir<T1>(object degeri) where T1 : new()
        {
            return dal.SorgulaDetayTabloGetir<T1>(degeri);
        }
        public virtual List<TYPE_LIBRARY_TIPI> SorgulaKolonIsmiIle(string filtre, object oDegeri)
        {
            return dal.SorgulaKolonIsmiIle(filtre, oDegeri);
        }

        public virtual List<TYPE_LIBRARY_TIPI> SorgulaKolonIsmiIle(List<string> filtreListesi, List<object> degerListesi)
        {
            return dal.SorgulaKolonIsmiIle(filtreListesi, degerListesi);
        }
        public virtual List<TYPE_LIBRARY_TIPI> SorgulaKolonIsmiIle(string[] filtreListesi, object[] degerListesi)
        {
            return dal.SorgulaKolonIsmiIle(filtreListesi, degerListesi);
        }



    }

}

