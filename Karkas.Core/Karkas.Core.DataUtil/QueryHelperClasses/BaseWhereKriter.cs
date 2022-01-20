using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.DataUtil.QueryHelperClasses
{
    public abstract class BaseWhereKriter
    {
        protected LikePlacementEnum likePlacement = LikePlacementEnum.None;

        public LikePlacementEnum LikePlacement
        {
            get { return likePlacement; }
            set { likePlacement = value; }
        }


        protected string parameterName;

        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }


        protected WhereOperatorEnum whereOperator;

        public WhereOperatorEnum WhereOperator
        {
            get { return whereOperator; }
            set { whereOperator = value; }
        }



        protected string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public abstract string SqlHali
        {
            get;
        }

        public string whereOperatorDegeriniAl()
        {
            string s = "";
            switch (whereOperator)
            {
                case WhereOperatorEnum.GreaterAndEquals:
                    s = " >= ";
                    break;
                case WhereOperatorEnum.Greater:
                    s = ">";
                    break;
                case WhereOperatorEnum.NotEquals:
                    s = "<>";
                    break;
                case WhereOperatorEnum.Equals:
                    s = "=";
                    break;
                case WhereOperatorEnum.LesserAndEquals:
                    s = "<=";
                    break;
                case WhereOperatorEnum.Lesser:
                    s = "<";
                    break;
                case WhereOperatorEnum.Like:
                    s = " LIKE ";
                    break;
            }
            return s;
        }
    }
}

