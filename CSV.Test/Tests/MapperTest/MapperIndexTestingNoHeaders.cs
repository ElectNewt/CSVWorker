using CSV.Map.Reader;
using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CSV.Test.Tests.MapperTest
{
    [TestClass]
    public class MapperIndexTestingNoHeaders
    {
        private IReader<InsuranceMap> Csv { get; set; }

        public MapperIndexTestingNoHeaders()
        {
            Csv = new CsvReader<InsuranceMap>(@"Resources", "FL_insurance_CSV_SAMPLE_no_headers.csv",false);
            Csv.Map(16, a => a.Material);
            Csv.Configuration.SetDelimiter(';');
        }

        [TestMethod]
        public void BasicMapperPropertyUsageNoHeaders()
        {
            var mapper = new CsvReaderMapper<InsuranceMap>();
            mapper.Add(16, a => a.Material);
            Assert.AreEqual(1, mapper.Get().Count);
        }

        [TestMethod]
        public void ConvertToClassWithMapperProppertyNoHeaders()
        {
            Assert.AreEqual(2, Csv.Read(a => a[16] == "Reinforced Concrete" && a[2] == "NASSAU COUNTY").Where(b => !string.IsNullOrWhiteSpace(b.Material)).Count());
        }

    }
}
