
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
    public partial class MusteriBs 
    {
        MusteriDal dal = new MusteriDal();
        public void Ekle(Musteri k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(Musteri k)
        {
            dal.Guncelle(k);
        }
        public void Sil(Musteri k)
        {
            dal.Sil(k);
        }

        public void DurumaGoreEkleGuncelleVeyaSil(Musteri k)
        {
            dal.DurumaGoreEkleGuncelleVeyaSil(k);
        }

        public List<Musteri> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

		public Musteri SorgulaMusteriKeyIle(Guid p1)
		{
			return dal.SorgulaMusteriKeyIle(p1);
		}

        public void TopluEkleGuncelleVeyaSil(List<Musteri> liste)
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
