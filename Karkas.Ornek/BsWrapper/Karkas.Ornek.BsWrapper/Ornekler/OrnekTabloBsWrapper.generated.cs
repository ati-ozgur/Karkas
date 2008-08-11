
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
    public partial class OrnekTabloBsWrapper 
    {
        OrnekTabloBs bs = new OrnekTabloBs();
		

		public OrnekTabloBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(OrnekTablo p1)
        {
            bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(OrnekTablo k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(OrnekTablo k)
        {
            bs.Sil(k);
        }

        public void DurumaGoreEkleGuncelleVeyaSil(OrnekTablo k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<OrnekTablo> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public OrnekTablo SorgulaOrnekTabloKeyIle(Guid p1)
		{
			return bs.SorgulaOrnekTabloKeyIle(p1);
		}
		
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<OrnekTablo> liste)
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
