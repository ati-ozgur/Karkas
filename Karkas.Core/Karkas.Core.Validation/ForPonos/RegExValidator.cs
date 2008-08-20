using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Karkas.Core.Validation.ForPonos
{
    [Serializable]
    public class RegExValidator : BaseOnaylayici
    {
        private string regularExpression;
        private RegexOptions regExOptions;

        public RegExValidator(object pUzerindeCalisilacakNesne, string pPropertyName,
            string pRegularExpression,RegexOptions pRegExOptions) 
            : base(pUzerindeCalisilacakNesne,pPropertyName)
        {
            this.regExOptions = pRegExOptions;
            this.regularExpression = pRegularExpression;
        }

        public RegExValidator(object pUzerindeCalisilacakNesne, string pPropertyName,
            string pRegularExpression, RegexOptions pRegExOptions,string pErrorMessage)
            : base(pUzerindeCalisilacakNesne, pPropertyName,pErrorMessage)
        {
            this.regExOptions = pRegExOptions;
            this.regularExpression = pRegularExpression;
        }
        
        
        public override bool IslemYap(object instance, object fieldValue)
        {
            if (instance == null || fieldValue == null)
            {
                return false;
            }
            return new Regex(regularExpression, regExOptions).IsMatch(fieldValue.ToString());
        }

        protected override string HataMesajlariniOlustur()
        {
            return string.Format("{0} kabul edilen bir formatta deðildir",this.Property.Name);
        }
    }
}
