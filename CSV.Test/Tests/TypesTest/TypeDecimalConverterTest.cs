using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;


namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeDecimalConverterTest
    {

        [TestMethod]
        public void ValidateReadTypeDecimal()
        {

            var value = new DecimalConverter(121658168m).GetString("0.00", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("121658168.00", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeDecimal()
        {
            var value = new DecimalConverter("121658168").ConvertToObject("", CultureInfo.CurrentCulture);
            Assert.AreEqual(121658168m, value);
        }
    }
}
