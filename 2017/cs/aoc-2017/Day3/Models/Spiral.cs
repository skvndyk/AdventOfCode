using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3.Models
{
    public class Spiral
    {
        public enum PuzzlePart
        {
            Part1,
            Part2
        };

        public Spiral(int maxVal, PuzzlePart puzzlePart, int testValue = 0)
        {
            Squares = new List<Square>();
            Squares.Add(new Square()
            {
                value = 1,
                x = 0,
                y = 0
            });
            int dirIdx = 0;
            Square currSquare = Squares[0];
            string dirKey;

            for (int i = 1; i < maxVal; i++)
            {
                dirKey = SquareMovement.Directions[dirIdx];
                Square movedToSquare = SquareMovement.Move(this, currSquare, dirKey);
                //keep moving in this direction till you find a new square, then set its value
                while (movedToSquare.value != null)
                {
                    dirIdx = SquareMovement.Directions.GetPreviousIndex(dirIdx);
                    dirKey = SquareMovement.Directions[dirIdx];
                    movedToSquare = SquareMovement.Move(this, currSquare, dirKey);
                }
                movedToSquare.value = GetSquareValue(currSquare, movedToSquare, puzzlePart);
                if (testValue != 0)
                {
                    if (movedToSquare.value > testValue)
                    {
                        Squares.Add(movedToSquare);
                        break;
                    }
                }
                //then cycle to next direction
                dirIdx = SquareMovement.Directions.GetNextIndex(dirIdx);
                currSquare = movedToSquare;
                Squares.Add(currSquare);
            }
        }

        public int GetSquareValue(Square currSquare, Square movedToSquare, PuzzlePart puzzlePart)
        {
            if (puzzlePart == PuzzlePart.Part1)
            {
                return currSquare.value + 1 ?? throw new Exception("Current square does not have a value!");
            }
            else
            {
                int x = movedToSquare.x;
                int y = movedToSquare.y;

                List<Tuple<int, int>> neighborList = new List<Tuple<int, int>>()
                {
                    Tuple.Create(x, y + 1),
                    Tuple.Create(x, y - 1),
                    Tuple.Create(x - 1, y),
                    Tuple.Create(x + 1, y),
                    Tuple.Create(x - 1, y + 1),
                    Tuple.Create(x + 1, y + 1),
                    Tuple.Create(x - 1, y - 1),
                    Tuple.Create(x + 1, y - 1)

                };
                int squareSum = 0;
                foreach (Tuple<int, int> nTuple in neighborList)
                {
                    if (Squares.Any(s => s.x == nTuple.Item1 && s.y == nTuple.Item2))
                    {
                        squareSum += Squares.First(s => s.x == nTuple.Item1 && s.y == nTuple.Item2).value ?? throw new Exception("Square has no value!");
                    }
                }
                return squareSum;
            }
        }

     
        //todo this doesn't work with non-square spiral sizes
        public void PrintSpiral()
        {
            int valuesPrinted = 0;
            List<Square> availableSquares = Squares;
            while (valuesPrinted < Squares.Count )
            {
                Dictionary<string, int> minMaxDict = GetMinsAndMaxes(availableSquares);
                int y = minMaxDict["maxY"];
                int minX = minMaxDict["minX"];
                int maxX = minMaxDict["maxX"];
                List<Square> squareRow = new List<Square>();
                for (int i = minX; i <= maxX; i++)
                {
                    squareRow.Add(availableSquares.First(s => s.x == i && s.y == y));
                    valuesPrinted += 1;
                }
                string printingRow = "";
                foreach (Square square in squareRow)
                {
                    printingRow += $"{square.value}\t";
                }
                Console.WriteLine(printingRow);
                availableSquares = availableSquares.Where(s => squareRow.All(r => s.value != r.value)).ToList();
            }
        }

        public int GetManhattanDistanceToCenter(int squareValue)
        {
            Square startSquare = Squares.First(s => s.value == squareValue);
            if (startSquare == null)
            {
                throw new Exception($"Square {squareValue} does not exist.");
            }
            return Math.Abs(startSquare.x) + Math.Abs(startSquare.y);
        }

        public Dictionary<string, int> GetMinsAndMaxes(List<Square> squares)
        {
            return new Dictionary<string, int>()
            {
                { "minX", squares.Min(s => s.x)},
                { "maxX", squares.Max(s => s.x)},
                { "minY", squares.Min(s => s.y)},
                { "maxY", squares.Max(s => s.y)},
            };
        } 

        public List<Square> Squares { get; set; }
    }
}
