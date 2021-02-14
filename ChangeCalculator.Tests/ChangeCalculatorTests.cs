using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChangeCalculator.Tests
{
    [TestClass]
    public class ChangeCalculatorTests
    {
        [TestMethod]
        public void CalculateChangeSuccessWithExampleData()
        {
            var calc = new ChangeCalculator();

            var actual = calc.CalculateChange(20.00m, 5.50m);

            Assert.AreEqual(3, actual.Count);
            Assert.AreEqual(1, actual[10.00m]);
            Assert.AreEqual(2, actual[2.00m]);
            Assert.AreEqual(1, actual[0.50m]);
        }

        [TestMethod]
        public void CalculateChangeSuccessWithMinimumChange()
        {
            var calc = new ChangeCalculator();

            var actual = calc.CalculateChange(0.02m, 0.01m);

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(1, actual[0.01m]);
        }

        [TestMethod]
        public void CalculateChangeSuccessWithAllDenominations()
        {
            var calc = new ChangeCalculator();

            var actual = calc.CalculateChange(88.89m, 0.01m);

            Assert.AreEqual(12, actual.Count);
            Assert.AreEqual(1, actual[0.01m]);
            Assert.AreEqual(1, actual[0.02m]);
            Assert.AreEqual(1, actual[0.05m]);
            Assert.AreEqual(1, actual[0.10m]);
            Assert.AreEqual(1, actual[0.20m]);
            Assert.AreEqual(1, actual[0.50m]);
            Assert.AreEqual(1, actual[1.00m]);
            Assert.AreEqual(1, actual[2.00m]);
            Assert.AreEqual(1, actual[5.00m]);
            Assert.AreEqual(1, actual[10.00m]);
            Assert.AreEqual(1, actual[20.00m]);
            Assert.AreEqual(1, actual[50.00m]);
        }

        [TestMethod]
        public void CalculateChangeFailureMoneyGivenZero()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calc.CalculateChange(0m, 5.50m));
        }

        [TestMethod]
        public void CalculateChangeFailureMoneyGivenNegative()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calc.CalculateChange(-10m, 5.50m));
        }

        [TestMethod]
        public void CalculateChangeFailurePriceZero()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calc.CalculateChange(10m, 0m));
        }

        [TestMethod]
        public void CalculateChangeFailurePriceNegative()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calc.CalculateChange(10m, -10m));
        }

        [TestMethod]
        public void CalculateChangeFailurePriceEqualMoneyGiven()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentException>(() => calc.CalculateChange(10m, 10m));
        }

        [TestMethod]
        public void CalculateChangeFailurePriceGreaterThanMoneyGiven()
        {
            var calc = new ChangeCalculator();

            Assert.ThrowsException<ArgumentException>(() => calc.CalculateChange(10m, 20m));
        }
    }
}
