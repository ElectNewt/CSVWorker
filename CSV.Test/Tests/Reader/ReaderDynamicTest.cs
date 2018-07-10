using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.Reader
{
    [TestClass]
    public class ReaderDynamicTest
    {
        private CsvReader<dynamic> Csv { get; set; }

        public ReaderDynamicTest()
        {
            Csv = new CsvReader<dynamic>(@"Resources", "FL_insurance_CSV_SAMPLE.csv");
        }

        [TestMethod]
        public void ReadFile()
        {
            Assert.AreEqual(true, Csv.Rows.Any());
        }


        [TestMethod]
        public void GetByPostiion()
        {
            Assert.AreEqual("FL", Csv.Rows.FirstOrDefault()[1]);
        }

        [TestMethod]
        public void GetListByPosition()
        {
            Assert.AreEqual(1301, Csv.Rows.Where(a => a[1] == "FL").Count());
        }

        [TestMethod]
        public void GetListByPositionIndexer()
        {
            Assert.AreEqual(1301, Csv.Rows.Where(a => a[1] == "FL").Count());
        }

        [TestMethod]
        public void GetListByMultiplePosition()
        {
            Assert.AreEqual(20, Csv.Rows.Where(a => a[1] == "FL" && a[16] == "Reinforced Concrete").Count());
        }

        [TestMethod]
        public void GetByHeader()
        {
            Assert.AreEqual("Masonry", Csv.Rows.FirstOrDefault()["construction"]);
        }


        [TestMethod]
        public void GetListByHeader()
        {
            Assert.AreEqual(20, Csv.Rows.Where(a => a["construction"] == "Reinforced Concrete").Count());
        }

        [TestMethod]
        public void GetListByMultipleHeader()
        {
            Assert.AreEqual(2, Csv.Rows.Where(a => a["construction"] == "Reinforced Concrete" && a["county"] == "NASSAU COUNTY").Count());
        }

        [TestMethod]
        public void GetListByMultipleHeaderIndexer()
        {
            Assert.AreEqual(2, Csv.Rows.Where(a => a["construction"] == "Reinforced Concrete" && a["county"] == "NASSAU COUNTY").Count());
        }




    }
}
