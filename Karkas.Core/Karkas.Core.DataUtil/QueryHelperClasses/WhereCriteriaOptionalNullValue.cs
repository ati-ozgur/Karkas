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
            columnName = pKolonIsmi;
            parameterName = pParamaterIsmi;
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

