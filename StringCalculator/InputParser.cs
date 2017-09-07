using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class InputParser
    {
        private const char DelimitersAndNumbersSeparator = '\n';
        private const string DelimiterHeader = "//";
        private static readonly char[] DefaultDelimiters = { ',', '\n' };

        public IEnumerable<int> ExtractNumbersAsInts(string input)
        {
            IEnumerable<string> numbers;

            if (!input.StartsWith(DelimiterHeader))
            {
                numbers = new List<string>(input.Split(DefaultDelimiters));
            }
            else
            {
                var delimitersAndNumbers = new List<string>(input.Split(DelimitersAndNumbersSeparator));
                var delimiter = ExtractDelimiter(delimitersAndNumbers[0]);
                numbers = ExtractNumbers(delimitersAndNumbers, delimiter);
            }

            return numbers.Select(int.Parse).ToList();
        }

        private static string[] ExtractDelimiter(string stringContainingDelimiter)
        {
            var delimiter = stringContainingDelimiter.Replace(DelimiterHeader, "");

            if (delimiter.Equals(""))
            {
                return new[] { "\n" };
            }

            return ContainsMultipleDelimiters(delimiter) ? ExtractMultipleDelimiters(delimiter) : new[] { delimiter };
        }

        private static string[] ExtractMultipleDelimiters(string multipleDelimiters)
        {
            var tempDelimiter = "";
            var delimiters = new List<string>();
            foreach (var str in multipleDelimiters)
            {
                if (str.Equals('['))
                {
                }
                else if (str.Equals(']'))
                {
                    delimiters.Add(tempDelimiter);
                    tempDelimiter = "";
                }
                else
                {
                    tempDelimiter += str;
                }
            }
            return delimiters.ToArray();
        }

        private static IEnumerable<string> ExtractNumbers(IList<string> delimitersAndNumbers, string[] delimiter)
        {
            if (!delimiter.Contains("\n"))
            {
                return new List<string>(delimitersAndNumbers[1].Split(delimiter, StringSplitOptions.None));
            }

            return RemoveNonNumbers(delimitersAndNumbers);
        }

        private static IEnumerable<string> RemoveNonNumbers(IList<string> delimitersAndNumbers)
        {
            delimitersAndNumbers.RemoveAt(0);
            delimitersAndNumbers.RemoveAt(0);
            return delimitersAndNumbers;
        }

        private static bool ContainsMultipleDelimiters(string delimiter)
        {
            return delimiter.IndexOf("[", StringComparison.Ordinal) > -1 && 
                delimiter.LastIndexOf("]", StringComparison.Ordinal) > -1;
        }
    }
}