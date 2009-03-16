﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Dal.Ornekler;


namespace Karkas.Ornek.Bs.Ornekler
{
    public partial class MusteriSiparisBs : BaseBs<MusteriSiparis, MusteriSiparisDal>
    {
        /// <summary>
        /// MusteriKey ile siparişleri arar
        /// </summary>
        /// <param name="pMusteriKey"></param>
        /// <returns></returns>
        public DataTable SorgulaMusteriKeyIle(Guid pMusteriKey)
        {
            return dal.SorgulaMusteriKeyIle(pMusteriKey);
        }
    }
}
