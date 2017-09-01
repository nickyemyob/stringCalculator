using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class ArrayExtensions
    {
        public static string[] SubStringArray(this string[] data, int index, int length)
        {
            string[] result = new string[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
