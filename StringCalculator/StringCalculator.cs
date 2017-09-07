using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly InputParser _inputParser;
        private const string ErrorMessage = "Negatives not allowed:";

        public StringCalculator(InputParser inputParser)
        {
            _inputParser = inputParser;
        }
        public int Add(string input)
        {
            var count = 0;
            if (string.IsNullOrEmpty(input))
            {
                return count;
            }
            var numbersAsInts = _inputParser.ExtractNumbersAsInts(input);

            var negativeNumbers = new List<int>();

            foreach (var number in numbersAsInts)
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

            var errorMessage = BuildErrorMessage(negativeNumbers);
            throw new ArgumentException(errorMessage);
        }

        private static string BuildErrorMessage(IEnumerable<int> negativeNumbers)
        {
            var errorMessage = ErrorMessage;
            foreach (var number in negativeNumbers)
            {
                errorMessage += " " + number;
            }
            return errorMessage;
        }
    }
}
