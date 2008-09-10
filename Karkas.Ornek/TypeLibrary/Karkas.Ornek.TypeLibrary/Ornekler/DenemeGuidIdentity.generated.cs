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
		public partial class 		DenemeGuidIdentity		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private Guid denemeKey;
			private int denemeNo;
			private string denemeKolon;

			public Guid DenemeKey
			{
				get
				{
					return denemeKey;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (denemeKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					denemeKey = value;
				}
			}

			public int DenemeNo
			{
				get
				{
					return denemeNo;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (denemeNo!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					denemeNo = value;
				}
			}

			public string DenemeKolon
			{
				get
				{
					return denemeKolon;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (denemeKolon!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					denemeKolon = value;
				}
			}

			public string DenemeKeyAsString
			{
				get
				{
					return denemeKey.ToString();
				}
				set
				{
					try
					{
						Guid _a = new Guid(value);
					DenemeKey = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DenemeKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string DenemeNoAsString
			{
				get
				{
					return denemeNo.ToString();
				}
				set
				{
					try
					{
						int _a = Convert.ToInt32(value);
					DenemeNo = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"DenemeNo","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string DenemeKolonAsString
			{
				get
				{
					return denemeKolon.ToString();
				}
				set
				{
					DenemeKolon = value;
				}
			}

		public class PropertyIsimleri
		{
			public const string DenemeKey = "DenemeKey";
			public const string DenemeNo = "DenemeNo";
			public const string DenemeKolon = "DenemeKolon";
		}
			public DenemeGuidIdentity ShallowCopy()
			{
				DenemeGuidIdentity obj = new DenemeGuidIdentity();
				obj.denemeKey = denemeKey;
				obj.denemeNo = denemeNo;
				obj.denemeKolon = denemeKolon;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "DenemeNo"));			
			this.Onaylayici.OnaylayiciListesi.Add(new GerekliAlanOnaylayici(this, "DenemeKolon"));		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string DenemeKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DenemeKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "DenemeKey";
					}
				}
			}
			public static string DenemeNo
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DenemeNo"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "DenemeNo";
					}
				}
			}
			public static string DenemeKolon
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".DenemeKolon"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "DenemeKolon";
					}
				}
			}
		}
	}
}
