using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Validation.ForPonos;
using System.Data;

namespace Karkas.Ornek.TypeLibrary.Ornekler
{
	[Serializable]
	public partial class 	OrnekTablo	
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
	

	protected override void ValidationListesiniOlusturCodeGeneration()
	{		
		}
	}
}
