﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
            new object[] {4800, "1,22,333,4444"}
        };

        [Test, TestCaseSource(nameof(AddCases))]
        public void AddStrings(int expected, string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();
            var result = stringCalculator.Add(numbers);
            Assert.AreEqual(expected, result);
        }
        
    }
}
