using System;
using testclass;

namespace testclass
{
    class Test
    {
        static void Main(string[] args)
        {
            Distance d1 = new Distance(12);
            Distance d2 = new Distance(18);

            Distance d3 = Distance.Add(d1, d2);

            d3.Display();
        }
    }
}
