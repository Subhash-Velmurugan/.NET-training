using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge4.question3
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1001,
                    FirstName = "Malcolm",
                    LastName = "Daruwalla",
                    Title = "Manager",
                    DOB = new DateTime(1984, 11, 16),
                    DOJ = new DateTime(2011, 6, 8),
                    City = "Mumbai"
                },

                new Employee
                {
                    EmployeeID = 1002,
                    FirstName = "Asdin",
                    LastName = "Dhalla",
                    Title = "AsstManager",
                    DOB = new DateTime(1984, 8, 20),
                    DOJ = new DateTime(2012, 7, 7),
                    City = "Mumbai"
                },

                new Employee
                {
                    EmployeeID = 1003,
                    FirstName = "Madhavi",
                    LastName = "Oza",
                    Title = "Consultant",
                    DOB = new DateTime(1987, 11, 14),
                    DOJ = new DateTime(2015, 4, 12),
                    City = "Pune"
                },

                new Employee
                {
                    EmployeeID = 1004,
                    FirstName = "Saba",
                    LastName = "Shaikh",
                    Title = "SE",
                    DOB = new DateTime(1990, 6, 3),
                    DOJ = new DateTime(2016, 2, 2),
                    City = "Pune"
                },

                new Employee
                {
                    EmployeeID = 1005,
                    FirstName = "Nazia",
                    LastName = "Shaikh",
                    Title = "SE",
                    DOB = new DateTime(1991, 3, 8),
                    DOJ = new DateTime(2016, 2, 2),
                    City = "Mumbai"
                },

                new Employee
                {
                    EmployeeID = 1006,
                    FirstName = "Amit",
                    LastName = "Pathak",
                    Title = "Consultant",
                    DOB = new DateTime(1989, 11, 7),
                    DOJ = new DateTime(2014, 8, 8),
                    City = "Chennai"
                },

                new Employee
                {
                    EmployeeID = 1007,
                    FirstName = "Vijay",
                    LastName = "Natrajan",
                    Title = "Consultant",
                    DOB = new DateTime(1989, 12, 2),
                    DOJ = new DateTime(2015, 6, 1),
                    City = "Mumbai"
                },

                new Employee
                {
                    EmployeeID = 1008,
                    FirstName = "Rahul",
                    LastName = "Dubey",
                    Title = "Associate",
                    DOB = new DateTime(1993, 11, 11),
                    DOJ = new DateTime(2014, 11, 6),
                    City = "Chennai"
                },

                new Employee
                {
                    EmployeeID = 1009,
                    FirstName = "Suresh",
                    LastName = "Mistry",
                    Title = "Associate",
                    DOB = new DateTime(1992, 8, 12),
                    DOJ = new DateTime(2014, 12, 3),
                    City = "Chennai"
                },

                new Employee
                {
                    EmployeeID = 1010,
                    FirstName = "Sumit",
                    LastName = "Shah",
                    Title = "Manager",
                    DOB = new DateTime(1991, 4, 12),
                    DOJ = new DateTime(2016, 1, 2),
                    City = "Pune"
                }
            };

            int choice;
            do
            {
                Console.WriteLine("\n===== EMPLOYEE LINQ MENU =====");
                Console.WriteLine("1. Display all employees");
                Console.WriteLine("2. Employees not in Mumbai");
                Console.WriteLine("3. Employees with title AsstManager");
                Console.WriteLine("4. Employees whose last name starts with 'S'");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Display(empList);
                        break;

                    case 2:
                        Display(empList.Where(e => e.City != "Mumbai"));
                        break;

                    case 3:
                        Display(empList.Where(e => e.Title == "AsstManager"));
                        break;

                    case 4:
                        Display(empList.Where(e => e.LastName.StartsWith("S")));
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

            } while (choice != 0);
        }
        static void Display(IEnumerable<Employee> employees)
        {
            Console.WriteLine("\nID | Name | Title | DOB | DOJ | City");
            foreach (var e in employees)
            {
                Console.WriteLine(
                    $"{e.EmployeeID} | {e.FirstName} {e.LastName} | {e.Title} | " +
                    $"{e.DOB.ToShortDateString()} | {e.DOJ.ToShortDateString()} | {e.City}");
            }
        }

    }
}


        

