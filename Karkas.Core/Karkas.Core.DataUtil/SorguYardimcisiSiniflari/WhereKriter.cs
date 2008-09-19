using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.SorguYardimcisiSiniflari
{

    internal class WhereKriter : BaseWhereKriter
    {
        public WhereKriter(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;

        }

        public WhereKriter(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikeYeriEnum pLikeYeriEnum)
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
                    return string.Format("{0} {1} {2}", kolonIsmi, s, parameterIsmi);
                }
                else
                {
                    string son = "";
                    switch (likeYeri)
                    {
                        case LikeYeriEnum.Yok:
                            son = string.Format("{0} {1} {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Basinda:
                            son = string.Format("{0} {1} {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Sonunda:
                            son = string.Format("{0} {1} '%' + {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikeYeriEnum.Icinde:
                            son = string.Format("{0} {1} '%' + {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                    }
                    return son;
                }
            }
        }
    }



}
