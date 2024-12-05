using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2024.Day1
{
    class Day1_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day1\inputFileDay1-2024.txt";
            string exFilePath1 = $@"Day1\exInputFileDay1-2024_P1.txt";
            string exFilePath2 = $@"Day1\exInputFileDay1-2024_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings1)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            (List<int> listLeft, List<int> listRight) = ParseInputStrings(inputStrings);

            var sum = 0;
            for (int i = 0; i < listLeft.Count; i++)
            {
                sum += Math.Abs(listLeft[i] - listRight[i]);
            }
            return sum;

        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static (List<int>, List<int>) ParseInputStrings(List<string> strings)
        {
            var listLeft = new List<int>();
            var listRight = new List<int>();
            foreach (var line in strings)
            {
                var split = line.Split("  ");
                listLeft.Add(int.Parse(split[0]));
                listRight.Add(int.Parse(split[1]));
            }
            return (listLeft.OrderBy(i => i).ToList(), listRight.OrderBy(i => i).ToList());
        }
    }
}
