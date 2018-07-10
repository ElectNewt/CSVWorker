using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{

    [TestClass]
    public class TypeLongConverterTest
    {
        [TestMethod]
        public void ValidateConvertFromLongToString()
        {
            var val = new LongConverter(0x100000000).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("4294967296", val);
        }

        [TestMethod]
        public void ValidateConvertToObjectFromString()
        {
            var val = new LongConverter("4294967296").ConvertToObject("", CultureInfo.CurrentCulture);
            Assert.AreEqual(0x100000000, val);
        }
    }
}
