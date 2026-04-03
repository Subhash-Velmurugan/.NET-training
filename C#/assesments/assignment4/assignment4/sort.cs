using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    internal class sort
    {
        public static Stack<int> SortStackDescending(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();
            while (stack.Count > 0)
            {
                int current = stack.Pop();
                while (tempStack.Count > 0 && tempStack.Peek() < current)
                {
                    stack.Push(tempStack.Pop());
                }
                tempStack.Push(current);
            }
            return tempStack;
        }
        public static void run()
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Enter the number of elements for the stack:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());
                stack.Push(element);
            }
            Console.WriteLine("\nOriginal Stack:");
            PrintStack(stack);
            Stack<int> sortedStack = sort.SortStackDescending(stack);
            Console.WriteLine("\nStack after sorting in descending order:");
            PrintStack(sortedStack);
        }
        static void PrintStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>(stack);
            while (temp.Count > 0)
            {
                Console.WriteLine(temp.Pop());
            }
        }
    }
}
