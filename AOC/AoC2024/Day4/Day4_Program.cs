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

            //Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings1)}");
            Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings2)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var grid = SetupGrid(inputStrings);
            //grid.PrintGrid();
            var stringNum = CountNumberOfXmasStrings(grid);
            return stringNum;
        }

        private static int Part2(List<string> inputStrings)
        {
            CountNumberOfMasStrings(SetupGrid(inputStrings));
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

        private static int CountNumberOfMasStrings(Grid grid)
        {
            //find A first
            var numStrings = 0;
            var aCells = grid.GetCellsWithValue("A");
            var cellsToKeepList = new List<Cell>();
            foreach (var aCell in aCells)
            {
                var masCells = MasSearch(grid, aCell);
                if (masCells.Any())
                {
                    cellsToKeepList.AddRange(masCells);
                    numStrings++;
                }
            }

            var cellsToKeepHash = new HashSet<Cell>(cellsToKeepList);


            foreach (var cell in grid.Cells.Except(cellsToKeepHash))
            {
                cell.Value = ".";
            }

            grid.PrintGrid();


            return numStrings;
        }

        private static int CountNumberOfXmasStrings(Grid grid)
        {
            var numStrings = 0;
            var xCells = grid.GetCellsWithValue("X");

            var cellsToKeepList = new List<Cell>();
            foreach (var xCell in xCells)
            {
                //look right
                var lookRightCells = GenericSearch(grid, xCell, Add, null);
                if (lookRightCells.Any())
                {
                    cellsToKeepList.AddRange(lookRightCells);
                    numStrings++;
                }

                //look left
                var lookLeftCells = GenericSearch(grid, xCell, Subtract, null);
                if (lookLeftCells.Any())
                {
                    cellsToKeepList.AddRange(lookLeftCells);
                    numStrings++;
                }

                //look up
                var lookUpCells = GenericSearch(grid, xCell, null, Subtract);
                if (lookUpCells.Any())
                {
                    cellsToKeepList.AddRange(lookUpCells);
                    numStrings++;
                }

                //look down
                var lookDownCells = GenericSearch(grid, xCell, null, Add);
                if (lookDownCells.Any())
                {
                    cellsToKeepList.AddRange(lookDownCells);
                    numStrings++;
                }

                //look upper left
                var lookUpperLeftCells = GenericSearch(grid, xCell, Subtract, Subtract);
                if (lookUpperLeftCells.Any())
                {
                    cellsToKeepList.AddRange(lookUpperLeftCells);
                    numStrings++;
                }
                
                //look upper right
                var lookUpperRightCells = GenericSearch(grid, xCell, Add, Subtract);
                if (lookUpperRightCells.Any())
                {
                    cellsToKeepList.AddRange(lookUpperRightCells);
                    numStrings++;
                }

                //look lower left
                var lookLowerLeftCells = GenericSearch(grid, xCell, Subtract, Add);
                if (lookLowerLeftCells.Any())
                {
                    cellsToKeepList.AddRange(lookLowerLeftCells);
                    numStrings++;
                }

                //look lower right
                var lookLowerRightCells = GenericSearch(grid, xCell, Add, Add);
                if (lookLowerRightCells.Any())
                {
                    cellsToKeepList.AddRange(lookLowerRightCells);
                    numStrings++;
                }
               
            }

            var cellsToKeepHash = new HashSet<Cell>(cellsToKeepList);


            foreach (var cell in grid.Cells.Except(cellsToKeepHash))
            {
                cell.Value = ".";
            }

            //grid.PrintGrid();

            return numStrings;
        }

        private static int Add(int a, int b)
        {
            var val = a + b;
            return val;
        }

        private static int Subtract(int a, int b)
        {
            var val = a - b;
            return val;
        }


        private static List<Cell> MasSearch(Grid grid, Cell aCell)
        {
            var letters = new List<string> { "M", "S" };
            var counter = 0;
            var potentialCellsToKeep = new List<Cell>() { aCell };
            var breakFlag = false;

            (Func<int, int, int> xOp, Func<int, int, int> yOp) upperLeft = (Subtract, Subtract);
            (Func<int, int, int> xOp, Func<int, int, int> yOp) lowerRight = (Add, Add);
            (Func<int, int, int> xOp, Func<int, int, int> yOp) upperRight = (Add, Subtract);
            (Func<int, int, int> xOp, Func<int, int, int> yOp) lowerLeft = (Subtract, Add);

            var upperLeftXCoord = upperLeft.xOp(aCell.X, 1);
            var upperLeftYCoord = upperLeft.yOp(aCell.Y, 1);

            var cellExists = grid.CellExists(upperLeftXCoord, upperLeftYCoord);
            if (cellExists.DoesExist)
            {
                var potentialCell = cellExists.Cell;
                if (potentialCell != null && letters.Contains(potentialCell.Value))
                {
                    potentialCellsToKeep.Add(potentialCell);
                    letters.Remove(letters.First(l => l == potentialCell.Value));
                }

                else return [];
            }
            else return [];

            var lowerRightXCoord = lowerRight.xOp(aCell.X, 1);
            var lowerRightYCoord = lowerRight.yOp(aCell.Y, 1);

            cellExists = grid.CellExists(lowerRightXCoord, lowerRightYCoord);
            if (cellExists.DoesExist)
            {
                var potentialCell = cellExists.Cell;
                if (potentialCell != null && letters.Contains(potentialCell.Value))
                {
                    potentialCellsToKeep.Add(potentialCell);
                }
                else return [];
            }
            else return [];

            //////////check next axis

            letters = ["M", "S"];

            var upperRightXCoord = upperRight.xOp(aCell.X, 1);
            var upperRightYCoord = upperRight.yOp(aCell.Y, 1);

            cellExists = grid.CellExists(upperRightXCoord, upperRightYCoord);
            if (cellExists.DoesExist)
            {
                var potentialCell = cellExists.Cell;
                if (potentialCell != null && letters.Contains(potentialCell.Value))
                {
                    potentialCellsToKeep.Add(potentialCell);
                    letters.Remove(letters.First(l => l == potentialCell.Value));
                }

                else return [];
            }
            else return [];

            var lowerLeftXCoord = lowerLeft.xOp(aCell.X, 1);
            var lowerLeftYCoord = lowerLeft.yOp(aCell.Y, 1);

            cellExists = grid.CellExists(lowerLeftXCoord, lowerLeftYCoord);
            if (cellExists.DoesExist)
            {
                var potentialCell = cellExists.Cell;
                if (potentialCell != null && letters.Contains(potentialCell.Value))
                {
                    potentialCellsToKeep.Add(potentialCell);
                }
            }
            else return [];

            return potentialCellsToKeep;
        }


        private static List<Cell> GenericSearch(Grid grid, Cell xCell, Func<int, int, int>? xOp, Func<int, int, int>? yOp)
        {
            var letters = new List<string> { "M", "A", "S" };
            var counter = 0;
            var potentialCellsToKeep = new List<Cell>() { xCell };
            var newXCell = new Cell(xCell.X, xCell.Y, xCell.Value);
            var breakFlag = false;
            while (counter < 3 && !breakFlag)
            {
                var xCoord = xOp == null ? newXCell.X : xOp(newXCell.X, 1);
                var yCoord = yOp == null ? newXCell.Y : yOp(newXCell.Y, 1);

                var cellExists = grid.CellExists(xCoord, yCoord);
                if (cellExists.DoesExist)
                {
                    var potentialCell = cellExists.Cell;
                    if (potentialCell != null && potentialCell.Value == letters[counter])
                    {
                        potentialCellsToKeep.Add(potentialCell);
                        newXCell = potentialCell;
                    }
                    else
                    {
                        breakFlag = true;
                        break;
                    }
                }

                else
                {
                    breakFlag = true;
                    break;
                }

                counter++;
            }

            if (potentialCellsToKeep.Count == 4)
            {
                return potentialCellsToKeep;
            }
            return new List<Cell>();
        }

        private static int GetSecondInt(Func<int, int, int>? op, int counter) => op == null ? 0 : counter;

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

            public (bool DoesExist, Cell Cell) CellExists(int x, int y)
            {
                Cell cellToReturn = null;
                var cellMatchExists = Cells.Any(c => c.X == x && c.Y == y);
                if (cellMatchExists)
                {
                    cellToReturn = GetCell(x, y);
                }

                return (cellMatchExists, cellToReturn);
            }

            public void AddCell(Cell cell)
            {
                Cells.Add(cell);
            }

            public void PrintGrid()
            {
                var lineToPrint = new List<string>();
                for (int y = 0; y <= MaxY; y++)
                {
                    lineToPrint = new List<string>();
                    for (int x = 0; x <= MaxX; x++)
                    {
                        var cellExists = CellExists(x, y);
                        if (cellExists.DoesExist)
                        {
                            lineToPrint.Add(cellExists.Cell.Value);
                        }
                    }
                    Console.WriteLine(string.Join("", lineToPrint));
                }
            }

            public List<Cell> GetCellsWithValue(string value) => Cells.Where(c => c.Value == value).ToList();

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
