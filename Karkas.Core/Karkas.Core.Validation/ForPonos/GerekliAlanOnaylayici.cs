using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Karkas.Core.Onaylama.ForPonos
{
    [Serializable]
    public class GerekliAlanOnaylayici : BaseOnaylayici
    {
        public GerekliAlanOnaylayici(object pUzerindeCalisilacakNesne,string pPropertyName) : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
        }
        public GerekliAlanOnaylayici(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
        }


        public override bool IslemYap(object instance, object fieldValue)
        {
            return fieldValue != null && fieldValue.ToString().Length != 0;
        }

        protected override string HataMesajlariniOlustur()
        {
            return String.Format("{0} Gereklidir.", Property.Name);
        }



    }
}
