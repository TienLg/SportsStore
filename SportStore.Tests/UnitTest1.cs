using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Models;

namespace SportsStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            // act
            var discountedTotal = target.ApplyDiscount(total);

            // assert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            IDiscountHelper target = getTestObject();
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);

            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 discount is wrong");

        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            IDiscountHelper target = getTestObject();

            decimal discount_5 = target.ApplyDiscount(5);
            decimal discount_0 = target.ApplyDiscount(0);

            Assert.AreEqual(5, discount_5);
            Assert.AreEqual(0, discount_0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            IDiscountHelper target = getTestObject();

            target.ApplyDiscount(-1);
        }
    }
}
