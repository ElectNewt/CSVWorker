using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CSV.TypeConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSV.Test.Tests.TypesTest
{
    [TestClass]
    public class TypeBaseConverter
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException),
            "Not Implemented")]
        public void BaseToObjectException()
        {
            var baseconverter = new BaseConverter("123").ConvertToObject("",CultureInfo.CurrentCulture);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException),
            "Not Implemented")]
        public void BaseTostringException()
        {
            var baseconverter = new BaseConverter("123").GetString("", CultureInfo.CurrentCulture);
        }


    }
}
