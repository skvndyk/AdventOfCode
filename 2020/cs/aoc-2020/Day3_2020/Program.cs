using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3_2020
{
    class Program
    {
        public static void Main(string[] args)
        {
            var exFilePath = "day3-ex-2020.txt";
            var filePath = "day3-2020.txt";
            int rise = 1;
            int run = 3;
            var inputLines = Common.Utilities.ReadFileToStrings(filePath);
            ParseInputFile1(inputLines, rise, run);
            Console.WriteLine($@"Part 2: {ParseInputFile1(inputLines, rise, run)} trees encountered");
            Console.ReadLine();
        }

        private static int ParseInputFile1(List<string> inputLines, int rise, int run)
        {
            var grid = new Grid(rise, run);
            Setup(inputLines, grid);
            while (grid.TobogganSquare.YCoord < grid.Rows.Count -1)
            {
                grid.MoveToboggan();
            }
            return grid.TreesEncountered;
            
        }

        public static void Setup(List<string> inputLines, Grid grid)
        {
            var rowCtr = 0;

            Console.WriteLine("Initial Config");

            foreach (var line in inputLines)
            {
                var row = new Row { RowNum = rowCtr };
                var colCtr = 0;

                foreach (var symbol in line)
                {
                    row.OriginalSquares.Add(new Square()
                    {
                        XCoord = colCtr,
                        YCoord = rowCtr,
                        Contents = symbol
                    });
                    colCtr++;
                }

                var list = new List<Square>();
                row.CurrentSquares = row.OriginalSquares.Select(s => s.Copy()).ToList();

                //optional writing to console

                //Console.WriteLine(row.ToString());
                grid.Rows.Add(row);

                rowCtr++;
            }

            grid.TobogganSquare = grid.GetSquareByCoordinates(0, 0);
        }



        public class Grid
        {
            public List<Row> Rows { get; set; }
            public int Rise { get; set; }
            public int Run { get; set; }
            public Square TobogganSquare { get; set; }
            public int TreesEncountered { get; set; }
            public int TobogganCounter { get; set; }
            public Grid(int rise, int run)
            {
                Rise = rise;
                Run = run;
                Rows = new List<Row>();
                TreesEncountered = 0;
                TobogganCounter = 0;
            }

            public Square GetSquareByCoordinates(int xCoord, int yCoord)
            {
                var targetRow = Rows[yCoord];
                while (targetRow.CurrentSquares.Count <= xCoord)
                {
                    targetRow.ExtendRow();
                }
                return targetRow.CurrentSquares[xCoord];
            }

            public void MoveToboggan()
            {
                TobogganSquare = GetSquareByCoordinates(TobogganSquare.XCoord + Run, TobogganSquare.YCoord + Rise);
                switch (TobogganSquare.Contents)
                {
                    case '.':
                        TobogganSquare.Contents = 'O';
                        break;
                    case '#':
                        TobogganSquare.Contents = 'X';
                        TreesEncountered++;
                        break;
                }
                TobogganCounter++;

                //optional writing to console

                //Console.Clear();
                //Console.WriteLine($@"Step {TobogganCounter}");
                //Rows.ForEach(r => Console.WriteLine(r.ToString()));
                //Console.ReadLine();
            }
        }

        public class Row
        {
            public int RowNum { get; set; }
            public List<Square> CurrentSquares { get; set; } = new List<Square>();
            public List<Square> OriginalSquares { get; set; } = new List<Square>();
            public override string ToString() => new string(CurrentSquares.Select(s => s.Contents).ToArray());
            public void ExtendRow()
            {
                var xCoordStart = CurrentSquares.Count;
                foreach (var square in OriginalSquares)
                {
                    var newSquare = square.Copy();
                    newSquare.XCoord = xCoordStart;
                    CurrentSquares.Add(newSquare);
                    xCoordStart++;
                }
            }
        }

        public class Square
        {
            public int XCoord { get; set; }
            public int YCoord { get; set; }
            public char Contents { get; set; }

            public Square Copy()
            {
                return new Square
                {
                    XCoord = XCoord,
                    YCoord = YCoord,
                    Contents = Contents
                };
            }
        }

    }
}
