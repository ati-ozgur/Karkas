using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;
using Simetri.Core.Validation.ForPonos;
using Simetri.Core.Validation;

namespace Simetri.Core.DataUtil.TestConsoleApp.TypeLibrary
{
    public partial class OrnekA : BaseTypeLibrary
    {
        private short shortDegisken;

        public short ShortDegisken
        {
            get { return shortDegisken; }
            set { shortDegisken = value; }
        }


        private string emailDegisken;

        public string EmailDegisken
        {
            get { return emailDegisken; }
            set { emailDegisken = value; }
        }
	

        protected override void ValidationListesiniOlustur()
        {
            this.Validator.ValidatorList.Add(new CompareValidator(this, "ShortDegisken", 18, CompareOperator.GreatThanEqual));
            base.ValidationListesiniOlustur();
        }

        protected override void ValidationListesiniOlusturCodeGeneration()
        {
        }
    }
}
