using System;

namespace EX_2_TrafficAccidents
{
    class Program
    {
        static void Main(string[] args)
        {
            AccidentAnalyzer analyzer = new AccidentAnalyzer();

            analyzer.FindMostAccidents();

            Console.WriteLine("");

            analyzer.FindPercentage(1999);

            Console.WriteLine("");

            analyzer.FindPercentage(2009);

            Console.WriteLine("");

            analyzer.FindPercentage(2019);

            Console.WriteLine("");

            analyzer.FindYearWithMostDeaths();

            Console.WriteLine("");

            analyzer.PrintAccidents();

            Console.WriteLine("");

            analyzer.FindChangePercentageForDeaths();
        }
    }
}
