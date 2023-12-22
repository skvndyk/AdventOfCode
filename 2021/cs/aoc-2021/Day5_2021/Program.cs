using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day5_2021
{
    class Program
    {
        private static Regex _inputRegex = new Regex(@"(?<firstPoint>\d*,\d*) -> (?<secondPoint>\d*,\d*)");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day5-2021.txt";
            string exFilePath = "day5-ex-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);
            Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            //Console.WriteLine($@"Part 2 Answer:{ParseInputLinesPart2(inputStrings)}");
            Console.ReadLine();
        }

        private static object ParseInputLinesPart1(List<string> inputStrings)
        {
            throw new NotImplementedException();
        }

        public static List<List<Point>> ParseInputToPoints(List<string> inputStrings)
        {
            foreach (var str in inputStrings)
            {
                MatchCollection matches = _inputRegex.Matches(str);
                foreach (var match in matches)
                {

                }
            }
            return null;
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
