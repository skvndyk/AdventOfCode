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
            int rise = 3;
            int run = 1;
            var inputLines = Common.Utilities.ReadFileToStrings(exFilePath);
            ParseInputFile1(inputLines, rise, run);
            //Console.WriteLine($@"Part 2: {ParseInputFile2(inputLines)}");
            Console.ReadLine();
        }

        private static void ParseInputFile1(List<string> inputLines, int rise, int run)
        {
            var grid = new Grid();
            Setup(inputLines, grid);
            
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
                    row.Squares.Add(new Square()
                    {
                        XCoord = colCtr,
                        YCoord = rowCtr,
                        Contents = symbol
                    });
                    colCtr++;
                }

                Console.WriteLine(row.ToString());
                grid.Rows.Add(row);
                rowCtr++;
            }
        }


        private static void ApplySlope(Grid grid)
        {

        }

        public class Grid
        {
            public List<Row> Rows { get; set; } = new List<Row>();
            public int Rise { get; set; }
            public int Run { get; set; }

            public Grid(int rise, int run)
            {
                Rise = rise;
                Run = run;
            }
        }

        public class Row
        {
            public int RowNum { get; set; }
            public List<Square> Squares { get; set; } = new List<Square>();
            public override string ToString() => new string(Squares.Select(s => s.Contents).ToArray());
        }

        public class Square
        {
            public int XCoord { get; set; }
            public int YCoord { get; set; }
            public char Contents { get; set; }
            public Annotation Annotation = Annotation.None;
        }

        public class Slope
        {
            int Rise { get; set; }
            int Run { get; set; }
        }
        public enum Annotation { None, X, O }
    }
}
