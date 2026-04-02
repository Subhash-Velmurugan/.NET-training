using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge1
{
    internal class Emp
    {
        public struct Date
        {
            public int Day;
            public int Month;
            public int Year;
        }
        public struct emp
        {
            public string Name;
            public Date Dob;
            public void Get()
            {
                Console.Write("Name of the employee: ");
                Name = Console.ReadLine();
                Console.Write("Input day of birth: ");
                Dob.Day = int.Parse(Console.ReadLine());
                Console.Write("Input month of birth: ");
                Dob.Month = int.Parse(Console.ReadLine());
                Console.Write("Input year of birth: ");
                Dob.Year = int.Parse(Console.ReadLine());
            }
            public void Display()
            {
                Console.WriteLine("\nName: " + Name);
                Console.WriteLine("Date of Birth: " +
                    Dob.Day + "/" + Dob.Month + "/" + Dob.Year);
            }
        }
    }
}
