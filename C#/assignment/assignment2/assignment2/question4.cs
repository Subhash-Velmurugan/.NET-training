using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class question4
    {
        public static void array_details()
        {
            const int SIZE = 10;
            int[] marks = new int[SIZE];
            int sum = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            Console.WriteLine("Enter 10 marks:");
            for (int i = 0; i < SIZE; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());

                sum += marks[i];

                if (marks[i] < min)
                    min = marks[i];

                if (marks[i] > max)
                    max = marks[i];
            }
            double average = (double)sum / SIZE;
            Array.Sort(marks);
            Console.WriteLine("Total Marks   : " + sum);
            Console.WriteLine("Average Marks : " + average);
            Console.WriteLine("Minimum Marks : " + min);
            Console.WriteLine("Maximum Marks : " + max);
            Console.WriteLine("\nMarks in Ascending Order:");
            foreach (int m in marks)
                Console.Write(m + " ");
            Console.WriteLine("\n\nMarks in Descending Order:");
            for (int i = SIZE - 1; i >= 0; i--)
                Console.Write(marks[i] + " ");
        }
    }
}
