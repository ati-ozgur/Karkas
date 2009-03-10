
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
    public partial class MusteriSiparisBsWrapper 
    {
        MusteriSiparisBs bs = new MusteriSiparisBs();
		

		public MusteriSiparisBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(MusteriSiparis p1 )        {
            bs.Ekle(p1);
            return;
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(MusteriSiparis k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(MusteriSiparis k)
        {
            bs.Sil(k);
        }

		public void Sil(Guid MusteriSiparisKey)
		{
			bs.Sil(MusteriSiparisKey);
		}
        [DataObjectMethod(DataObjectMethodType.Select)]
		public MusteriSiparis SorgulaMusteriSiparisKeyIle(Guid p1)
		{
			return bs.SorgulaMusteriSiparisKeyIle(p1);
		}
		
        public void DurumaGoreEkleGuncelleVeyaSil(MusteriSiparis k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<MusteriSiparis> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<MusteriSiparis> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<MusteriSiparis> liste)
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
