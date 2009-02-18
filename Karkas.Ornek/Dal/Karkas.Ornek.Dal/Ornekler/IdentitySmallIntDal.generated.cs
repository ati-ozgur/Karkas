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
	public partial class IdentitySmallIntDal : BaseDal<IdentitySmallInt>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(IdentitySmallInt pTypeLibrary,long pIdentityKolonValue)
		{
			pTypeLibrary.IdentitySmallIntKey = (short )pIdentityKolonValue;
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.IDENTITY_SMALL_INT";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT IdentitySmallIntKey,Adi FROM ORNEKLER.IDENTITY_SMALL_INT";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.IDENTITY_SMALL_INT WHERE IdentitySmallIntKey = @IdentitySmallIntKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.IDENTITY_SMALL_INT
				 SET 
				Adi = @Adi				
				WHERE 
				 IdentitySmallIntKey = @IdentitySmallIntKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.IDENTITY_SMALL_INT 
				 (Adi) 
				 VALUES 
								(@Adi);SELECT scope_identity();";
			}
		}
		public IdentitySmallInt SorgulaIdentitySmallIntKeyIle(short p1)
		{
			List<IdentitySmallInt> liste = new List<IdentitySmallInt>();
			SorguCalistir(liste,String.Format(" IdentitySmallIntKey = '{0}'", p1));			
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
				return "IdentitySmallIntKey";
			}
		}
		
		public virtual void Sil(short IdentitySmallIntKey)
		{
			IdentitySmallInt row = new IdentitySmallInt();
			row.IdentitySmallIntKey = IdentitySmallIntKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, IdentitySmallInt row)
		{
			row.IdentitySmallIntKey = dr.GetInt16(0);
			row.Adi = dr.GetString(1);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, IdentitySmallInt row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		IdentitySmallInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentitySmallIntKey",SqlDbType.SmallInt, row.IdentitySmallIntKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		IdentitySmallInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentitySmallIntKey",SqlDbType.SmallInt, row.IdentitySmallIntKey);
		}
	}
}
