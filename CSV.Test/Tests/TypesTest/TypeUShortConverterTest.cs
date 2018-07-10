using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeUShortConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeUInt16()
        {

            var value = new UShortConverter(0xFE0A).GetString("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("65034", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeUInt16()
        {
            var value = new UShortConverter("65034").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual((ushort)0xFE0A, value);
        }
    }
}
