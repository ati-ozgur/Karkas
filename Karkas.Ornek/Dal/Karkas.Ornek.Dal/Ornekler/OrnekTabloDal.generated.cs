using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using System.Data.Common;


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
		protected override void identityKolonDegeriniSetle(OrnekTablo pTypeLibrary,long pIdentityKolonValue)
		{
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
		
		
		public override string PrimaryKey
		{
			get
			{
				return "OrnekTabloKey";
			}
		}
		
		public virtual void Sil(Guid OrnekTabloKey)
		{
			OrnekTablo row = new OrnekTablo();
			row.OrnekTabloKey = OrnekTabloKey;
			base.Sil(row);
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
				// row.KolonBinary = dr.GetValue(2);
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
				row.KolonNchar = dr.GetString(11);
			}
			if (!dr.IsDBNull(12))
			{
				row.KolonNtext = dr.GetString(12);
			}
			if (!dr.IsDBNull(13))
			{
				row.KolonNumeric = dr.GetDecimal(13);
			}
			if (!dr.IsDBNull(14))
			{
				row.KolonNvarchar = dr.GetString(14);
			}
			if (!dr.IsDBNull(15))
			{
				row.KolonNvarcharMax = dr.GetString(15);
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
		protected override void InsertCommandParametersAdd(DbCommand cmd, OrnekTablo row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@OrnekTabloKey",DbType.Guid, row.OrnekTabloKey);
			builder.parameterEkle("@KolonBigInt",DbType.Int64, row.KolonBigInt);
			builder.parameterEkle("@KolonBinary",DbType.Binary, row.KolonBinary,50);
			builder.parameterEkle("@KolonBit",DbType.Boolean, row.KolonBit);
			builder.parameterEkle("@KolonChar",DbType.AnsiStringFixedLength, row.KolonChar,10);
			builder.parameterEkle("@KolonDateTime",DbType.DateTime, row.KolonDateTime);
			builder.parameterEkle("@KolonDecimal",DbType.Decimal, row.KolonDecimal);
            builder.parameterEkle("@KolonFloat", DbType.Single, row.KolonFloat);
			builder.parameterEkle("@KolonImage",DbType.Object, row.KolonImage,2147483647);
			builder.parameterEkle("@KolonInt",DbType.Int32, row.KolonInt);
			builder.parameterEkle("@KolonMoney",DbType.Decimal, row.KolonMoney);
			builder.parameterEkle("@KolonNChar",DbType.String, row.KolonNchar,10);
            builder.parameterEkle("@KolonNText", DbType.Object, row.KolonNtext, 1073741823);
			builder.parameterEkle("@KolonNumeric",DbType.Decimal, row.KolonNumeric);
			builder.parameterEkle("@KolonNVarchar",DbType.String, row.KolonNvarchar,50);
			builder.parameterEkle("@KolonNVarcharMax",DbType.Object, row.KolonNvarcharMax);
			builder.parameterEkle("@KolonReal",DbType.Double, row.KolonReal);
			builder.parameterEkle("@KolonSmallDateTime",DbType.DateTime, row.KolonSmallDateTime);
			builder.parameterEkle("@KolonSmallInt",DbType.Int16, row.KolonSmallInt);
			builder.parameterEkle("@KolonSmallMoney",DbType.Currency, row.KolonSmallMoney);
			builder.parameterEkle("@KolonSqlVariant",DbType.Object, row.KolonSqlVariant);
			builder.parameterEkle("@KolonText",DbType.Object, row.KolonText,2147483647);
			builder.parameterEkle("@KolonTinyInt",DbType.Byte, row.KolonTinyInt);
			builder.parameterEkle("@KolonUniqueIdentifier",DbType.Guid, row.KolonUniqueIdentifier);
			builder.parameterEkle("@KolonVarBinary",DbType.Binary, row.KolonVarBinary,50);
			builder.parameterEkle("@KolonVarBinaryMax",DbType.Object, row.KolonVarBinaryMax);
			builder.parameterEkle("@KolonVarchar",DbType.String, row.KolonVarchar,50);
			builder.parameterEkle("@KolonVarcharMax",DbType.String, row.KolonVarcharMax);
			builder.parameterEkle("@KolonXml",DbType.Xml, row.KolonXml);
		}
		protected override void UpdateCommandParametersAdd(DbCommand cmd, 		OrnekTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
            builder.parameterEkle("@OrnekTabloKey", DbType.Guid, row.OrnekTabloKey);
            builder.parameterEkle("@KolonBigInt", DbType.Int64, row.KolonBigInt);
            builder.parameterEkle("@KolonBinary", DbType.Binary, row.KolonBinary, 50);
            builder.parameterEkle("@KolonBit", DbType.Boolean, row.KolonBit);
            builder.parameterEkle("@KolonChar", DbType.AnsiStringFixedLength, row.KolonChar, 10);
            builder.parameterEkle("@KolonDateTime", DbType.DateTime, row.KolonDateTime);
            builder.parameterEkle("@KolonDecimal", DbType.Decimal, row.KolonDecimal);
            builder.parameterEkle("@KolonFloat", DbType.Single, row.KolonFloat);
            builder.parameterEkle("@KolonImage", DbType.Object, row.KolonImage, 2147483647);
            builder.parameterEkle("@KolonInt", DbType.Int32, row.KolonInt);
            builder.parameterEkle("@KolonMoney", DbType.Decimal, row.KolonMoney);
            builder.parameterEkle("@KolonNChar", DbType.String, row.KolonNchar, 10);
            builder.parameterEkle("@KolonNText", DbType.Object, row.KolonNtext, 1073741823);
            builder.parameterEkle("@KolonNumeric", DbType.Decimal, row.KolonNumeric);
            builder.parameterEkle("@KolonNVarchar", DbType.String, row.KolonNvarchar, 50);
            builder.parameterEkle("@KolonNVarcharMax", DbType.Object, row.KolonNvarcharMax);
            builder.parameterEkle("@KolonReal", DbType.Double, row.KolonReal);
            builder.parameterEkle("@KolonSmallDateTime", DbType.DateTime, row.KolonSmallDateTime);
            builder.parameterEkle("@KolonSmallInt", DbType.Int16, row.KolonSmallInt);
            builder.parameterEkle("@KolonSmallMoney", DbType.Currency, row.KolonSmallMoney);
            builder.parameterEkle("@KolonSqlVariant", DbType.Object, row.KolonSqlVariant);
            builder.parameterEkle("@KolonText", DbType.Object, row.KolonText, 2147483647);
            builder.parameterEkle("@KolonTinyInt", DbType.Byte, row.KolonTinyInt);
            builder.parameterEkle("@KolonUniqueIdentifier", DbType.Guid, row.KolonUniqueIdentifier);
            builder.parameterEkle("@KolonVarBinary", DbType.Binary, row.KolonVarBinary, 50);
            builder.parameterEkle("@KolonVarBinaryMax", DbType.Object, row.KolonVarBinaryMax);
            builder.parameterEkle("@KolonVarchar", DbType.String, row.KolonVarchar, 50);
            builder.parameterEkle("@KolonVarcharMax", DbType.String, row.KolonVarcharMax);
            builder.parameterEkle("@KolonXml", DbType.Xml, row.KolonXml);
        }
		protected override void DeleteCommandParametersAdd(DbCommand cmd, 		OrnekTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@OrnekTabloKey",DbType.Guid, row.OrnekTabloKey);
		}
	}
}
