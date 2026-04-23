using System;
using CodeChallenge4.Interfaces;
using CodeChallenge4.Reports;

namespace CodeChallenge4.Factory
{
    public static class ReportGeneratorFactory
    {
        public static IReportGenerator CreateReport(string reportType)
        {
            switch (reportType.ToLower())
            {
                case "chart":
                    return new ChartReportGenerator();

                case "tabular":
                    return new TabularReportGenerator();

                case "summary":
                    return new SummaryReportGenerator();

                default:
                    throw new ArgumentException("Invalid report type");
            }
        }
    }
}