using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingchallenge2
{

    public delegate int CalculatorDelegate(int a, int b);
    public class Calculator
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;
        public static int Divide(int x, int y)
        {
            if (y == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return x / y;
        }
        public static int Calculate(int a, int b, CalculatorDelegate del)
        {
            return del(a, b);
        }
        public static void run()
        {
            try
            {
                Console.Write("Enter first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Calculator Menu");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                int result = 0;
                switch (choice)
                {
                    case 1:
                        result = Calculator.Calculate(num1, num2, Calculator.Add);
                        Console.WriteLine("Addition Result: " + result);
                        break;
                    case 2:
                        result = Calculator.Calculate(num1, num2, Calculator.Subtract);
                        Console.WriteLine("Subtraction Result: " + result);
                        break;
                    case 3:
                        result = Calculator.Calculate(num1, num2, Calculator.Multiply);
                        Console.WriteLine("Multiplication Result: " + result);
                        break;
                    case 4:
                        result = Calculator.Calculate(num1, num2, Calculator.Divide);
                        Console.WriteLine("Division Result: " + result);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadLine();
        }

    }
}
