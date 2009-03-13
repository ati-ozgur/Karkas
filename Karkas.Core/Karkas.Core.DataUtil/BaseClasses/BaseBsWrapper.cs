using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web;
using Karkas.Core.TypeLibrary;

namespace Karkas.Core.DataUtil.BaseClasses
{
    public abstract class BaseBsWrapper<TYPE_LIBRARY_TIPI,DAL_TIPI, BS_TIPI> : BaseBsWrapperWithoutEntity
                where TYPE_LIBRARY_TIPI : BaseTypeLibrary, new()
        where DAL_TIPI : BaseDal<TYPE_LIBRARY_TIPI>, new()
        where BS_TIPI : BaseBs<TYPE_LIBRARY_TIPI, DAL_TIPI>, new()
    {
        public abstract BS_TIPI bs
        {
            get;
        }


        public BaseBsWrapper()
        {
            if (
                (HttpContext.Current != null) 
                && (HttpContext.Current.Session != null) 
                && (HttpContext.Current.Session["KISI_KEY"] != null)
                && (bs != null)
                )
            {
                bs.KomutuCalistiranKullaniciKisiKey = (Guid)HttpContext.Current.Session["KISI_KEY"];
            }
        }



        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Ekle(TYPE_LIBRARY_TIPI p1)
        {
            bs.Ekle(p1);
            return;
        }


        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Guncelle(TYPE_LIBRARY_TIPI k)
        {
            bs.Guncelle(k);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Sil(TYPE_LIBRARY_TIPI k)
        {
            bs.Sil(k);
        }


        public void DurumaGoreEkleGuncelleVeyaSil(TYPE_LIBRARY_TIPI k)
        {
            bs.DurumaGoreEkleGuncelleVeyaSil(k);
        }


      [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<TYPE_LIBRARY_TIPI> SorgulaHepsiniGetir()
        {
            return bs.SorgulaHepsiniGetir();
        }

      [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<TYPE_LIBRARY_TIPI> SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
        {
            return bs.SorgulaHepsiniGetirSirali(pSiraListesi);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void TopluEkleGuncelleVeyaSil(List<TYPE_LIBRARY_TIPI> liste)
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
