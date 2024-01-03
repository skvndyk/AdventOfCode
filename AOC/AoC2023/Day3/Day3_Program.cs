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
            schematic.PopulateDigitPointGroups();

            var total = 0;
            foreach (var pointGroup in schematic.DigitPointGroups)
            {
                if (schematic.IsPointGroupAdjacentToSymbol(pointGroup))
                {
                    total += PointGroupToInt(pointGroup.Points);
                }
            }
            return total;
        }

        private static int Part2(List<string> inputStrings)
        {
            var schematic = InputStringsToSchematic(inputStrings);
            schematic.PopulateDigitPointGroups();

            //get point groups adjacent to gears
            var gears = schematic.Points.Where(p => p.IsGear).ToList();
            var totalList = new List<int>();
            var total = 0;
            foreach (var gear in gears)
            {
                var digitPointGroups = schematic.GetDigitPointGroupsAdjacentToGear(gear);
                if (digitPointGroups.Count == 2)
                {
                    foreach (var group in digitPointGroups)
                    {
                        totalList.Add(PointGroupToInt(group.Points));
                    }
                }

                if (totalList.Count > 0)
                {
                    total += totalList.Aggregate((a,x) => a * x);
                    totalList = new List<int>();
                }
            }
            
            return total;
        }

        private static int PointGroupToInt(List<Point> pointGroup)
        {
            var orderedPointGroupToString = pointGroup.OrderBy(p => p.X).Select(p => p.Contents.ToString()).ToList();
            return int.Parse(string.Join(string.Empty, orderedPointGroupToString));
            
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
            public int XMax => Points.Select(p => p.X).Max();
            public int YMax => Points.Select(p => p.Y).Max();
            public IEnumerable<IGrouping<int, Point>> PointGroupingsByRow => Points.GroupBy(p => p.Y);
            public List<PointGroup> DigitPointGroups = new List<PointGroup>();

            public Point GetPointByCoordinates(int x, int y)
            {
                return Points.Where(p => p.X == x && p.Y == y).FirstOrDefault();
            }
            public Point GetNextPointInRow(Point point)
            {
                var nextXCoord = point.X + 1;
                if (nextXCoord <= XMax)
                {
                    return GetPointByCoordinates(nextXCoord, point.Y);
                }
                else
                {
                    return null;
                }
            }

            public void PopulateDigitPointGroups()
            {
                foreach (var pointGroup in PointGroupingsByRow)
                {
                    DigitPointGroups.AddRange(GetDigitPointGroupsForRow(pointGroup.FirstOrDefault(p => p.X == 0)));
                }
            }

            private List<PointGroup> GetDigitPointGroupsForRow(Point point)
            {
                var id = 0;
                var bigPointGroup = new List<PointGroup>();

                var currXCoord = point.X;
                var currPoint = point;
                while (currPoint != null && currXCoord <= XMax)
                {
                    var pointGroup = new PointGroup(id);
                    while (currPoint != null && currPoint.IsDigit && currXCoord <= XMax)
                    {
                        pointGroup.Points.Add(currPoint);
                        currPoint = GetNextPointInRow(currPoint);
                        if (currPoint != null)
                        {
                            currXCoord = currPoint.X;
                        }
                        
                    }

                    if (pointGroup.Points.Count > 0)
                    {
                        bigPointGroup.Add(pointGroup);
                        id++;
                    }
                    
                    if (currPoint != null)
                    {
                        currPoint = GetNextPointInRow(currPoint);
                        if (currPoint != null)
                        {
                            currXCoord = currPoint.X;
                        }
                    }
                }

                return bigPointGroup;
            }

            public List<Point> GetAdjacentPoints(Point point)
            {
                var adjacentPoints = new List<Point>();

                //vertical neighbors
                if (point.Y - 1 >= 0)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X, point.Y - 1));
                }
                if (point.Y + 1 <= YMax)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X, point.Y + 1));
                }

                //horizontal neighbors
                if (point.X - 1 >= 0)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X - 1, point.Y));
                }
                if (point.X + 1 <= XMax)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X + 1, point.Y));
                }

                //diagonal neighbors
                if (point.X - 1 >= 0 && point.Y - 1 >= 0)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X - 1, point.Y - 1));
                }
                if (point.X - 1 >= 0 && point.Y + 1 <= YMax)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X - 1, point.Y + 1));
                }
                if (point.X + 1 <= XMax && point.Y + 1 <= YMax)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X + 1, point.Y + 1));
                }
                if (point.X + 1 <= XMax && point.Y - 1 >= 0)
                {
                    adjacentPoints.Add(GetPointByCoordinates(point.X + 1, point.Y - 1));
                }

                return adjacentPoints;
            }

            public void DrawSchematic()
            {
                foreach (var pointGroup in PointGroupingsByRow)
                {
                    var pointList = pointGroup.ToList();
                    Console.WriteLine(string.Join(string.Empty,pointList.Select(x => x.Contents)));
                }
            }

            public bool IsPointGroupAdjacentToSymbol(PointGroup pointGroup)
            {
                foreach (var point in pointGroup.Points)
                {
                    if(GetAdjacentPoints(point).Any(p => p.IsSymbol))
                        return true;
                }
                return false;
            }

            public HashSet<PointGroup> GetDigitPointGroupsAdjacentToGear(Point gear)
            {
                var uniquePointGroups = new HashSet<PointGroup>();
                var adjacentPoints = GetAdjacentPoints(gear).Where(g => g.IsDigit);
                foreach (var ap in adjacentPoints)
                {
                    var digitPointGroup = GetDigitPointGroupByPoint(ap);
                    if (digitPointGroup != null)
                    {
                        uniquePointGroups.Add(digitPointGroup);
                    }
                }
           
                return uniquePointGroups;
            }

            public PointGroup GetDigitPointGroupByPoint(Point point)
            {
                var digitPointGroup = DigitPointGroups.Where(p => p.Points.Contains(point)).ToList();
                return digitPointGroup.Count > 0 ? digitPointGroup[0] : null;
            }

        }

        public class Point
        {
            public int Id { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public char Contents { get; set; }
            public bool IsSymbol => !int.TryParse(Contents.ToString(), out int _) && Contents != '.';
            public bool IsDigit => Common.Utilities.IsCharDigit(Contents).IsDigit;
            public bool IsGear => Contents == '*';
            public int GetIntValueFromContents => !IsDigit ? -1 : (int)Common.Utilities.IsCharDigit(Contents).DigitValue;
        }

        public class PointGroup
        {
            public int Id {get; set;}
            public List<Point> Points = new List<Point>();

            public PointGroup (int id)
            {
                Id = id;
            }
        }


        #endregion
    }
}
