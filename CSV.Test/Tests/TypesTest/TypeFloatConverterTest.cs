using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;


namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeFloatConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeFloat()
        {
            var value = new FloatConverter(1.001f).GetString("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("1.001", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeFloat()
        {
            var value = new FloatConverter("121658168").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(121658168f, value);
        }

    }
}
