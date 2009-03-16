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
	public partial class MusteriSiparisDal
	{
        /// <summary>
        /// MusteriKey ile siparişleri arar
        /// </summary>
        /// <param name="pMusteriKey"></param>
        /// <returns></returns>
        public DataTable SorgulaMusteriKeyIle(Guid pMusteriKey)
        {
            string strSQL = @"SELECT *
                              FROM ORNEKLER.MUSTERI_SIPARIS
                            WHERE MusteriKey = @MusteriKey";
            ParameterBuilder builder = new ParameterBuilder();
            builder.parameterEkle("@MusteriKey", SqlDbType.UniqueIdentifier, pMusteriKey);
            return Template.DataTableOlustur(strSQL, builder.GetParameterArray());
        }
	}
}
