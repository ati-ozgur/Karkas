
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
	public partial class 	ConcurrencyOrnekBs
		{
				ConcurrencyOrnekDal dal = new ConcurrencyOrnekDal();				
				public void Ekle(ConcurrencyOrnek k)
				{
					dal.Ekle(k);
				}
				public void Guncelle(ConcurrencyOrnek k)
				{
					dal.Guncelle(k);
				}
				public void Sil(ConcurrencyOrnek k)
				{
					dal.Sil(k);
				}
				public void Sil(Guid ConcurrencyOrnekKey)
				{
					dal.Sil(ConcurrencyOrnekKey);
				}
				public void DurumaGoreEkleGuncelleVeyaSil(ConcurrencyOrnek k)
				{
					dal.DurumaGoreEkleGuncelleVeyaSil(k);
				}
				public List< ConcurrencyOrnek > SorgulaHepsiniGetir()
				{
					return dal.SorgulaHepsiniGetir();
				}
				public List< ConcurrencyOrnek > SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
				{
					return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
				}
				public ConcurrencyOrnek SorgulaConcurrencyOrnekKeyIle(Guid p1)
				{
					return dal.SorgulaConcurrencyOrnekKeyIle(p1);
				}
				public void TopluEkleGuncelleVeyaSil(List<ConcurrencyOrnek> liste)
				{
					dal.TopluEkleGuncelleVeyaSil(liste);
				}
				public int TablodakiSatirSayisi
				{
					get
					{
						return dal.TablodakiSatirSayisi;
					}
				}
				public Guid KomutuCalistiranKullaniciKisiKey
				{
					get
					{
						return dal.KomutuCalistiranKullaniciKisiKey;
					}
					set
					{
						dal.KomutuCalistiranKullaniciKisiKey = value;
					}
				}
			}
		}
