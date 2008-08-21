using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.Onaylama;

namespace Karkas.Core.Onaylama.ForPonos
{
    public class EsitDegerOnaylayici : KarsilastirmaOnaylayici
    {
        private const KarsilastirmaOperatoru KARSILASTIRMA_OP = KarsilastirmaOperatoru.Esittir;

        public EsitDegerOnaylayici(object pUzerindeCalisilacakNesne
                        , string pPropertyName,
                        IComparable pKarsilastirilacakDeger)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP)
        {

        }
        public EsitDegerOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,
            IComparable pKarsilastirilacakDeger, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP, pErrorMessage)
        {

        }

    }
}
