using System;
using System.Collections.Generic;

namespace aoc_2021
{
    public class Day1_2021
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day1-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //count the number of times a depth measurement increases from the previous measurement
            Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            Console.ReadLine();
        }

        private static int ParseInputLinesPart1(List<string> inputStrings)
        {
            var depths = GetIntsFromInputStrings(inputStrings);
            var increaseCtr = 0;
            var depthCtr = 0;
            var prevDepth = depths[0];
            foreach (var depth in depths)
            {
                if (depth > prevDepth)
                {
                    increaseCtr++;
                }

                prevDepth = depths[depthCtr];
                depthCtr++;
 
            }
            return increaseCtr;
        }

        private static List<int> GetIntsFromInputStrings(List<string> inputStrings)
        {
            var depths = new List<int>();
            foreach (var str in inputStrings)
            {
                depths.Add(int.Parse(str));
            }

            return depths;
        }
    }
}
