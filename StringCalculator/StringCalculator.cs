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

            var list = numbers.Split(',');
            foreach (string number in list)
            {
                int numberAsInt = int.Parse(number);
                count += numberAsInt;
            }

            return count;
            
        }
    }
}
