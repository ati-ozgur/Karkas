
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
	public partial class 	BasitTabloIdentityBs
 
    {
        BasitTabloIdentityDal dal = new BasitTabloIdentityDal();
        public void Ekle(BasitTabloIdentity k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(BasitTabloIdentity k)
        {
            dal.Guncelle(k);
        }
        public void Sil(BasitTabloIdentity k)
        {
            dal.Sil(k);
        }

		public void Sil(int BasitTabloIdentityKey)
		{
			dal.Sil(BasitTabloIdentityKey);
		}
        public void DurumaGoreEkleGuncelleVeyaSil(BasitTabloIdentity k)
        {
            dal.DurumaGoreEkleGuncelleVeyaSil(k);
        }

        public List<BasitTabloIdentity> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

        public List<BasitTabloIdentity> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

		public BasitTabloIdentity SorgulaBasitTabloIdentityKeyIle(int p1)
		{
			return dal.SorgulaBasitTabloIdentityKeyIle(p1);
		}

        public void TopluEkleGuncelleVeyaSil(List<BasitTabloIdentity> liste)
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
