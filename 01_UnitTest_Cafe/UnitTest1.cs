using _01_RepositoryCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_UnitTest_Cafe
{
    [TestClass]
    public class UnitTest1
    {
        private CafeRepository _cafeRepo;
        private Menu _content;

        [TestInitialize]
        public void Initialize()
        {
            _cafeRepo = new CafeRepository();
            _content = new Menu(1, "Hamburger Meal", "Juicy Burger Loaded with all your Fixings", "8 oz Angus Beef Patty with Lettuce, Tomato, Ketchup & Mustard; French Fries; 20 oz Soft Drink", 10.99);
        }
        [TestMethod]
        public void AddItems()
        {
            _cafeRepo.AddItems(_content);

            int expected = 1;
            int actual = _cafeRepo.ListOrders().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItems()
        {
            CafeRepository cafeRepo = new CafeRepository();

            _cafeRepo.AddItems(_content);

            bool wasRemoved = cafeRepo.RemoveItems(_content);
            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Menu neworder = new Menu(5, "Salad Meal", "Made with Fresh Ingredients and Hand-Chopped Daily", "Romaine Lettuce, Eggs, Croutons, Bacon Bits, Cheese & Tomatoes; 20 oz Soft Drink", 5.99);

            Assert.AreEqual(5, neworder.MealNumber);
            Assert.AreEqual("Salad Meal", neworder.MealName);
            Assert.AreEqual("Made with Fresh Ingredients and Hand-Chopped Daily", neworder.Description);
            Assert.AreEqual("Romaine Lettuce, Eggs, Croutons, Bacon Bits, Cheese & Tomatoes; 20 oz Soft Drink", neworder.Ingredients);
            Assert.AreEqual(5.99, neworder.Price);
        }
    }
}
