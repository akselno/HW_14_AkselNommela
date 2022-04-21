using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EX_2_TrafficAccidents
{
    public class AccidentAnalyzer
    {
        public static int[] _accidents1999 = ReadFileToArray("1999_totalAccidents.txt");
        public static int[] _deaths1999 = ReadFileToArray("1999_deaths.txt");
        public static int[] _accidents2009 = ReadFileToArray("2009_totalAccidents.txt");
        public static int[] _deaths2009 = ReadFileToArray("2009_deaths.txt");
        public static int[] _accidents2019 = ReadFileToArray("2019_totalAccidents.txt");
        public static int[] _deaths2019 = ReadFileToArray("2019_deaths.txt");
        public static string[] _monthNames = { "January", "February", "March", "April", "May",
            "June", "July", "August", "September", "October", "November", "December" };
        double accidentSum1999 = _accidents1999.Sum();
        double accidentSum2009 = _accidents2009.Sum();
        double accidentSum2019 = _accidents2019.Sum();
        double deathSum1999 = _deaths1999.Sum();
        double deathSum2009 = _deaths2009.Sum();
        double deathSum2019 = _deaths2019.Sum();

        public static int[] ReadFileToArray(string fileName)
        {
            int index = 0;
            int[] returnArray = new int[12];
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    returnArray[index] = int.Parse(line);
                    index++;
                }
            }
            return returnArray;
        }

        public void FindMostAccidents()
        {
            int maxValue1999 = _accidents1999.Max();
            int maxValue2009 = _accidents2009.Max();
            int maxValue2019 = _accidents2019.Max();
            int maxIndex1999 = _accidents1999.ToList().IndexOf(maxValue1999);
            int maxIndex2009 = _accidents2009.ToList().IndexOf(maxValue2009);
            int maxIndex2019 = _accidents2019.ToList().IndexOf(maxValue2019);
            if (maxValue1999 > maxValue2009 && maxValue1999 > maxValue2019)
            {
                string month = _monthNames[maxIndex1999];
                Console.WriteLine($"Most accidents occured in {month} 1999 ({maxValue1999}).");
            }
            else if (maxValue2009 > maxValue1999 && maxValue2009 > maxValue2019)
            {
                string month = _monthNames[maxValue2009];
                Console.WriteLine($"Most accidents occured in {month} 2009 ({maxValue2009}).");
            }
            else if (maxValue2019 > maxValue1999 && maxValue2019 > maxValue2009)
            {
                string month = _monthNames[maxIndex2019];
                Console.WriteLine($"Most accidents occured in {month} 2019 ({maxValue2019}).");
            }
        }

        public void FindPercentage(int year)
        {
            double percentage;
            double deaths;
            double accidents;

            if (year == 1999 || year == 2009 || year == 2019)
            {
                Console.WriteLine("Percentage of accidents that ended with death:");
                Console.WriteLine("");
                if (year == 1999)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        deaths = _deaths1999[i];
                        accidents = _accidents1999[i];
                        percentage = deaths / accidents * 100;
                        Console.WriteLine("1999 {0}: {1}%", _monthNames[i], Math.Round(percentage, 2));
                    }
                }
                else if (year == 2009)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        deaths = _deaths2009[i];
                        accidents = _accidents2009[i];
                        percentage = deaths / accidents * 100;
                        Console.WriteLine("2009 {0}: {1}%", _monthNames[i], Math.Round(percentage, 2));
                    }
                }
                else if (year == 2019)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        deaths = _deaths2019[i];
                        accidents = _accidents2019[i];
                        percentage = deaths / accidents * 100;
                        Console.WriteLine("2019 {0}: {1}%", _monthNames[i], Math.Round(percentage, 2));
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Year must be either 1999, 2009 or 2019.");
            }
        }

        public void FindYearWithMostDeaths()
        {
            double deathRate1999 = Math.Round(deathSum1999 / accidentSum1999 * 100, 2);
            double deathRate2009 = Math.Round(deathSum2009 / accidentSum2009 * 100, 2);
            double deathRate2019 = Math.Round(deathSum2019 / accidentSum2019 * 100, 2);
            if (deathRate1999 > deathRate2009 && deathRate1999 > deathRate2019)
            {
                Console.WriteLine($"The year with most deaths was 1999 ({deathSum1999}).");
            }
            else if (deathRate2009 > deathRate1999 && deathRate2009 > deathRate2019)
            {
                Console.WriteLine($"The year with most deaths was 2009 ({deathSum2009}).");
            }
            else if (deathRate2019 > deathRate1999 && deathRate2019 > deathRate2009)
            {
                Console.WriteLine($"The year with most deaths was 2019 ({deathSum2019}).");
            }
        }

        public void PrintAccidents()
        {
            string accidentSum1999 = _accidents1999.Sum() + " accidents";
            string accidentSum2009 = _accidents2009.Sum() + " accidents";
            string accidentSum2019 = _accidents2019.Sum() + " accidents";
            Dictionary<string, string> years = new Dictionary<string, string>();
            years.Add("1999: ", accidentSum1999);
            years.Add("2009: ", accidentSum2009);
            years.Add("2019: ", accidentSum2019);
            foreach (KeyValuePair<string, string> year in years.OrderByDescending(key => key.Value))
            {
                Console.WriteLine(year.Key + year.Value);
            }
        }

        public void FindChangePercentageForDeaths()
        {
            double changeFor1999And2009 = deathSum2009 / deathSum1999 * 100;
            double changeFor2009And2019 = deathSum2019 / deathSum2009 * 100;

            double answer1999And2009 = 100 - changeFor1999And2009;
            double answer2009And2019 = 100 - changeFor2009And2019;

            if (answer1999And2009 < 0)
            {
                Console.WriteLine($"Death percentage for 2009 compared to 1999 " +
                    $"increased by {Math.Abs(answer1999And2009)}%.");
            }
            else if (answer1999And2009 > 0)
            {
                Console.WriteLine($"Death percentage for 2009 compared to 1999 " +
                    $"decreased by {Math.Abs(answer1999And2009)}%.");
            }
            if (answer2009And2019 < 0)
            {
                Console.WriteLine($"Death percentage for 2019 compared to 2009 " +
                    $"increased by {Math.Abs(answer2009And2019)}%.");
            }
            else if (answer2009And2019 > 0)
            {
                Console.WriteLine($"Death percentage for 2019 compared to 2009 " +
                    $"decreased by {Math.Abs(answer2009And2019)}%.");
            }
        }
    }
}
