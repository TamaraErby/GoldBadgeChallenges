using _02_RepositoryClaim;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_UnitTest_Claims
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _claimRepo;
        private Claims _claims;
        private Claims _falseClaims;

        [TestInitialize]
        public void Initialize()
        {
            _claimRepo = new ClaimRepository();
            _claims = new Claims(2, TypeOfClaim.Home, "Water damage in upstairs bathroom", 5000, DateTime.Parse("02/4/2021"), DateTime.Parse("02/06/2021"), true);
            _falseClaims = new Claims(3, TypeOfClaim.Theft, "Stolen phone charger", 5, DateTime.Parse("03/6/2021"), DateTime.Parse("05/6/2021"), false);
        }
        [TestMethod]
        public void TestMethod1()
        {
            Claims content = new Claims(1, TypeOfClaim.Car, "Hail damage", 2500, DateTime.Parse("06/15/2021"), DateTime.Parse("06/17/2021"), true);

            Assert.AreEqual(1, content.ClaimID);
            Assert.AreEqual(TypeOfClaim.Car, content.ClaimType);
            Assert.AreEqual("Hail damage", content.Description);
            Assert.AreEqual(2500, content.Amount);
            Assert.AreEqual(DateTime.Parse("06/15/2021"), content.IncidentDate);
            Assert.AreEqual(DateTime.Parse("06/17/2021"), content.ClaimDate);
            Assert.AreEqual(true, content.IsValid);
        }

        [TestMethod]
        public void AddClaim()
        {
            _claimRepo.AddClaim(_claims);

            int expected = 1;
            int actual = _claimRepo.GetList().Count;

            Assert.AreEqual(actual, expected);
        }

        public void RemoveClaim()
        {
            ClaimRepository content = new ClaimRepository();
        }

        [TestMethod]
        public void IsValid()
        {
            _claimRepo.AddClaim(_claims);

            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsNotValid()
        {
            _claimRepo.AddClaim(_falseClaims);

            bool expected = false;
            bool actual = _falseClaims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetList()
        {
            _claimRepo.GetList();
            Assert.IsNotNull(_claimRepo);
        }
    }
}
