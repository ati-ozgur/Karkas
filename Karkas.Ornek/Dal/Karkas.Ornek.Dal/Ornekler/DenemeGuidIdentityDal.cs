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
	public partial class DenemeGuidIdentityDal
	{
        public DataTable SatirGetir(int DenemeNo)
        {
            string sql = "SELECT * FROM [ORNEKLER].[DENEME_GUID_IDENTITY] WHERE DenemeNo = @DenemeNo";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@DenemeNo", DbType.Int32, DenemeNo);
            return Template.DataTableOlustur(sql, builder.GetParameterArray());

        }
        public int DenemeNoBul(Guid DenemeKey)
        {
            string sql = "SELECT DenemeNo FROM [ORNEKLER].[DENEME_GUID_IDENTITY] WHERE DenemeKey = @DenemeKey";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@DenemeKey", DbType.Guid, DenemeKey);
            object sonuc = Template.TekDegerGetir(sql, builder.GetParameterArray());
            return Convert.ToInt32(sonuc);

        }

	}
}

