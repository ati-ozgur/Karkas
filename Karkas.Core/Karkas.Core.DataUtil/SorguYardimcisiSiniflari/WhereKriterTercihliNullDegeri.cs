using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.SorguYardimcisiSiniflari
{

    internal class WhereKriterTercihliNullDegeri : BaseWhereKriter
    {
        public WhereKriterTercihliNullDegeri(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, string pNullDegeri)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;
            nullDegeri = pNullDegeri;
        }

        private string nullDegeri = "";
        public WhereKriterTercihliNullDegeri(
            string pKolonIsmi
            , WhereOperatorEnum pWhereOperator
            , string pParamaterIsmi
            , string pNullDegeri
            , LikeYeriEnum pLikeYeriEnum)
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
                        case LikeYeriEnum.Yok:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Basinda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR( {0} {1} {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Sonunda:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ( {0} {1} '%' + {2}))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                        case LikeYeriEnum.Icinde:
                            son = string.Format("(({2} IS NULL) OR ({2} = '{3}') OR ({0} {1} '%' + {2} + '%'))", kolonIsmi, s, parameterIsmi,nullDegeri);
                            break;
                    }
                    return son;
                }

            }
        }

    }


}
