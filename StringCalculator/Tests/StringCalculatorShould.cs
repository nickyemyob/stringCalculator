﻿using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private static readonly object[] SpecialCases =
        {
            new object[] {0, ""},
            new object[] {0, null},
            new object[] {2, "//.\n2.1001"}
        };

        private static readonly object[] DefaultDelimiterCases =
        {
            new object[] {1, "1"},
            new object[] {3, "1,2"},
            new object[] {356, "1,22,333,4444"},
            new object[] {2, "1\n1"},
            new object[] {6, "1\n2,3"}
        };

        private static readonly object[] SingleCustomDelimiterCases =
        {
            new object[] {3, "//.\n1.2"},
            new object[] {7, "//\n\n3\n4"},
            new object[] {1002, "//.\n2.1000"},
            new object[] {6, "//]\n1]2]3"}
        };

        private static readonly object[] MultipleCustomDelimiterCases =
        {
            new object[] {6, "//[***]\n1***2***3"},
            new object[] {6, "//[*][%]\n1*2%3"},
            new object[] {6, "//[*!][!@]\n1*!2!@3"}
        };

        [Test]
        [TestCaseSource(nameof(DefaultDelimiterCases))]
        [TestCaseSource(nameof(SingleCustomDelimiterCases))]
        [TestCaseSource(nameof(MultipleCustomDelimiterCases))]
        [TestCaseSource(nameof(SpecialCases))]
        public void AddStrings(int expected, string numbers)
        {
            var stringCalculator = new StringCalculator(new InputParser());
            var result = stringCalculator.Add(numbers);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ThrowExceptionWhenGivenANegativeNumber()
        {
            var stringCalculator = new StringCalculator(new InputParser());
            Assert.Throws<ArgumentException>(() => stringCalculator.Add("-1,-2"));
            Assert.That(() => stringCalculator.Add("-1,-2"),Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Negatives not allowed: -1 -2"));
        }
    }
}
