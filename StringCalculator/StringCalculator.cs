using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const char DelimitersAndNumbersSeparator = '\n';
        private const string DelimiterHeader = "//";
        private static readonly char[] DefaultDelimiters = {',', '\n'};

        public int Add(string numbers)
        {
            var count = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return count;
            }

            var list = ExtractNumbersToList(numbers);

            var negativeNumbers = new List<int>();

            foreach (var number in list)
            {
                var numberAsInt = int.Parse(number);
                if (numberAsInt < 0)
                {
                    negativeNumbers.Add(numberAsInt);
                }
                else
                {
                    count += numberAsInt;
                }          
            }

            if (!negativeNumbers.Any())
            {
                return count;
            }

            var errorMessage = "Negatives not allowed:";
            foreach (var number in negativeNumbers)
            {
                errorMessage += " " + number;
            }
            throw new ArgumentException(errorMessage);

        }

        private IEnumerable<string> ExtractNumbersToList(string numbers)
        {
            if (!ContainsCustomDelimiter(numbers))
            {
                return new List<string>(numbers.Split(DefaultDelimiters));
            }

            var delimitersAndNumbers = new List<string>(numbers.Split(DelimitersAndNumbersSeparator));
            var delimeter = GetDelimiter(delimitersAndNumbers[0]);

            if (!delimeter.Equals('\n'))
            {
                return new List<string>(delimitersAndNumbers[1].Split(delimeter));
            }

            delimitersAndNumbers.RemoveAt(0);
            delimitersAndNumbers.RemoveAt(0);
            return delimitersAndNumbers;
        }

        public char GetDelimiter(string stringContainingDelimiter)
        {
            var stringWithoutSlashes = stringContainingDelimiter.Replace("//", "");
            return stringWithoutSlashes.Equals("") ? '\n' : char.Parse(stringWithoutSlashes);
        }

        private bool ContainsCustomDelimiter(string input)
        {
            return input.StartsWith(DelimiterHeader);
        }
    }
}
