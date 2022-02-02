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
            columnName = pColumnName;
        }
        public OrderBy(string pColumnName, String pOrderByType)
        {
            orderByTypeAsString = pOrderByType;
            columnName = pColumnName;
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



        private string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public string SqlForm
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
                        case OrderByEnum.DESC:
                            s = "DESC";
                            break;
                    }
                }
                else
                {
                    s = orderByTypeAsString;
                }
                return columnName + " " + s;
            }
        }
    }

}

