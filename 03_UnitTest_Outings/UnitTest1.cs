using _03_RepositoryOutings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _03_UnitTest_Outings
{
    [TestClass]
    public class UnitTest1
    {
        private OutingRepository _outingRepo = new OutingRepository();
        [TestMethod]
        public void AddOuting()
        {
            Outing Wham = new Outing(TypeOfOuting.Concert, 50, new DateTime(1985, 04, 02), 25d, 1250d);

            _outingRepo.AddOuting(Wham);
            int count = _outingRepo.GetList().Count;

            Assert.AreEqual(1, count);
        }

        [TestMethod]

        public void TotalCost()
        {
            _outingRepo.SeedOuting();
            Outing Bowling = new Outing(TypeOfOuting.Bowling, 15, new DateTime(2018, 04, 02), 8d, 120d);

            _outingRepo.AddOuting(Bowling);
            double totalCost = _outingRepo.TotalCost();

            Assert.AreEqual(120d, totalCost);
        }

        public void CostByType()
        {
            _outingRepo.SeedOuting();
            Outing CedarPoint = new Outing(TypeOfOuting.AmusementPark, 25, new DateTime(2019, 07, 04), 30d, 750d);

            _outingRepo.AddOuting(CedarPoint);
            double totalCost = _outingRepo.CostByType(TypeOfOuting.AmusementPark);

            Assert.AreEqual(750d, totalCost);
        }
    }
}
