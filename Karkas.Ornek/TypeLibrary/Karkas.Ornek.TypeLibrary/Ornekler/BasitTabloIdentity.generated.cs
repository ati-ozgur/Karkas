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
	[DebuggerDisplay("BasitTabloIdentityKey = {BasitTabloIdentityKey}")]
	public partial class 	BasitTabloIdentity: BaseTypeLibrary
	{
		private int basitTabloIdentityKey;
		private string adi;
		private string soyadi;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int BasitTabloIdentityKey
		{
			[DebuggerStepThrough]
			get
			{
				return basitTabloIdentityKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (basitTabloIdentityKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				basitTabloIdentityKey = value;
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
		[XmlIgnore, SoapIgnore]
		public string BasitTabloIdentityKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return basitTabloIdentityKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					int _a = Convert.ToInt32(value);
				BasitTabloIdentityKey = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"BasitTabloIdentityKey",string.Format(CEVIRI_YAZISI,"BasitTabloIdentityKey","int")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string BasitTabloIdentityKey = "BasitTabloIdentityKey";
		public const string Adi = "Adi";
		public const string Soyadi = "Soyadi";
	}
		public BasitTabloIdentity ShallowCopy()
		{
			BasitTabloIdentity obj = new BasitTabloIdentity();
			obj.basitTabloIdentityKey = basitTabloIdentityKey;
			obj.adi = adi;
			obj.soyadi = soyadi;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
		public static string BasitTabloIdentityKey
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".BasitTabloIdentityKey"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "BasitTabloIdentityKey";
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
	}
}
}
