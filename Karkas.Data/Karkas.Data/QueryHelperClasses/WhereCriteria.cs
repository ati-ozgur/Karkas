using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Data.QueryHelperClasses
{

    public class WhereCriteria : BaseWhereCriteria
    {
        public WhereCriteria(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName)
        {
            whereOperator = pWhereOperator;
            columnName = pColumnName;
            parameterName = pParameterName;

        }

        public WhereCriteria(string pColumnName, WhereOperatorEnum pWhereOperator, string pParameterName, LikePlacementEnum pLikePlacementEnum)
            : this(pColumnName, pWhereOperator, pParameterName)
        {
            likePlacement = pLikePlacementEnum;
        }



        public override string SqlForm
        {
            get
            {
                string op = GetWhereOperatorValue();
                if (WhereOperator != WhereOperatorEnum.Like)
                {
                    return string.Format(@"""{0}"" {1} {2}", columnName, op, parameterName);
                }
                else
                {
                    string son = "";
                    switch (likePlacement)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format(@"""{0}"" {1} {2}", columnName, op, parameterName);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format(@"""{0}"" {1} {2} + '%'", columnName, op, parameterName);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format(@"""{0}"" {1} '%' + {2}", columnName, op, parameterName);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format(@"""{0}"" {1} '%' + {2} + '%'", columnName, op, parameterName);
                            break;
                    }
                    return son;
                }
            }
        }
    }



}

