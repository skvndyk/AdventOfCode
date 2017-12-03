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
                    movedToSquare = SquareMovement.Move(this, currSquare, dirKey);
                }
                movedToSquare.value = currSquare.value + 1;

                //then cycle to next direction
                dirIdx = SquareMovement.Directions.GetNextIndex(dirIdx);
                currSquare = movedToSquare;
                Squares.Add(currSquare);
            }
        }       
        public List<Square> Squares { get; set; }
    }
}
