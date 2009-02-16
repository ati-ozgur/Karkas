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
		[DebuggerDisplay("IdentitySmallIntKey = {IdentitySmallIntKey}")]
		public partial class 		IdentitySmallInt		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private short identitySmallIntKey;
			private string adi;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public short IdentitySmallIntKey
			{
				[DebuggerStepThrough]
				get
				{
					return identitySmallIntKey;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (identitySmallIntKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					identitySmallIntKey = value;
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
			public string IdentitySmallIntKeyAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return identitySmallIntKey.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						short _a = Convert.ToInt16(value);
					IdentitySmallIntKey = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"IdentitySmallIntKey","Ceviri islemi Başarısız oldu"));
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
			public const string IdentitySmallIntKey = "IdentitySmallIntKey";
			public const string Adi = "Adi";
		}
			public IdentitySmallInt ShallowCopy()
			{
				IdentitySmallInt obj = new IdentitySmallInt();
				obj.identitySmallIntKey = identitySmallIntKey;
				obj.adi = adi;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string IdentitySmallIntKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".IdentitySmallIntKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "IdentitySmallIntKey";
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

