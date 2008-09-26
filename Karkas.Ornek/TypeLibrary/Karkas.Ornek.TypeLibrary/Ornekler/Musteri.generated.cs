using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;

namespace Karkas.Ornek.TypeLibrary.Ornekler

{
		[Serializable]
		[DebuggerDisplay("MusteriKey = {MusteriKey}")]
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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Guid MusteriKey
			{
				[DebuggerStepThrough]
				get
				{
					return musteriKey;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (musteriKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					musteriKey = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string Adi
			{
				[DebuggerStepThrough]
				get
				{
					return adi;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (adi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					adi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string Soyadi
			{
				[DebuggerStepThrough]
				get
				{
					return soyadi;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (soyadi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					soyadi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string IkinciAdi
			{
				[DebuggerStepThrough]
				get
				{
					return ikinciAdi;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (ikinciAdi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					ikinciAdi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Nullable<DateTime> DogumTarihi
			{
				[DebuggerStepThrough]
				get
				{
					return dogumTarihi;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (dogumTarihi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					dogumTarihi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string TamAdi
			{
				[DebuggerStepThrough]
				get
				{
					return tamAdi;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (tamAdi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					tamAdi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string MusteriKeyAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return musteriKey.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						Guid _a = new Guid(value);
					MusteriKey = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"MusteriKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string AdiAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return adi != null ? adi.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					Adi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string SoyadiAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return soyadi != null ? soyadi.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					Soyadi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string IkinciAdiAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return ikinciAdi != null ? ikinciAdi.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					IkinciAdi = value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string DogumTarihiAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return dogumTarihi != null ? dogumTarihi.ToString() : ""; 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						DateTime _a = Convert.ToDateTime(value);
					DogumTarihi = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DogumTarihi","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore]
			public string TamAdiAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return tamAdi != null ? tamAdi.ToString() : ""; 
				}
				[DebuggerStepThrough]
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
