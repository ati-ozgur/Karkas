using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.TypeLibrary;
using Karkas.Core.Validation.ForPonos;
using Karkas.Core.Validation;

namespace Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary
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
	

        protected override void OnaylamaListesiniOlustur()
        {
            this.Onaylayici.ValidatorList.Add(new CompareValidator(this, "ShortDegisken", 18, KarsilastirmaOperatoru.GreatThanEqual));
            base.OnaylamaListesiniOlustur();
        }

        protected override void OnaylamaListesiniOlusturCodeGeneration()
        {
        }
    }
}
