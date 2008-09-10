using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Onaylama;
using Karkas.Core.Onaylama.ForPonos;
using System.Configuration;

namespace Karkas.Ornek.TypeLibrary.Ornekler

{
		[Serializable]
		public partial class 		BasitTabloIdentity		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private int basitTabloIdentityKey;
			private string adi;
			private string soyadi;

			public int BasitTabloIdentityKey
			{
				get
				{
					return basitTabloIdentityKey;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (basitTabloIdentityKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					basitTabloIdentityKey = value;
				}
			}

			public string Adi
			{
				get
				{
					return adi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (adi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					adi = value;
				}
			}

			public string Soyadi
			{
				get
				{
					return soyadi;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (soyadi!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					soyadi = value;
				}
			}

			public string BasitTabloIdentityKeyAsString
			{
				get
				{
					return basitTabloIdentityKey.ToString();
				}
				set
				{
					try
					{
						int _a = Convert.ToInt32(value);
					BasitTabloIdentityKey = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"BasitTabloIdentityKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string AdiAsString
			{
				get
				{
					return adi.ToString();
				}
				set
				{
					Adi = value;
				}
			}

			public string SoyadiAsString
			{
				get
				{
					return soyadi.ToString();
				}
				set
				{
					Soyadi = value;
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
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "Soyadi"));		}
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
