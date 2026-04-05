using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class InvalidMarksException : ApplicationException
    {
        public InvalidMarksException(string message) : base(message)
        {
        }
    }
    class Scholarship
    {
        public double Merit(double marks, double fees)
        {
            if (marks >= 70 && marks <= 80)
            {
                return fees * 0.20;
            }
            else if (marks > 80 && marks <= 90)
            {
                return fees * 0.30;
            }
            else if (marks > 90)
            {
                return fees * 0.50;
            }
            else
            {
                throw new InvalidMarksException("Marks not eligible for scholarship.");
            }
        }
    }
}
