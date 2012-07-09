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
	[DebuggerDisplay("OrnekTabloKey = {OrnekTabloKey}")]
	public partial class 	OrnekTablo: BaseTypeLibrary
	{
		private Guid ornekTabloKey;
		private Nullable<long> kolonBigInt;
		private byte[] kolonBinary;
		private Nullable<bool> kolonBit;
		private string kolonChar;
		private Nullable<DateTime> kolonDateTime;
		private Nullable<decimal> kolonDecimal;
		private Nullable<double> kolonFloat;
		private byte[] kolonImage;
		private Nullable<int> kolonInt;
		private Nullable<decimal> kolonMoney;
		private string kolonNchar;
		private string kolonNtext;
		private Nullable<decimal> kolonNumeric;
		private string kolonNvarchar;
		private string kolonNvarcharMax;
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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid OrnekTabloKey
		{
			[DebuggerStepThrough]
			get
			{
				return ornekTabloKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ornekTabloKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ornekTabloKey = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<long> KolonBigInt
		{
			[DebuggerStepThrough]
			get
			{
				return kolonBigInt;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonBigInt!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonBigInt = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] KolonBinary
		{
			[DebuggerStepThrough]
			get
			{
				return kolonBinary;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonBinary!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonBinary = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<bool> KolonBit
		{
			[DebuggerStepThrough]
			get
			{
				return kolonBit;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonBit!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonBit = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonChar
		{
			[DebuggerStepThrough]
			get
			{
				return kolonChar;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonChar!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonChar = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<DateTime> KolonDateTime
		{
			[DebuggerStepThrough]
			get
			{
				return kolonDateTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonDateTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonDateTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> KolonDecimal
		{
			[DebuggerStepThrough]
			get
			{
				return kolonDecimal;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonDecimal!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonDecimal = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<double> KolonFloat
		{
			[DebuggerStepThrough]
			get
			{
				return kolonFloat;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonFloat!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonFloat = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] KolonImage
		{
			[DebuggerStepThrough]
			get
			{
				return kolonImage;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonImage!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonImage = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<int> KolonInt
		{
			[DebuggerStepThrough]
			get
			{
				return kolonInt;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonInt!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonInt = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> KolonMoney
		{
			[DebuggerStepThrough]
			get
			{
				return kolonMoney;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonMoney!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonMoney = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonNchar
		{
			[DebuggerStepThrough]
			get
			{
				return kolonNchar;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonNchar!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonNchar = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonNtext
		{
			[DebuggerStepThrough]
			get
			{
				return kolonNtext;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonNtext!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonNtext = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> KolonNumeric
		{
			[DebuggerStepThrough]
			get
			{
				return kolonNumeric;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonNumeric!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonNumeric = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonNvarchar
		{
			[DebuggerStepThrough]
			get
			{
				return kolonNvarchar;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonNvarchar!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonNvarchar = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonNvarcharMax
		{
			[DebuggerStepThrough]
			get
			{
				return kolonNvarcharMax;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonNvarcharMax!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonNvarcharMax = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<float> KolonReal
		{
			[DebuggerStepThrough]
			get
			{
				return kolonReal;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonReal!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonReal = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<DateTime> KolonSmallDateTime
		{
			[DebuggerStepThrough]
			get
			{
				return kolonSmallDateTime;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonSmallDateTime!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonSmallDateTime = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<short> KolonSmallInt
		{
			[DebuggerStepThrough]
			get
			{
				return kolonSmallInt;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonSmallInt!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonSmallInt = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<decimal> KolonSmallMoney
		{
			[DebuggerStepThrough]
			get
			{
				return kolonSmallMoney;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonSmallMoney!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonSmallMoney = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public object KolonSqlVariant
		{
			[DebuggerStepThrough]
			get
			{
				return kolonSqlVariant;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonSqlVariant!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonSqlVariant = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonText
		{
			[DebuggerStepThrough]
			get
			{
				return kolonText;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonText!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonText = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] KolonTimeStamp
		{
			[DebuggerStepThrough]
			get
			{
				return kolonTimeStamp;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonTimeStamp!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonTimeStamp = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<byte> KolonTinyInt
		{
			[DebuggerStepThrough]
			get
			{
				return kolonTinyInt;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonTinyInt!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonTinyInt = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<Guid> KolonUniqueIdentifier
		{
			[DebuggerStepThrough]
			get
			{
				return kolonUniqueIdentifier;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonUniqueIdentifier!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonUniqueIdentifier = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] KolonVarBinary
		{
			[DebuggerStepThrough]
			get
			{
				return kolonVarBinary;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonVarBinary!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonVarBinary = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] KolonVarBinaryMax
		{
			[DebuggerStepThrough]
			get
			{
				return kolonVarBinaryMax;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonVarBinaryMax!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonVarBinaryMax = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonVarchar
		{
			[DebuggerStepThrough]
			get
			{
				return kolonVarchar;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonVarchar!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonVarchar = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonVarcharMax
		{
			[DebuggerStepThrough]
			get
			{
				return kolonVarcharMax;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonVarcharMax!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonVarcharMax = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string KolonXml
		{
			[DebuggerStepThrough]
			get
			{
				return kolonXml;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (kolonXml!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				kolonXml = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string OrnekTabloKeyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return ornekTabloKey.ToString(); 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					Guid _a = new Guid(value);
				OrnekTabloKey = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"OrnekTabloKey",string.Format("","OrnekTabloKey","Guid")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonBigIntAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonBigInt != null ? kolonBigInt.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					long _a = Convert.ToInt64(value);
				KolonBigInt = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonBigInt",string.Format("","KolonBigInt","long")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonBinaryAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonBinary != null ? kolonBinary.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonBitAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonBit != null ? kolonBit.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					bool _a = Convert.ToBoolean(value);
				KolonBit = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonBit",string.Format("","KolonBit","bool")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonDateTimeAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonDateTime != null ? kolonDateTime.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				KolonDateTime = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonDateTime",string.Format("","KolonDateTime","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonDecimalAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonDecimal != null ? kolonDecimal.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				KolonDecimal = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonDecimal",string.Format("","KolonDecimal","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonFloatAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonFloat != null ? kolonFloat.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					double _a = Convert.ToDouble(value);
				KolonFloat = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonFloat",string.Format("","KolonFloat","double")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonImageAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonImage != null ? kolonImage.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonIntAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonInt != null ? kolonInt.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					int _a = Convert.ToInt32(value);
				KolonInt = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonInt",string.Format("","KolonInt","int")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonMoneyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonMoney != null ? kolonMoney.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				KolonMoney = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonMoney",string.Format("","KolonMoney","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonNumericAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonNumeric != null ? kolonNumeric.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				KolonNumeric = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonNumeric",string.Format("","KolonNumeric","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonRealAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonReal != null ? kolonReal.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					float _a = Convert.ToSingle(value);
				KolonReal = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonReal",string.Format("","KolonReal","float")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonSmallDateTimeAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonSmallDateTime != null ? kolonSmallDateTime.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					DateTime _a = Convert.ToDateTime(value);
				KolonSmallDateTime = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallDateTime",string.Format("","KolonSmallDateTime","DateTime")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonSmallIntAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonSmallInt != null ? kolonSmallInt.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					short _a = Convert.ToInt16(value);
				KolonSmallInt = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallInt",string.Format("","KolonSmallInt","short")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonSmallMoneyAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonSmallMoney != null ? kolonSmallMoney.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					decimal _a = Convert.ToDecimal(value);
				KolonSmallMoney = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSmallMoney",string.Format("","KolonSmallMoney","decimal")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonSqlVariantAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonSqlVariant != null ? kolonSqlVariant.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
				object _a =(object) value;
				KolonSqlVariant = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonSqlVariant",string.Format("","KolonSqlVariant","object")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonTimeStampAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonTimeStamp != null ? kolonTimeStamp.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonTinyIntAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonTinyInt != null ? kolonTinyInt.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					byte _a = Convert.ToByte(value);
				KolonTinyInt = _a;
				}
				catch(Exception)
				{
					this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonTinyInt",string.Format("","KolonTinyInt","byte")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonUniqueIdentifierAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonUniqueIdentifier != null ? kolonUniqueIdentifier.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				try
				{
					Guid _a = new Guid(value);
				KolonUniqueIdentifier = _a;
				}
				catch(Exception)
				{
					//this.Onaylayici.OnaylayiciListesi.Add(new DaimaBasarisiz(this,"KolonUniqueIdentifier",string.Format("","KolonUniqueIdentifier","Guid")));
				}
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonVarBinaryAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonVarBinary != null ? kolonVarBinary.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[XmlIgnore, SoapIgnore]
		public string KolonVarBinaryMaxAsString
		{
			[DebuggerStepThrough]
			get
			{
				 return kolonVarBinaryMax != null ? kolonVarBinaryMax.ToString() : ""; 
			}
			[DebuggerStepThrough]
			set
			{
				throw new ArgumentException("String'ten byte[] array'e cevirim desteklenmemektedir");
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
		public const string KolonNchar = "KolonNChar";
		public const string KolonNtext = "KolonNText";
		public const string KolonNumeric = "KolonNumeric";
		public const string KolonNvarchar = "KolonNVarchar";
		public const string KolonNvarcharMax = "KolonNVarcharMax";
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
			obj.kolonNchar = kolonNchar;
			obj.kolonNtext = kolonNtext;
			obj.kolonNumeric = kolonNumeric;
			obj.kolonNvarchar = kolonNvarchar;
			obj.kolonNvarcharMax = kolonNvarcharMax;
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
		public static string KolonNchar
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNchar"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "KolonNchar";
				}
			}
		}
		public static string KolonNtext
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNtext"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "KolonNtext";
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
		public static string KolonNvarchar
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNvarchar"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "KolonNvarchar";
				}
			}
		}
		public static string KolonNvarcharMax
		{
			get
			{
				string s = ConfigurationManager.AppSettings[namespaceVeClass + ".KolonNvarcharMax"];
				if (s != null)
				{
					return s;
				}
				else
				{
					return "KolonNvarcharMax";
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
