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
    }
}
