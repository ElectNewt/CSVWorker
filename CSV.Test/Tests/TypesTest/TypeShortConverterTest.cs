using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
namespace CSV.Test.Tests.TypesTest
{

    [TestClass]
    public class TypeShortConverterTest
    {
        [TestMethod]
        public void ValidateReadShort()
        {
            var val = new ShortConverter(123).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("123", val);
        }

        [TestMethod]
        public void ValidateConvertShortToString()
        {
            var val = new ShortConverter("123").ConvertToObject("", CultureInfo.CurrentCulture);
            Assert.AreEqual((short)123, val);
        }
    }
}
