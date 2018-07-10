using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeUIntConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeUInt32()
        {

            var value = new UIntConverter(0xB2D05E00).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("3000000000", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeUInt32()
        {
            var value = new UIntConverter("3000000000").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(0xB2D05E00, value);
        }
    }
}
