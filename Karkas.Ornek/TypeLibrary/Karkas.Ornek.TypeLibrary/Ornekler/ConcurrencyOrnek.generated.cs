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
	[DebuggerDisplay("ConcurrencyOrnekKey = {ConcurrencyOrnekKey}")]
	public partial class 	ConcurrencyOrnek: BaseTypeLibrary
	{
		private Guid concurrencyOrnekKey;
		private string adi;
		private byte[] versiyonZamani;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid ConcurrencyOrnekKey
		{
			[DebuggerStepThrough]
			get
			{
				return concurrencyOrnekKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (concurrencyOrnekKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				concurrencyOrnekKey = value;
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
		public byte[] VersiyonZamani
		{
			[DebuggerStepThrough]
			get
			{
				return versiyonZamani;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (versiyonZamani!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				versiyonZamani = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string ConcurrencyOrnekKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return concurrencyOrnekKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					Guid _a = new Guid(value);
				ConcurrencyOrnekKey = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"ConcurrencyOrnekKey",string.Format(CEVIRI_YAZISI,"ConcurrencyOrnekKey","Guid")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string VersiyonZamaniAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return versiyonZamani != null ? versiyonZamani.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
			}
		}

	public class PropertyIsimleri
	{
		public const string ConcurrencyOrnekKey = "ConcurrencyOrnekKey";
		public const string Adi = "Adi";
		public const string VersiyonZamani = "VersiyonZamani";
	}
		public ConcurrencyOrnek ShallowCopy()
		{
			ConcurrencyOrnek obj = new ConcurrencyOrnek();
			obj.concurrencyOrnekKey = concurrencyOrnekKey;
			obj.adi = adi;
			obj.versiyonZamani = versiyonZamani;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "VersiyonZamani"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
		public static string ConcurrencyOrnekKey
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".ConcurrencyOrnekKey"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "ConcurrencyOrnekKey";
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
		public static string VersiyonZamani
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".VersiyonZamani"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "VersiyonZamani";
				}
			}
		}
	}
}
}
