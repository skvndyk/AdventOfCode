using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6
{
    public class Program
    {
        public static readonly Regex _coordRegx = new Regex(@"(?<x>\d+), (?<y>\d+)");
        static void Main(string[] args)
        {
            string filePath = "day6-2018.txt";
            List<string> lines = ReadTextIntoLines(filePath);
            List<Point> points = ReadLinesIntoCoords(lines);
            Console.WriteLine($"Part 1: {Part1(points)}");
            //Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();

        }

        public static int Part1(List<Point> points)
        {
            throw new NotImplementedException();
        }

        public static int Part2(List<Point> points)
        {
            throw new NotImplementedException();
        }

        public static void DisplayGrid(List<Point> points)
        {
            Grid grid = new Grid(){ Points = points };
            for (int x = grid.LowerLeft.X; x < grid.LowerRight.X; x++)
            {
                string line = "";
                for (int y = grid.LowerLeft.Y; y >= grid.UpperLeft.Y; y++)
                {
                    line += grid.DoesPointExistAtCoord(x, y) ? "X" : ".";
                }
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        public static List<Point> ReadLinesIntoCoords(List<string> lines)
        {
            return lines.Select(ReadLineIntoCoord).ToList();
        }

        public static Point ReadLineIntoCoord(string line)
        {
            Match match = _coordRegx.Match(line);
            if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
            GroupCollection groups = match.Groups;
            return new Point (int.Parse(groups["x"].Value), int.Parse(groups["y"].Value));
        }

        
        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
