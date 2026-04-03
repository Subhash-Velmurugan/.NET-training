using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    internal class swap
    {
        public static string SwapFirstAndLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }

            char[] chars = str.ToCharArray();
            char temp = chars[0];
            chars[0] = chars[chars.Length - 1];
            chars[chars.Length - 1] = temp;

            return new string(chars);
        }
        public static void run()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();
            string result = SwapFirstAndLast(input);
            Console.WriteLine("String after swapping first and last characters: " + result);
        }   
    }
}
