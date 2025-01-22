using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static AoC2024.Day6.Day6_Program;

namespace AoC2024.Day6
{
    class Day6_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day6\inputFileDay6-2024.txt";
            string exFilePath = $@"Day6\exInputFileDay6-2024.txt";
            string exFilePath2 = $@"Day6\exInputFileDay6-2024_P2.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var map = ParseInputStrings(inputStrings);
            map.PrintMap();
            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        
        

        private static Map ParseInputStrings(List<string> inputStrings)
        {
            var map = new Map();
            for (int y = 0; y < inputStrings.Count; y++)
            {
                var row = new List<Square>();
                for (int x = 0; x < inputStrings[y].Length; x++)
                {
                    var square = new Square
                    {
                        X = x,
                        Y = y,
                        Content = CharToContent(inputStrings[y][x])
                    };
                    row.Add(square);
                }
                map.Squares.AddRange(row);
            }
            return map;
        }

        #region lil classes
        public class Map
        {
            public List<Square> Squares = new List<Square>();

            public Square GetSquare(int x, int y)
            {
                return Squares.FirstOrDefault(s => s.X == x && s.Y == y);
            }

            public void PrintMap()
            {
                var maxX = Squares.Max(s => s.X);
                var maxY = Squares.Max(s => s.Y);
                for (int y = 0; y <= maxY; y++)
                {
                    var strBuilder = new StringBuilder();
                    var row = new List<Square>();
                    for (int x = 0; x <= maxX; x++)
                    {
                        var square = GetSquare(x, y);
                        if (square != null)
                        {
                            strBuilder.Append(ContentToString(square.Content));
                        }
                    }

                    Console.WriteLine(strBuilder.ToString());
  
                }
            }
        }

        public class Square
        {
            public int X;
            public int Y;
            public Content Content { get; set; }

            public override string ToString()
            {
                return $"X: {X}, Y: {Y}, Content: {Content}";
            }
        }

        public static Content StringToContent(string s)
        {
            return s switch
            {
                "." => Content.Empty,
                "^" => Content.Guard,
                _ => Content.Obstacle,
            };
        }

        public static string ContentToString(Content content)
        {
            return content switch
            {
                Content.Empty => ".",
                Content.Guard => "^",
                _ => "#",
            };
        }

        public static Content CharToContent(char c)
        {
            return c switch
            {
                '.' => Content.Empty,
                '^' => Content.Guard,
                _ => Content.Obstacle,
            };
        }

        public static char ContentToChar(Content content)
        {
            return content switch
            {
                Content.Empty => '.',
                Content.Guard => '^',
                _ => '#',
            };
        }

        public enum Content
        {
            Empty,
            Obstacle,
            Guard
        }

        #endregion
    }

    
}
