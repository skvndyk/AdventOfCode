using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3.Models
{
    public static class SquareMovement
    {
        public static readonly List<string> Directions = new List<string>() { "r", "u", "l", "d" };
        public static readonly Dictionary<string, Tuple<int, int>> DirDict = new Dictionary<string, Tuple<int, int>>()
        {
            { "r", Tuple.Create(1, 0) },
            { "u", Tuple.Create(0, 1) },
            { "l", Tuple.Create(-1, 0) },
            { "d", Tuple.Create(0, -1) }
        };
        public static Square Move(Spiral spiral, Square square, string direction)
        {
            Tuple<int, int> outTuple;
            if(DirDict.TryGetValue(direction, out outTuple))
            {
                int newX = square.x + outTuple.Item1;
                int newY = square.y + outTuple.Item2;
                List<Square> newSquares = spiral.Squares.Where(s => s.x == newX && s.y == newY).ToList();
                if (newSquares.Count() == 0)
                {
                    return new Square() { x = newX, y = newY };
                }
                if (newSquares.Count() == 1)
                {
                    return newSquares.First();
                }
                else
                {
                    throw new Exception($"Multiple squares found at location {square.x}, {square.y}");
                }                
            }
            else
            {
                throw new Exception($"Invalid direction of {direction} found.");
            }
        }
    }
   
}
