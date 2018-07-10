using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeStringConverterTest
    {
        [TestMethod]
        public void ValidateReadString()
        {
            var val = new StringConverter("123").GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("123", val);
        }

        [TestMethod]
        public void ValidateConvertToString()
        {
            var val = new StringConverter("123").ConvertToObject("", CultureInfo.CurrentCulture);
            Assert.AreEqual("123", val);
        }
    }
}
