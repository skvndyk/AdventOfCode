using System;
using System.Linq;
using System.Collections.Generic;

namespace Day3_2021
{
    class Program
    {
        private static int _numLength = 0;
        private static Dictionary<string, List<string>> _firstIdxStrings = new Dictionary<string, List<string>>() { { "0", new List<string>()}, { "1", new List<string>()} };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day3-2021.txt";
            string exFilePath = "day3-ex-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);
            ParseInputLinesPart1(inputStrings);
            //Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            //ParseInputLinesPart2(inputStrings);
            Console.WriteLine($@"Part 2 Answer:{ParseInputLinesPart2(inputStrings)}");
            Console.ReadLine();
        }

        private static int ParseInputLinesPart1(List<string> inputStrings)
        {
            _numLength = inputStrings[0].Length;
            var gammaRate = new List<int>();
            var listOfLists = ParseInputToLists(inputStrings);
            for (int i = 0; i < _numLength; i++)
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

        private static int ParseInputLinesPart2(List<string> inputStrings)
        {
            _numLength = inputStrings[0].Length;
            (List<string> o2g, List<string> co2s) = PopulateDictionary(inputStrings);
            var result = Convert.ToInt32(string.Join("", o2g), 2) * Convert.ToInt32(string.Join("", co2s), 2);
            return result;
        }

        private static Dictionary<string, int> NewInnerDictionary() => new Dictionary<string, int>(){ { "0", 0 }, { "1",  0 } };

        private static (List<string>, List<string>) PopulateDictionary(List<string> inputStrings)
        {
            var o2num = GetO2GRatingBestNumbers(inputStrings);

            var co2num = GetCO2ScrubberRatingBestNumbers(inputStrings);

            return (o2num[0], co2num[0]);
            
        }

        private static List<List<string>> GetO2GRatingBestNumbers(List<string> inputStrings)
        {
            var freqDict = new Dictionary<int, Dictionary<string, int>>();
            var bestNumbersO2GRating = ParseInputToStringLists(inputStrings);
            string mostCommonValue = string.Empty;

            for (int idx = 0; idx < _numLength; idx++)
            {
                if (bestNumbersO2GRating.Count == 1)
                {
                    break;
                }

                freqDict.Add(idx, NewInnerDictionary());
                foreach (var ls in bestNumbersO2GRating)
                {
                    freqDict[idx][ls[idx]]++;

                }
              
                var mcv = freqDict[idx].Keys.Where(k => freqDict[idx][k] == freqDict[idx].Values.Max()).ToArray();
                mostCommonValue = mcv.Count() > 1 ? "1" : mcv[0];

                var numbersToRemove = bestNumbersO2GRating.Where(b => b[idx].ToString() != mostCommonValue);
                bestNumbersO2GRating.RemoveAll(n => numbersToRemove.Contains(n));
            }

            return bestNumbersO2GRating;
        }

        private static List<List<string>> GetCO2ScrubberRatingBestNumbers(List<string> inputStrings)
        {
            var freqDict = new Dictionary<int, Dictionary<string, int>>();
            var bestNumbersO2GRating = ParseInputToStringLists(inputStrings);
            string leastCommonValue = string.Empty;

            for (int idx = 0; idx < _numLength; idx++)
            {
                if (bestNumbersO2GRating.Count == 1)
                {
                    break;
                }

                freqDict.Add(idx, NewInnerDictionary());
                foreach (var ls in bestNumbersO2GRating)
                {
                    freqDict[idx][ls[idx]]++;

                }

                var lcv = freqDict[idx].Keys.Where(k => freqDict[idx][k] == freqDict[idx].Values.Min()).ToArray();
                leastCommonValue = lcv.Count() > 1 ? "0" : lcv[0];

                var numbersToRemove = bestNumbersO2GRating.Where(b => b[idx].ToString() != leastCommonValue);
                bestNumbersO2GRating.RemoveAll(n => numbersToRemove.Contains(n));
            }

            return bestNumbersO2GRating;
        }

        private static IEnumerable<List<int>> ParseInputToLists(List<string> inputStrings)
        {
            return inputStrings.Select(str => str.Select(c => int.Parse(c.ToString())).ToList());
        }

        private static List<List<string>> ParseInputToStringLists(List<string> inputStrings)
        {
            return inputStrings.Select(str => str.Select(c => c.ToString()).ToList()).ToList();
        }

        private static int FlipBit(int i) { return i == 0 ? 1 : 0; }
    }
}
