using System;
using System.Collections.Generic;
using System.Text;

namespace Simetri.Core.Validation.ForPonos
{
    [Serializable]
    public class AlwaysFail : BaseValidator
    {
        /// <summary>
        /// Set Error Message icin daima fail edecek.
        /// </summary>
        /// <param name="pUzerindeCalisilacakNesne"></param>
        /// <param name="pPropertyName"></param>
        public AlwaysFail(object pUzerindeCalisilacakNesne, string pPropertyName)
            : base(pUzerindeCalisilacakNesne, pPropertyName)
        {
        }
        public AlwaysFail(object pUzerindeCalisilacakNesne, string pPropertyName, string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName, pErrorMessage)
        {
        }


        /// <summary>
        /// Daima fail edicek zaten.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public override bool Perform(object instance, object fieldValue)
        {
            return false;
        }

        protected override string BuildErrorMessage()
        {
            return string.Format("{0} hatalý", this.PropertyName);
        }
    }
}

