using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class CompareValidator : BaseValidator
    {
        IComparable value;
        CompareOperator compareOperator;

        public CompareValidator(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pValue, CompareOperator pCompareOperator)
            : base(pUzerindeCalisilacakNesne, pPropertyName)
        {
            value = pValue;
            compareOperator = pCompareOperator;
        }

        public CompareValidator(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pValue, CompareOperator pCompareOperator,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
            value = pValue;
            compareOperator = pCompareOperator;
        }

        public override bool Perform(object instance, object fieldValue)
        {
             if (
                    (fieldValue is Byte)
                || (fieldValue is Int16) 
                || (fieldValue is Int32) 
                || (fieldValue is Int64)
                || (fieldValue is SByte)
                || (fieldValue is UInt16) 
                || (fieldValue is UInt32) 
                || (fieldValue is UInt64) 
                )
            {
                fieldValue = Convert.ChangeType(fieldValue, value.GetType());
            }
            IComparable val = fieldValue as IComparable;
            if (val == null)
            {
                return false;
            }
            if (val is string)
            {
                val = val.ToString().Length;
            }
  
            bool sonuc = false;
            switch (compareOperator)
            {
                case CompareOperator.Equal:
                    sonuc = val.CompareTo(value) == 0;
                    break;
                case CompareOperator.GreaterThan:
                    sonuc = val.CompareTo(value) > 0;
                    break;
                case CompareOperator.GreatThanEqual:
                    sonuc = val.CompareTo(value) >= 0;
                    break;
                case CompareOperator.LessThan:
                    sonuc = val.CompareTo(value) < 0;
                    break;
                case CompareOperator.LessThanEqual:
                    sonuc = val.CompareTo(value) >= 0;
                    break;
                case CompareOperator.NotEqual:
                    sonuc = val.CompareTo(value) != 0;
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return sonuc;
        }

        protected override string BuildErrorMessage()
        {
            string str;
            switch (compareOperator)
            {
                case CompareOperator.Equal:
                    str = "{0} " + value + "'ye eþit olmalýdýr.";
                    break;
                case CompareOperator.GreaterThan:
                    str = "{0} " + value + "'den büyük olmalýdýr.";
                    break;
                case CompareOperator.GreatThanEqual:
                    str = "{0} " + value + "'den büyük veya eþit olmalýdýr.";
                    break;
                case CompareOperator.LessThan:
                    str = "{0} " + value + "'den küçük olmalýdýr.";
                    break;
                case CompareOperator.LessThanEqual:
                    str = "{0} " + value + "'den küçük veya eþit olmalýdýr.";
                    break;
                case CompareOperator.NotEqual:
                    str = "{0} " + value + "'ye eþit olmamalýdýr.";
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return str;
        }
    }
}
