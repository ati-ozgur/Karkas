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
	public partial class BasitTabloDal : BaseDal<BasitTablo>
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
				return @"SELECT COUNT(*) FROM ORNEKLER.BASIT_TABLO";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT BasitTabloKey,Adi,Soyadi FROM ORNEKLER.BASIT_TABLO";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.BASIT_TABLO WHERE BasitTabloKe";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.BASIT_TABLO
				 SET 
				Adi = @Adi,Soyadi = @Soyadi				
				WHERE 
				BasitTabloKey = @BasitTabloKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.BASIT_TABLO 
				 (BasitTabloKey,Adi,Soyadi) 
				 VALUES 
								(@BasitTabloKey,@Adi,@Soyadi)";
			}
		}
		public List<BasitTablo>SorgulaHepsiniGetir()
		{
			List<BasitTablo> liste = new List<BasitTablo>();
			SorguCalistir(liste);
			return liste;
		}
		public BasitTablo SorgulaBasitTabloKeyIle(Guid p1)
		{
			List<BasitTablo> liste = new List<BasitTablo>();
			SorguCalistir(liste,String.Format(" BasitTabloKey = '{0}'", p1));			
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
		
		protected override void ProcessRow(System.Data.IDataReader dr, BasitTablo row)
		{
			row.BasitTabloKey = dr.GetGuid(0);
			row.Adi = dr.GetString(1);
			row.Soyadi = dr.GetString(2);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, BasitTablo row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		BasitTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		BasitTablo		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier, row.BasitTabloKey);
		}
	}
}
