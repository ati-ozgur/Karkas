using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class CompareValidator : BaseValidator
    {
        IComparable karsilastirilacakDeger;
        CompareOperator compareOperator;

        public CompareValidator(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pKarsilastirilacakDeger, CompareOperator pCompareOperator)
            : base(pUzerindeCalisilacakNesne, pPropertyName)
        {
            karsilastirilacakDeger = pKarsilastirilacakDeger;
            compareOperator = pCompareOperator;
        }

        public CompareValidator(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pKarsilastirilacakDeger, CompareOperator pCompareOperator,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
            karsilastirilacakDeger = pKarsilastirilacakDeger;
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
                fieldValue = Convert.ChangeType(fieldValue, karsilastirilacakDeger.GetType());
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
                    sonuc = val.CompareTo(karsilastirilacakDeger) == 0;
                    break;
                case CompareOperator.GreaterThan:
                    sonuc = val.CompareTo(karsilastirilacakDeger) > 0;
                    break;
                case CompareOperator.GreatThanEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) >= 0;
                    break;
                case CompareOperator.LessThan:
                    sonuc = val.CompareTo(karsilastirilacakDeger) < 0;
                    break;
                case CompareOperator.LessThanEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) >= 0;
                    break;
                case CompareOperator.NotEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) != 0;
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
                    str = "{0} " + karsilastirilacakDeger + "'ye e�it olmal�d�r.";
                    break;
                case CompareOperator.GreaterThan:
                    str = "{0} " + karsilastirilacakDeger + "'den b�y�k olmal�d�r.";
                    break;
                case CompareOperator.GreatThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den b�y�k veya e�it olmal�d�r.";
                    break;
                case CompareOperator.LessThan:
                    str = "{0} " + karsilastirilacakDeger + "'den k���k olmal�d�r.";
                    break;
                case CompareOperator.LessThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den k���k veya e�it olmal�d�r.";
                    break;
                case CompareOperator.NotEqual:
                    str = "{0} " + karsilastirilacakDeger + "'ye e�it olmamal�d�r.";
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return str;
        }
    }
}
