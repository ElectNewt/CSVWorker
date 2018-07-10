using System;
using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CSV.Utilities;

namespace CSV.Test.Tests.Writer
{
    [TestClass]
    public class WriterWithClasstest
    {
        private List<Insurance> _insuranceList;
        private IWriter<Insurance> Csv { get; set; }
        public WriterWithClasstest()
        {
            Createinsurance(10);
            Csv = new CsvWriter<Insurance>();
            CreateMapper();
        }

        public void Createinsurance(int items)
        {
            _insuranceList = new List<Insurance>();
            for (int i = 0; i < items; i++)
            {
                var insurance = new Insurance() { County = "country " + i, EqSiteLimit = i, NotExistInt = 0, NotExistString = "test " + i, Policyid = "PolicyID" + i };
                _insuranceList.Add(insurance);
            }
        }

        
        public void CreateMapper()
        {
            Csv.Map(a => a.County, "Country");
            Csv.Map(a => a.EqSiteLimit, "limit");
            Csv.Map(a => a.NotExistInt).Visible(false);
            Csv.Map(a => a.Policyid, "Policy").Visible(true);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException),
            "Directory not found exception")]
        public void CreateBasicInfo()
        {
            Createinsurance(10);
            Csv.Configuration.SetCreateDirectory(false);
            Csv.Write(_insuranceList, @"c:\temp\Failed\test.csv");
        }

        [TestMethod]
        public void CreateDirectory()
        {
            Createinsurance(10);
            Csv.Configuration.CreateDirectory = true; 
            Csv.Write(_insuranceList, @"c:\temp\created\test.csv");
        }


        [TestMethod]
        public void SetEmptyExtenstion()
        {
            Createinsurance(0);
            Csv.Configuration.EmptyFilesExtension = ".empty";
            Csv.Write(_insuranceList, @"c:\temp\test.csv");
        }

        [TestMethod]
        public void SetEmptyDirectoryExtension()
        {
            Createinsurance(0);
            Csv.Configuration.SetCreateDirectory(true).SetEmptyFilesExtension(".empty");
            Csv.Write(_insuranceList, @"c:\temp\SetEmptyDirectoryExtension\test.csv");
        }

        [TestMethod]
        public void SetPopulatedwithExtension()
        {
            Createinsurance(10);
            Csv.Configuration.SetEmptyFilesExtension(".empty");
            Csv.Write(_insuranceList, @"c:\temp\testpopulatedExtension.csv");
        }

        //[TestMethod]
        public void Test100Records()
        {
            Createinsurance(100);
            Csv.Write(_insuranceList, @"c:\temp\test100r.csv");
        }
     //   [TestMethod]
        public void Test1KRecords()
        {
            Createinsurance(1000);
            Csv.Write(_insuranceList, @"c:\temp\test1kr.csv");
        }
       // [TestMethod]
        public void Test10KRecords()
        {
            Createinsurance(10000);
            Csv.Write(_insuranceList, @"c:\temp\test10kr.csv");
        }
       // [TestMethod]
        public void Test100KRecords()
        {
            Createinsurance(100000);
            Csv.Write(_insuranceList, @"c:\temp\test100kr.csv");
        }
      //  [TestMethod]
        public void Test1MRecords()
        {
            try
            {
                Csv.Configuration.CreateDirectory = true;
                Createinsurance(1000000);
                Csv.Write(_insuranceList, @"c:\temp\test1Mr.csv");
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }

        }



    }
}
