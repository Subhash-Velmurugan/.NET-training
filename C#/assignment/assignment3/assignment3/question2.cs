using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    using System;

    internal class Student
    {
        int rollno;
        string name;
        string studentClass;
        int semester;
        string branch;
        int[] marks = new int[5];
        public Student(int rollno, string name, string studentClass, int semester, string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Subject " + (i + 1) + ": ");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int total = 0;
            bool isFailed = false;

            for (int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    isFailed = true;
                }
                total += marks[i];
            }

            double average = total / 5.0;

            Console.WriteLine("Average Marks: " + average);

            if (isFailed)
            {
                Console.WriteLine("Result: Failed (One or more subjects < 35)");
            }
            else if (average < 50)
            {
                Console.WriteLine("Result: Failed (Average < 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }
        public void DisplayData()
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine("Roll No: " + rollno);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Class: " + studentClass);
            Console.WriteLine("Semester: " + semester);
            Console.WriteLine("Branch: " + branch);

            Console.WriteLine("Marks:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Subject " + (i + 1) + ": " + marks[i]);
            }
        }
    }
}
