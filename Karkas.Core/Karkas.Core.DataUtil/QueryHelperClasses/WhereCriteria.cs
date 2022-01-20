﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{

    internal class WhereCriteria : BaseWhereKriter
    {
        public WhereCriteria(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi)
        {
            whereOperator = pWhereOperator;
            kolonIsmi = pKolonIsmi;
            parameterIsmi = pParamaterIsmi;

        }

        public WhereCriteria(string pKolonIsmi, WhereOperatorEnum pWhereOperator, string pParamaterIsmi, LikePlacementEnum pLikeYeriEnum)
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
                        case LikePlacementEnum.Yok:
                            son = string.Format("{0} {1} {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Basinda:
                            son = string.Format("{0} {1} {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Sonunda:
                            son = string.Format("{0} {1} '%' + {2}", kolonIsmi, s, parameterIsmi);
                            break;
                        case LikePlacementEnum.Icinde:
                            son = string.Format("{0} {1} '%' + {2} + '%'", kolonIsmi, s, parameterIsmi);
                            break;
                    }
                    return son;
                }
            }
        }
    }



}

