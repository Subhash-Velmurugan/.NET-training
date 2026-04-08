using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingchallenge2
{
    public class number
    {
        public static void CheckNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }
            Console.WriteLine("Valid number entered: " + number);
        }
        public static void run()
        {
            try
            {
                Console.Write("Enter an integer: ");
                int num = int.Parse(Console.ReadLine());
                number.CheckNumber(num);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
            }
            Console.ReadLine();
        }

    }
}
