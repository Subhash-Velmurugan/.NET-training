
using System;
using CodeChallenge4.Interfaces;

namespace CodeChallenge4.Reports
{
    public class TabularReportGenerator : IReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("Generating Tabular Report...");
        }
    }
}
