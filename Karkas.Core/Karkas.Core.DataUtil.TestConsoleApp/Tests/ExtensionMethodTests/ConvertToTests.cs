using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Karkas.ExtensionMethods;

namespace Karkas.Core.DataUtil.TestConsoleApp.Tests.ExtensionMethodTests
{
    [TestFixture]
    public class ConvertToTests
    {
        [Test]
        public void ToDecimalTest()
        {
            decimal? sonuc = "".ToDecimalAsNullable();
            Assert.AreEqual(null, sonuc);
            sonuc = "1".ToDecimalAsNullable();
            Assert.AreEqual(1, sonuc);
            sonuc = "0".ToDecimalAsNullable();
            Assert.AreEqual(0, sonuc);
            string s = null;
            sonuc = s.ToDecimalAsNullable();
            Assert.AreEqual(null, sonuc);


        }
        [Test]
        public void ToIntTest()
        {
            Int32? sonuc = "".ToIntAsNullable();
            Assert.AreEqual(null, sonuc);
            sonuc = "1".ToIntAsNullable();
            Assert.AreEqual(1, sonuc);
            sonuc = "0".ToIntAsNullable();
            Assert.AreEqual(0, sonuc);
            string s = null;
            sonuc = s.ToIntAsNullable();
            Assert.AreEqual(null, sonuc);


        }
        [Test]
        public void ToByteTest()
        {
            byte? sonuc = "".ToByteAsNullable();
            Assert.AreEqual(null, sonuc);
            sonuc = "1".ToByteAsNullable();
            Assert.AreEqual(1, sonuc);
            sonuc = "0".ToByteAsNullable();
            Assert.AreEqual(0, sonuc);
            string s = null;
            sonuc = s.ToByteAsNullable();
            Assert.AreEqual(null, sonuc);
        }

        [Test]
        public void ToLongTest()
        {
            long? sonuc = "".ToLongAsNullable();
            Assert.AreEqual(null, sonuc);
            sonuc = "1".ToLongAsNullable();
            Assert.AreEqual(1, sonuc);
            sonuc = "0".ToLongAsNullable();
            Assert.AreEqual(0, sonuc);
            string s = null;
            sonuc = s.ToLongAsNullable();
            Assert.AreEqual(null, sonuc);
        }
        [Test]
        public void ToShortTest()
        {
            short? sonuc = "".ToShortAsNullable();
            Assert.AreEqual(null, sonuc);
            sonuc = "1".ToShortAsNullable();
            Assert.AreEqual(1, sonuc);
            sonuc = "0".ToShortAsNullable();
            Assert.AreEqual(0, sonuc);
            string s = null;
            sonuc = s.ToShortAsNullable();
            Assert.AreEqual(null, sonuc);
        }

    }
}
