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

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var bloop = ParseInputStrings(inputStrings);
            foreach (var item in bloop)
            {
                ComputeNextValue(item);
            }
            return 0;

        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static int ComputeNextValue(List<int> values)
        {
            var sequences = new List<List<int>>();
            sequences.Add(values);

            var sequence = new List<int>();
            while (!sequence.Any() || !sequence.All(s => s == sequence[0]))
            {
                sequence = new List<int>();
                for (int i = 0; i < values.Count - 1; i++)
                {
                    sequence.Add(values[i + 1] - values[i]);
                }

                sequences.Add(sequence);
            }

            return 0;
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
