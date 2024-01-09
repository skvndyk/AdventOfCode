using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day6_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day6\inputFileDay6-2023.txt";
            string exFilePath1 = $@"Day6\exInputFileDay6-2023_P1.txt";
            string exFilePath2 = $@"Day6\exInputFileDay6-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var tuples = InputStringsToTuples(inputStrings);
            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

       
        private static List<(int time, int distance)> InputStringsToTuples(List<string> inputStrings)
        {
            var returnList = new List<(int, int)>();
            string timePattern = $@"(Time: *)(.*)";
            string distancePattern = $@"(Distance: *)(.*)";

            var timeRegex = new Regex(timePattern);
            var timeMatches = timeRegex.Matches(inputStrings[0]);
            var times = timeMatches[0].Groups[2].Value;
            var timeList = times.Split(' ').Where(x => int.TryParse(x, out int _)).ToList();

            var distanceRegex = new Regex(distancePattern);
            var distanceMatches = distanceRegex.Matches(inputStrings[1]);
            var distances = distanceMatches[0].Groups[2].Value;
            var distanceList = distances.Split(' ').Where(x => int.TryParse(x, out int _)).ToList();


            for (int i = 0; i <= timeList.Count - 1; i++)
            {
                returnList.Add((int.Parse(timeList[i]), int.Parse(distanceList[i])));
            }

            return returnList;
        }

        #region lil classes
        

        #endregion
    }
}
