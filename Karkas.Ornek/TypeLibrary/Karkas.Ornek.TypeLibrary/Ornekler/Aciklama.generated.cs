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
	[DebuggerDisplay("AciklamaKey = {AciklamaKey}")]
	public partial class 	Aciklama: BaseTypeLibrary
	{
		private Guid aciklamaKey;
		private string aciklama;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid AciklamaKey
		{
			[DebuggerStepThrough]
			get
			{
				return aciklamaKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (aciklamaKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				aciklamaKey = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string AciklamaProperty
		{
			[DebuggerStepThrough]
			get
			{
				return aciklama;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (aciklama!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				aciklama = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string AciklamaKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return aciklamaKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					Guid _a = new Guid(value);
				AciklamaKey = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"AciklamaKey",string.Format(CEVIRI_YAZISI,"AciklamaKey","Guid")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string AciklamaKey = "AciklamaKey";
		public const string AciklamaProperty = "Aciklama";
	}
		public Aciklama ShallowCopy()
		{
			Aciklama obj = new Aciklama();
			obj.aciklamaKey = aciklamaKey;
			obj.aciklama = aciklama;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
		
		this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "AciklamaProperty"));	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
		public static string AciklamaKey
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".AciklamaKey"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "AciklamaKey";
				}
			}
		}
		public static string Aciklama
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".Aciklama"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "Aciklama";
				}
			}
		}
	}
}
}
