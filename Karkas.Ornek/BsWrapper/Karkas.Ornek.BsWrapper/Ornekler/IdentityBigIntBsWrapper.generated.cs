
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
    public partial class IdentityBigIntBsWrapper 
    {
        IdentityBigIntBs bs = new IdentityBigIntBs();
		

		public IdentityBigIntBsWrapper()
		{
			if ((HttpContext.Current != null) && (HttpContext.Current.Session != null) && (HttpContext.Current.Session[SessionEnumHelper.KISI_KEY] != null))
			{
				bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session[SessionEnumHelper.KISI_KEY];
			}
		}
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public long Ekle(IdentityBigInt p1 )        {
            return (long) bs.Ekle(p1);
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(IdentityBigInt k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(IdentityBigInt k)
        {
            bs.Sil(k);
        }

		public void Sil(long IdentityBigIntKey)
		{
			bs.Sil(IdentityBigIntKey);
		}
        [DataObjectMethod(DataObjectMethodType.Select)]
		public IdentityBigInt SorgulaIdentityBigIntKeyIle(long p1)
		{
			return bs.SorgulaIdentityBigIntKeyIle(p1);
		}
		
        public void DurumaGoreEkleGuncelleVeyaSil(IdentityBigInt k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<IdentityBigInt> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<IdentityBigInt> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<IdentityBigInt> liste)
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
