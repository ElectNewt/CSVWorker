using System;
using System.Diagnostics;
using System.Globalization;
using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.Reader
{
    [TestClass]
    public class ReaderWithClassTest
    {
        private CsvReader<Insurance> Csv { get; set; }
        private CsvReader<Sp1Example> CsvSp1 { get; set; }

        public ReaderWithClassTest()
        {
            Csv = new CsvReader<Insurance>(@"Resources", "FL_insurance_CSV_SAMPLE.csv");
            CsvSp1 = new CsvReader<Sp1Example>(@"Resources", "sp1.csv");
        }

        public void PerfomanceIssue()
        {
            // test here the perfomance isuue
            var st = new Stopwatch();
            st.Start();
            var test = Csv.Read(a => a[1] == "FL");
            st.Stop();
            var time1 = st.ElapsedMilliseconds;
        }

        [TestMethod] 
        public void ConvertToClass()
        {
            Assert.AreEqual(1301, Csv.Read().Count);
        }


        [TestMethod]
        public void ConvertToClassWithPredicate()
        {
            Assert.AreEqual(2,
                Csv.Read(a => a["construction"] == "Reinforced Concrete" && a["county"] == "NASSAU COUNTY").Count);
        }

        [TestMethod]
        public void ApplyFormat()
        {
            CsvSp1 = new CsvReader<Sp1Example>(@"Resources", "sp1.csv");
            CsvSp1.Map("Local", a => a.HomeTeam);
            CsvSp1.Map("Date", a => a.Date).Format("dd/MM/yy");
            var matchdate = CsvSp1.Read(a => a["HomeTeam"] == "Betis").FirstOrDefault()?.Date;
            Assert.AreEqual(new DateTime(2017,08,25), matchdate);
        }

        [TestMethod]
        public void ApplyProvider()
        {
            CsvSp1 = new CsvReader<Sp1Example>(@"Resources", "sp1.csv");
            CsvSp1.Map("Local", a => a.HomeTeam);
            CsvSp1.Map("B365H", a => a.B365H).Format(new CultureInfo("en-IE"));
            var b365H = CsvSp1.Read(a => a["HomeTeam"] == "Leganes" && a["AwayTeam"]== "Alaves").FirstOrDefault()?.B365H;
            Assert.AreEqual((decimal)2.05, b365H);
        }
        [TestMethod]
        public void ApplyFormatProvider()
        {
            CsvSp1 = new CsvReader<Sp1Example>(@"Resources", "sp1.csv");
            CsvSp1.Map("Local", a => a.HomeTeam);
            CsvSp1.Map("Date", a => a.Date).Format("dd/MM/yy", new CultureInfo("es-ES"));
            var matchdate = CsvSp1.Read(a => a["HomeTeam"] == "Betis").FirstOrDefault()?.Date;
            Assert.AreEqual(new DateTime(2017, 08, 25), matchdate);
        }
    }
}
