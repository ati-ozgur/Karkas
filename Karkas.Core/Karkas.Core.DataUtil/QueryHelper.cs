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
        List<WhereCriteria> listWhere = new List<WhereCriteria>();
        List<WhereCriteriaOptional> listWhereOptional = new List<WhereCriteriaOptional>();
        List<WhereCriteriaOptionalNullValue> listWhereOptionalNullValues = new List<WhereCriteriaOptionalNullValue>();


        public void AddOrderBy(string pColumnName, OrderByEnum pOrderByType)
        {
            OrderBy s = new OrderBy(pColumnName, pOrderByType);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }
        public void AddOrderBy(string pColumnName)
        {
            OrderBy s = new OrderBy(pColumnName);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }
        public void AddOrderBy(string pColumnName, String pOrderByType)
        {
            OrderBy s = new OrderBy(pColumnName, pOrderByType);
            if (!listOrderBy.Contains(s))
            {
                listOrderBy.Add(s);
            }
        }

        public string GetCriteriaResultsWithWhere()
        {
            string sonuc = "";
            sonuc += getCriteriaResultsForWhere();
            sonuc += GetOrderByResults();
            return sonuc;
        }
        public string GetCriteriaResultsWithoutWhere()
        {
            string sonuc = GetCriteriaResultsWithWhere();
            return sonuc.Replace("WHERE", "");

        }


        private string GetOrderByResults()
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

        public void AddWhereCriteria(string pColumnName)
        {
            WhereCriteria wk = new WhereCriteria(pColumnName,WhereOperatorEnum.Equals , ParameterCharacter + pColumnName);
            listWhere.Add(wk);
        }
        
        public void AddWhereCriteria(string pColumnName, WhereOperatorEnum whereOperator)
        {
            WhereCriteria wk = new WhereCriteria(pColumnName, whereOperator, ParameterCharacter + pColumnName);
            listWhere.Add(wk);
        }

        public void AddWhereCriteria(string pColumnName, WhereOperatorEnum whereOperator, string pParameterName)
        {
            WhereCriteria wk = new WhereCriteria(pColumnName, whereOperator, pParameterName);
            listWhere.Add(wk);
        }

        private string getCriteriaResultsForWhere()
        {
            if ((listWhere.Count == 0) && (listWhereOptional.Count == 0)
                && (listWhereOptionalNullValues.Count == 0))
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("WHERE ");
            foreach (WhereCriteria s in listWhere)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereCriteriaOptional s in listWhereOptional)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            foreach (WhereCriteriaOptionalNullValue s in listWhereOptionalNullValues)
            {
                sb.Append(Environment.NewLine + s.SqlHali + " AND ");
            }
            sb.Remove(sb.Length - 5, 5);
            sb.Append(Environment.NewLine);
            return sb.ToString();

        }


        public void AddWhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperatorEnum, string pParameterName)
        {
            WhereCriteriaOptional wk = new WhereCriteriaOptional(pColumnName, pWhereOperatorEnum, pParameterName);
            listWhereOptional.Add(wk);

        }
        public void AddWhereCriteriaOptional(string pColumnName)
        {
            AddWhereCriteriaOptional(pColumnName, WhereOperatorEnum.Equals, ParameterCharacter + pColumnName);
        }

        public void AddWhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperatorEnum)
        {
            AddWhereCriteriaOptional(pColumnName, pWhereOperatorEnum, ParameterCharacter + pColumnName);
        }

        public void AddWhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperatorEnum, string pParameterName, LikePlacementEnum pLikeYeriEnum)
        {
            WhereCriteriaOptional wk = new WhereCriteriaOptional(pColumnName, pWhereOperatorEnum, pParameterName, pLikeYeriEnum);
            listWhereOptional.Add(wk);
        }
        public void WhereKriterineArasindaEkle(string pColumnName, string pParameterName1, string pParameterName2)
        {

            WhereCriteria wk1 = new WhereCriteria(pColumnName, WhereOperatorEnum.GreaterAndEquals, pParameterName1);
            listWhere.Add(wk1);
            WhereCriteria wk2 = new WhereCriteria(pColumnName, WhereOperatorEnum.LesserAndEquals, pParameterName2);
            listWhere.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkle(string pColumnName, string pParameterName1, string pParameterName2)
        {
            WhereCriteriaOptional wk1 = new WhereCriteriaOptional(pColumnName, WhereOperatorEnum.GreaterAndEquals, pParameterName1);
            listWhereOptional.Add(wk1);
            WhereCriteriaOptional wk2 = new WhereCriteriaOptional(pColumnName, WhereOperatorEnum.LesserAndEquals, pParameterName2);
            listWhereOptional.Add(wk2);
        }

        public void WhereKriterineArasindaTercihliEkleNullDegeriVer(string pColumnName, string pParameterName1, string pParameterName2, string pNullDegeri)
        {
            WhereCriteriaOptionalNullValue wk1 = new WhereCriteriaOptionalNullValue(pColumnName, WhereOperatorEnum.GreaterAndEquals, pParameterName1, pNullDegeri);
            listWhereOptionalNullValues.Add(wk1);
            WhereCriteriaOptionalNullValue wk2 = new WhereCriteriaOptionalNullValue(pColumnName, WhereOperatorEnum.LesserAndEquals, pParameterName2, pNullDegeri);
            listWhereOptionalNullValues.Add(wk2);
        }


        public void AddWhereCriteriaOptionalNullValueSet(
            string pColumnName
            , WhereOperatorEnum pWhereOperatorEnum
            , string pParameterName, string pNullDegeri
            )
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pColumnName, pWhereOperatorEnum, pParameterName, pNullDegeri);
            listWhereOptionalNullValues.Add(wk);
        }
        public void AddWhereCriteriaOptionalNullValueSet(
            string pColumnName
            , string pNullDegeri
            )
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pColumnName, WhereOperatorEnum.Equals, ParameterCharacter + pColumnName, pNullDegeri);
            listWhereOptionalNullValues.Add(wk);
        }


        public void AddWhereCriteriaOptionalNullValueSet(string pColumnName, WhereOperatorEnum pWhereOperatorEnum, string pParameterName, LikePlacementEnum pLikeYeriEnum, string pNullDegeri)
        {
            WhereCriteriaOptionalNullValue wk = new WhereCriteriaOptionalNullValue(pColumnName, pWhereOperatorEnum, pParameterName, pNullDegeri, pLikeYeriEnum);
            listWhereOptionalNullValues.Add(wk);
        }
    }
}





