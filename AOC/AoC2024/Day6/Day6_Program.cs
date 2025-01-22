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
            map.ExecuteGuardPatrol();
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
                    var content = CharToContent(inputStrings[y][x]);
                    if (content == Content.GuardNorth)
                    {
                        row.Add(new GuardSquare()
                        {
                            X = x,
                            Y = y,
                            Content = content
                        });
                    }

                    else
                    {
                        row.Add(new Square()
                        {
                            X = x,
                            Y = y,
                            Content = content
                        });
                    }
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

            public Square GetGuardSquare()
            {
                return Squares.FirstOrDefault(s => IsGuardSquare(s));
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

                Console.WriteLine("\n\n\n\n");
            }

            public void ExecuteGuardPatrol()
            {
                var guardSquare = GetGuardSquare();
                var guardBlocked = false;
                var nextMoveOnBoard = true;

                while (nextMoveOnBoard)
                {
                    while (!guardBlocked && nextMoveOnBoard)
                    {
                        ((GuardSquare)guardSquare).MoveGuard();
                        PrintMap();
                    }

                    if (guardBlocked)
                    {
                        var (x, y) = ((GuardSquare)guardSquare).MoveGuardDryRun();
                        var square = GetSquare(x, y);
                        if (square.Content == Content.Obstacle)
                        {
                            ((GuardSquare)guardSquare).RotateGuard();
                        }

                        ((GuardSquare)guardSquare).MoveGuard();
                        PrintMap();
                    }

                    guardBlocked = IsGuardBlockedOnNextMove();
                    nextMoveOnBoard = IsNextMoveStillOnBoard();
                }

                Console.WriteLine("rest easy"); 
            }

            public Square GetNextMoveSquare()
            {
                var guardSquare = GetGuardSquare();
                var (x, y) = ((GuardSquare)guardSquare).MoveGuardDryRun();
                return GetSquare(x, y);
            }

            public bool IsGuardBlockedOnNextMove()
            {
                var square = GetNextMoveSquare();
                if (square.Content == Content.Obstacle)
                {
                    return true;
                }
                return false;
            }

            public bool IsNextMoveStillOnBoard()
            {
                var square = GetNextMoveSquare();
                if (square.X < 0 || square.Y < 0)
                {
                    return false;
                }
                return true;
            }
        }

        public class Square
        {
            public int X;
            public int Y;
            public virtual Content Content { get; set; }
        }

        public static bool IsGuardSquare(Square square)
        {
            return square is GuardSquare;
        }

        public class GuardSquare : Square
        {
            public readonly Dictionary<Content, Content> RotationDict = new()
            {
                {Content.GuardNorth, Content.GuardEast},
                {Content.GuardEast, Content.GuardSouth},
                {Content.GuardSouth, Content.GuardWest},
                {Content.GuardWest, Content.GuardNorth}
            };

            public void RotateGuard()
            {
                Content = RotationDict[Content];
            }

            public void MoveGuard()
            {
                switch (Content)
                {
                    case Content.GuardNorth:
                        Y = Y-1;
                        break;
                    case Content.GuardSouth:
                        Y = Y + 1;
                        break;
                    case Content.GuardEast:
                        X = X + 1;
                        break;
                    case Content.GuardWest:
                        X = X - 1;
                        break;
                }
            }

            public (int, int) MoveGuardDryRun()
            {
                switch (Content)
                {
                    case Content.GuardNorth:
                        return (X, Y - 1);
                    case Content.GuardSouth:
                        return (X, Y + 1);
                    case Content.GuardEast:
                        return (X + 1, Y);
                    case Content.GuardWest:
                        return (X - 1, Y);
                    default:
                        throw new InvalidOperationException("Invalid guard movement");
                }
            }
        }

        #region helper methods
        public static Content StringToContent(string s)
        {
            return s switch
            {
                "." => Content.Empty,
                "^" => Content.GuardNorth,
                "v" => Content.GuardSouth,
                ">" => Content.GuardEast,
                "<" => Content.GuardWest,
                _ => Content.Obstacle,
            };
        }

        public static string ContentToString(Content content)
        {
            return content switch
            {
                Content.Empty => ".",
                Content.GuardNorth => "^",
                Content.GuardSouth => "v",
                Content.GuardEast => ">",
                Content.GuardWest => "<",
                _ => "#",
            };
        }

        public static Content CharToContent(char c)
        {
            return c switch
            {
                '.' => Content.Empty,
                '^' => Content.GuardNorth,
                'v' => Content.GuardSouth,
                '>' => Content.GuardEast,
                '<' => Content.GuardWest,
                _ => Content.Obstacle,
            };
        }

        public static char ContentToChar(Content content)
        {
            return content switch
            {
                Content.Empty => '.',
                Content.GuardNorth => '^',
                Content.GuardSouth => 'v',
                Content.GuardEast => '>',
                Content.GuardWest => '<',
                _ => '#',
            };
        }

        #endregion
        public enum Content
        {
            Empty,
            Obstacle,
            GuardNorth,
            GuardSouth,
            GuardEast,
            GuardWest
        }

        #endregion
    }


}
