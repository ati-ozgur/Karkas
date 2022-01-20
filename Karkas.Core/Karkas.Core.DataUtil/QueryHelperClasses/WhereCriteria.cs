using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{

    internal class WhereCriteria : BaseWhereKriter
    {
        public WhereCriteria(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            columnName = pKolonIsmi;
            parameterName = pParamaterIsmi;

        }

        public WhereCriteria(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikePlacementEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi)
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
                    return string.Format("{0} {1} {2}", columnName, s, parameterName);
                }
                else
                {
                    string son = "";
                    switch (likePlacement)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format("{0} {1} {2}", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format("{0} {1} {2} + '%'", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format("{0} {1} '%' + {2}", columnName, s, parameterName);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format("{0} {1} '%' + {2} + '%'", columnName, s, parameterName);
                            break;
                    }
                    return son;
                }
            }
        }
    }



}

