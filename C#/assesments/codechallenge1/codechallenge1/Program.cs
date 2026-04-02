using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge1
{
    internal class program
    {
        static void Main(string[] args)
        {
            /*int choice;

            do
            {
                Console.WriteLine("Employee Management Systen");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display Employees");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee.Add();
                        break;
                    case 2:
                        Employee.Display();
                        break;
                    case 3:
                        Employee.Search();
                        break;
                    case 4:
                        Employee.Update();
                        break;
                    case 5:
                        Employee.Delete();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 6);*/
            Emp.emp[] emp = new Emp.emp[2];
            for (int i = 0; i < emp.Length; i++)
            {
                Console.WriteLine($"\nEnter details for employee {i + 1}");
                emp[i].Get();
            }
            Console.WriteLine("\n--- Employee Details ---");
            for (int i = 0; i < emp.Length; i++)
            {
                emp[i].Display();
            }
        }
    }
    
}
