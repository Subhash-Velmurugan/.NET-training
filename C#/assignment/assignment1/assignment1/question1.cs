using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class question1
    {
        public static void run()
        {
            Console.WriteLine("Enter num x:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num y:");
            int y = int.Parse(Console.ReadLine());
            isEqual(x, y);
        }
        static void isEqual(int x, int y)
        {
            if (x == y) Console.WriteLine("Equal");
            else Console.WriteLine("Not Equal");
        }
    }
}
