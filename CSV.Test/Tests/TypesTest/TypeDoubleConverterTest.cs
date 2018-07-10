using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeDoubleConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeDouble()
        {
            var value = new DoubleConverter(1216581.68).GetString("0.00", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("1216581.68", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeDouble()
        {
            var value = new DoubleConverter("1216581.68").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(1216581.68, value);
        }
    }
}
