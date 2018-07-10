using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeCharConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeChar()
        {

            var value = new CharConverter("C").GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("C", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeChar()
        {
            var value = new CharConverter('C').ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual('C', value);
        }
    }
}
