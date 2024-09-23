using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Data
{
    internal class WhereCriteriaOptional : BaseWhereCriteria
    {
        public WhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName)
        {
            whereOperator = pWhereOperator;
            columnName = pColumnName;
            parameterName = pParameterName;
        }
        public WhereCriteriaOptional(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName, LikePlacementEnum pLikePlacementEnum)
            : this(pColumnName, pWhereOperator, pParameterName)
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

