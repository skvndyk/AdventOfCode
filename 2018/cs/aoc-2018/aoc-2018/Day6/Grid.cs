using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Day6
{
    public class Grid
    {
        public List<Point> Points { get; set; } = new List<Point>();
        public Point UpperBoundary => Points.FirstOrDefault(p => p.Y == Points.Max(p1 => p1.Y));
        public Point LowerBoundary => Points.FirstOrDefault(p => p.X == Points.Min(p1 => p1.X) && p.Y == Points.Max(p2 => p2.Y));
        public Point LowerLeft => Points.FirstOrDefault(p => p.X == Points.Min(p1 => p1.X) && p.Y == Points.Min(p2 => p2.Y));
        public Point LowerRight => Points.FirstOrDefault(p => p.X == Points.Max(p1 => p1.X) && p.Y == Points.Min(p2 => p2.Y));
        public bool DoesPointExistAtCoord(int x, int y) => Points.Contains(new Point(x, y));

     
    }
}