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
	[DebuggerDisplay("MusteriSiparisKey = {MusteriSiparisKey}")]
	public partial class 	MusteriSiparis: BaseTypeLibrary
	{
		private Guid musteriSiparisKey;
		private Guid musteriKey;
		private decimal tutar;
		private DateTime siparisTarihi;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid MusteriSiparisKey
		{
			[DebuggerStepThrough]
			get
			{
				return musteriSiparisKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (musteriSiparisKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				musteriSiparisKey = value;
			}
		}

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
		public decimal Tutar
		{
			[DebuggerStepThrough]
			get
			{
				return tutar;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (tutar!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				tutar = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime SiparisTarihi
		{
			[DebuggerStepThrough]
			get
			{
				return siparisTarihi;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (siparisTarihi!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				siparisTarihi = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string MusteriSiparisKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return musteriSiparisKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					Guid _a = new Guid(value);
				MusteriSiparisKey = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"MusteriSiparisKey",string.Format(CEVIRI_YAZISI,"MusteriSiparisKey","Guid")));
				}
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
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"MusteriKey",string.Format(CEVIRI_YAZISI,"MusteriKey","Guid")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string TutarAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return tutar.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				Tutar = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"Tutar",string.Format(CEVIRI_YAZISI,"Tutar","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string SiparisTarihiAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return siparisTarihi.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				SiparisTarihi = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"SiparisTarihi",string.Format(CEVIRI_YAZISI,"SiparisTarihi","DateTime")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string MusteriSiparisKey = "MusteriSiparisKey";
		public const string MusteriKey = "MusteriKey";
		public const string Tutar = "Tutar";
		public const string SiparisTarihi = "SiparisTarihi";
	}
		public MusteriSiparis ShallowCopy()
		{
			MusteriSiparis obj = new MusteriSiparis();
			obj.musteriSiparisKey = musteriSiparisKey;
			obj.musteriKey = musteriKey;
			obj.tutar = tutar;
			obj.siparisTarihi = siparisTarihi;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "MusteriKey"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Tutar"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "SiparisTarihi"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
		public static string MusteriSiparisKey
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".MusteriSiparisKey"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "MusteriSiparisKey";
				}
			}
		}
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
		public static string Tutar
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Tutar"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Tutar";
				}
			}
		}
		public static string SiparisTarihi
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".SiparisTarihi"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "SiparisTarihi";
				}
			}
		}
	}
}
}
