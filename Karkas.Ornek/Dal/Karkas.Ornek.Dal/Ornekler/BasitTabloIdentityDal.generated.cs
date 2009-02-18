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
	public partial class BasitTabloIdentityDal : BaseDal<BasitTabloIdentity>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(BasitTabloIdentity pTypeLibrary,long pIdentityKolonValue)
		{
			pTypeLibrary.BasitTabloIdentityKey = (int )pIdentityKolonValue;
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.BASIT_TABLO_IDENTITY";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT BasitTabloIdentityKey,Adi,Soyadi FROM ORNEKLER.BASIT_TABLO_IDENTITY";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.BASIT_TABLO_IDENTITY WHERE BasitTabloIdentityKey = @BasitTabloIdentityKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.BASIT_TABLO_IDENTITY
				 SET 
				Adi = @Adi,Soyadi = @Soyadi				
				WHERE 
				 BasitTabloIdentityKey = @BasitTabloIdentityKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.BASIT_TABLO_IDENTITY 
				 (Adi,Soyadi) 
				 VALUES 
								(@Adi,@Soyadi);SELECT scope_identity();";
			}
		}
		public BasitTabloIdentity SorgulaBasitTabloIdentityKeyIle(int p1)
		{
			List<BasitTabloIdentity> liste = new List<BasitTabloIdentity>();
			SorguCalistir(liste,String.Format(" BasitTabloIdentityKey = '{0}'", p1));			
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
				return true;
			}
		}
		
		protected override bool PkGuidMi
		{
			get
			{
				return false;
			}
		}
		
		
		public override string PrimaryKey
		{
			get
			{
				return "BasitTabloIdentityKey";
			}
		}
		
		public virtual void Sil(int BasitTabloIdentityKey)
		{
			BasitTabloIdentity row = new BasitTabloIdentity();
			row.BasitTabloIdentityKey = BasitTabloIdentityKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, BasitTabloIdentity row)
		{
			row.BasitTabloIdentityKey = dr.GetInt32(0);
			row.Adi = dr.GetString(1);
			row.Soyadi = dr.GetString(2);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, BasitTabloIdentity row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		BasitTabloIdentity		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@BasitTabloIdentityKey",SqlDbType.Int, row.BasitTabloIdentityKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		BasitTabloIdentity		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@BasitTabloIdentityKey",SqlDbType.Int, row.BasitTabloIdentityKey);
		}
	}
}
