using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Models
{
    public class Grid
    {
        public List<Point> Points { get; set; }

        public int MaxX => Points.Max(p => p.InitialPosition.X);
        public int MinX => Points.Min(p => p.InitialPosition.X);

        public int MaxY => Points.Max(p => p.InitialPosition.Y);
        public int MinY => Points.Min(p => p.InitialPosition.Y);

        public void ApplyVelocities()
        {
            foreach (var point in Points)
            {
                point.ApplyVelocity();
            }
        }

        public void PrintGrid()
        {
            List<string> toPrint = new List<string>();

            for (int y = MinY; y <= MaxY; y++)
            {
                string lineToPrint = "";

                for (int x = MinX; x <= MaxX; x++)
                {
                    if (Points.Any(p => p.CurrentPosition.X == x && p.CurrentPosition.Y == y))
                    {
                        lineToPrint += "#";
                    }
                    else
                    {
                        lineToPrint += ".";
                    }
                }

                toPrint.Add(lineToPrint);
            }

            Console.WriteLine(string.Join("\n", toPrint));
        }
    }
}
