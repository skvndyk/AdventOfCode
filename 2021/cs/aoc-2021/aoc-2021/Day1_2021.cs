using System;
using System.Linq;
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
            //Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            Console.WriteLine($@"Part 2 Answer:{ParseInputLinesPart2(inputStrings)}");
            Console.ReadLine();
        }

        private static int ParseInputLinesPart1(List<string> inputStrings)
        {
            var depths = GetIntsFromInputStrings(inputStrings);
            var increaseCtr = 0;
     
            for (int i = 1; i < depths.Count; i++)
            {
                if (depths[i] > depths[i-1])
                {
                    increaseCtr++;
                }
            }
           
            return increaseCtr;
        }

        private static int ParseInputLinesPart2(List<string> inputStrings)
        {
            var depths = GetIntsFromInputStrings(inputStrings);
            var increaseCtr = 0;
            int prevDepthSum = 999999999;

            for (int i = 0; i < depths.Count - 2; i++)
            {
                var windowSum = depths.GetRange(i, 3).Sum();
                if (windowSum > prevDepthSum)
                {
                    increaseCtr++;
                }

                prevDepthSum = windowSum;
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
