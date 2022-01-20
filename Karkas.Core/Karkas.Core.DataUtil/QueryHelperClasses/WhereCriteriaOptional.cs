using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{
    internal class WhereCriteriaOptional : BaseWhereKriter
    {
        public WhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            columnName = pColumnName;
            parameterName = pParamaterIsmi;
        }
        public WhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikePlacementEnum pLikeYeriEnum)
            : this(pColumnName, pWhereOperator, pParamaterIsmi)
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
                    return string.Format("(({2} IS NULL) OR ({0} {1} {2}))", columnName, s, parameterName);
                }
                else
                {
                    string son = "";
                    switch (likePlacement)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2}))", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2} + '%'))", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} '%' + {2}))", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format("(({2} IS NULL) OR ({0} {1} '%' + {2} + '%'))", columnName, s, parameterName);
                            break;
                    }
                    return son;
                }

            }
        }
    }



}

