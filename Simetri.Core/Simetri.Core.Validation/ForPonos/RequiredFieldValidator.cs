using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class RequiredFieldValidator : BaseValidator
    {
        public RequiredFieldValidator(object pUzerindeCalisilacakNesne,string pPropertyName) : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
        }
        public RequiredFieldValidator(object pUzerindeCalisilacakNesne, string pPropertyName,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
        }


        public override bool Perform(object instance, object fieldValue)
        {
            return fieldValue != null && fieldValue.ToString().Length != 0;
        }

        protected override string BuildErrorMessage()
        {
            return String.Format("{0} Gereklidir.", Property.Name);
        }



    }
}
