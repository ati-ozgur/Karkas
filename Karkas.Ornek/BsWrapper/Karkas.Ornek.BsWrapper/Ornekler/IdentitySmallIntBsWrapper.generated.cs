
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
    public partial class IdentitySmallIntBsWrapper 
    {
        IdentitySmallIntBs bs = new IdentitySmallIntBs();
		

		public IdentitySmallIntBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public short Ekle(IdentitySmallInt p1 )        {
            return (short) bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(IdentitySmallInt k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(IdentitySmallInt k)
        {
            bs.Sil(k);
        }

		public void Sil(short IdentitySmallIntKey)
		{
			bs.Sil(IdentitySmallIntKey);
		}
        public void DurumaGoreEkleGuncelleVeyaSil(IdentitySmallInt k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IdentitySmallInt> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<IdentitySmallInt> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
		public IdentitySmallInt SorgulaIdentitySmallIntKeyIle(short p1)
		{
			return bs.SorgulaIdentitySmallIntKeyIle(p1);
		}
		
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<IdentitySmallInt> liste)
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
