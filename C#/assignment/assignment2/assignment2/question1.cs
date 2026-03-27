using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class question1
    {
        public static void printn()
        {
            Console.WriteLine("Enter a digit");
            string s=Console.ReadLine();
            for(int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}", s);
                Console.WriteLine("{0}{0}{0}{0}", s);
            }
        }
    }
}
