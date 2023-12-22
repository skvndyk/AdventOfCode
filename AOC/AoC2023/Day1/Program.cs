using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2023.Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day1\inputFileDay-2023.txt";
            string exFilePath1 = $@"Day1\exInputFileDay-2023_P1.txt";
            string exFilePath2 = $@"Day1\exInputFileDay-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);
            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var total = 0;
            foreach (var str in inputStrings)
            {
                var subTotal = string.Empty;
                var allDigitChars = new List<char>();
                
                foreach (var ch in str)
                {
                    (bool isCharDigit, int? digit) = Common.Utilities.IsCharDigit(ch);
                    if (isCharDigit)
                    {
                        allDigitChars.Add(ch);
                    } 
                }

                subTotal = $"{allDigitChars.First()}{allDigitChars.Last()}";

                total += int.Parse(subTotal);
            }
            return total;
        }
    }
}
