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
		protected override void identityKolonDegeriniSetle(Musteri pTypeLibrary,int pIdentityKolonValue)
		{
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
				return @"SELECT MusteriKey,Adi,Soyadi,IkinciAdi,DogumTarihi,AktifMi,Onemi,Kredisi,TamAdi FROM ORNEKLER.MUSTERI";
			}
		}
		protected override string DeleteString
		{
			get 
			{
				return @"DELETE   FROM ORNEKLER.MUSTERI WHERE MusteriKey = @MusteriKey";
			}
		}
		protected override string UpdateString
		{
			get 
			{
				return @"UPDATE ORNEKLER.MUSTERI
				 SET 
				Adi = @Adi,Soyadi = @Soyadi,IkinciAdi = @IkinciAdi,DogumTarihi = @DogumTarihi,AktifMi = @AktifMi,Onemi = @Onemi,Kredisi = @Kredisi				
				WHERE 
				 MusteriKey = @MusteriKey ";
			}
		}
		protected override string InsertString
		{
			get 
			{
				return @"INSERT INTO ORNEKLER.MUSTERI 
				 (MusteriKey,Adi,Soyadi,IkinciAdi,DogumTarihi,AktifMi,Onemi,Kredisi) 
				 VALUES 
								(@MusteriKey,@Adi,@Soyadi,@IkinciAdi,@DogumTarihi,@AktifMi,@Onemi,@Kredisi)";
			}
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
		
		public virtual void Sil(Guid MusteriKey)
		{
			Musteri row = new Musteri();
			row.MusteriKey = MusteriKey;
			base.Sil(row);
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
			row.AktifMi = dr.GetBoolean(5);
			if (!dr.IsDBNull(6))
			{
				row.Onemi = dr.GetInt32(6);
			}
			if (!dr.IsDBNull(7))
			{
				row.Kredisi = dr.GetDecimal(7);
			}
			if (!dr.IsDBNull(8))
			{
				row.TamAdi = dr.GetString(8);
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
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
			builder.parameterEkle("@Onemi",SqlDbType.Int, row.Onemi);
			builder.parameterEkle("@Kredisi",SqlDbType.Decimal, row.Kredisi);
		}
		protected override void UpdateCommandParametersAdd(SqlCommand cmd, 		Musteri		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@MusteriKey",SqlDbType.UniqueIdentifier, row.MusteriKey);
			builder.parameterEkle("@Adi",SqlDbType.VarChar, row.Adi,50);
			builder.parameterEkle("@Soyadi",SqlDbType.VarChar, row.Soyadi,50);
			builder.parameterEkle("@IkinciAdi",SqlDbType.VarChar, row.IkinciAdi,50);
			builder.parameterEkle("@DogumTarihi",SqlDbType.DateTime, row.DogumTarihi);
			builder.parameterEkle("@AktifMi",SqlDbType.Bit, row.AktifMi);
			builder.parameterEkle("@Onemi",SqlDbType.Int, row.Onemi);
			builder.parameterEkle("@Kredisi",SqlDbType.Decimal, row.Kredisi);
		}
		protected override void DeleteCommandParametersAdd(SqlCommand cmd, 		Musteri		 row)
		{
			ParameterBuilder builder = new ParameterBuilder(cmd);
			builder.parameterEkle("@MusteriKey",SqlDbType.UniqueIdentifier, row.MusteriKey);
		}
	}
}
