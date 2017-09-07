using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        private string[] ExtractDelimiter(string stringContainingDelimiter)
        {
            var delimiter = stringContainingDelimiter.Replace(DelimiterHeader, "");
            if (delimiter.Equals(""))
            {
                return new [] { "\n" };
            }
            var firstBracketIndex = delimiter.IndexOf("[", StringComparison.Ordinal);
            var lastBracketIndex = delimiter.LastIndexOf("]", StringComparison.Ordinal);
            if (firstBracketIndex <= -1 || lastBracketIndex <= -1)
            {
                return new[] {delimiter};
            }

            return ExtractMultipleDelimiters(delimiter);
           
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
