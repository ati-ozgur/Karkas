using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{
    internal class WhereCriteriaOptional : BaseWhereKriter
    {
        public WhereCriteriaOptional(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;
        }
        public WhereCriteriaOptional(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikePlacementEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi)
        {
            likeYeri = pLikeYeriEnum;
        }


        public override string SqlHali
        {
            get
            {
                string s = whereOperatorDegeriniAl();

                if (WhereOperator != WhereOperatorEnum.Like)
                {
                    return string.Format("(({2} IS NULL) OR ({0} {1} {2}))", kolonIsmi, s, parameterIsmi);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikePlacementEnum.None:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2}))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Start:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} {2} + '%'))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Last:
                            son = string.Format("(({2} IS NULL) OR ( {0} {1} '%' + {2}))", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Between:
                            son = string.Format("(({2} IS NULL) OR ({0} {1} '%' + {2} + '%'))", kolonIsmi, s, parameterIsmi);
                            break;
                    }
                    return son;
                }

            }
        }
    }



}

