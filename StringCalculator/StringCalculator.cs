﻿using System;
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

            List<string> list;

            if (numbers.StartsWith("//"))
            {
                List<string> delimitersAndNumbers = new List<string>(numbers.Split('\n'));
                var delimeter = RemoveSlashes(delimitersAndNumbers[0]);
                if (delimeter.Equals('\n'))
                {
                    delimitersAndNumbers.RemoveAt(0);
                    delimitersAndNumbers.RemoveAt(0);
                    list = delimitersAndNumbers;
                }
                else
                {
                    list = new List<string>(SplitStringByDelimiter(delimitersAndNumbers[1], delimeter));
                }
            }
            else
            {
                list = new List<string>(numbers.Split(','));
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

        public string[] SplitStringByDelimiter(string input, char delimeter)
        {
            return input.Split(delimeter);
        }

        public char RemoveSlashes(string input)
        {
            var stringWithoutSlashes = input.Replace("//", "");
            return stringWithoutSlashes.Equals("") ? '\n' : char.Parse(stringWithoutSlashes);
        }
    }
}
