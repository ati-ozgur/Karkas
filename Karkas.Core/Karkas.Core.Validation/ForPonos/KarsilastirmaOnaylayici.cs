using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class KarsilastirmaOnaylayici : BaseOnaylayici
    {
        IComparable karsilastirilacakDeger;
        KarsilastirmaOperatoru compareOperator;
        /// <summary>
        /// Verilen Nesnenin = pUzerindeCalisilacakNesne
        /// verilen propertisinin = pPropertyName
        /// verilen bir deger ile = pKarsilastirilacakDeger
        /// karsilastirmasini yapar.
        /// <example>
        /// // bu ornek uzerinde Kisinin 18 yasindan buyuk olmasi lazim.
        ///  // this.DogumTarihi >= DateTime.Now.AddYears(-18)
        ///   this.Validator.ValidatorList.Add(new CompareValidator(this, "DogumTarihi",DateTime.Now.AddYears(-19),CompareOperator.GreatThanEqual,"Kisi 18 ya��ndan b�y�k olmal�d�r"));
        /// </example>
        /// </summary>
        /// <param name="pUzerindeCalisilacakNesne"></param>
        /// <param name="pPropertyName"></param>
        /// <param name="pKarsilastirilacakDeger"></param>
        /// <param name="pCompareOperator"></param>
        public KarsilastirmaOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pKarsilastirilacakDeger, KarsilastirmaOperatoru pCompareOperator)
            : base(pUzerindeCalisilacakNesne, pPropertyName)
        {
            karsilastirilacakDeger = pKarsilastirilacakDeger;
            compareOperator = pCompareOperator;
        }

        public KarsilastirmaOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName
            , IComparable pKarsilastirilacakDeger, KarsilastirmaOperatoru pCompareOperator, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pErrorMessage)
        {
            karsilastirilacakDeger = pKarsilastirilacakDeger;
            compareOperator = pCompareOperator;
        }

        public override bool IslemYap(object instance, object fieldValue)
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
                case KarsilastirmaOperatoru.Equal:
                    sonuc = val.CompareTo(karsilastirilacakDeger) == 0;
                    break;
                case KarsilastirmaOperatoru.GreaterThan:
                    sonuc = val.CompareTo(karsilastirilacakDeger) > 0;
                    break;
                case KarsilastirmaOperatoru.GreatThanEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) >= 0;
                    break;
                case KarsilastirmaOperatoru.LessThan:
                    sonuc = val.CompareTo(karsilastirilacakDeger) < 0;
                    break;
                case KarsilastirmaOperatoru.LessThanEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) >= 0;
                    break;
                case KarsilastirmaOperatoru.NotEqual:
                    sonuc = val.CompareTo(karsilastirilacakDeger) != 0;
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return sonuc;
        }

        protected override string HataMesajlariniOlustur()
        {
            string str;
            switch (compareOperator)
            {
                case KarsilastirmaOperatoru.Equal:
                    str = "{0} " + karsilastirilacakDeger + "'ye e�it olmal�d�r.";
                    break;
                case KarsilastirmaOperatoru.GreaterThan:
                    str = "{0} " + karsilastirilacakDeger + "'den b�y�k olmal�d�r.";
                    break;
                case KarsilastirmaOperatoru.GreatThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den b�y�k veya e�it olmal�d�r.";
                    break;
                case KarsilastirmaOperatoru.LessThan:
                    str = "{0} " + karsilastirilacakDeger + "'den k���k olmal�d�r.";
                    break;
                case KarsilastirmaOperatoru.LessThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den k���k veya e�it olmal�d�r.";
                    break;
                case KarsilastirmaOperatoru.NotEqual:
                    str = "{0} " + karsilastirilacakDeger + "'ye e�it olmamal�d�r.";
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return str;
        }
    }
}
