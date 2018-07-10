using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.Reader
{
    [TestClass]
    public class ReaderDynamicTestNoHeaders
    {
        private IReader<dynamic> Csv { get; set; }

        public ReaderDynamicTestNoHeaders()
        {
            Csv = new CsvReader<dynamic>(@"Resources", "FL_insurance_CSV_SAMPLE_no_headers.csv",false);
            Csv.Configuration.SetDelimiter(';');
        }

        [TestMethod]
        public void ReadFileNoHeaders()
        {
            Assert.AreEqual(true, Csv.Rows.Any());
        }


        [TestMethod]
        public void GetByPostiionNoHeaders()
        {
            Assert.AreEqual("FL", Csv.Rows.FirstOrDefault()?[1]);
        }

        [TestMethod]
        public void GetListByPositionNoHeaders()
        {
            var t = Csv.Rows.Where(a => a[1] == "FL").ToList();
            Assert.AreEqual(1301, Csv.Rows.Count(a => a[1] == "FL"));
        }

        [TestMethod]
        public void GetListByMultiplePositionNoHeaders()
        {
            Assert.AreEqual(20, Csv.Rows.Count(a => a[1] == "FL" && a[16] == "Reinforced Concrete"));
        }

    }
}
