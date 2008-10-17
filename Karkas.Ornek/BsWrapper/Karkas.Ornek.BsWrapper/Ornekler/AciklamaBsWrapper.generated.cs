
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
    public partial class AciklamaBsWrapper 
    {
        AciklamaBs bs = new AciklamaBs();
		

		public AciklamaBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(Aciklama p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(Aciklama k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(Aciklama k)
        {
            bs.Sil(k);
        }

		public void Sil(Guid AciklamaKey)
		{
			bs.Sil(AciklamaKey);
		}
        public void DurumaGoreEkleGuncelleVeyaSil(Aciklama k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<Aciklama> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Aciklama> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public Aciklama SorgulaAciklamaKeyIle(Guid p1)
		{
			return bs.SorgulaAciklamaKeyIle(p1);
		}
		
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<Aciklama> liste)
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
