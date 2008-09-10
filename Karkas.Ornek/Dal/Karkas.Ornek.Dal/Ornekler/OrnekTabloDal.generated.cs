using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;


namespace Karkas.Ornek.Dal.Ornekler
{
	public partial class OrnekTabloDal : BaseDal<OrnekTablo>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.ORNEK_TABLO";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT OrnekTabloKey,KolonBigInt,KolonBinary,KolonBit,KolonChar,KolonDateTime,KolonDecimal,KolonFloat,KolonImage,KolonInt,KolonMoney,KolonNChar,KolonNText,KolonNumeric,KolonNVarchar,KolonNVarcharMax,KolonReal,KolonSmallDateTime,KolonSmallInt,KolonSmallMoney,KolonSqlVariant,KolonText,KolonTimeStamp,KolonTinyInt,KolonUniqueIdentifier,KolonVarBinary,KolonVarBinaryMax,KolonVarchar,KolonVarcharMax,KolonXml FROM ORNEKLER.ORNEK_TABLO";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.ORNEK_TABLO WHERE OrnekTabloKey = @OrnekTabloKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.ORNEK_TABLO
				 SET 
				KolonBigInt = @KolonBigInt,KolonBinary = @KolonBinary,KolonBit = @KolonBit,KolonChar = @KolonChar,KolonDateTime = @KolonDateTime,KolonDecimal = @KolonDecimal,KolonFloat = @KolonFloat,KolonImage = @KolonImage,KolonInt = @KolonInt,KolonMoney = @KolonMoney,KolonNChar = @KolonNChar,KolonNText = @KolonNText,KolonNumeric = @KolonNumeric,KolonNVarchar = @KolonNVarchar,KolonNVarcharMax = @KolonNVarcharMax,KolonReal = @KolonReal,KolonSmallDateTime = @KolonSmallDateTime,KolonSmallInt = @KolonSmallInt,KolonSmallMoney = @KolonSmallMoney,KolonSqlVariant = @KolonSqlVariant,KolonText = @KolonText,KolonTinyInt = @KolonTinyInt,KolonUniqueIdentifier = @KolonUniqueIdentifier,KolonVarBinary = @KolonVarBinary,KolonVarBinaryMax = @KolonVarBinaryMax,KolonVarchar = @KolonVarchar,KolonVarcharMax = @KolonVarcharMax,KolonXml = @KolonXml				
				WHERE 
				OrnekTabloKey = @OrnekTabloKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.ORNEK_TABLO 
				 (OrnekTabloKey,KolonBigInt,KolonBinary,KolonBit,KolonChar,KolonDateTime,KolonDecimal,KolonFloat,KolonImage,KolonInt,KolonMoney,KolonNChar,KolonNText,KolonNumeric,KolonNVarchar,KolonNVarcharMax,KolonReal,KolonSmallDateTime,KolonSmallInt,KolonSmallMoney,KolonSqlVariant,KolonText,KolonTinyInt,KolonUniqueIdentifier,KolonVarBinary,KolonVarBinaryMax,KolonVarchar,KolonVarcharMax,KolonXml) 
				 VALUES 
								(@OrnekTabloKey,@KolonBigInt,@KolonBinary,@KolonBit,@KolonChar,@KolonDateTime,@KolonDecimal,@KolonFloat,@KolonImage,@KolonInt,@KolonMoney,@KolonNChar,@KolonNText,@KolonNumeric,@KolonNVarchar,@KolonNVarcharMax,@KolonReal,@KolonSmallDateTime,@KolonSmallInt,@KolonSmallMoney,@KolonSqlVariant,@KolonText,@KolonTinyInt,@KolonUniqueIdentifier,@KolonVarBinary,@KolonVarBinaryMax,@KolonVarchar,@KolonVarcharMax,@KolonXml)";
			}
		}
		public OrnekTablo SorgulaOrnekTabloKeyIle(Guid p1)
		{
			List<OrnekTablo> liste = new List<OrnekTablo>();
			SorguCalistir(liste,String.Format(" OrnekTabloKey = '{0}'", p1));			
			if (liste.Count > 0)
			{
				return liste[0];
			}
			else
			{
				return null;
			}
		}
		
		protected override bool IdentityVarMi
		{
			get
			{
				return false;
			}
		}
		
		protected override bool PkGuidMi
		{
			get
			{
				return true;
			}
		}
		
		protected override void ProcessRow(System.Data.IDataReader dr, OrnekTablo row)
		{
			row.OrnekTabloKey = dr.GetGuid(0);
			if (!dr.IsDBNull(1))
			{
				row.KolonBigInt = dr.GetInt64(1);
			}
			if (!dr.IsDBNull(2))
			{
				row.KolonBinary = dr.GetValue(2);
			}
			if (!dr.IsDBNull(3))
			{
				row.KolonBit = dr.GetBoolean(3);
			}
			if (!dr.IsDBNull(4))
			{
				row.KolonChar = dr.GetString(4);
			}
			if (!dr.IsDBNull(5))
			{
				row.KolonDateTime = dr.GetDateTime(5);
			}
			if (!dr.IsDBNull(6))
			{
				row.KolonDecimal = dr.GetDecimal(6);
			}
			if (!dr.IsDBNull(7))
			{
				row.KolonFloat = dr.GetDouble(7);
			}
			if (!dr.IsDBNull(8))
			{
				row.KolonImage = (Byte[])dr.GetValue(8);
			}
			if (!dr.IsDBNull(9))
			{
				row.KolonInt = dr.GetInt32(9);
			}
			if (!dr.IsDBNull(10))
			{
				row.KolonMoney = dr.GetDecimal(10);
			}
			if (!dr.IsDBNull(11))
			{
				row.KolonNChar = dr.GetString(11);
			}
			if (!dr.IsDBNull(12))
			{
				row.KolonNText = dr.GetString(12);
			}
			if (!dr.IsDBNull(13))
			{
				row.KolonNumeric = dr.GetDecimal(13);
			}
			if (!dr.IsDBNull(14))
			{
				row.KolonNVarchar = dr.GetString(14);
			}
			if (!dr.IsDBNull(15))
			{
				row.KolonNVarcharMax = dr.GetString(15);
			}
			if (!dr.IsDBNull(16))
			{
				row.KolonReal = dr.GetFloat(16);
			}
			if (!dr.IsDBNull(17))
			{
				row.KolonSmallDateTime = dr.GetDateTime(17);
			}
			if (!dr.IsDBNull(18))
			{
				row.KolonSmallInt = dr.GetInt16(18);
			}
			if (!dr.IsDBNull(19))
			{
				row.KolonSmallMoney = dr.GetDecimal(19);
			}
			if (!dr.IsDBNull(20))
			{
				row.KolonSqlVariant = dr.GetValue(20);
			}
			if (!dr.IsDBNull(21))
			{
				row.KolonText = dr.GetString(21);
			}
			if (!dr.IsDBNull(22))
			{
				row.KolonTimeStamp = (Byte[])dr.GetValue(22);
			}
			if (!dr.IsDBNull(23))
			{
				row.KolonTinyInt = dr.GetByte(23);
			}
			if (!dr.IsDBNull(24))
			{
				row.KolonUniqueIdentifier = dr.GetGuid(24);
			}
			if (!dr.IsDBNull(25))
			{
				row.KolonVarBinary = (Byte[])dr.GetValue(25);
			}
			if (!dr.IsDBNull(26))
			{
				row.KolonVarBinaryMax = (Byte[])dr.GetValue(26);
			}
			if (!dr.IsDBNull(27))
			{
				row.KolonVarchar = dr.GetString(27);
			}
			if (!dr.IsDBNull(28))
			{
				row.KolonVarcharMax = dr.GetString(28);
			}
			if (!dr.IsDBNull(29))
			{
				row.KolonXml = dr.GetString(29);
			}
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, OrnekTablo row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@OrnekTabloKey",SqlDbType.UniqueIdentifier, row.OrnekTabloKey);
			builder.parameterEkle("@KolonBigInt",SqlDbType.BigInt, row.KolonBigInt);
			builder.parameterEkle("@KolonBinary",SqlDbType.Binary, row.KolonBinary,50);
			builder.parameterEkle("@KolonBit",SqlDbType.Bit, row.KolonBit);
			builder.parameterEkle("@KolonChar",SqlDbType.Char, row.KolonChar,10);
			builder.parameterEkle("@KolonDateTime",SqlDbType.DateTime, row.KolonDateTime);
			builder.parameterEkle("@KolonDecimal",SqlDbType.Decimal, row.KolonDecimal);
			builder.parameterEkle("@KolonFloat",SqlDbType.Float, row.KolonFloat);
			builder.parameterEkle("@KolonImage",SqlDbType.Image, row.KolonImage,2147483647);
			builder.parameterEkle("@KolonInt",SqlDbType.Int, row.KolonInt);
			builder.parameterEkle("@KolonMoney",SqlDbType.Money, row.KolonMoney);
			builder.parameterEkle("@KolonNChar",SqlDbType.NChar, row.KolonNChar,10);
			builder.parameterEkle("@KolonNText",SqlDbType.NText, row.KolonNText,1073741823);
			builder.parameterEkle("@KolonNumeric",SqlDbType.Decimal, row.KolonNumeric);
			builder.parameterEkle("@KolonNVarchar",SqlDbType.NVarChar, row.KolonNVarchar,50);
			builder.parameterEkle("@KolonNVarcharMax",SqlDbType.NVarChar, row.KolonNVarcharMax);
			builder.parameterEkle("@KolonReal",SqlDbType.Real, row.KolonReal);
			builder.parameterEkle("@KolonSmallDateTime",SqlDbType.SmallDateTime, row.KolonSmallDateTime);
			builder.parameterEkle("@KolonSmallInt",SqlDbType.SmallInt, row.KolonSmallInt);
			builder.parameterEkle("@KolonSmallMoney",SqlDbType.SmallMoney, row.KolonSmallMoney);
			builder.parameterEkle("@KolonSqlVariant",SqlDbType.Variant, row.KolonSqlVariant);
			builder.parameterEkle("@KolonText",SqlDbType.Text, row.KolonText,2147483647);
			builder.parameterEkle("@KolonTinyInt",SqlDbType.TinyInt, row.KolonTinyInt);
			builder.parameterEkle("@KolonUniqueIdentifier",SqlDbType.UniqueIdentifier, row.KolonUniqueIdentifier);
			builder.parameterEkle("@KolonVarBinary",SqlDbType.VarBinary, row.KolonVarBinary,50);
			builder.parameterEkle("@KolonVarBinaryMax",SqlDbType.VarBinary, row.KolonVarBinaryMax);
			builder.parameterEkle("@KolonVarchar",SqlDbType.VarChar, row.KolonVarchar,50);
			builder.parameterEkle("@KolonVarcharMax",SqlDbType.VarChar, row.KolonVarcharMax);
			builder.parameterEkle("@KolonXml",SqlDbType.Xml, row.KolonXml);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		OrnekTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@OrnekTabloKey",SqlDbType.UniqueIdentifier, row.OrnekTabloKey);
			builder.parameterEkle("@KolonBigInt",SqlDbType.BigInt, row.KolonBigInt);
			builder.parameterEkle("@KolonBinary",SqlDbType.Binary, row.KolonBinary,50);
			builder.parameterEkle("@KolonBit",SqlDbType.Bit, row.KolonBit);
			builder.parameterEkle("@KolonChar",SqlDbType.Char, row.KolonChar,10);
			builder.parameterEkle("@KolonDateTime",SqlDbType.DateTime, row.KolonDateTime);
			builder.parameterEkle("@KolonDecimal",SqlDbType.Decimal, row.KolonDecimal);
			builder.parameterEkle("@KolonFloat",SqlDbType.Float, row.KolonFloat);
			builder.parameterEkle("@KolonImage",SqlDbType.Image, row.KolonImage,2147483647);
			builder.parameterEkle("@KolonInt",SqlDbType.Int, row.KolonInt);
			builder.parameterEkle("@KolonMoney",SqlDbType.Money, row.KolonMoney);
			builder.parameterEkle("@KolonNChar",SqlDbType.NChar, row.KolonNChar,10);
			builder.parameterEkle("@KolonNText",SqlDbType.NText, row.KolonNText,1073741823);
			builder.parameterEkle("@KolonNumeric",SqlDbType.Decimal, row.KolonNumeric);
			builder.parameterEkle("@KolonNVarchar",SqlDbType.NVarChar, row.KolonNVarchar,50);
			builder.parameterEkle("@KolonNVarcharMax",SqlDbType.NVarChar, row.KolonNVarcharMax);
			builder.parameterEkle("@KolonReal",SqlDbType.Real, row.KolonReal);
			builder.parameterEkle("@KolonSmallDateTime",SqlDbType.SmallDateTime, row.KolonSmallDateTime);
			builder.parameterEkle("@KolonSmallInt",SqlDbType.SmallInt, row.KolonSmallInt);
			builder.parameterEkle("@KolonSmallMoney",SqlDbType.SmallMoney, row.KolonSmallMoney);
			builder.parameterEkle("@KolonSqlVariant",SqlDbType.Variant, row.KolonSqlVariant);
			builder.parameterEkle("@KolonText",SqlDbType.Text, row.KolonText,2147483647);
			builder.parameterEkle("@KolonTinyInt",SqlDbType.TinyInt, row.KolonTinyInt);
			builder.parameterEkle("@KolonUniqueIdentifier",SqlDbType.UniqueIdentifier, row.KolonUniqueIdentifier);
			builder.parameterEkle("@KolonVarBinary",SqlDbType.VarBinary, row.KolonVarBinary,50);
			builder.parameterEkle("@KolonVarBinaryMax",SqlDbType.VarBinary, row.KolonVarBinaryMax);
			builder.parameterEkle("@KolonVarchar",SqlDbType.VarChar, row.KolonVarchar,50);
			builder.parameterEkle("@KolonVarcharMax",SqlDbType.VarChar, row.KolonVarcharMax);
			builder.parameterEkle("@KolonXml",SqlDbType.Xml, row.KolonXml);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		OrnekTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@OrnekTabloKey",SqlDbType.UniqueIdentifier, row.OrnekTabloKey);
		}
	}
}
