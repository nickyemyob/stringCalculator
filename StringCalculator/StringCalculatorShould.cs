using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private static readonly object[] AddCases =
        {
            new object[] {0, ""},
            new object[] {0, null},
            new object[] {1, "1"},
            new object[] {3, "1,2"},
            new object[] {4800, "1,22,333,4444"},
            new object[] {2, "1\n1"},
            new object[] {6, "1\n2,3"},
            new object[] {3, "//.\n1.2"}
        };

        [Test, TestCaseSource(nameof(AddCases))]
        public void AddStrings(int expected, string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ReturnCommaWhenDelimterIsAComma()
        {
            StringCalculator stringCalculator = new StringCalculator();
            var result = stringCalculator.GetDelimiter("//,");
            Assert.AreEqual(',', result);
        }

        [Test]
        public void ReturnAnArrayOfOneAndTwoWhen()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string[] expectedResult = new string[]{"1", "2"};

            var result = stringCalculator.GetNumbers("1,2", ',');
            CollectionAssert.AreEqual(expectedResult, result);
        }

    }
}
