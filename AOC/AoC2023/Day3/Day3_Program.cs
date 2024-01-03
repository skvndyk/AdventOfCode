using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day3_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day3\inputFileDay3-2023.txt";
            string exFilePath1 = $@"Day3\exInputFileDay3-2023_P1.txt";
            string exFilePath2 = $@"Day3\exInputFileDay3-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var schematic = InputStringsToSchematic(inputStrings);
            schematic.DrawSchematic();
            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static Schematic InputStringsToSchematic(List<string> inputStrings)
        {
            var schematic = new Schematic();
            int x = 0;
            int y = 0;
            int counter = 0;
            foreach (var str in inputStrings)
            {
                foreach (var character in str)
                {
                    var point = new Point()
                    {
                        Id = counter,
                        X = x,
                        Y = y,
                        Contents = character
                    };
                    schematic.Points.Add(point);
                    x++;
                    counter++;
                }
                x = 0;
                y++;
            }
            return schematic;
        }

        #region lil classes
        public class Schematic
        {
            public List<Point> Points { get; set; } = new List<Point>();
            public void DrawSchematic()
            {
                var pointGroups = Points.GroupBy(p => p.Y);
                foreach (var pointGroup in pointGroups)
                {
                    var pointList = pointGroup.ToList();
                    Console.WriteLine(string.Join(string.Empty,pointList.Select(x => x.Contents)));
                }
            }

        }

        public class Point
        {
            public int Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public char Contents { get; set; }
            public bool IsSymbol => !int.TryParse(Contents.ToString(), out int output) && Contents != '.';
            public (bool IsDigit, int? DigitValue) IsDigit => Common.Utilities.IsCharDigit(Contents);
            public int GetIntValueFromContents => !IsDigit.IsDigit ? -1 : (int)IsDigit.DigitValue;
            public List<Point> SiblingDigitPoints { get; set; }
        }
        #endregion
    }
}
