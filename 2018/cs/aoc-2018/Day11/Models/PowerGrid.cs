using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class PowerGrid
    {
        public List<Square> PowerCells { get; set; }
        public List<FuelCell> Positions { get; set; }
        public PowerGrid(int serialNum)
        {
            PowerCells = new List<Square>();
            int height = 300;
            int width = 300;
            for (int x = 1; x <= width; x++)
            {
                for (int y = 1; y <= height; y++)
                {
                    Positions.Add(new FuelCell(x, y, serialNum));
                }
            }
        }
    }
}
