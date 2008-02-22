using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simetri.Core.DataUtil.TestConsoleApp.TypeLibrary;

namespace Simetri.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri
{
    [TestFixture]
    public class KarsilastirmaTestleri
    {
        
        [Test]
        public void TestCastIntToShort()
        {
            OrnekA a = new OrnekA();
            a.ShortDegisken = 25;
            Assert.IsTrue(a.Validate());
        }
	


    }
}
