using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public class remove_char_from_pos
    {
        public static string RemoveCharAtPosition(string str, int pos)
        {
            if (pos < 0 || pos >= str.Length)
            {
                return str;
            }
            return str.Remove(pos, 1);
        }
        public static void run()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the position of the character to remove:");
            int position = int.Parse(Console.ReadLine());
            string result = RemoveCharAtPosition(input, position);
            Console.WriteLine("String after removing character at position " + position + ": " + result);


        }
    }
}
