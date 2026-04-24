using System;

namespace testclass
{
    public class Distance
    {
        public int Kilometer;

        public Distance(int km)
        {
            Kilometer = km;
        }

        public static Distance Add(Distance d1, Distance d2)
        {
            return new Distance(d1.Kilometer + d2.Kilometer);
        }

        public void Display()
        {
            Console.WriteLine("Total Distance: " + Kilometer + " km");
        }
    }
}
