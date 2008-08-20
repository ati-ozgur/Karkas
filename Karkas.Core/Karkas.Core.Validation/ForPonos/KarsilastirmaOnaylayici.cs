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
        ///   this.Validator.ValidatorList.Add(new CompareValidator(this, "DogumTarihi",DateTime.Now.AddYears(-19),CompareOperator.GreatThanEqual,"Kisi 18 yaþýndan büyük olmalýdýr"));
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
                    str = "{0} " + karsilastirilacakDeger + "'ye eþit olmalýdýr.";
                    break;
                case KarsilastirmaOperatoru.GreaterThan:
                    str = "{0} " + karsilastirilacakDeger + "'den büyük olmalýdýr.";
                    break;
                case KarsilastirmaOperatoru.GreatThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den büyük veya eþit olmalýdýr.";
                    break;
                case KarsilastirmaOperatoru.LessThan:
                    str = "{0} " + karsilastirilacakDeger + "'den küçük olmalýdýr.";
                    break;
                case KarsilastirmaOperatoru.LessThanEqual:
                    str = "{0} " + karsilastirilacakDeger + "'den küçük veya eþit olmalýdýr.";
                    break;
                case KarsilastirmaOperatoru.NotEqual:
                    str = "{0} " + karsilastirilacakDeger + "'ye eþit olmamalýdýr.";
                    break;
                default:
                    throw new ArgumentException("Beklenmeyen CompareOption");
            }
            return str;
        }
    }
}
