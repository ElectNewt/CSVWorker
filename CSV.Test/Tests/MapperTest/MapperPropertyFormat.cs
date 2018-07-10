using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.MapperTest
{
    [TestClass]
    public class MapperPropertyFormat
    {

        private CsvReader<InsuranceMap> Csv { get; set; }

        public MapperPropertyFormat()
        {
            Csv = new CsvReader<InsuranceMap>(@"Resources", "FL_insurance_CSV_SAMPLE.csv");
            Csv.Map("construction", a => a.Material);
            Csv.Map("eq_site_limit", a => a.EqSiteLimit);

        }

        [TestMethod]
        public void BasicMapperPropertyFormatUsage()
        {
            var test = Csv.Read(a => a["construction"] == "Masonry" && a["county"] == "CLAY COUNTY").Where(b => b.EqSiteLimit == 498960);
            Assert.AreEqual(1, test.Count());
        }
    }
}
