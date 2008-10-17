
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
	public partial class 	AciklamaBs
		{
				AciklamaDal dal = new AciklamaDal();				
				public void Ekle(Aciklama k)
				{
					dal.Ekle(k);
				}
				public void Guncelle(Aciklama k)
				{
					dal.Guncelle(k);
				}
				public void Sil(Aciklama k)
				{
					dal.Sil(k);
				}
				public void Sil(Guid AciklamaKey)
				{
					dal.Sil(AciklamaKey);
				}
				public void DurumaGoreEkleGuncelleVeyaSil(Aciklama k)
				{
					dal.DurumaGoreEkleGuncelleVeyaSil(k);
				}
				public List< Aciklama > SorgulaHepsiniGetir()
				{
					return dal.SorgulaHepsiniGetir();
				}
				public List< Aciklama > SorgulaHepsiniGetirSirali(params string[] pSiraListesi)
				{
					return dal.SorgulaHepsiniGetirSirali(pSiraListesi);
				}
				public Aciklama SorgulaAciklamaKeyIle(Guid p1)
				{
					return dal.SorgulaAciklamaKeyIle(p1);
				}
				public void TopluEkleGuncelleVeyaSil(List<Aciklama> liste)
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
