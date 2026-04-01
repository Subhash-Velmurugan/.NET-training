using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    internal class Program
    {
        static void Main()
        {
            /*Accounts acc = new Accounts(101, "John", "Savings", 1000);
            Console.Write("Enter Transaction Type (D/W): ");
            char type = Convert.ToChar(Console.ReadLine());
            Console.Write("Enter Amount: ");
            double amt = Convert.ToDouble(Console.ReadLine());
            acc.ProcessTransaction(type, amt);
            acc.ShowData();*/
            /*Student s1 = new Student(1, "John", "BCA", 3, "Computer Science");
            s1.GetMarks();
            s1.DisplayData();
            s1.DisplayResult();*/
            SaleDetails s1 = new SaleDetails(101, 5001, 250.5, 4, DateTime.Now);
            s1.Sales();
            SaleDetails.ShowData(s1);
        }
    }
}
