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
	public partial class ConcurrencyOrnekDal : BaseDal<ConcurrencyOrnek>
	{
		
		public override string DatabaseName
		{
			get
			{
				return "KARKAS_ORNEK";
			}
		}
		protected override void identityKolonDegeriniSetle(ConcurrencyOrnek pTypeLibrary,long pIdentityKolonValue)
		{
		}
		protected override string SelectCountString
		{
			get
			{
				return @"SELECT COUNT(*) FROM ORNEKLER.CONCURRENCY_ORNEK";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT ConcurrencyOrnekKey,Adi,VersiyonZamani FROM ORNEKLER.CONCURRENCY_ORNEK";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.CONCURRENCY_ORNEK WHERE ConcurrencyOrnekKey = @ConcurrencyOrnekKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.CONCURRENCY_ORNEK
				 SET 
				Adi = @Adi				
				WHERE 
				 ConcurrencyOrnekKey = @ConcurrencyOrnekKey AND VersiyonZamani = @VersiyonZamani ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.CONCURRENCY_ORNEK 
				 (ConcurrencyOrnekKey,Adi) 
				 VALUES 
								(@ConcurrencyOrnekKey,@Adi)";
			}
		}
		public ConcurrencyOrnek SorgulaConcurrencyOrnekKeyIle(Guid p1)
		{
			List<ConcurrencyOrnek> liste = new List<ConcurrencyOrnek>();
			SorguCalistir(liste,String.Format(" ConcurrencyOrnekKey = '{0}'", p1));			
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
		
		public virtual void Sil(Guid ConcurrencyOrnekKey)
		{
			ConcurrencyOrnek row = new ConcurrencyOrnek();
			row.ConcurrencyOrnekKey = ConcurrencyOrnekKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, ConcurrencyOrnek row)
		{
			row.ConcurrencyOrnekKey = dr.GetGuid(0);
			row.Adi = dr.GetString(1);
			row.VersiyonZamani = (Byte[])dr.GetValue(2);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, ConcurrencyOrnek row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ConcurrencyOrnekKey",SqlDbType.UniqueIdentifier, row.ConcurrencyOrnekKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		ConcurrencyOrnek		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ConcurrencyOrnekKey",SqlDbType.UniqueIdentifier, row.ConcurrencyOrnekKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@VersiyonZamani",SqlDbType.Timestamp, row.VersiyonZamani,8);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		ConcurrencyOrnek		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@ConcurrencyOrnekKey",SqlDbType.UniqueIdentifier, row.ConcurrencyOrnekKey);
		}
	}
}

