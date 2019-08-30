using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class PowerCell
    {
        public Position TopLeftCorner { get; set; }
        public List<Position> PositionsCovered { get; set; }
        public bool FullyInGrid => !PositionsCovered.Any(p => p.X < 1 || p.X > 300 || p.Y < 1 || p.Y > 300);
        public void SetPositionsCovered()
        {
            if (TopLeftCorner != null)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        PositionsCovered.Add(new Position()
                        {
                            X = TopLeftCorner.X + x,
                            Y = TopLeftCorner.Y + y
                        });
                    }
                }
            }
        }

        public void SetTopLeftCorner()
        {
            if (PositionsCovered != null)
            {
                TopLeftCorner = PositionsCovered.Where(p => p.X == PositionsCovered.Min(p1 => p1.X) && 
                p.Y == PositionsCovered.Min(p2 => p2.Y)).First();
            }
        }
    }
}
