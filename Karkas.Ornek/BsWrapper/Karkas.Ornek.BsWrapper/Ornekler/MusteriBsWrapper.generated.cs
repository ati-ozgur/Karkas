
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using Karkas.Web.Helpers.HelperClasses;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Bs.Ornekler;


namespace Karkas.Ornek.BsWrapper.Ornekler
{
    [DataObject]
    public partial class MusteriBsWrapper 
    {
        MusteriBs bs = new MusteriBs();
		

		public MusteriBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(Musteri p1 )        {
            bs.Ekle(p1);
            return;
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(Musteri k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(Musteri k)
        {
            bs.Sil(k);
        }

		public void Sil(Guid MusteriKey)
		{
			bs.Sil(MusteriKey);
		}
        [DataObjectMethod(DataObjectMethodType.Select)]
		public Musteri SorgulaMusteriKeyIle(Guid p1)
		{
			return bs.SorgulaMusteriKeyIle(p1);
		}
		
        public void DurumaGoreEkleGuncelleVeyaSil(Musteri k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Musteri> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Musteri> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<Musteri> liste)
        {
            bs.TopluEkleGuncelleVeyaSil(liste);
        }
        public Guid KomutuCalistiranKullaniciKisiKey
        {
			get
			{
				return bs.KomutuCalistiranKullaniciKisiKey;
			}
			set
			{
				bs.KomutuCalistiranKullaniciKisiKey = value;
			}
        }


    }
}
