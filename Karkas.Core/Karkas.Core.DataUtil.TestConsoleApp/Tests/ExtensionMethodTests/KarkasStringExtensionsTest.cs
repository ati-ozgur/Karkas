using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.Core.Utility;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.ExtensionMethodTests
{
    [TestFixture]
    public class KarkasStringExtensionsTest
    {
        [Test]
        public void ReplaceLastOccuranceTest()
        {
            string deger = @"( SELECT * FROM DENEME_TABLO ) AS DENEME SELECT * 0FROM1 DENEME";

            string degismis = deger.ReplaceLastOccurance("FROM", "FROM_DEGISMIS");
            string beklenen = @"( SELECT * FROM DENEME_TABLO ) AS DENEME SELECT * 0FROM_DEGISMIS1 DENEME";
            Assert.AreEqual(beklenen, degismis);
        }
    }
}
