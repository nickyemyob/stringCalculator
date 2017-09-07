using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {

        private readonly StringToListParser _stringToListParser;

        public StringCalculator()
        {
            _stringToListParser = new StringToListParser();
        }

        public int Add(string input)
        {
            var count = 0;
            if (string.IsNullOrEmpty(input))
            {
                return count;
            }

            var numbersAsStringList = _stringToListParser.ExtractNumbersToList(input);
            var numbersAsIntList = numbersAsStringList.Select(int.Parse).ToList();
            var negativeNumbers = new List<int>();

            foreach (var number in numbersAsIntList)
            {
                if (number < 0)
                {
                    negativeNumbers.Add(number);
                    continue;
                }
                if (number > 1000)
                {
                    continue;
                }
                count += number;         
            }

            if (!negativeNumbers.Any())
            {
                return count;
            }

            var errorMessage = _stringToListParser.BuildErrorMessage(negativeNumbers);
            throw new ArgumentException(errorMessage);

        }
    }
}
