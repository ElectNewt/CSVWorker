using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TipeTimespanConverterTest
    {
        [TestMethod]
        public void ValidateReadTimespan()
        {
            var val = new TimesSpanConverter(new TimeSpan(1, 2, 0, 30, 0)).GetString("", CultureInfo.CurrentCulture);
            Assert.AreEqual("1.02:00:30", val);
        }

        [TestMethod]
        public void ValidateConvertToTimespan()
        {
            var val = new TimesSpanConverter(new TimeSpan(1, 2, 0, 30, 0).ToString("c")).ConvertToObject("c", CultureInfo.CurrentCulture);
            Assert.AreEqual(new TimeSpan(1, 2, 0, 30, 0), TimeSpan.Parse((val.ToString())));
        }
    }
}
