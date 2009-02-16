using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Onaylama.ForPonos
{
    public class MaxDegerOnaylayici : KarsilastirmaOnaylayici
    {
        private const KarsilastirmaOperatoru KARSILASTIRMA_OP = KarsilastirmaOperatoru.KucukEsittir;

        public MaxDegerOnaylayici(object pUzerindeCalisilacakNesne
                        , string pPropertyName,
                        IComparable pKarsilastirilacakDeger)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP)
        {

        }
        public MaxDegerOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,
            IComparable pKarsilastirilacakDeger, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP, pErrorMessage)
        {

        }


    }
}

