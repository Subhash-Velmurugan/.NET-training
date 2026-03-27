using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class question2
    {

        enum Day
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public static void numtoday()
        {
            Console.Write("Enter day number: ");
            int dayNumber = int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(Day), dayNumber))
            {
                Day day = (Day)dayNumber;
                Console.WriteLine(day);
            }
            else
            {
                Console.WriteLine("Invalid day number");
            }
        }


    }
}
