
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
    public partial class DenemeGuidIdentityBsWrapper 
    {
        DenemeGuidIdentityBs bs = new DenemeGuidIdentityBs();
		

		public DenemeGuidIdentityBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(DenemeGuidIdentity p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(DenemeGuidIdentity k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(DenemeGuidIdentity k)
        {
            bs.Sil(k);
        }

		public void Sil(Guid DenemeKey)
		{
			bs.Sil(DenemeKey);
		}
        public void DurumaGoreEkleGuncelleVeyaSil(DenemeGuidIdentity k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<DenemeGuidIdentity> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<DenemeGuidIdentity> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public DenemeGuidIdentity SorgulaDenemeKeyIle(Guid p1)
		{
			return bs.SorgulaDenemeKeyIle(p1);
		}
		
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<DenemeGuidIdentity> liste)
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
