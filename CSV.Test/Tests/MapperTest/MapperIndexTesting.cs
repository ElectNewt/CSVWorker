using CSV.Map.Reader;
using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.MapperTest
{
    [TestClass]
    public class MapperIndexTesting
    {
        private CsvReader<InsuranceMap> Csv { get; set; }

        public MapperIndexTesting()
        {
            Csv = new CsvReader<InsuranceMap>(@"Resources", "FL_insurance_CSV_SAMPLE.csv");
            Csv.Map(16, a => a.Material);
        }

        [TestMethod]
        public void BasicMapperPropertyUsage()
        {
            var mapper = new CsvReaderMapper<InsuranceMap>();
            mapper.Add(16, a => a.Material);
            Assert.AreEqual(1, mapper.Get().Count);
        }

        [TestMethod]
        public void ConvertToClassWithMapperPropperty()
        {
            Assert.AreEqual(2, Csv.Read(a => a["construction"] == "Reinforced Concrete" && a["county"] == "NASSAU COUNTY").Where(b => !string.IsNullOrWhiteSpace(b.Material)).Count());
        }
    }
}
