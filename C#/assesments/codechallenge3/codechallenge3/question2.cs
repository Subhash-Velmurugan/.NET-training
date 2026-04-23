using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace codechallenge3
{
    internal class question2
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter file name: ");
            string filePath = Console.ReadLine();
            Console.Write("Enter text to append to the file: ");
            string text = Console.ReadLine();
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(text);
                }
                Console.WriteLine("Text appended to the file successfully.");
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
