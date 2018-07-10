using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeByteConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeByte()
        {

            var value = new ByteConverter(0xC9).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("201", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeByte()
        {
            var value = new ByteConverter("201").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual((byte)0xC9, value);
        }
    }
}
