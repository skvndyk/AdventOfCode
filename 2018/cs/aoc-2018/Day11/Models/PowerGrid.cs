using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class PowerGrid
    {
        public List<Square> Squares { get; set; }
        public List<FuelCell> FuelCells { get; set; }
        public int Height = 300;
        public int Width = 300;
        public PowerGrid(int serialNum)
        {
            Squares = new List<Square>();
            FuelCells = new List<FuelCell>();
            for (int x = 1; x <= Width; x++)
            {
                for (int y = 1; y <= Height; y++)
                {
                    FuelCells.Add(new FuelCell(x, y, serialNum));
                }
            }


        }

        private void SetSquares()
        {
            if (FuelCells != null)
            {
                for (int x = 1; x <= Width - 2; x++)
                {
                    for (int y = 1; y <= Height - 2; y++)
                    {
                       
                    }
                }
            }
        }

    }
}
