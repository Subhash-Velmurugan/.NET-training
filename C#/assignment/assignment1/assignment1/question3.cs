using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class question3
    {
        public static void run()
        {
            Console.WriteLine("enter x:");
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter operator {+,-,*,/}");
            char op=char.Parse(Console.ReadLine());
            Console.WriteLine("Enter y:");
            int y=int.Parse(Console.ReadLine());
            Arithmetic(x, op, y);
        }
        static void Arithmetic(int x, char op, int y)
        {
            if (op == '+') Console.WriteLine($"{x + y}");
            else if (op == '-') Console.WriteLine($"{0} {1} "=" {2}"{x - y}");
            else if (op == '*') Console.WriteLine($"{x * y}");
            else Console.WriteLine($"{x / y}");
        }
    }
}
