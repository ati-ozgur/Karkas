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
		[DebuggerDisplay("KisiOid = {KisiOid}")]
		public partial class 		IsimlendirmeBozuk		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private int kisiOid;
			private string adi;
			private string soyadi;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int KisiOid
			{
				[DebuggerStepThrough]
				get
				{
					return kisiOid;
				}
				[DebuggerStepThrough]
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kisiOid!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kisiOid = value;
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
			public string KisiOidAsString
			{
				[DebuggerStepThrough]
				get
				{
					 return kisiOid.ToString(); 
				}
				[DebuggerStepThrough]
				set
				{
					try
					{
						int _a = Convert.ToInt32(value);
					KisiOid = _a;
					}
					catch(Exception)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KisiOid","Ceviri islemi Başarısız oldu"));
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
			public const string KisiOid = "KISI_OID";
			public const string Adi = "ADI";
			public const string Soyadi = "SOYADI";
		}
			public IsimlendirmeBozuk ShallowCopy()
			{
				IsimlendirmeBozuk obj = new IsimlendirmeBozuk();
				obj.kisiOid = kisiOid;
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
			public static string KisiOid
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KisiOid"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KisiOid";
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
