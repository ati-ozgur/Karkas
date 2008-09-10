using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;
using System.Configuration;

namespace Karkas.Ornek.TypeLibrary.Ornekler

{
		[Serializable]
		public partial class 		Musteri		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private Guid musteriKey;
			private string adi;
			private string soyadi;
			private string ikinciAdi;
			private Nullable<DateTime> dogumTarihi;
			private string tamAdi;

			public Guid MusteriKey
			{
				get
				{
					return musteriKey;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (musteriKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					musteriKey = value;
				}
			}

			public string Adi
			{
				get
				{
					return adi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (adi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					adi = value;
				}
			}

			public string Soyadi
			{
				get
				{
					return soyadi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (soyadi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					soyadi = value;
				}
			}

			public string IkinciAdi
			{
				get
				{
					return ikinciAdi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (ikinciAdi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					ikinciAdi = value;
				}
			}

			public Nullable<DateTime> DogumTarihi
			{
				get
				{
					return dogumTarihi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (dogumTarihi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					dogumTarihi = value;
				}
			}

			public string TamAdi
			{
				get
				{
					return tamAdi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (tamAdi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					tamAdi = value;
				}
			}

			public string MusteriKeyAsString
			{
				get
				{
					return musteriKey.ToString();
				}
				set
				{
					try
					{
						Guid _a = new Guid(value);
					MusteriKey = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"MusteriKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string AdiAsString
			{
				get
				{
					return adi.ToString();
				}
				set
				{
					Adi = value;
				}
			}

			public string SoyadiAsString
			{
				get
				{
					return soyadi.ToString();
				}
				set
				{
					Soyadi = value;
				}
			}

			public string IkinciAdiAsString
			{
				get
				{
					return ikinciAdi.ToString();
				}
				set
				{
					IkinciAdi = value;
				}
			}

			public string DogumTarihiAsString
			{
				get
				{
					return dogumTarihi.ToString();
				}
				set
				{
					try
					{
						DateTime _a = Convert.ToDateTime(value);
					DogumTarihi = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DogumTarihi","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string TamAdiAsString
			{
				get
				{
					return tamAdi.ToString();
				}
				set
				{
					TamAdi = value;
				}
			}

		public class PropertyIsimleri
		{
			public const string MusteriKey = "MusteriKey";
			public const string Adi = "Adi";
			public const string Soyadi = "Soyadi";
			public const string IkinciAdi = "IkinciAdi";
			public const string DogumTarihi = "DogumTarihi";
			public const string TamAdi = "TamAdi";
		}
			public Musteri ShallowCopy()
			{
				Musteri obj = new Musteri();
				obj.musteriKey = musteriKey;
				obj.adi = adi;
				obj.soyadi = soyadi;
				obj.ikinciAdi = ikinciAdi;
				obj.dogumTarihi = dogumTarihi;
				obj.tamAdi = tamAdi;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string MusteriKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".MusteriKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "MusteriKey";
					}
				}
			}
			public static string Adi
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Adi"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "Adi";
					}
				}
			}
			public static string Soyadi
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Soyadi"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "Soyadi";
					}
				}
			}
			public static string IkinciAdi
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IkinciAdi"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "IkinciAdi";
					}
				}
			}
			public static string DogumTarihi
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DogumTarihi"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "DogumTarihi";
					}
				}
			}
			public static string TamAdi
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".TamAdi"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "TamAdi";
					}
				}
			}
		}
	}
}
