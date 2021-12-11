using System;
using System.Linq;
using System.Collections.Generic;

namespace Day4_2021
{
    public class Program
    {
        public static List<List<Coords>> _winningCoords = new List<List<Coords>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day4-2021.txt";
            string exFilePath = "day4-ex-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);
            Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            //ParseInputLinesPart2(inputStrings);
            Console.ReadLine();
        }

        public static int ParseInputLinesPart1(List<string> inputStrings)
        {
            int winningStep = 0;
            var game = ParseInput(inputStrings);
            foreach (var step in game.Steps)
            {
                if (!game.Boards.Any(b => b.IsWinningBoard))
                {
                    foreach (var b in game.Boards)
                    {
                        b.ApplyStep(step);
                        if (b.IsWinningBoard)
                        {
                            winningStep = step;
                            break;
                        }
                    }
                }
                else 
                {
                    var winningBoard = game.Boards.First(b => b.IsWinningBoard);
                    var unmarkedSquaresSum = winningBoard.AllSquares.Where(s => !winningBoard.MarkedSquares.Contains(s)).Sum(s => s.Contents);
                    return unmarkedSquaresSum * winningStep;

                }
            }
            throw new NotImplementedException();
        }

        public static Game ParseInput(List<string> inputStrings)
        {
            var rawStepsStrings = inputStrings[0];
            var rawSteps = rawStepsStrings.Split(",").ToList().Select(s => int.Parse(s)).ToList();

            var game = new Game(rawSteps);

            var rawBoards = new List<List<int>>();
            var board = new Board();
            var rowNum = 0;
            for (int i = 2; i < inputStrings.Count; i++)
            {
                if (inputStrings[i] != string.Empty)
                {
                    
                    var rawRow = inputStrings[i].Split(" ").ToList();
                    rawRow.RemoveAll(s => s == string.Empty);
                    board.SetRow(rowNum, rawRow.Select(r => int.Parse(r)).ToList());
                    rowNum++;
                }
                else
                {
                    game.Boards.Add(board);
                    board = new Board();
                    rowNum = 0;
                }
            }

            game.Boards.Add(board);
            return game;
        }

        public class Game
        {
            public List<int> Steps { get; set; }
            public List<Board> Boards { get; set; }

            public Game(List<int> rawSteps, int? boardLength=5)
            {
                Steps = rawSteps;
                Boards = new List<Board>();
            }
        }

        public class Board
        {
            public List<Square> AllSquares { get; set; }
            public IEnumerable<Square> MarkedSquares => AllSquares.Where(s => s.IsMarked);
            public int SideLength { get; set; }
            public bool IsWinningBoard { get; set; } = false;
            public Board(int? sideLength=5)
            {
                SideLength = sideLength ?? 5;
                AllSquares = new List<Square>();
            }

            public Square GetSquareByCoords(int x, int y)
            {
                return AllSquares.Where(s => s.XCoord == x && s.YCoord == y).First();
            }

            public Square GetSquareByContents(int contents) { return AllSquares.First(s => s.Contents == contents); }

            public void SetRow(int rowNum, List<int> rowContents)
            {
                for (int i = 0; i < SideLength; i++)
                {
                    AllSquares.Add(new Square(i, rowNum, rowContents[i]));
                }
            }

            private bool CheckBoardForWinner()
            {
                var range = Enumerable.Range(0, SideLength);
                var foundWinner = false;
                if (MarkedSquares.Count() > SideLength)
                {
                    for (int x = 0; x < SideLength; x++)
                    {
                        foundWinner = range.All(j => GetSquareByCoords(x, j).IsMarked);
                        if (foundWinner)
                        {
                            break;
                        }
                    }

                    if (!foundWinner)
                    {
                        for (int y = 0; y < SideLength; y++)
                        {
                            foundWinner = range.All(j => GetSquareByCoords(j, y).IsMarked);
                            if (foundWinner)
                            {
                                break;
                            }
                        }
                    }
                   
                    return foundWinner;
                }
               
                return false;
            }
            public void ApplyStep(int step)
            {
                GetSquareByContents(step).IsMarked = true;

                if (CheckBoardForWinner())
                {
                    IsWinningBoard = true;
                }
            }
        }

        public class Square
        {
            public int XCoord { get; set; }
            public int YCoord { get; set; }
            public int Contents { get; set; }
            public bool IsMarked { get; set; } = false;
            public bool IsWinningSquare { get; set; } = false;

            public Square() { }
            public Square(int x, int y)
            {
                XCoord = x;
                YCoord = y;
            }
            public Square(int x, int y, int contents)
            {
                XCoord = x;
                YCoord = y;
                Contents = contents;
            }

            
        }
        public class Coords
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Coords(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
