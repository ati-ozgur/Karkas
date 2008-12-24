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
	public partial class IdentityIntDal : BaseDal<IdentityInt>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(IdentityInt pTypeLibrary,long pIdentityKolonValue)
		{
			pTypeLibrary.IdentityIntKey = (byte )pIdentityKolonValue;
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.IDENTITY_INT";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT IdentityIntKey,Adi FROM ORNEKLER.IDENTITY_INT";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.IDENTITY_INT WHERE IdentityIntKey = @IdentityIntKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.IDENTITY_INT
				 SET 
				Adi = @Adi				
				WHERE 
				 IdentityIntKey = @IdentityIntKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.IDENTITY_INT 
				 (Adi) 
				 VALUES 
								(@Adi);SELECT scope_identity();";
			}
		}
		public IdentityInt SorgulaIdentityIntKeyIle(byte p1)
		{
			List<IdentityInt> liste = new List<IdentityInt>();
			SorguCalistir(liste,String.Format(" IdentityIntKey = '{0}'", p1));			
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
		
		public virtual void Sil(byte IdentityIntKey)
		{
			IdentityInt row = new IdentityInt();
			row.IdentityIntKey = IdentityIntKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, IdentityInt row)
		{
			row.IdentityIntKey = dr.GetByte(0);
			if (!dr.IsDBNull(1))
			{
				row.Adi = dr.GetString(1);
			}
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, IdentityInt row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		IdentityInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentityIntKey",SqlDbType.TinyInt, row.IdentityIntKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		IdentityInt		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@IdentityIntKey",SqlDbType.TinyInt, row.IdentityIntKey);
		}
	}
}
