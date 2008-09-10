
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
	public partial class 	OrnekTabloBs
 
    {
        OrnekTabloDal dal = new OrnekTabloDal();
        public void Ekle(OrnekTablo k)
        {
            dal.Ekle(k);
        }

        public void Guncelle(OrnekTablo k)
        {
            dal.Guncelle(k);
        }
        public void Sil(OrnekTablo k)
        {
            dal.Sil(k);
        }

        public void DurumaGoreEkleGuncelleVeyaSil(OrnekTablo k)
        {
            dal.DurumaGoreEkleGuncelleVeyaSil(k);
        }

        public List<OrnekTablo> SorgulaHepsiniGetir()
        {
            return dal.SorgulaHepsiniGetir();
        }

        public List<OrnekTablo> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

		public OrnekTablo SorgulaOrnekTabloKeyIle(Guid p1)
		{
			return dal.SorgulaOrnekTabloKeyIle(p1);
		}

        public void TopluEkleGuncelleVeyaSil(List<OrnekTablo> liste)
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
