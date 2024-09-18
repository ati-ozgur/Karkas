using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.Common;

namespace Karkas.Core.DataUtil
{
    public class PagingTemplate
    {
        private string selectSql;
        private string countSql;
        private DbParameter[] parameters = null;
        private PagingHelper pHelper = null;
        private Guid komutuCalistiranKullaniciKisiKey;
        private DbTransaction currentTransaction;
        private IAdoTemplate<IParameterBuilder> template;

        public PagingTemplate(IAdoTemplate<IParameterBuilder> template)
        {
            this.template = template;
        }

        /// <summary>
        /// Dal komutumuzu calistiran kisinin guid olarak key bilgisi.
        /// Login olan kullanicinin Kisi Key'ine setlenmesi gerekir.
        /// Otomatik olarak Bs tarafindan yapilacak
        /// </summary>
        public Guid KomutuCalistiranKullaniciKisiKey
        {
            get { return komutuCalistiranKullaniciKisiKey; }
            set { komutuCalistiranKullaniciKisiKey = value; }
        }



        public DbTransaction CurrentTransaction
        {
            get { return currentTransaction; }
            set { currentTransaction = value; }
        }
        public PagingTemplate(IAdoTemplate<IParameterBuilder> template, string pSql, DbParameter[] pParameters)
            : this(template, pSql)
        {
            this.parameters = pParameters;
        }

        public PagingTemplate(IAdoTemplate<IParameterBuilder> template,string pSql)
        {
            this.template = template;
            new PagingHelper(template);
            this.selectSql = pSql;
            this.countSql = sqlCumlesiniCountIleDegistir(pSql);
        }



        public DataTable DataTableOlusturSayfalamaYap(int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            if (parameters == null)
            {
                return pHelper.CreateDataTableWithPaging(selectSql, pPageSize, pStartRowIndex, pOrderBy);
            }
            else
            {
                return pHelper.DataTableOlusturSayfalamaYap(selectSql, pPageSize, pStartRowIndex, pOrderBy, parameters);
            }
        }

        private static string sqlCumlesiniCountIleDegistir(string sql)
        {
            return Regex.Replace(sql, "SELECT.*FROM", "SELECT COUNT(*) FROM");
        }

        public int KayitSayisiniBul()
        {

            if (parameters == null)
            {
                return (int) template.BringOneValue(countSql);
            }
            else
            {
                return (int) template.BringOneValue(countSql, parameters);
            }
        }



    }
}

