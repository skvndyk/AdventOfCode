using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class Square
    {
        public FuelCell TopLeftCorner { get; set; }
        public List<FuelCell> FuelCellsCovered { get; set; }
        public bool FullyInGrid => FuelCellsCovered.Count == 9;

        public Square(int x, int y, PowerGrid grid)
        {
            FuelCellsCovered = new List<FuelCell>();
            TopLeftCorner = grid.FuelCells.Where(c => c.X == x && c.Y == y).First();
            SetPositionsCovered(grid);
        }
        public void SetPositionsCovered(PowerGrid grid)
        {
            if (TopLeftCorner != null)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        var fuelCell = grid.FuelCells.Where(p => p.X == TopLeftCorner.X + x && p.Y == TopLeftCorner.Y + y).First();
                        FuelCellsCovered.Add(fuelCell);
                    }
                }
            }
        }

        public int TotalPower => FuelCellsCovered.Sum(f => f.PowerLevel);

        public override bool Equals(object value)
        {
            Square square = value as Square;

            return (TopLeftCorner == square.TopLeftCorner);
        }

        public override int GetHashCode()
        {
            var hashCode = 1095206954;
            hashCode = hashCode * -1521134295 + EqualityComparer<FuelCell>.Default.GetHashCode(TopLeftCorner);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<FuelCell>>.Default.GetHashCode(FuelCellsCovered);
            hashCode = hashCode * -1521134295 + FullyInGrid.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPower.GetHashCode();
            return hashCode;
        }
    }
}
