using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLinqComplete
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{ EmployeeID=1001, FirstName="Malcolm", LastName="Daruwalla", Title="Manager",
                    DOB=new DateTime(1984,11,16), DOJ=new DateTime(2011,6,8), City="Mumbai" },

                new Employee{ EmployeeID=1002, FirstName="Asdin", LastName="Dhalla", Title="AsstManager",
                    DOB=new DateTime(1984,8,20), DOJ=new DateTime(2012,7,7), City="Mumbai" },

                new Employee{ EmployeeID=1003, FirstName="Madhavi", LastName="Oza", Title="Consultant",
                    DOB=new DateTime(1987,11,14), DOJ=new DateTime(2015,4,12), City="Pune" },

                new Employee{ EmployeeID=1004, FirstName="Saba", LastName="Shaikh", Title="SE",
                    DOB=new DateTime(1990,6,3), DOJ=new DateTime(2016,2,2), City="Pune" },

                new Employee{ EmployeeID=1005, FirstName="Nazia", LastName="Shaikh", Title="SE",
                    DOB=new DateTime(1991,3,8), DOJ=new DateTime(2016,2,2), City="Mumbai" },

                new Employee{ EmployeeID=1006, FirstName="Amit", LastName="Pathak", Title="Consultant",
                    DOB=new DateTime(1989,11,7), DOJ=new DateTime(2014,8,8), City="Chennai" },

                new Employee{ EmployeeID=1007, FirstName="Vijay", LastName="Natrajan", Title="Consultant",
                    DOB=new DateTime(1989,12,2), DOJ=new DateTime(2015,6,1), City="Mumbai" },

                new Employee{ EmployeeID=1008, FirstName="Rahul", LastName="Dubey", Title="Associate",
                    DOB=new DateTime(1993,11,11), DOJ=new DateTime(2014,11,6), City="Chennai" },

                new Employee{ EmployeeID=1009, FirstName="Suresh", LastName="Mistry", Title="Associate",
                    DOB=new DateTime(1992,8,12), DOJ=new DateTime(2014,12,3), City="Chennai" },

                new Employee{ EmployeeID=1010, FirstName="Sumit", LastName="Shah", Title="Manager",
                    DOB=new DateTime(1991,4,12), DOJ=new DateTime(2016,1,2), City="Pune" }
            };

            Console.WriteLine("1. Employees joined before 01/01/2015");
            foreach (var e in empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)))
            {
                Console.WriteLine(
                    $"ID: {e.EmployeeID}, " +
                    $"Name: {e.FirstName} {e.LastName}, " +
                    $"Title: {e.Title}, " +
                    $"DOB: {e.DOB.ToShortDateString()}, " +
                    $"DOJ: {e.DOJ.ToShortDateString()}, " +
                    $"City: {e.City}"
                );
            }
            Console.WriteLine();

            Console.WriteLine("2. Employees born after 01/01/1990");
            foreach (var e in empList.Where(e => e.DOB > new DateTime(1990, 1, 1)))
            {
                Console.WriteLine(
                    $"ID: {e.EmployeeID}, " +
                    $"Name: {e.FirstName} {e.LastName}, " +
                    $"Title: {e.Title}, " +
                    $"DOB: {e.DOB.ToShortDateString()}, " +
                    $"DOJ: {e.DOJ.ToShortDateString()}, " +
                    $"City: {e.City}"
                );
            }
            Console.WriteLine();

            Console.WriteLine("3. Employees with designation Consultant or Associate");
            foreach (var e in empList.Where(e => e.Title == "Consultant" || e.Title == "Associate"))
            {
                Console.WriteLine(
                    $"ID: {e.EmployeeID}, " +
                    $"Name: {e.FirstName} {e.LastName}, " +
                    $"Title: {e.Title}, " +
                    $"DOB: {e.DOB.ToShortDateString()}, " +
                    $"DOJ: {e.DOJ.ToShortDateString()}, " +
                    $"City: {e.City}"
                );
            }
            Console.WriteLine();

            Console.WriteLine("4. Total number of employees");
            Console.WriteLine(empList.Count);
            Console.WriteLine();

            Console.WriteLine("5. Total employees in Chennai");
            Console.WriteLine(empList.Count(e => e.City == "Chennai"));
            Console.WriteLine();

            Console.WriteLine("6. Highest Employee ID");
            Console.WriteLine(empList.Max(e => e.EmployeeID));
            Console.WriteLine();

            Console.WriteLine("7. Employees joined after 01/01/2015");
            Console.WriteLine(empList.Count(e => e.DOJ > new DateTime(2015, 1, 1)));
            Console.WriteLine();

            Console.WriteLine("8. Employees whose designation is not Associate");
            Console.WriteLine(empList.Count(e => e.Title != "Associate"));
            Console.WriteLine();

            Console.WriteLine("9. Employees count based on City");
            foreach (var g in empList.GroupBy(e => e.City))
                Console.WriteLine($"{g.Key} : {g.Count()}");
            Console.WriteLine();

            Console.WriteLine("10. Employees count based on City and Title");
            foreach (var g in empList.GroupBy(e => new { e.City, e.Title }))
                Console.WriteLine($"{g.Key.City} - {g.Key.Title} : {g.Count()}");
            Console.WriteLine();

            Console.WriteLine("11. Youngest employee(s)");
            var youngestDOB = empList.Max(e => e.DOB);
            foreach (var e in empList.Where(e => e.DOB == youngestDOB))
            {
                Console.WriteLine(
                    $"ID: {e.EmployeeID}, " +
                    $"Name: {e.FirstName} {e.LastName}, " +
                    $"Title: {e.Title}, " +
                    $"DOB: {e.DOB.ToShortDateString()}, " +
                    $"DOJ: {e.DOJ.ToShortDateString()}, " +
                    $"City: {e.City}"
                );
            }

            Console.ReadLine();
        }
    }
}