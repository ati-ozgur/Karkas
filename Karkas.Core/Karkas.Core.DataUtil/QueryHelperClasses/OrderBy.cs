using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{
    internal class OrderBy
    {

        public OrderBy(string pColumnName) : this(pColumnName,"")
        {
        }
        public OrderBy(string pColumnName, OrderByEnum pOrderByType)
        {
            orderByType = pOrderByType;
            kolonIsmi = pColumnName;
        }
        public OrderBy(string pColumnName, String pOrderByType)
        {
            orderByTypeAsString = pOrderByType;
            kolonIsmi = pColumnName;
        }

        private OrderByEnum orderByType;

        public OrderByEnum OrderByType
        {
            get { return orderByType; }
            set { orderByType = value; }
        }
        private string orderByTypeAsString;

        public string OrderByTypeAsString
        {
            get { return orderByTypeAsString; }
            set { orderByTypeAsString = value; }
        }



        private string kolonIsmi;

        public string KolonIsmi
        {
            get { return kolonIsmi; }
            set { kolonIsmi = value; }
        }

        public string SqlHali
        {
            get
            {
                string s = "";
                if (string.IsNullOrEmpty(orderByTypeAsString))
                {
                    switch (orderByType)
                    {
                        case OrderByEnum.ASC:
                            s = "ASC";
                            break;
                        case OrderByEnum.Azalarak:
                            s = "DESC";
                            break;
                    }
                }
                else
                {
                    s = orderByTypeAsString;
                }
                return kolonIsmi + " " + s;
            }
        }
    }

}

