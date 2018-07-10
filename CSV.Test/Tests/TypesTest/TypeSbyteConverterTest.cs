using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;


namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeSbyteConverterTest
    {
        [TestMethod]
        public void ValidateReadTypesByte()
        {

            var value = new SbyteConverter(-102).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("-102", value);
        }

        [TestMethod]
        public void ValidateconvertToTypeSbyte()
        {
            var value = new SbyteConverter("-102").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual((sbyte)-102, value);
        }
    }
}
