using System;
using System.Linq;
using System.Collections.Generic;

namespace Day3_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day3-2021.txt";
            string exFilePath = "day3-ex-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);
            ParseInputLinesPart1(inputStrings);
            Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            //Console.WriteLine($@"Part 2 Answer:{ParseInputLinesPart2(inputStrings)}");
            Console.ReadLine();
        }

        private static int ParseInputLinesPart1(List<string> inputStrings)
        {
            int numLength = inputStrings[0].Length;
            var gammaRate = new List<int>();
            var listOfLists = ParseInputToLists(inputStrings);
            for (int i = 0; i < numLength; i++)
            {
                var freqDict = new Dictionary<int, int>() { { 0, 0 }, { 1, 0 } };
                foreach (var ls in listOfLists)
                {
                    freqDict[ls[i]]++;
                }
                gammaRate.Add(freqDict.Keys.Where(k => freqDict[k] == freqDict.Values.Max()).First());
            }

            var epsilonRate = new List<int>();
            epsilonRate = gammaRate.Select(g => FlipBit(g)).ToList();
            var result = Convert.ToInt32(string.Join("", gammaRate), 2) * Convert.ToInt32(string.Join("", epsilonRate), 2);
            return result;
        }

        private static void ParseInputLinesPart2(List<string> inputStrings)
        {

        }

        private static IEnumerable<List<int>> ParseInputToLists(List<string> inputStrings)
        {
            return inputStrings.Select(str => str.Select(c => int.Parse(c.ToString())).ToList());
        }

        private static int FlipBit(int i) { return i == 0 ? 1 : 0; }
    }
}
