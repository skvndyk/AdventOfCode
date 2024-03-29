﻿using System;
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
            List<Coord> points = ReadLinesIntoCoords(lines);
            Console.WriteLine($"Part 1: {Part1(points)}");
            //Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();

        }

        public static int Part1(List<Coord> points)
        {
            throw new NotImplementedException();
        }

        public static int Part2(List<Coord> points)
        {
            throw new NotImplementedException();
        }

        public static void DisplayGrid(List<Coord> points)
        {
            Grid grid = new Grid(points);
            for (int y = grid.MinYCoord.Y; y <= grid.MaxYCoord.Y; y++)
            {
                string line = "";
                for (int x = grid.MinXCoord.X; x <= grid.MaxXCoord.X; x++)
                {
                    grid.GetClosestNamedPoint(new Coord() {X = x, Y = y});
                    line += grid.DoesNamedPointExistAtCoord(x, y) ? "X" : "o";
                }
                Console.WriteLine(line);
            }
        }

        public static List<Coord> ReadLinesIntoCoords(List<string> lines)
        {
            return lines.Select(ReadLineIntoCoord).ToList();
        }

        public static Coord ReadLineIntoCoord(string line)
        {
            Match match = _coordRegx.Match(line);
            if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
            GroupCollection groups = match.Groups;
            return new Coord (){ X = int.Parse(groups["x"].Value), Y = int.Parse(groups["y"].Value)};
        }

        
        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
