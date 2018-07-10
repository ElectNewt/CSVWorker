using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CSV.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSV.Test.Tests.Utilities
{
 
    [TestClass]
    public class CreateDirectoryTest
    {
        [TestMethod]
        public void Create()
        {
            try
            {
                new CreateDirectory(@"C:\temp\CREATE").Create();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
          
        }


        

    }
}
