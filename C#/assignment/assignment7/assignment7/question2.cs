using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment7
{
    internal class question2
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Enter words separated by comma");
            string input = Console.ReadLine();
            List<string> words = input.Split(',').Select(n => n.Trim()).ToList();
            var result =
                from word in words
                where word.StartsWith("a") && word.EndsWith("m")
                select word;
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }

        }
    }
}
