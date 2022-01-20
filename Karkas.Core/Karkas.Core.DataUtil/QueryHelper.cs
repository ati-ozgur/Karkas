using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.DataUtil.QueryHelperClasses;

namespace Karkas.Core.DataUtil
{
    public class QueryHelper
    {

        public QueryHelper(string pParameterCharacter)
        {
            this.ParameterCharacter = pParameterCharacter;
        }


        public string ParameterCharacter { get; set; }

        List<OrderBy> listOrderBy = new List<OrderBy>();
        List<WhereCriteria> whereListesi = new List<WhereCriteria>();
        List<WhereCriteriaOptional> whereTercihliListesi = new List<WhereCriteriaOptional>();
        List<WhereCriteriaOptionalNullValue> whereTercihliNullDegeriListesi = new List<WhereCriteriaOptionalNullValue>();


        public void OrderByEkle(string pKolonIsmi, OrderByEnum pSiralamaTuru)
        {
            OrderBy s = new OrderBy(pKolonIsmi, pSiralamaTuru);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }
        public void OrderByEkle(string pKolonIsmi)
        {
            OrderBy s = new OrderBy(pKolonIsmi);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }
        public void OrderByEkle(string pKolonIsmi, String pSiralamaTuru)
        {
            OrderBy s = new OrderBy(pKolonIsmi, pSiralamaTuru);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }

        public string KriterSonucunuGetir()
        {
            string sonuc = "";
            sonuc += whereKriterlerininSonucunuGetir();
            sonuc += OrderBylarinSonucunuGetir();
            return sonuc;
        }
        public string KriterSonucunuWhereOlmadanGetir()
        {
            string sonuc = KriterSonucunuGetir();
            return sonuc.Replace("WHERE", "");

        }


        private string OrderBylarinSonucunuGetir()
        {
            if (listOrderBy.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("ORDER BY ");
            foreach (OrderBy s in listOrderBy)
            {
                sb.Append(s.SqlHali + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public void WhereKriterineEkle(string pKolonIsmi)
        {
            WhereCriteria wk = new WhereCriteria(pKolonIsmi,WhereOperatorEnum.Equals , ParameterCharacter + pKolonIsmi);
            whereListesi.Add(wk);
        }
        
        public void WhereKriterineEkle(string pKolonIsmi, WhereOperatorEnum whereOperator)
        {
            WhereCriteria wk = new WhereCriteria(pKolonIsmi, whereOperator, ParameterCharacter + pKolonIsmi);
            whereListesi.Add(wk);
        }

        public void WhereKriterineEkle(string pKolonIsmi, WhereOperatorEnum whereOperator, string pParameterIsmi)
        {
            WhereCriteria wk = new WhereCriteria(pKolonIsmi, whereOperator, pParameterIsmi);
            whereListesi.Add(wk);
        }

        private string whereKriterlerininSonucunuGetir()
        {
            if ((whereListesi.Count == 0) && (whereTercihliListesi.Count == 0)
                && (whereTercihliNullDegeriListesi.Count == 0))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("WHERE ");
            foreach (WhereCriteria s in whereListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereCriteriaOptional s in whereTercihliListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereCriteriaOptionalNullValue s in whereTercihliNullDegeriListesi)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            sb.Remove(sb.Length - 5, 5);
            sb.Append(Environment.NewLine);
            return sb.ToString();

        }


        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi)
        {
            WhereCriteriaOptional wk = new WhereCriteriaOptional(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi);
            whereTercihliListesi.Add(wk);

        }
        public void WhereKriterineTercihliEkle(string pKolonIsmi)
        {
            WhereKriterineTercihliEkle(pKolonIsmi, WhereOperatorEnum.Equals, ParameterCharacter + pKolonIsmi);
        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum)
        {
            WhereKriterineTercihliEkle(pKolonIsmi, pWhereOperatorEnum, ParameterCharacter + pKolonIsmi);
        }

        public void WhereKriterineTercihliEkle(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi, LikePlacementEnum pLikeYeriEnum)
        {
            WhereCriteriaOptional wk = new WhereCriteriaOptional(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pLikeYeriEnum);
            whereTercihliListesi.Add(wk);
        }
        public void WhereKriterineArasindaEkle(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2)
        {

            WhereCriteria wk1 = new WhereCriteria(pKolonIsmi, WhereOperatorEnum.GreaterAndEquals, pParameterIsmi1);
            whereListesi.Add(wk1);
            WhereCriteria wk2 = new WhereCriteria(pKolonIsmi, WhereOperatorEnum.LesserAndEquals, pParameterIsmi2);
            whereListesi.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkle(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2)
        {
            WhereCriteriaOptional wk1 = new WhereCriteriaOptional(pKolonIsmi, WhereOperatorEnum.GreaterAndEquals, pParameterIsmi1);
            whereTercihliListesi.Add(wk1);
            WhereCriteriaOptional wk2 = new WhereCriteriaOptional(pKolonIsmi, WhereOperatorEnum.LesserAndEquals, pParameterIsmi2);
            whereTercihliListesi.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkleNullDegeriVer(string pKolonIsmi, string pParameterIsmi1, string pParameterIsmi2, string pNullDegeri)
        {
            WhereCriteriaOptionalNullValue wk1 = new WhereCriteriaOptionalNullValue(pKolonIsmi, WhereOperatorEnum.GreaterAndEquals, pParameterIsmi1, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk1);
            WhereCriteriaOptionalNullValue wk2 = new WhereCriteriaOptionalNullValue(pKolonIsmi, WhereOperatorEnum.LesserAndEquals, pParameterIsmi2, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk2);
        }


        public void WhereKriterineTercihliEkleNullDegeriVer(
            string pKolonIsmi
            , WhereOperatorEnum pWhereOperatorEnum
            , string pParameterIsmi, string pNullDegeri
            )
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk);
        }
        public void WhereKriterineTercihliEkleNullDegeriVer(
            string pKolonIsmi
            , string pNullDegeri
            )
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pKolonIsmi, WhereOperatorEnum.Equals, ParameterCharacter + pKolonIsmi, pNullDegeri);
            whereTercihliNullDegeriListesi.Add(wk);
        }


        public void WhereKriterineTercihliEkleNullDegeriVer(string pKolonIsmi, WhereOperatorEnum pWhereOperatorEnum, string pParameterIsmi, LikePlacementEnum pLikeYeriEnum, string pNullDegeri)
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pKolonIsmi, pWhereOperatorEnum, pParameterIsmi, pNullDegeri, pLikeYeriEnum);
            whereTercihliNullDegeriListesi.Add(wk);
        }
    }
}





