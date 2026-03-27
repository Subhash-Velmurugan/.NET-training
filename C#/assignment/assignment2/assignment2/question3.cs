using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class question3
    {

        public static void avg_min_max()
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            int min = arr[0];
            int max = arr[0];

            for (int i = 0; i < n; i++)
            {
                sum += arr[i];

                if (arr[i] < min)
                    min = arr[i];

                if (arr[i] > max)
                    max = arr[i];
            }

            double average = (double)sum / n;
            Console.WriteLine("Average value: " + average);
            Console.WriteLine("Minimum value: " + min);
            Console.WriteLine("Maximum value: " + max);
        }

    }
}
