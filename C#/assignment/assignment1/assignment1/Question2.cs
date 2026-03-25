using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Question2
    {
        public static void run()
        {
            Console.WriteLine("Enter x");
            int x=int.Parse(Console.ReadLine());
            negativeorpositive(x);
        }
       static void negativeorpositive(int x)
        {
            if (x > 0) Console.WriteLine("Positive");
            else if (x < 0) Console.WriteLine("Negative");
            else Console.WriteLine("Zero");
        }
    }
}
