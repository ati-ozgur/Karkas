using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
namespace Karkas.Ornek.Dal.Ornekler
{
    public partial class StoredProcedures
    {
        public static int MusteriEkle
        (

            string @Adi
            , string @Soyadi
            , string @IkinciAdi
            , DateTime? @DogumTarihi
            , DateTime? @KayitTarihi
            , AdoTemplate template
            )
        {
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkleReturnValue("@RETURN_VALUE", DbType.Int32);
            builder.parameterEkle("@Adi", DbType.String, @Adi);
            builder.parameterEkle("@Soyadi", DbType.String, @Soyadi);
            builder.parameterEkle("@IkinciAdi", DbType.String, @IkinciAdi);
            builder.parameterEkle("@DogumTarihi", DbType.DateTime, @DogumTarihi);
            builder.parameterEkle("@KayitTarihi", DbType.DateTime, @KayitTarihi);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ORNEKLER.MUSTERI_EKLE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(builder.GetParameterArray());
            template.SorguHariciKomutCalistir(cmd);
            return (int)cmd.Parameters["@RETURN_VALUE"].Value;
        }
        public static int MusteriEkle
        (

            string @Adi
            , string @Soyadi
            , string @IkinciAdi
            , DateTime? @DogumTarihi
            , DateTime? @KayitTarihi
            )
        {
            AdoTemplate template = new AdoTemplate();
            template.Connection = ConnectionSingleton.Instance.getConnection("KARKAS_ORNEK");
            return MusteriEkle(
                @Adi
                , @Soyadi
                , @IkinciAdi
                , @DogumTarihi
                , @KayitTarihi
                , template
                );
        }

    }
}