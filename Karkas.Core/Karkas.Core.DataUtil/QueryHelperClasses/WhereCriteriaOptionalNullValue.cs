using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{

    internal class WhereCriteriaOptionalNullValue : BaseWhereCriteria
    {
        public WhereCriteriaOptionalNullValue(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName, string pNullValue)
        {
            whereOperator = pWhereOperator;
            columnName = pColumnName;
            parameterName = pParameterName;
            nullValue = pNullValue;
        }

        private string nullValue = "";
        public WhereCriteriaOptionalNullValue(
            string pColumnName
            , WhereOperatorEnum pWhereOperator
            , string pParameterName
            , string pNullValue
            , LikePlacementEnum pLikePlacementEnum)
            : this(pColumnName, pWhereOperator, pParameterName, pNullValue)
        {
            likePlacement = pLikePlacementEnum;
        }

        public override string SqlForm
        {
            get
            {
                string s = GetWhereOperatorValue();
                if (WhereOperator != WhereOperatorEnum.Like)
                {
                    return string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} {2}))", columnName, s, parameterName, nullValue);
                }
                else
                {
                    string son = "";
                    switch (likePlacement)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} {2}))", columnName, s, parameterName,nullValue);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR( {0} {1} {2} + '%'))", columnName, s, parameterName,nullValue);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} '%' + {2}))", columnName, s, parameterName,nullValue);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} '%' + {2} + '%'))", columnName, s, parameterName,nullValue);
                            break;
                    }
                    return son;
                }

            }
        }

    }


}

