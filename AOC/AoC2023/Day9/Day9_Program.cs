using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2023.Day9
{
    class Day9_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day9\inputFileDay9-2023.txt";
            string exFilePath1 = $@"Day9\exInputFileDay9-2023_P1.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath1);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var bloop = ParseInputStrings(inputStrings);
            var runningSum = 0;
            foreach (var item in bloop)
            {
                runningSum += ComputeNextValue(item);
            }
            return runningSum;

        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static int ComputeNextValue(List<int> values)
        {
            var sequences = new List<List<int>>();
            sequences.Add(values);
            var newSequence = new List<int>();
            var currSequence = values;
            while (!newSequence.Any() || !newSequence.All(s => s == newSequence[0]))
            {
                newSequence = new List<int>();
                for (int i = 0; i < currSequence.Count - 1; i++)
                {
                    newSequence.Add(currSequence[i + 1] - currSequence[i]);
                }

                sequences.Add(newSequence);
                currSequence = newSequence;
            }

            var sum = 0;
            foreach (var sequence in sequences)
            {
                sum += sequence.Last();
            }
            return sum;
        }

        #region lil classes

        private static List<List<int>> ParseInputStrings(List<string> inputStrings)
        {
            var allLines = new List<List<int>>();
            foreach (var line in inputStrings)
            {
                var lineList = new List<int>();
                var split = line.Split(' ');
                foreach (var s in split)
                {
                    lineList.Add(int.Parse(s));
                }
                allLines.Add(lineList);
            }

            return allLines;
        }
        #endregion
    }
}
