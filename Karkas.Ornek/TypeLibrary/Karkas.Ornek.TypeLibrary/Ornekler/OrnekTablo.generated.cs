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
		public partial class 		OrnekTablo		
//::PRESERVE_BEGIN inheritance::// 
: BaseTypeLibrary 
//::PRESERVE_END inheritance:://
		{
			private Guid ornekTabloKey;
			private Nullable<long> kolonBigInt;
			private object kolonBinary;
			private Nullable<bool> kolonBit;
			private string kolonChar;
			private Nullable<DateTime> kolonDateTime;
			private Nullable<decimal> kolonDecimal;
			private Nullable<double> kolonFloat;
			private byte[] kolonImage;
			private Nullable<int> kolonInt;
			private Nullable<decimal> kolonMoney;
			private string kolonNChar;
			private string kolonNText;
			private Nullable<decimal> kolonNumeric;
			private string kolonNVarchar;
			private string kolonNVarcharMax;
			private Nullable<float> kolonReal;
			private Nullable<DateTime> kolonSmallDateTime;
			private Nullable<short> kolonSmallInt;
			private Nullable<decimal> kolonSmallMoney;
			private object kolonSqlVariant;
			private string kolonText;
			private byte[] kolonTimeStamp;
			private Nullable<byte> kolonTinyInt;
			private Nullable<Guid> kolonUniqueIdentifier;
			private byte[] kolonVarBinary;
			private byte[] kolonVarBinaryMax;
			private string kolonVarchar;
			private string kolonVarcharMax;
			private string kolonXml;

			public Guid OrnekTabloKey
			{
				get
				{
					return ornekTabloKey;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (ornekTabloKey!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					ornekTabloKey = value;
				}
			}

			public Nullable<long> KolonBigInt
			{
				get
				{
					return kolonBigInt;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonBigInt!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonBigInt = value;
				}
			}

			public object KolonBinary
			{
				get
				{
					return kolonBinary;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonBinary!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonBinary = value;
				}
			}

			public Nullable<bool> KolonBit
			{
				get
				{
					return kolonBit;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonBit!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonBit = value;
				}
			}

			public string KolonChar
			{
				get
				{
					return kolonChar;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonChar!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonChar = value;
				}
			}

			public Nullable<DateTime> KolonDateTime
			{
				get
				{
					return kolonDateTime;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonDateTime!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonDateTime = value;
				}
			}

			public Nullable<decimal> KolonDecimal
			{
				get
				{
					return kolonDecimal;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonDecimal!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonDecimal = value;
				}
			}

			public Nullable<double> KolonFloat
			{
				get
				{
					return kolonFloat;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonFloat!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonFloat = value;
				}
			}

			public byte[] KolonImage
			{
				get
				{
					return kolonImage;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonImage!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonImage = value;
				}
			}

			public Nullable<int> KolonInt
			{
				get
				{
					return kolonInt;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonInt!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonInt = value;
				}
			}

			public Nullable<decimal> KolonMoney
			{
				get
				{
					return kolonMoney;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonMoney!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonMoney = value;
				}
			}

			public string KolonNChar
			{
				get
				{
					return kolonNChar;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonNChar!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonNChar = value;
				}
			}

			public string KolonNText
			{
				get
				{
					return kolonNText;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonNText!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonNText = value;
				}
			}

			public Nullable<decimal> KolonNumeric
			{
				get
				{
					return kolonNumeric;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonNumeric!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonNumeric = value;
				}
			}

			public string KolonNVarchar
			{
				get
				{
					return kolonNVarchar;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonNVarchar!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonNVarchar = value;
				}
			}

			public string KolonNVarcharMax
			{
				get
				{
					return kolonNVarcharMax;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonNVarcharMax!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonNVarcharMax = value;
				}
			}

			public Nullable<float> KolonReal
			{
				get
				{
					return kolonReal;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonReal!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonReal = value;
				}
			}

			public Nullable<DateTime> KolonSmallDateTime
			{
				get
				{
					return kolonSmallDateTime;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonSmallDateTime!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonSmallDateTime = value;
				}
			}

			public Nullable<short> KolonSmallInt
			{
				get
				{
					return kolonSmallInt;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonSmallInt!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonSmallInt = value;
				}
			}

			public Nullable<decimal> KolonSmallMoney
			{
				get
				{
					return kolonSmallMoney;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonSmallMoney!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonSmallMoney = value;
				}
			}

			public object KolonSqlVariant
			{
				get
				{
					return kolonSqlVariant;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonSqlVariant!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonSqlVariant = value;
				}
			}

			public string KolonText
			{
				get
				{
					return kolonText;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonText!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonText = value;
				}
			}

			public byte[] KolonTimeStamp
			{
				get
				{
					return kolonTimeStamp;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonTimeStamp!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonTimeStamp = value;
				}
			}

			public Nullable<byte> KolonTinyInt
			{
				get
				{
					return kolonTinyInt;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonTinyInt!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonTinyInt = value;
				}
			}

			public Nullable<Guid> KolonUniqueIdentifier
			{
				get
				{
					return kolonUniqueIdentifier;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonUniqueIdentifier!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonUniqueIdentifier = value;
				}
			}

			public byte[] KolonVarBinary
			{
				get
				{
					return kolonVarBinary;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonVarBinary!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonVarBinary = value;
				}
			}

			public byte[] KolonVarBinaryMax
			{
				get
				{
					return kolonVarBinaryMax;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonVarBinaryMax!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonVarBinaryMax = value;
				}
			}

			public string KolonVarchar
			{
				get
				{
					return kolonVarchar;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonVarchar!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonVarchar = value;
				}
			}

			public string KolonVarcharMax
			{
				get
				{
					return kolonVarcharMax;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonVarcharMax!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonVarcharMax = value;
				}
			}

			public string KolonXml
			{
				get
				{
					return kolonXml;
				}
				set
				{
					if ((this.RowState == DataRowState.Unchanged) && (kolonXml!= value))
					{
						this.RowState = DataRowState.Modified;
					}
					kolonXml = value;
				}
			}

			public string OrnekTabloKeyAsString
			{
				get
				{
					return ornekTabloKey.ToString();
				}
				set
				{
					try
					{
						Guid _a = new Guid(value);
					OrnekTabloKey = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"OrnekTabloKey","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonBigIntAsString
			{
				get
				{
					return kolonBigInt.ToString();
				}
				set
				{
					try
					{
						long _a = Convert.ToInt64(value);
					KolonBigInt = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonBigInt","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonBinaryAsString
			{
				get
				{
					return kolonBinary.ToString();
				}
				set
				{
					try
					{
					object _a =(object) value;
					KolonBinary = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonBinary","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonBitAsString
			{
				get
				{
					return kolonBit.ToString();
				}
				set
				{
					try
					{
						bool _a = Convert.ToBoolean(value);
					KolonBit = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonBit","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonCharAsString
			{
				get
				{
					return kolonChar.ToString();
				}
				set
				{
					KolonChar = value;
				}
			}

			public string KolonDateTimeAsString
			{
				get
				{
					return kolonDateTime.ToString();
				}
				set
				{
					try
					{
						DateTime _a = Convert.ToDateTime(value);
					KolonDateTime = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonDateTime","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonDecimalAsString
			{
				get
				{
					return kolonDecimal.ToString();
				}
				set
				{
					try
					{
						decimal _a = Convert.ToDecimal(value);
					KolonDecimal = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonDecimal","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonFloatAsString
			{
				get
				{
					return kolonFloat.ToString();
				}
				set
				{
					try
					{
						double _a = Convert.ToDouble(value);
					KolonFloat = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonFloat","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonImageAsString
			{
				get
				{
					return kolonImage.ToString();
				}
				set
				{
					throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
				}
			}

			public string KolonIntAsString
			{
				get
				{
					return kolonInt.ToString();
				}
				set
				{
					try
					{
						int _a = Convert.ToInt32(value);
					KolonInt = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonInt","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonMoneyAsString
			{
				get
				{
					return kolonMoney.ToString();
				}
				set
				{
					try
					{
						decimal _a = Convert.ToDecimal(value);
					KolonMoney = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonMoney","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonNCharAsString
			{
				get
				{
					return kolonNChar.ToString();
				}
				set
				{
					KolonNChar = value;
				}
			}

			public string KolonNTextAsString
			{
				get
				{
					return kolonNText.ToString();
				}
				set
				{
					KolonNText = value;
				}
			}

			public string KolonNumericAsString
			{
				get
				{
					return kolonNumeric.ToString();
				}
				set
				{
					try
					{
						decimal _a = Convert.ToDecimal(value);
					KolonNumeric = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonNumeric","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonNVarcharAsString
			{
				get
				{
					return kolonNVarchar.ToString();
				}
				set
				{
					KolonNVarchar = value;
				}
			}

			public string KolonNVarcharMaxAsString
			{
				get
				{
					return kolonNVarcharMax.ToString();
				}
				set
				{
					KolonNVarcharMax = value;
				}
			}

			public string KolonRealAsString
			{
				get
				{
					return kolonReal.ToString();
				}
				set
				{
					try
					{
						float _a = Convert.ToSingle(value);
					KolonReal = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonReal","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonSmallDateTimeAsString
			{
				get
				{
					return kolonSmallDateTime.ToString();
				}
				set
				{
					try
					{
						DateTime _a = Convert.ToDateTime(value);
					KolonSmallDateTime = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallDateTime","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonSmallIntAsString
			{
				get
				{
					return kolonSmallInt.ToString();
				}
				set
				{
					try
					{
						short _a = Convert.ToInt16(value);
					KolonSmallInt = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallInt","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonSmallMoneyAsString
			{
				get
				{
					return kolonSmallMoney.ToString();
				}
				set
				{
					try
					{
						decimal _a = Convert.ToDecimal(value);
					KolonSmallMoney = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallMoney","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonSqlVariantAsString
			{
				get
				{
					return kolonSqlVariant.ToString();
				}
				set
				{
					try
					{
					object _a =(object) value;
					KolonSqlVariant = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSqlVariant","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonTextAsString
			{
				get
				{
					return kolonText.ToString();
				}
				set
				{
					KolonText = value;
				}
			}

			public string KolonTimeStampAsString
			{
				get
				{
					return kolonTimeStamp.ToString();
				}
				set
				{
					throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
				}
			}

			public string KolonTinyIntAsString
			{
				get
				{
					return kolonTinyInt.ToString();
				}
				set
				{
					try
					{
						byte _a = Convert.ToByte(value);
					KolonTinyInt = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonTinyInt","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonUniqueIdentifierAsString
			{
				get
				{
					return kolonUniqueIdentifier.ToString();
				}
				set
				{
					try
					{
						Guid _a = new Guid(value);
					KolonUniqueIdentifier = _a;
					}
					catch(Exception ex)
					{
						this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonUniqueIdentifier","Ceviri islemi Başarısız oldu"));
					}
				}
			}

			public string KolonVarBinaryAsString
			{
				get
				{
					return kolonVarBinary.ToString();
				}
				set
				{
					throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
				}
			}

			public string KolonVarBinaryMaxAsString
			{
				get
				{
					return kolonVarBinaryMax.ToString();
				}
				set
				{
					throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
				}
			}

			public string KolonVarcharAsString
			{
				get
				{
					return kolonVarchar.ToString();
				}
				set
				{
					KolonVarchar = value;
				}
			}

			public string KolonVarcharMaxAsString
			{
				get
				{
					return kolonVarcharMax.ToString();
				}
				set
				{
					KolonVarcharMax = value;
				}
			}

			public string KolonXmlAsString
			{
				get
				{
					return kolonXml.ToString();
				}
				set
				{
					KolonXml = value;
				}
			}

		public class PropertyIsimleri
		{
			public const string OrnekTabloKey = "OrnekTabloKey";
			public const string KolonBigInt = "KolonBigInt";
			public const string KolonBinary = "KolonBinary";
			public const string KolonBit = "KolonBit";
			public const string KolonChar = "KolonChar";
			public const string KolonDateTime = "KolonDateTime";
			public const string KolonDecimal = "KolonDecimal";
			public const string KolonFloat = "KolonFloat";
			public const string KolonImage = "KolonImage";
			public const string KolonInt = "KolonInt";
			public const string KolonMoney = "KolonMoney";
			public const string KolonNChar = "KolonNChar";
			public const string KolonNText = "KolonNText";
			public const string KolonNumeric = "KolonNumeric";
			public const string KolonNVarchar = "KolonNVarchar";
			public const string KolonNVarcharMax = "KolonNVarcharMax";
			public const string KolonReal = "KolonReal";
			public const string KolonSmallDateTime = "KolonSmallDateTime";
			public const string KolonSmallInt = "KolonSmallInt";
			public const string KolonSmallMoney = "KolonSmallMoney";
			public const string KolonSqlVariant = "KolonSqlVariant";
			public const string KolonText = "KolonText";
			public const string KolonTimeStamp = "KolonTimeStamp";
			public const string KolonTinyInt = "KolonTinyInt";
			public const string KolonUniqueIdentifier = "KolonUniqueIdentifier";
			public const string KolonVarBinary = "KolonVarBinary";
			public const string KolonVarBinaryMax = "KolonVarBinaryMax";
			public const string KolonVarchar = "KolonVarchar";
			public const string KolonVarcharMax = "KolonVarcharMax";
			public const string KolonXml = "KolonXml";
		}
			public OrnekTablo ShallowCopy()
			{
				OrnekTablo obj = new OrnekTablo();
				obj.ornekTabloKey = ornekTabloKey;
				obj.kolonBigInt = kolonBigInt;
				obj.kolonBinary = kolonBinary;
				obj.kolonBit = kolonBit;
				obj.kolonChar = kolonChar;
				obj.kolonDateTime = kolonDateTime;
				obj.kolonDecimal = kolonDecimal;
				obj.kolonFloat = kolonFloat;
				obj.kolonImage = kolonImage;
				obj.kolonInt = kolonInt;
				obj.kolonMoney = kolonMoney;
				obj.kolonNChar = kolonNChar;
				obj.kolonNText = kolonNText;
				obj.kolonNumeric = kolonNumeric;
				obj.kolonNVarchar = kolonNVarchar;
				obj.kolonNVarcharMax = kolonNVarcharMax;
				obj.kolonReal = kolonReal;
				obj.kolonSmallDateTime = kolonSmallDateTime;
				obj.kolonSmallInt = kolonSmallInt;
				obj.kolonSmallMoney = kolonSmallMoney;
				obj.kolonSqlVariant = kolonSqlVariant;
				obj.kolonText = kolonText;
				obj.kolonTimeStamp = kolonTimeStamp;
				obj.kolonTinyInt = kolonTinyInt;
				obj.kolonUniqueIdentifier = kolonUniqueIdentifier;
				obj.kolonVarBinary = kolonVarBinary;
				obj.kolonVarBinaryMax = kolonVarBinaryMax;
				obj.kolonVarchar = kolonVarchar;
				obj.kolonVarcharMax = kolonVarcharMax;
				obj.kolonXml = kolonXml;
				return obj;
			}
		

		protected override void OnaylamaListesiniOlusturCodeGeneration()
		{
		}
		public static class EtiketIsimleri
		{
			const string namespaceVeClass = "Karkas.Ornek.TypeLibrary.Ornekler";
			public static string OrnekTabloKey
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".OrnekTabloKey"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "OrnekTabloKey";
					}
				}
			}
			public static string KolonBigInt
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonBigInt"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonBigInt";
					}
				}
			}
			public static string KolonBinary
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonBinary"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonBinary";
					}
				}
			}
			public static string KolonBit
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonBit"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonBit";
					}
				}
			}
			public static string KolonChar
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonChar"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonChar";
					}
				}
			}
			public static string KolonDateTime
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonDateTime"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonDateTime";
					}
				}
			}
			public static string KolonDecimal
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonDecimal"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonDecimal";
					}
				}
			}
			public static string KolonFloat
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonFloat"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonFloat";
					}
				}
			}
			public static string KolonImage
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonImage"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonImage";
					}
				}
			}
			public static string KolonInt
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonInt"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonInt";
					}
				}
			}
			public static string KolonMoney
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonMoney"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonMoney";
					}
				}
			}
			public static string KolonNChar
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNChar"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonNChar";
					}
				}
			}
			public static string KolonNText
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNText"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonNText";
					}
				}
			}
			public static string KolonNumeric
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNumeric"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonNumeric";
					}
				}
			}
			public static string KolonNVarchar
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNVarchar"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonNVarchar";
					}
				}
			}
			public static string KolonNVarcharMax
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNVarcharMax"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonNVarcharMax";
					}
				}
			}
			public static string KolonReal
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonReal"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonReal";
					}
				}
			}
			public static string KolonSmallDateTime
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonSmallDateTime"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonSmallDateTime";
					}
				}
			}
			public static string KolonSmallInt
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonSmallInt"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonSmallInt";
					}
				}
			}
			public static string KolonSmallMoney
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonSmallMoney"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonSmallMoney";
					}
				}
			}
			public static string KolonSqlVariant
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonSqlVariant"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonSqlVariant";
					}
				}
			}
			public static string KolonText
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonText"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonText";
					}
				}
			}
			public static string KolonTimeStamp
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonTimeStamp"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonTimeStamp";
					}
				}
			}
			public static string KolonTinyInt
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonTinyInt"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonTinyInt";
					}
				}
			}
			public static string KolonUniqueIdentifier
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonUniqueIdentifier"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonUniqueIdentifier";
					}
				}
			}
			public static string KolonVarBinary
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonVarBinary"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonVarBinary";
					}
				}
			}
			public static string KolonVarBinaryMax
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonVarBinaryMax"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonVarBinaryMax";
					}
				}
			}
			public static string KolonVarchar
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonVarchar"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonVarchar";
					}
				}
			}
			public static string KolonVarcharMax
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonVarcharMax"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonVarcharMax";
					}
				}
			}
			public static string KolonXml
			{
				get
				{
					string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonXml"];
					if (s != null)
					{
						return s;
					}
					else
					{
						return "KolonXml";
					}
				}
			}
		}
	}
}
