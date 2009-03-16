
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ComponentModel;
using System.Web;
using System.Web.Caching;
using Karkas.Web.Helpers.HelperClasses;
using Karkas.Ornek.TypeLibrary;
using Karkas.Ornek.TypeLibrary.Ornekler;
using Karkas.Ornek.Bs.Ornekler;


namespace Karkas.Ornek.BsWrapper.Ornekler
{
    public partial class MusteriSiparisBsWrapper
    {
        /// <summary>
        /// MusteriKey ile sipariþleri arar
        /// </summary>
        /// <param name="pMusteriKey"></param>
        /// <returns></returns>
        public DataTable SorgulaMusteriKeyIle(Guid pMusteriKey)
        {
            return bs.SorgulaMusteriKeyIle(pMusteriKey);
        }
    }
}
