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
	public partial class AciklamaDal : BaseDal<Aciklama>
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
				return @"SELECT COUNT(*) FROM ORNEKLER.ACIKLAMA";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT AciklamaKey,Aciklama FROM ORNEKLER.ACIKLAMA";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.ACIKLAMA WHERE AciklamaKey = @AciklamaKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.ACIKLAMA
				 SET 
				Aciklama = @Aciklama				
				WHERE 
				 AciklamaKey = @AciklamaKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.ACIKLAMA 
				 (AciklamaKey,Aciklama) 
				 VALUES 
								(@AciklamaKey,@Aciklama)";
			}
		}
		public Aciklama SorgulaAciklamaKeyIle(Guid p1)
		{
			List<Aciklama> liste = new List<Aciklama>();
			SorguCalistir(liste,String.Format(" AciklamaKey = '{0}'", p1));			
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
		
		public virtual void Sil(Guid AciklamaKey)
		{
			Aciklama row = new Aciklama();
			row.AciklamaKey = AciklamaKey;
			base.Sil(row);
		}
		protected override void ProcessRow(System.Data.IDataReader dr, Aciklama row)
		{
			row.AciklamaKey = dr.GetGuid(0);
			row.AciklamaProperty = dr.GetString(1);
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, Aciklama row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@AciklamaKey",SqlDbType.UniqueIdentifier, row.AciklamaKey);
			builder.parameterEkle("@Aciklama",SqlDbType.VarChar, row.AciklamaProperty,50);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		Aciklama		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@AciklamaKey",SqlDbType.UniqueIdentifier, row.AciklamaKey);
			builder.parameterEkle("@Aciklama",SqlDbType.VarChar, row.AciklamaProperty,50);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		Aciklama		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@AciklamaKey",SqlDbType.UniqueIdentifier, row.AciklamaKey);
		}
	}
}
