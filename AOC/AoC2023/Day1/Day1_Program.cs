using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2023.Day1
{
    class Day1_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day1\inputFileDay-2023.txt";
            string exFilePath1 = $@"Day1\exInputFileDay-2023_P1.txt";
            string exFilePath2 = $@"Day1\exInputFileDay-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
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

        private static int Part2(List<string> inputStrings)
        {
            var digitStrings = new List<string>()
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "0"
            };

            var digitCharMapper = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            var total = 0;
            foreach (var str in inputStrings)
            {
                var digitDict = new Dictionary<string, List<int>>();
                var subTotal = string.Empty;
                var allDigitChars = new List<char>();
                (int minDigit, int minIdx) min = (99999, 99999);
                (int maxDigit, int maxIdx) max = (-1, -1);

                foreach (var digitStr in digitStrings)
                {
                    var allIdxs = AllIndexesOf(str, digitStr);
                    digitDict[digitStr] = allIdxs.ToList();
                }

                //https://stackoverflow.com/a/16062510
                IEnumerable<int> AllIndexesOf(string str, string searchString)
                {
                    int minIndex = str.IndexOf(searchString);
                    while (minIndex != -1)
                    {
                        yield return minIndex;
                        minIndex = str.IndexOf(searchString, minIndex + searchString.Length);
                    }
                }

                foreach (var kvp in digitDict.Where(x => x.Value.Count > 0))
                {
                    var localMinIdx = kvp.Value.Min();
                    if (localMinIdx < min.minIdx)
                    {
                        //convert string digit to digit digit
                        min.minDigit = kvp.Key.Length > 1 ?
                            digitCharMapper[kvp.Key]
                            : int.Parse(kvp.Key);
                     
                        min.minIdx = localMinIdx;
                    }

                    var localMaxIdx = kvp.Value.Max();
                    if (localMaxIdx > max.maxIdx)
                    {
                        max.maxDigit = kvp.Key.Length > 1 ?
                            digitCharMapper[kvp.Key]
                            : int.Parse(kvp.Key);


                        max.maxIdx = localMaxIdx;
                    }
                }

                subTotal = $"{min.minDigit}{max.maxDigit}";
                total += int.Parse(subTotal);
            }

            return total;
        }
    }
}
