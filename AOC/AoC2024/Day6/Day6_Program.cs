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
            //map.ExecuteGuardPatrol();
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
                for (int x = 0; x < inputStrings[y].Length; x++)
                {
                    var charVal = inputStrings[y][x];
                    var content = CharToContentObj(charVal);
                    if (content != null)
                    {
                        content.X = x;
                        content.Y = y;

                        bool v = content is Guard;
                        if (v)
                        {
                            var guard = (Guard)content;
                            guard.Direction = charVal switch
                            {
                                '^' => GuardDirection.North,
                                'v' => GuardDirection.South,
                                '>' => GuardDirection.East,
                                '<' => GuardDirection.West,
                                _ => throw new InvalidOperationException("Invalid guard direction")
                            };
                        }
                        map.Contents.Add(content);
                    }
                }
            }
            return map;
        }

        #region lil classes
        public class Map
        {
            public List<Content> Contents = new();

            public Content GetContent(int x, int y)
            {
                return Contents.FirstOrDefault(s => s.X == x && s.Y == y);
            }

            public Content GetGuardSquare()
            {
                return Contents.FirstOrDefault(s => s is Guard);
            }

            public void PrintMap()
            {
                var maxX = Contents.Max(c => c.X);
                var maxY = Contents.Max(c => c.Y);
                for (int y = 0; y <= maxY; y++)
                {
                    var strBuilder = new StringBuilder();
                    for (int x = 0; x <= maxX; x++)
                    {
                        var content = GetContent(x, y);
                        if (content != null)
                        {
                            strBuilder.Append(content.StringDisplay());
                        }
                        else
                        {
                            strBuilder.Append(".");
                        }
                    }

                    Console.WriteLine(strBuilder.ToString());

                }

                Console.WriteLine("\n\n\n\n");
            }

            //    public void ExecuteGuardPatrol()
            //    {
            //        var guardSquare = (GuardSquare)GetGuardSquare();
            //        var guardX = guardSquare.X;
            //        var guardY = guardSquare.Y;
            //        var guardBlocked = false;
            //        var nextMoveOnBoard = true;

            //        while (nextMoveOnBoard)
            //        {
            //            while (!guardBlocked && nextMoveOnBoard)
            //            {

            //                guardSquare.MoveGuard();
            //                var prevGuardSquare = GetSquare(guardX, guardY);
            //                if (prevGuardSquare != null)
            //                {
            //                    prevGuardSquare.Content = Content.Empty;
            //                    guardX = guardSquare.X;
            //                    guardY = guardSquare.Y;
            //                }

            //                PrintMap();
            //            }

            //            if (guardBlocked)
            //            {
            //                var (x, y) = guardSquare.MoveGuardDryRun();
            //                var square = GetSquare(x, y);
            //                if (square.Content == Content.Obstacle)
            //                {
            //                    guardSquare.RotateGuard();
            //                }

            //                guardSquare.MoveGuard();
            //                var prevGuardSquare = GetSquare(guardX, guardY);
            //                if (prevGuardSquare != null)
            //                {
            //                    prevGuardSquare.Content = Content.Empty;
            //                    guardX = guardSquare.X;
            //                    guardY = guardSquare.Y;
            //                }
            //                PrintMap();
            //            }

            //            guardBlocked = IsGuardBlockedOnNextMove();
            //            nextMoveOnBoard = IsNextMoveStillOnBoard();
            //        }

            //        Console.WriteLine("rest easy");
            //    }

            //    //public void MoveGuard

            //    public Square GetNextMoveSquare()
            //    {
            //        var guardSquare = GetGuardSquare();
            //        var (x, y) = ((GuardSquare)guardSquare).MoveGuardDryRun();
            //        return GetSquare(x, y);
            //    }

            //    public bool IsGuardBlockedOnNextMove()
            //    {
            //        var square = GetNextMoveSquare();
            //        if (square.Content == Content.Obstacle)
            //        {
            //            return true;
            //        }
            //        return false;
            //    }

            //    public bool IsNextMoveStillOnBoard()
            //    {
            //        var square = GetNextMoveSquare();
            //        if (square.X < 0 || square.Y < 0)
            //        {
            //            return false;
            //        }
            //        return true;
            //    }
        }

        public abstract class Content
        {
            public int X { get; set; }
            public int Y { get; set; }
            public abstract string StringDisplay();
        }

        public class Obstacle : Content
        {
            public override string StringDisplay() => "#";
        }

        public class Guard : Content
        {
            public readonly Dictionary<GuardDirection, GuardDirection> RotationDict = new()
            {
                {GuardDirection.North, GuardDirection.East},
                {GuardDirection.East, GuardDirection.South},
                {GuardDirection.South, GuardDirection.West},
                {GuardDirection.West, GuardDirection.North}
            };

            public GuardDirection Direction { get; set; }

            public void RotateGuard()
            {
                Direction = RotationDict[Direction];
            }

            public void MoveGuard()
            {
                switch (Direction)
                {
                    case GuardDirection.North:
                        Y = Y - 1;
                        break;
                    case GuardDirection.South:
                        Y = Y + 1;
                        break;
                    case GuardDirection.East:
                        X = X + 1;
                        break;
                    case GuardDirection.West:
                        X = X - 1;
                        break;
                }
            }

            public (int, int) MoveGuardDryRun()
            {
                switch (Direction)
                {
                    case GuardDirection.North:
                        return (X, Y - 1);
                    case GuardDirection.South:
                        return (X, Y + 1);
                    case GuardDirection.East:
                        return (X + 1, Y);
                    case GuardDirection.West:
                        return (X - 1, Y);
                    default:
                        throw new InvalidOperationException("Invalid guard movement");
                }
            }

            public override string StringDisplay()
            {
                return Direction switch
                {
                    GuardDirection.North => "^",
                    GuardDirection.South => "v",
                    GuardDirection.East => ">",
                    GuardDirection.West => "<",
                    _ => throw new InvalidOperationException("Invalid guard movement"),
                };
            }

        }
        
        #region helper methods
       

        public static Content? CharToContentObj(char c)
        {
            return c switch
            {
                '.' => null,
                '^' => new Guard(),
                'v' => new Guard(),
                '>' => new Guard(),
                '<' => new Guard(),
                _ => new Obstacle()
            };
        }

       

        #endregion
        

        public enum GuardDirection
        {
            North,
            South,
            East,
            West
        }

        #endregion
    }


}
