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
		[DebuggerDisplay("BasitTabloKey = {BasitTabloKey}")]
		public partial class 		BasitTablo		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private Guid basitTabloKey;
			private string adi;
			private string soyadi;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Guid BasitTabloKey
			{
				[DebuggerStepThrough]
				get
				{
					return basitTabloKey;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (basitTabloKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					basitTabloKey = value;
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
			public string BasitTabloKeyAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return basitTabloKey.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						Guid _a = new Guid(value);
					BasitTabloKey = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"BasitTabloKey","Ceviri islemi Başarısız oldu"));
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

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[XmlIgnore, SoapIgnore]
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

		public class PropertyIsimleri
		{
			public const string BasitTabloKey = "BasitTabloKey";
			public const string Adi = "Adi";
			public const string Soyadi = "Soyadi";
		}
			public BasitTablo ShallowCopy()
			{
				BasitTablo obj = new BasitTablo();
				obj.basitTabloKey = basitTabloKey;
				obj.adi = adi;
				obj.soyadi = soyadi;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Adi"));			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string BasitTabloKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".BasitTabloKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "BasitTabloKey";
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
