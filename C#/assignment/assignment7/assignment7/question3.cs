using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment7
{

    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public decimal EmpSalary { get; set; }

        static void AddEmployee(List<Employee> employees, int id, string name, string city, decimal salary)
        {
            employees.Add(new Employee
            {
                EmpId = id,
                EmpName = name,
                EmpCity = city,
                EmpSalary = salary
            });
        }
    }
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee { EmpId = 1, EmpName = "Arjun", EmpCity = "Bangalore", EmpSalary = 55000 },
            new Employee { EmpId = 2, EmpName = "Meera", EmpCity = "Chennai", EmpSalary = 42000 },
            new Employee { EmpId = 3, EmpName = "Ravi", EmpCity = "Bangalore", EmpSalary = 48000 },
            new Employee { EmpId = 4, EmpName = "Suman", EmpCity = "Hyderabad", EmpSalary = 60000 }
        };
            Console.WriteLine("All Employees:");
            DisplayEmployees(employees);
            Console.WriteLine("\nEmployees with Salary > 45000:");
            DisplayEmployees(employees.Where(e => e.EmpSalary > 45000));
            Console.WriteLine("\nEmployees from Bangalore:");
            DisplayEmployees(employees.Where(e => e.EmpCity == "Bangalore"));
            Console.WriteLine("\nEmployees Sorted by Name (Ascending):");
            DisplayEmployees(employees.OrderBy(e => e.EmpName));
            Console.ReadLine();
        }
        static void DisplayEmployees(IEnumerable<Employee> employeeList)
        {
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"{emp.EmpId} | {emp.EmpName} | {emp.EmpCity} | {emp.EmpSalary}");
            }
        }
    }
}
