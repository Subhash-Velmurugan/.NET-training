using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class question5
    {
        public static void run()
        {
            Console.WriteLine("Enter x:");
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter y:");
            int y = int.Parse(Console.ReadLine());
            addortriple(x,y);
        }
        static void addortriple(int x,int y)
        {
            if (x == y) Console.WriteLine($"{3 * (x + y)}");
            else Console.WriteLine($"{x + y}");
        }
    }
}
