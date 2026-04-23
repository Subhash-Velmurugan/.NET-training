using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingchallenge2
{
    public abstract class student
    {
        public string name { get; set; }
        public int id { get; set; }
        public double grade { get; set; }
        public student(string name, int id, double grade)
        {
            this.name = name;
            this.id = id;
            this.grade = grade;
        }
        public abstract bool ispassed(double grade);
        public static void run()
        {
            undergraduate ug = new undergraduate("Alice", 101, 75.5);
            Console.WriteLine("Undergraduate Student:");
            Console.WriteLine($"Name: {ug.name}, ID: {ug.id}, Grade: {ug.grade}");
            Console.WriteLine($"Passed: {ug.ispassed(ug.grade)}");
            Console.WriteLine();
            graduate grad = new graduate("Bob", 201, 78.0);
            Console.WriteLine("Graduate Student:");
            Console.WriteLine($"Name: {grad.name}, ID: {grad.id}, Grade: {grad.grade}");
            Console.WriteLine($"Passed: {grad.ispassed(grad.grade)}");
        }
    }
    public class undergraduate : student
    {
        public undergraduate(string name, int id, double grade) : base(name, id, grade)
        {
        }
        public override bool ispassed(double grade)
        {
            return grade > 70.0;
        }
    }
    public class graduate : student
    {
        public graduate(string name, int id, double grade) : base(name, id, grade)
        {
        }
        public override bool ispassed(double grade)
        {
            return grade > 80.0;
        }
        
    } 
  }


    
 
