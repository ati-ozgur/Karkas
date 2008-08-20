using System;
using System.Collections.Generic;
using System.Text;
using Karkas.Core.DataUtil.TestConsoleApp.TypeLibrary;
using NUnit.Framework;
using Karkas.Core.Validation.ForPonos;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.OnaylamaTestleri.Email
{
    [TestFixture]
    public class EmailTest
    {
        // Methods
        [Test]
        public void TestGmail()
        {
            OrnekA a = this.testIcinOrnekAOlustur();
            a.EmailDegisken = "Deneme";
            Assert.IsFalse(a.Onayla());
            a.EmailDegisken = "deneme@gmail.com";
            Assert.IsTrue(a.Onayla());
            a.EmailDegisken = "Deneme_Deneme.com";
            Assert.IsFalse(a.Onayla());
        }

        private OrnekA testIcinOrnekAOlustur()
        {
            OrnekA a = new OrnekA();
            a.Onaylayici.ValidatorList.Clear();
            a.Onaylayici.ValidatorList = new List<BaseValidator>();
            a.Onaylayici.ValidatorList.Add(new EmailValidator(a, "EmailDegisken"));
            return a;
        }
    }

 

}
