using System;
using System.Buffers;
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

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var parsedStrings = ParseInputStrings(inputStrings);
            var runningSum = 0;
            foreach (var parsedString in parsedStrings)
            {
                runningSum += ComputeNextValue(parsedString);
            }
            return runningSum;

        }

        private static int Part2(List<string> inputStrings)
        {
            var parsedStrings = ParseInputStrings(inputStrings);
            var runningSum = 0;
            foreach (var parsedString in parsedStrings)
            {
                runningSum += ComputeNextValueP2(parsedString);
            }
            return runningSum;
        }

        private static int ComputeNextValue(List<int> values)
        {
            var sequences = new List<List<int>>
            {
                values
            };
            var newSequence = new List<int>();
            var currSequence = values;
            while (newSequence.Count == 0 || !newSequence.All(s => s == 0))
            {
                newSequence = [];
                for (int i = 0; i < currSequence.Count - 1; i++)
                {
                    newSequence.Add(currSequence[i + 1] - currSequence[i]);
                }

                sequences.Add(newSequence);
                currSequence = newSequence;
            }
           
            for (int i = 0; i < sequences.Count; i++)
            {
                var numLeadingSpaces = 1 + i;
                var leadingSpaces = string.Join("", Enumerable.Repeat(" ", numLeadingSpaces));
                Console.WriteLine($"{leadingSpaces}" + string.Join(" ", sequences[i]));
            }

            
            var sum = 0;
            foreach (var sequence in sequences)
            {
                sum += sequence.Last();
            }
            return sum;
        }


        private static int ComputeNextValueP2(List<int> values)
        {
            var sequences = new List<List<int>>
            {
                values
            };
            var newSequence = new List<int>();
            var currSequence = values;
            while (newSequence.Count == 0 || !newSequence.All(s => s == 0))
            {
                newSequence = [];
                for (int i = 0; i < currSequence.Count - 1; i++)
                {
                    newSequence.Add(currSequence[i + 1] - currSequence[i]);
                }

                sequences.Add(newSequence);
                currSequence = newSequence;
            }

            var lastSequence = sequences.Last();
            //backfill last row with a 0
            lastSequence.Insert(0, 0);

            for (int i = sequences.Count - 2; i >= 0; i--)
            {
                var seqToUpdate = sequences[i];
                var seqToLookAt = sequences[i + 1];
                var valToInsert = seqToUpdate[0] - seqToLookAt[0];
                seqToUpdate.Insert(0, valToInsert);
                Console.WriteLine($"Inserting {valToInsert} at index 0 of sequence {i}");
            }

            Console.WriteLine("\n\n\n");
            for (int i = 0; i < sequences.Count; i++)
            {
                var numLeadingSpaces = i;
                var leadingSpaces = string.Join("", Enumerable.Repeat(" ", numLeadingSpaces));
                Console.WriteLine($"{leadingSpaces}" + string.Join(" ", sequences[i]));
            }


            return sequences[0][0];
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
