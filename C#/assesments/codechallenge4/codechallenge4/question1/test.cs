using System;

class Test
{
    static void Main()
    {
        test();
        Console.ReadLine();
    }
    static void test()
    {
        Distance d1 = new Distance(70);
        Distance d2 = new Distance(75);
        int expectedResult = 145;
        Distance result = Distance.Add(d1, d2);
        if (result.Kilometer == expectedResult)
        {
            Console.WriteLine("Testcase passed");
        }
        else
        {
            Console.WriteLine("Testcase failed");
        }
    }
}