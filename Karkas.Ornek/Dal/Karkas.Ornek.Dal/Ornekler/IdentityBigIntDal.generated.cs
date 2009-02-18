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
	public partial class IdentityBigIntDal : BaseDal<IdentityBigInt>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(IdentityBigInt pTypeLibrary,long pIdentityKolonValue)
		{
			pTypeLibrary.IdentityBigIntKey = (long )pIdentityKolonValue;
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.IDENTITY_BIG_INT";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT IdentityBigIntKey,Adi FROM ORNEKLER.IDENTITY_BIG_INT";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.IDENTITY_BIG_INT WHERE IdentityBigIntKey = @IdentityBigIntKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.IDENTITY_BIG_INT
				 SET 
				Adi = @Adi				
				WHERE 
				 IdentityBigIntKey = @IdentityBigIntKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.IDENTITY_BIG_INT 
				 (Adi) 
				 VALUES 
								(@Adi);SELECT scope_identity();";
			}
		}
		public IdentityBigInt SorgulaIdentityBigIntKeyIle(long p1)
		{
			List<IdentityBigInt> liste = new List<IdentityBigInt>();
			SorguCalistir(liste,String.Format(" IdentityBigIntKey = '{0}'", p1));			
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
				return "IdentityBigIntKey";
			}
		}
		
		public virtual void Sil(long IdentityBigIntKey)
		{
			IdentityBigInt row = new IdentityBigInt();
			row.IdentityBigIntKey = IdentityBigIntKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, IdentityBigInt row)
		{
			row.IdentityBigIntKey = dr.GetInt64(0);
			if (!dr.IsDBNull(1))
			{
				row.Adi = dr.GetString(1);
			}
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, IdentityBigInt row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		IdentityBigInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentityBigIntKey",SqlDbType.BigInt, row.IdentityBigIntKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		IdentityBigInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentityBigIntKey",SqlDbType.BigInt, row.IdentityBigIntKey);
		}
	}
}
