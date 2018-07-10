using System;
using System.Collections.Generic;
using System.Text;
using CSV.Map.Writer;
using CSV.Test.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSV.Test.Tests.MapperTest
{
    [TestClass]
    public class WritterMapperTesting
    {
        public CsvWriterMapper<InsuranceMap> _insuranceMapper;

        public WritterMapperTesting()
        {
            _insuranceMapper =  new CsvWriterMapper<InsuranceMap>();
        }

        [TestMethod]
        public void MapperBasedOnField()
        {
            _insuranceMapper.Add(a => a.County);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MapperBasedOnFieldVisibility()
        {
            _insuranceMapper.Add(a => a.EqSiteLimit, false);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void MapperBasedOnFiedlHeaderName()
        {
            _insuranceMapper.Add(a => a.EqSiteLimit, "Limit");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MapperBasedOnFiedlHeaderNameVisibility()
        {
            _insuranceMapper.Add(a => a.PolicyId, "Policy", true);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MapperBasedoinFieldPositionVisible()
        {
            _insuranceMapper.Add(a => a.County, 1, false);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MapperBasedoinFieldPosition()
        {
            _insuranceMapper.Add(a => a.Material, 1);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void MapperBasedoinFieldPositionHeaderVisible()
        {
            _insuranceMapper.Add(a => a.County, 1,"noExist", true);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetMaping()
        {
            _insuranceMapper = new CsvWriterMapper<InsuranceMap>();
            _insuranceMapper.Add(a => a.EqSiteLimit, 1, "noExist", true);
            Assert.AreEqual(_insuranceMapper.Get().Count, 1);
        }

        [TestMethod]
        public void CreateMapFromList()
        {
            List<IWriterMap<InsuranceMap>> listmap = new List<IWriterMap<InsuranceMap>>();
            var map1 = new WriteMap<InsuranceMap>(a => a.PolicyId, 0, "policy", true);
            var map2 = new WriteMap<InsuranceMap>(a=>a.County,1,"country",false);
            listmap.Add(map1);
            listmap.Add(map2);
            _insuranceMapper = new CsvWriterMapper<InsuranceMap>();
            _insuranceMapper.SetMap(listmap);
        }
    }
}
