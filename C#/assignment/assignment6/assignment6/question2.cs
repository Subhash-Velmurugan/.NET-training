using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    

namespace assignment6
{
    public class FileHandler
    {
        private string filePath;
        public FileHandler(string path)
        {
            filePath = path;
        }
        public void WriteToFile(string[] lines)
        {
            try
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Data written to file successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Write Error: " + e.Message);
            }
        }
        public void ReadFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    Console.WriteLine("\nReading data from file:\n");

                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Read Error: " + e.Message);
            }
        }
        public static void Main(string[] args)
        {
            string path = "C:/Training/.NET training/C#/assignment/assignment6/sample.txt.txt";

            string[] data = {
            "Hello World",
            "Welcome to C#",
            "Separate Class Example",
            "File Handling"
        };

            FileHandler handler = new FileHandler(path);

            handler.WriteToFile(data);
            handler.ReadFromFile();
        }
    }
}
