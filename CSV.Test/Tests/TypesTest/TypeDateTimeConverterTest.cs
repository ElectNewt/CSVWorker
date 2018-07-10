using System;
using System.Globalization;
using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeDateTimeConverterTest
    {
        [TestMethod]
        public void ValidateReadTypeDatetime()
        {

            var value = new DateTimeConverter(new DateTime(2018, 04, 20)).GetString("yyyyMMdd", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual("20180420", value);
        }


        [TestMethod]
        public void ValidateconvertToTypeDatetime()
        {
            var value = new DateTimeConverter("2018-04-20").ConvertToObject("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-IE"));
            Assert.AreEqual(new DateTime(2018, 04, 20), value);
        }

    }
}
