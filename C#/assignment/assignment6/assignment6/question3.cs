using System;
using System.IO;
namespace assignment6
{
    public class LineCounter
    {
        private string filePath;
        public LineCounter(string path)
        {
            filePath = path;
        }
        public int CountLines()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    return lines.Length;
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return 0;
            }
        }
        static void Main()
        {
            string path = "C:/Training/.NET training/C#/assignment/assignment6/sample.txt.txt";
            LineCounter counter = new LineCounter(path);
            int lineCount = counter.CountLines();
            Console.WriteLine("Number of lines in file: " + lineCount);
        }
    }
}
