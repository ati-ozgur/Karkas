using System;
using System.Collections.Generic;
using System.Text;

namespace Karkas.Core.Onaylama.ForPonos
{
    public class EsitDegilDegerOnaylayici : KarsilastirmaOnaylayici
    {
        private const KarsilastirmaOperatoru KARSILASTIRMA_OP = KarsilastirmaOperatoru.EsitDegildir;

        public EsitDegilDegerOnaylayici(object pUzerindeCalisilacakNesne
                        , string pPropertyName,
                        IComparable pKarsilastirilacakDeger)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP)
        {

        }
        public EsitDegilDegerOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,
            IComparable pKarsilastirilacakDeger, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pKarsilastirilacakDeger, KARSILASTIRMA_OP, pErrorMessage)
        {

        }

    }

}
