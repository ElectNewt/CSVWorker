using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;


namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeBooleanConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeBoolean()
        {

            var value = new BooleanConverter(true).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("True", value);
        }


        [TestMethod]
        public void ValidateconvertToTypeBooleanFromTrue()
        {
            var value = new BooleanConverter("true").ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(true, value);
        }
        [TestMethod]
        public void ValidateconvertToTypeBooleanFrom1()
        {
            var value = new BooleanConverter(1).ConvertToObject("", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(true, value);
        }

    }
}
