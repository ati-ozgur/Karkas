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
	public partial class 	Musteri: BaseTypeLibrary
	{
		private Guid musteriKey;
		private string adi;
		private string soyadi;
		private string ikinciAdi;
		private Nullable<DateTime> dogumTarihi;
		private bool aktifMi;
		private Nullable<int> onemi;
		private Nullable<decimal> kredisi;
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
		public bool AktifMi
		{
			[DebuggerStepThrough]
			get
			{
				return aktifMi;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (aktifMi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				aktifMi = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<int> Onemi
		{
			[DebuggerStepThrough]
			get
			{
				return onemi;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (onemi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				onemi = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> Kredisi
		{
			[DebuggerStepThrough]
			get
			{
				return kredisi;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kredisi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kredisi = value;
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
		[XmlIgnore, SoapIgnore]
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
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"MusteriKey",string.Format("","MusteriKey","Guid")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
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
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DogumTarihi",string.Format("","DogumTarihi","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string AktifMiAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return aktifMi.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					bool _a = Convert.ToBoolean(value);
				AktifMi = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"AktifMi",string.Format("","AktifMi","bool")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string OnemiAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return onemi != null ? onemi.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					int _a = Convert.ToInt32(value);
				Onemi = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"Onemi",string.Format("","Onemi","int")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KredisiAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kredisi != null ? kredisi.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				Kredisi = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"Kredisi",string.Format("","Kredisi","decimal")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string MusteriKey = "MusteriKey";
		public const string Adi = "Adi";
		public const string Soyadi = "Soyadi";
		public const string IkinciAdi = "IkinciAdi";
		public const string DogumTarihi = "DogumTarihi";
		public const string AktifMi = "AktifMi";
		public const string Onemi = "Onemi";
		public const string Kredisi = "Kredisi";
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
			obj.aktifMi = aktifMi;
			obj.onemi = onemi;
			obj.kredisi = kredisi;
			obj.tamAdi = tamAdi;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "AktifMi"));	}
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
		public static string AktifMi
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".AktifMi"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "AktifMi";
				}
			}
		}
		public static string Onemi
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Onemi"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Onemi";
				}
			}
		}
		public static string Kredisi
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Kredisi"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Kredisi";
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
