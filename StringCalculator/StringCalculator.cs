using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            string[] list;

            if (numbers.StartsWith("//"))
            {
                var delimitersAndNumbers = numbers.Split('\n');
                var delimeter = GetDelimiter(delimitersAndNumbers[0]);
                list = GetNumbers(delimitersAndNumbers[1], delimeter);
            }
            else
            {
                list = numbers.Split(',');
            }

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

        public string[] GetNumbers(string input, char delimeter)
        {
            return input.Split(delimeter);
        }

        public char GetDelimiter(string input)
        {
            return Char.Parse(input.Substring(2));
        }
    }
}
