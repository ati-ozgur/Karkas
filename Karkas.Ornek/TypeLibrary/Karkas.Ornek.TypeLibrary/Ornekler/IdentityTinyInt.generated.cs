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
		[DebuggerDisplay("IdentityTinyIntKey = {IdentityTinyIntKey}")]
		public partial class 		IdentityTinyInt		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private byte identityTinyIntKey;
			private string adi;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public byte IdentityTinyIntKey
			{
				[DebuggerStepThrough]
				get
				{
					return identityTinyIntKey;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (identityTinyIntKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					identityTinyIntKey = value;
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
			public string IdentityTinyIntKeyAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return identityTinyIntKey.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						byte _a = Convert.ToByte(value);
					IdentityTinyIntKey = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"IdentityTinyIntKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore, SoapIgnore]
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

		public class PropertyIsimleri
		{
			public const string IdentityTinyIntKey = "IdentityTinyIntKey";
			public const string Adi = "Adi";
		}
			public IdentityTinyInt ShallowCopy()
			{
				IdentityTinyInt obj = new IdentityTinyInt();
				obj.identityTinyIntKey = identityTinyIntKey;
				obj.adi = adi;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string IdentityTinyIntKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IdentityTinyIntKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "IdentityTinyIntKey";
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

