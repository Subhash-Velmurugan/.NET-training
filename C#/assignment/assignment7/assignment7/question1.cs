using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment7
{
    internal class question1
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers separated by comma");
            string input = Console.ReadLine();

            List<int> numbers = input
                .Split(',')
                .Select(n => int.Parse(n.Trim()))
                .ToList();

            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
        }
    }
}
