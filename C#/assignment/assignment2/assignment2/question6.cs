using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class question6
    { 
    public static void str()
        { 
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();
            Console.WriteLine("Length of the word: " + word.Length);
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversedWord = new string(charArray);
            Console.WriteLine("Reversed word: " + reversedWord);
            Console.Write("\nEnter str1: ");
            string word1 = Console.ReadLine();
            Console.Write("Enter str2: ");
            string word2 = Console.ReadLine();

            if (word1.Equals(word2))
            {
                Console.WriteLine("same.");
            }
            else
            {
                Console.WriteLine("different.");
            }
        }
    }

}
