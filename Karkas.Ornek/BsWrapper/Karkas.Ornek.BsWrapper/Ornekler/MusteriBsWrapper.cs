
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
    public partial class MusteriBsWrapper
    {
        public DataTable SorgulaHepsiniGetirDataTable()
        {
            return bs.SorgulaHepsiniGetirDataTable();
        }

        /// <summary>
        /// Adı soyadı ve durumuna göre müşteri arar
        /// </summary>
        /// <param name="pAdi"></param>
        /// <param name="pSoyadi"></param>
        /// <param name="pAktifMi"></param>
        /// <returns></returns>
        public DataTable SorgulaAdiSoyadiVeDurumuIle(string pAdi, string pSoyadi, bool pAktifMi)
        {
            return bs.SorgulaAdiSoyadiVeDurumuIle(pAdi, pSoyadi, pAktifMi);
        }
    }
}

