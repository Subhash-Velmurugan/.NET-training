using System;
using CodeChallenge4.Interfaces;

namespace CodeChallenge4.Reports
{
    public class SummaryReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating Summary Report...");
        }
    }
}