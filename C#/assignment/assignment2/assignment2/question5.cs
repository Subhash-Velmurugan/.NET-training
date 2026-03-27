using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class question5
    {

        public static void array_copy()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] sourceArray = new int[n];
            int[] copyArray = new int[n];
            Console.WriteLine("Enter elements of the source array:");
            for (int i = 0; i < n; i++)
            { 
                sourceArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                copyArray[i] = sourceArray[i];
            }

            Console.WriteLine("\nElements of the Copied array:");

            for (int i = 0; i < n; i++)
            {
                Console.Write(copyArray[i] + " ");
            }
        }

    }
}
