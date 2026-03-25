using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class question4
    {
        public static void run()
        {
            Console.WriteLine("Enter num:");
            int x=int.Parse(Console.ReadLine());
            multiplicationtable(x);
        }
        static void multiplicationtable(int x)
        {
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{x} * {i} ={x * i}");
            }
            
        }
    }
}
