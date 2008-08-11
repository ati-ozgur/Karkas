
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
    public partial class BasitTabloBs 
    {
        BasitTabloDal dal = new BasitTabloDal();
        public void Ekle(BasitTablo k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(BasitTablo k)
        {
            dal.Guncelle(k);
        }
        public void Sil(BasitTablo k)
        {
            dal.Sil(k);
        }

        public void DurumaGoreEkleGuncelleVeyaSil(BasitTablo k)
        {
            dal.DurumaGoreEkleGuncelleVeyaSil(k);
        }

        public List<BasitTablo> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public BasitTablo SorgulaBasitTabloKeyIle(Guid p1)
		{
			return dal.SorgulaBasitTabloKeyIle(p1);
		}

        public void TopluEkleGuncelleVeyaSil(List<BasitTablo> liste)
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
