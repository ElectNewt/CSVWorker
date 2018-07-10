using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeInt32ConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeInt32()
        {

            var value = new IntConverter("121658168").GetString("0.00", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("121658168.00", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeInt32()
        {
            var value = new IntConverter("121658168").ConvertToObject("", CultureInfo.CurrentCulture);
            Assert.AreEqual(121658168, value);
        }
    }
}
