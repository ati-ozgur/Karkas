
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
	public partial class 	DenemeGuidIdentityBs
		{
				DenemeGuidIdentityDal dal = new DenemeGuidIdentityDal();				
				public void Ekle(DenemeGuidIdentity k)
				{
					dal.Ekle(k);
				}
				public void Guncelle(DenemeGuidIdentity k)
				{
					dal.Guncelle(k);
				}
				public void Sil(DenemeGuidIdentity k)
				{
					dal.Sil(k);
				}
				public void Sil(Guid DenemeKey)
				{
					dal.Sil(DenemeKey);
				}
				public void DurumaGoreEkleGuncelleVeyaSil(DenemeGuidIdentity k)
				{
					dal.DurumaGoreEkleGuncelleVeyaSil(k);
				}
				public List< DenemeGuidIdentity > SorgulaHepsiniGetir()
				{
					return dal.SorgulaHepsiniGetir();
				}
				public List< DenemeGuidIdentity > SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
				{
					return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
				}
				public DenemeGuidIdentity SorgulaDenemeKeyIle(Guid p1)
				{
					return dal.SorgulaDenemeKeyIle(p1);
				}
				public void TopluEkleGuncelleVeyaSil(List<DenemeGuidIdentity> liste)
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
