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
            new object[] {3, "//.\n1.2"},
            new object[] {7, "//\n\n3\n4"},
        };

        [Test, TestCaseSource(nameof(AddCases))]
        public void AddStrings(int expected, string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ThrowExceptionWhenGivenNegativeNumber()
        {
            StringCalculator stringCalculator = new StringCalculator();
            Assert.Throws<ArgumentException>(() => stringCalculator.Add("-1,-2"));

            Assert.That(() => stringCalculator.Add("-1,-2"),Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Negatives not allowed: -1 -2"));
        }
    }
}
