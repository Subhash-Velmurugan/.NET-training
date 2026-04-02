using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codechallenge1
{
    class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string dept {  get; set; }
        public double salary { get; set; }
        private static List<Employee> employees = new List<Employee>();
        public Employee(int id, string name, string dept, double salary)
        {
            this.id = id;
            this.Name = name;
            this.dept = dept;
            this.salary = salary;
        }
        public static void Add()
        {
            Console.Write("Enter ID:");
            int id =int.Parse(Console.ReadLine());
            Console.Write("Enter name:");
            String name = Console.ReadLine();
            Console.Write("Enter dept:");
            string dept= Console.ReadLine();
            Console.Write("Enter salary:");
            double salary=double.Parse(Console.ReadLine());
            Employee emp = new Employee(id, name, dept, salary);
            employees.Add(emp);
            Console.WriteLine("Employee added successfully");
        }
        public static void Display() { 
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found");
                return;
            }
            Console.WriteLine("Employee List");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Id:{emp.id},Name:{emp.Name},Dept:{emp.dept},Salary:{emp.salary}");
            }
        }
        public static void Search()
        {
            Console.Write("Enter ID to search: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.FirstOrDefault(e => e.id == id);

            if (emp != null)
            {
                Console.WriteLine($"Found: ID: {emp.id}, Name: {emp.Name}, Dept: {emp.dept}, Salary: {emp.salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        public static void Update()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.id == id);

            if (emp != null)
            {
                Console.Write("Enter new Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter new Department: ");
                emp.dept = Console.ReadLine();

                Console.Write("Enter new Salary: ");
                emp.salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Employee updated successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
        public static void Delete()
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var emp = employees.Find(e => e.id == id);

            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

    }
}
