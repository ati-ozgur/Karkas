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
		[DebuggerDisplay("IdentityBigIntKey = {IdentityBigIntKey}")]
		public partial class 		IdentityBigInt		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private long identityBigIntKey;
			private string adi;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public long IdentityBigIntKey
			{
				[DebuggerStepThrough]
				get
				{
					return identityBigIntKey;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (identityBigIntKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					identityBigIntKey = value;
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
			public string IdentityBigIntKeyAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return identityBigIntKey.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						long _a = Convert.ToInt64(value);
					IdentityBigIntKey = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"IdentityBigIntKey","Ceviri islemi Başarısız oldu"));
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
			public const string IdentityBigIntKey = "IdentityBigIntKey";
			public const string Adi = "Adi";
		}
			public IdentityBigInt ShallowCopy()
			{
				IdentityBigInt obj = new IdentityBigInt();
				obj.identityBigIntKey = identityBigIntKey;
				obj.adi = adi;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string IdentityBigIntKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IdentityBigIntKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "IdentityBigIntKey";
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

