using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Onaylama.ForPonos
{
    public class MinDegerOnaylayici : KarsilastirmaOnaylayici
    {
        private const KarsilastirmaOperatoru KARSILASTIRMA_OP = KarsilastirmaOperatoru.BuyukEsittir;

        public MinDegerOnaylayici(object pUzerindeCalisilacakNesne
                        , string pPropertyName,
                        IComparable pKarsilastirilacakDeger)
                        : base( pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP)
        {

        }
        public MinDegerOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,
            IComparable pKarsilastirilacakDeger, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP, pErrorMessage)
        {

        }


    }
}

