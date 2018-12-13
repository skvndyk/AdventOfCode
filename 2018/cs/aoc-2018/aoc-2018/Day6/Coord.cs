using System;

namespace Day6
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coord ClosestNamedPoint { get; set; }

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