using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AoC2024.Day4
{
    class Day4_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day4\inputFileDay4-2024.txt";
            string exFilePath1 = $@"Day4\exInputFileDay4-2024_P1.txt";
            string exFilePath2 = $@"Day4\exInputFileDay4-2024_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings1)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings2)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var grid = SetupGrid(inputStrings);
            grid.PrintGrid();
            var numTimes = 0;
            
            return numTimes;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;   
        }

        private static Grid SetupGrid(List<string> inputStrings)
        {
            var grid = new Grid();
            for (var i = 0; i < inputStrings.Count; i++)
            {
                var row = inputStrings[i];
                for (var j = 0; j < row.Length; j++)
                {
                    var cell = new Cell(j, i, row[j].ToString());
                    grid.AddCell(cell);
                }
            }
            return grid;
        }

        #region lil classes
        private class Grid
        {
            public List<Cell> Cells { get; set; } = new List<Cell>();

            public int MaxX => Cells.Select(Cells => Cells.X).Max();
            public int MinX => Cells.Select(Cells => Cells.X).Min();
            public int MaxY => Cells.Select(Cells => Cells.Y).Max();
            public int MinY => Cells.Select(Cells => Cells.Y).Min();

            public Grid()
            {

            }

            public Grid(List<Cell> cells)
            {
                Cells = cells;
            }

            public Cell? GetCell(int x, int y)
            {
                return Cells.FirstOrDefault(c => c.X == x && c.Y == y);
            }

            public bool CellExists(int x, int y)
            {
                return Cells.Any(c => c.X == x && c.Y == y);
            }

            public void AddCell(Cell cell)
            {
                Cells.Add(cell);
            }

            public void PrintGrid()
            {
                var lineToPrint = new List<string>();
                for (int y = 0; y < MaxY; y++)
                {
                    lineToPrint = new List<string>();
                    for (int x = 0; x < MaxX; x++)
                    {
                        if (CellExists(x, y))
                        {
                            lineToPrint.Add(GetCell(x, y).Value);
                        }
                    }
                    Console.WriteLine(string.Join("", lineToPrint));
                }
            }

            public Cell? MoveLeft(Cell cell) => GetCell(cell.X - 1, cell.Y);
            public Cell? MoveRight(Cell cell) => GetCell(cell.X + 1, cell.Y);
            public Cell? MoveUp(Cell cell) => GetCell(cell.X, cell.Y - 1);
            public Cell? MoveDown(Cell cell) => GetCell(cell.X, cell.Y + 1);
            public Cell? MoveUpperRight(Cell cell) => GetCell(cell.X + 1, cell.Y + 1);
            public Cell? MoveLowerLeft(Cell cell) => GetCell(cell.X - 1, cell.Y - 1);
            public Cell? MoveLowerRight(Cell cell) => GetCell(cell.X + 1, cell.Y - 1);
        }
         
        private class Cell
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Value { get; set; }

            public Cell()
            {

            }
            public Cell(int x, int y, string value)
            {
                X = x;
                Y = y;
                Value = value;
            }

            public override string ToString()
            {
                return $"({X}, {Y}), {Value}";
            }
        }
        #endregion
    }
}
