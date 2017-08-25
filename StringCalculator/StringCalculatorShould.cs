using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator
{
    [TestClass]
    public class StringCalculatorShould
    {
        [TestMethod]
        public void Return0WithEmptyString()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Return0WhenStringIsNull()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Return1WhenStringIs1()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }
    }
}
