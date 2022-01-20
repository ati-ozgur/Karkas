using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{

    internal class WhereCriteriaOptionalNullValue : BaseWhereKriter
    {
        public WhereCriteriaOptionalNullValue(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName, string pNullValue)
        {
            whereOperator = pWhereOperator;
            columnName = pColumnName;
            parameterName = pParameterName;
            nullDegeri = pNullValue;
        }

        private string nullDegeri = "";
        public WhereCriteriaOptionalNullValue(
            string pColumnName
            , WhereOperatorEnum pWhereOperator
            , string pParameterName
            , string pNullValue
            , LikePlacementEnum pLikeYeriEnum)
            : this(pColumnName, pWhereOperator, pParameterName, pNullValue)
        {
            likePlacement = pLikeYeriEnum;
        }

        public override string SqlHali
        {
            get
            {
                string s = whereOperatorDegeriniAl();
                if (WhereOperator != WhereOperatorEnum.Like)
                {
                    return string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} {2}))", columnName, s, parameterName, nullDegeri);
                }
                else
                {
                    string son = "";
                    switch (likePlacement)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} {2}))", columnName, s, parameterName,nullDegeri);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR( {0} {1} {2} + '%'))", columnName, s, parameterName,nullDegeri);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} '%' + {2}))", columnName, s, parameterName,nullDegeri);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} '%' + {2} + '%'))", columnName, s, parameterName,nullDegeri);
                            break;
                    }
                    return son;
                }

            }
        }

    }


}

