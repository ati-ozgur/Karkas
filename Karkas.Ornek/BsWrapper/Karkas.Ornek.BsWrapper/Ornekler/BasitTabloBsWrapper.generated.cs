
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
    public partial class BasitTabloBsWrapper 
    {
        BasitTabloBs bs = new BasitTabloBs();
		

		public BasitTabloBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(BasitTablo p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(BasitTablo k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(BasitTablo k)
        {
            bs.Sil(k);
        }

        public void DurumaGoreEkleGuncelleVeyaSil(BasitTablo k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<BasitTablo> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public BasitTablo SorgulaBasitTabloKeyIle(Guid p1)
		{
			return bs.SorgulaBasitTabloKeyIle(p1);
		}
		
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<BasitTablo> liste)
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
