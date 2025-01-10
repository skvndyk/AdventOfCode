using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2024.Day3
{
    class Day3_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day3\inputFileDay3-2024.txt";
            string exFilePath1 = $@"Day3\exInputFileDay3-2024_P1.txt";
            string exFilePath2 = $@"Day3\exInputFileDay3-2024_P2.txt";

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
            var product = 0;
            var pattern = @"\((\d+),(\d+)\)";
            foreach (var inputStr in inputStrings)
            {
                var splits = inputStr.Split("mul");

                foreach (var split in splits)
                {
                    var matches = Regex.Matches(split, pattern);
                    if (matches.Count > 0)
                    {
                        Console.WriteLine($"found a match! {matches[0].Value}");
                        product += int.Parse(matches[0].Groups[1].Value) * int.Parse(matches[0].Groups[2].Value);
                    }
                }
            }
            
            
            return product;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;   
        }

      

       
    }
}
