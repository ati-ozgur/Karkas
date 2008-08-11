using System;
using System.Collections.Generic;
using System.Text;
using Simetri.Core.TypeLibrary;

namespace Simetri.Core.DataUtil.TestConsoleApp.TypeLibrary
{
    public class OrnekKarsilastirma : BaseTypeLibrary
    {
        private DateTime dogumTarihi;

        public DateTime DogumTarihi
        {
            get { return dogumTarihi; }
            set { dogumTarihi = value; }
        }
	

        protected override void ValidationListesiniOlusturCodeGeneration()
        {
        }
    }
}
