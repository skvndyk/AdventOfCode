using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Models
{
    public class Coord
    {
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var c = obj as Coord;
            if (c == null) return false;
            return X == c.X && Y == c.Y;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ X.GetHashCode();
            hash = (hash * 397) ^ Y.GetHashCode();
            return hash;
        }
    }
}
