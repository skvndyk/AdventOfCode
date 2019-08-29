using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Models
{
    public class Point
    {
        public Position InitialPosition { get; set; }
        public Position CurrentPosition { get; set; }
        public Position Velocity { get; set; }

        public void ApplyVelocity()
        {
            CurrentPosition.X += Velocity.X;
            //for some reason their coord system has the Y-axis flipped
            CurrentPosition.Y += -Velocity.Y;
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
