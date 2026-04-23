
using System;
using CodeChallenge4.Factory;
using CodeChallenge4.Interfaces;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter report type (chart / tabular / summary):");
        string input = Console.ReadLine();

        try
        {
            IReportGenerator report =
                ReportGeneratorFactory.CreateReport(input);

            report.GenerateReport();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
