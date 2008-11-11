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
	public partial class BasitTabloDal
	{

        public void AdSoyadiBuyukHarfeCevir(Guid pBasitTabloKey)
        {
            string sql = @"UPDATE [ORNEKLER].[BASIT_TABLO]
                           SET
                              Adi = UPPER(Adi)
                              ,Soyadi = UPPER(Soyadi)
                         WHERE 
                          BasitTabloKey = @BasitTabloKey
                        ";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@BasitTabloKey",SqlDbType.UniqueIdentifier,pBasitTabloKey);
            Template.SorguHariciKomutCalistir(sql, builder.GetParameterArray());
        }
    }
}
