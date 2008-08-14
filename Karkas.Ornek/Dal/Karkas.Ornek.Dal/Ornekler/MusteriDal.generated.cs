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
	public partial class MusteriDal : BaseDal<Musteri>
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
				return @"SELECT COUNT(*) FROM ORNEKLER.MUSTERI";
			}
		}
		protected override string SelectString
		{
			get 
			{
				return @"SELECT MusteriKey,Adi,Soyadi,IkinciAdi,DogumTarihi,TamAdi FROM ORNEKLER.MUSTERI";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.MUSTERI WHERE MusteriKey =";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.MUSTERI
				 SET 
				Adi = @Adi,Soyadi = @Soyadi,IkinciAdi = @IkinciAdi,DogumTarihi = @DogumTarihi				
				WHERE 
				MusteriKey = @MusteriKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.MUSTERI 
				 (MusteriKey,Adi,Soyadi,IkinciAdi,DogumTarihi) 
				 VALUES 
								(@MusteriKey,@Adi,@Soyadi,@IkinciAdi,@DogumTarihi)";
			}
		}
		public List<Musteri>SorgulaHepsiniGetir()
		{
			List<Musteri> liste = new List<Musteri>();
			SorguCalistir(liste);
			return liste;
		}
		public Musteri SorgulaMusteriKeyIle(Guid p1)
		{
			List<Musteri> liste = new List<Musteri>();
			SorguCalistir(liste,String.Format(" MusteriKey = '{0}'", p1));			
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
		
		protected override void ProcessRow(System.Data.IDataReader dr, Musteri row)
		{
			row.MusteriKey = dr.GetGuid(0);
			row.Adi = dr.GetString(1);
			row.Soyadi = dr.GetString(2);
			if (!dr.IsDBNull(3))
			{
				row.IkinciAdi = dr.GetString(3);
			}
			if (!dr.IsDBNull(4))
			{
				row.DogumTarihi = dr.GetDateTime(4);
			}
			if (!dr.IsDBNull(5))
			{
				row.TamAdi = dr.GetString(5);
			}
		}
		protected override void InsertCommandParametersAdd(SqlCommand cmd, Musteri row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@MusteriKey",SqlDbType.UniqueIdentifier, row.MusteriKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi,50);
			builder.parameterEkle("@DogumTarihi",SqlDbType.DateTime, row.DogumTarihi);
			builder.parameterEkle("@TamAdi",SqlDbType.VarChar, row.TamAdi,152);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		Musteri		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@MusteriKey",SqlDbType.UniqueIdentifier, row.MusteriKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi,50);
			builder.parameterEkle("@DogumTarihi",SqlDbType.DateTime, row.DogumTarihi);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		Musteri		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@MusteriKey",SqlDbType.UniqueIdentifier, row.MusteriKey);
		}
	}
}
