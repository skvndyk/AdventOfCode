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
        public Spiral(int maxVal)
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
                    dirIdx -= 1;
                    dirKey = SquareMovement.Directions[dirIdx];
                    movedToSquare = SquareMovement.Move(this, currSquare, dirKey);
                }
                movedToSquare.value = currSquare.value + 1;

                //then cycle to next direction
                dirIdx = SquareMovement.Directions.GetNextIndex(dirIdx);
                currSquare = movedToSquare;
                Squares.Add(currSquare);
            }
        }

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
                    printingRow += $"{square.value.ToString()}\t";
                }
                Console.WriteLine(printingRow);
                availableSquares = availableSquares.Where(s => squareRow.All(r => s.value != r.value)).ToList();
            }
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
