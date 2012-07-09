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
	[DebuggerDisplay("IdentityIntKey = {IdentityIntKey}")]
	public partial class 	IdentityInt: BaseTypeLibrary
	{
		private int identityIntKey;
		private string adi;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int IdentityIntKey
		{
			[DebuggerStepThrough]
			get
			{
				return identityIntKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (identityIntKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				identityIntKey = value;
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
		[XmlIgnore, SoapIgnore]
		public string IdentityIntKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return identityIntKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					int _a = Convert.ToInt32(value);
				IdentityIntKey = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"IdentityIntKey",string.Format("","IdentityIntKey","int")));
				}
			}
		}

	public class PropertyIsimleri
	{
		public const string IdentityIntKey = "IdentityIntKey";
		public const string Adi = "Adi";
	}
		public IdentityInt ShallowCopy()
		{
			IdentityInt obj = new IdentityInt();
			obj.identityIntKey = identityIntKey;
			obj.adi = adi;
			return obj;
		}
	

	protected override void OnaylamaListesiniOlusturCodeGeneration()
	{
	}
	public static class EtiketIsimleri
	{
		const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
		public static string IdentityIntKey
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IdentityIntKey"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "IdentityIntKey";
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
	}
}
}
