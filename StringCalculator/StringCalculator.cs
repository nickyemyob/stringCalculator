using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;

namespace StringCalculator
{
    class StringCalculator
    {
        public int Add(string numbers)
        {
            int count = 0;
            if (String.IsNullOrEmpty(numbers))
            {
                return count;
            }

            var delimeter = getDelimeter(numbers);
            var numbersArray = getNumbers(numbers);

            var list = numbers.Split(delimeter);

            foreach (string number in list)
            {
                var numbersSplitByNewLine = number.Split('\n');
                foreach (string number2 in numbersSplitByNewLine)
                {
                    int numberAsInt = int.Parse(number2);
                    count += numberAsInt;
                }
            }

            return count;
            
        }

        private char getDelimeter(string numbers)
        {
            var delimitersAndNumbers = numbers.Split('\n');
            var delimiter = delimitersAndNumbers[1];
            if (delimiter.Equals(""))
            {
                delimiter = "\n";
            }
            return Char.Parse(delimiter);
        }

        private string[] getNumbers(string numbersString)
        {
            var delimitersAndNumbers = numbersString.Split('\n');
            var numbers = delimitersAndNumbers.SubStringArray(2, numbersString.Length);
            return numbers;
        }
    }
}
