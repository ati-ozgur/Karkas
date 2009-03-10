
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
    public partial class IsimlendirmeBozukBsWrapper 
    {
        IsimlendirmeBozukBs bs = new IsimlendirmeBozukBs();
		

		public IsimlendirmeBozukBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Ekle(IsimlendirmeBozuk p1 )        {
            return (int) bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(IsimlendirmeBozuk k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(IsimlendirmeBozuk k)
        {
            bs.Sil(k);
        }

		public void Sil(int KISI_OID)
		{
			bs.Sil(KISI_OID);
		}
        [DataObjectMethod(DataObjectMethodType.Select)]
		public IsimlendirmeBozuk SorgulaKISI_OIDIle(int p1)
		{
			return bs.SorgulaKISI_OIDIle(p1);
		}
		
        public void DurumaGoreEkleGuncelleVeyaSil(IsimlendirmeBozuk k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IsimlendirmeBozuk> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<IsimlendirmeBozuk> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<IsimlendirmeBozuk> liste)
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
