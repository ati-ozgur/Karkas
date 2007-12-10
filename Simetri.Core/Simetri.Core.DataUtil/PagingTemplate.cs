using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Simetri.Core.DataUtil
{
    public class PagingTemplate
    {
        private string selectSql;
        private string countSql;
        private SqlParameter[] parameters = null;
        private PagingHelper pHelper = new PagingHelper(ConnectionSingleton.Instance.Connection);

        public PagingTemplate(string pSql)
        {
            this.selectSql = pSql;
            this.countSql = sqlCumlesiniCountIleDegistir(pSql);
        }

        public PagingTemplate(string pSql,SqlParameter[] pParameters):this(pSql)
        {
            this.parameters = pParameters;
        }

        public DataTable DataTableOlusturSayfalamaYap(int pPageSize, int pStartRowIndex, string pOrderBy)
        {
            if (parameters == null)
            {
                return pHelper.DataTableOlusturSayfalamaYap(selectSql, pPageSize, pStartRowIndex, pOrderBy);
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
            AdoTemplate template = new AdoTemplate();
            if (parameters == null)
            {
                return (int) template.TekDegerGetir(countSql);
            }
            else
            {
                return (int) template.TekDegerGetir(countSql, parameters);
            }
        }



    }
}
