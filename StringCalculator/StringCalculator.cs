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
        private const string ErrorMessage = "Negatives not allowed:";
        private static readonly char[] DefaultDelimiters = {',', '\n'};

        public int Add(string input)
        {
            var count = 0;
            if (string.IsNullOrEmpty(input))
            {
                return count;
            }

            var numbersAsStringList = ExtractNumbersToList(input);
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

            var errorMessage = BuildErrorMessage(negativeNumbers);
            throw new ArgumentException(errorMessage);

        }

        private IEnumerable<string> ExtractNumbersToList(string numbers)
        {
            if (!ContainsCustomDelimiter(numbers))
            {
                return new List<string>(numbers.Split(DefaultDelimiters));
            }

            var delimitersAndNumbers = new List<string>(numbers.Split(DelimitersAndNumbersSeparator));
            var delimiter = ExtractDelimiter(delimitersAndNumbers[0]);

            return ExtractNumbers(delimitersAndNumbers, delimiter);
        }

        private string ExtractDelimiter(string stringContainingDelimiter)
        {
            var delimiter = stringContainingDelimiter.Replace(DelimiterHeader, "");
            if (delimiter.Equals(""))
            {
                return "\n";
            }
            var firstBracketIndex = delimiter.IndexOf("[", StringComparison.Ordinal);
            var lastBracketIndex = delimiter.LastIndexOf("]", StringComparison.Ordinal);
            if (firstBracketIndex <= -1 || lastBracketIndex <= -1)
            {
                return delimiter;
            }
            var length = lastBracketIndex - firstBracketIndex - 1;
            return delimiter.Substring(firstBracketIndex + 1, length);
        }

        private static IEnumerable<string> ExtractNumbers(IList<string> delimitersAndNumbers, string delimiter)
        {
             if (!delimiter.Equals("\n"))
            {
                return new List<string>(delimitersAndNumbers[1].Split(new [] { delimiter }, StringSplitOptions.None));
            }

            delimitersAndNumbers.RemoveAt(0);
            delimitersAndNumbers.RemoveAt(0);
            return delimitersAndNumbers;
        }

        private static bool ContainsCustomDelimiter(string input)
        {
            return input.StartsWith(DelimiterHeader);
        }

        private string BuildErrorMessage(IEnumerable<int> negativeNumbers)
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
