using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Data
{
    public class OrderBy
    {

        public OrderBy(string pColumnName) : this(pColumnName, OrderByEnum.ASC)
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

        /// <summary>The ORDER BY part for this column, with the column name as given.</summary>
        public string SqlForm
        {
            get { return GetSqlForm(false); }
        }

        /// <summary>
        /// The ORDER BY part for this column. With quoteColumnName, a plain column name is quoted
        /// (see <see cref="QuoteColumnName"/>); Oracle DALs use this.
        /// </summary>
        public string GetSqlForm(bool quoteColumnName)
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
            string column = quoteColumnName ? QuoteColumnName(columnName) : columnName;
            return column + " " + s;
        }

        /// <summary>
        /// Quotes a plain column name, the same way WhereCriteria does.
        /// Oracle turns an unquoted CustomerId into CUSTOMERID, so ORDER BY CustomerId fails (ORA-00904)
        /// on tables created with quoted mixed-case names.
        /// Anything else (already quoted names, t.Name, LOWER(Name), ...) is returned as given.
        /// </summary>
        internal static string QuoteColumnName(string columnName)
        {
            if (string.IsNullOrEmpty(columnName) || !IsPlainIdentifier(columnName))
            {
                return columnName;
            }
            return "\"" + columnName + "\"";
        }

        private static bool IsPlainIdentifier(string name)
        {
            if (!(char.IsLetter(name[0]) || name[0] == '_'))
            {
                return false;
            }
            foreach (char c in name)
            {
                if (!(char.IsLetterOrDigit(c) || c == '_' || c == '$' || c == '#'))
                {
                    return false;
                }
            }
            return true;
        }
    }

}

