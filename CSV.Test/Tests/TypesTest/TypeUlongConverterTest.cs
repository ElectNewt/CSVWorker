using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeUlongConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeUInt64()
        {

            var value = new UlongConverter(0x0001D8e864DD).GetString("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("7934076125", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeUInt64()
        {
            var value = new UlongConverter("7934076125").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual((ulong)0x0001D8e864DD, value);
        }
    }
}
