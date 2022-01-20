using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{

    internal class WhereCriteriaOptionalNullValue : BaseWhereKriter
    {
        public WhereCriteriaOptionalNullValue(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, string pNullDegeri)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;
            nullDegeri = pNullDegeri;
        }

        private string nullDegeri = "";
        public WhereCriteriaOptionalNullValue(
            string pKolonIsmi
            , WhereOperatorEnum pWhereOperator
            , string pParamaterIsmi
            , string pNullDegeri
            , LikePlacementEnum pLikeYeriEnum)
            : this(pKolonIsmi, pWhereOperator, pParamaterIsmi, pNullDegeri)
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
                    return string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} {2}))", kolonIsmi, s, parameterIsmi, nullDegeri);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikePlacementEnum.Yok:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikePlacementEnum.Basinda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR( {0} {1} {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikePlacementEnum.Sonunda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} '%' + {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikePlacementEnum.Icinde:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} '%' + {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                    }
                    return son;
                }

            }
        }

    }


}

