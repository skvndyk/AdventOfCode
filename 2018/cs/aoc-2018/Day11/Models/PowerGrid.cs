using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class PowerGrid
    {
        public int SerialNum { get; set; }
        public List<Square> Squares { get; set; }
        public List<FuelCell> FuelCells { get; set; }
        public int Height = 300;
        public int Width = 300;
        public PowerGrid(int serialNum)
        {
            SerialNum = serialNum;
            Squares = new List<Square>();
            FuelCells = new List<FuelCell>();

            SetFuelCells();
            SetSquares();

        }

        public void SetFuelCells()
        {
            for (int x = 1; x <= Width; x++)
            {
                for (int y = 1; y <= Height; y++)
                {
                    FuelCells.Add(new FuelCell(x, y, SerialNum));
                }
            }
        }
        private void SetSquares()
        {
            if (FuelCells != null)
            {
                int highPowerLevel = -999999999;
                for (int x = 1; x <= Width - 2; x++)
                {
                    for (int y = 1; y <= Height - 2; y++)
                    {
                        var testSquare = new Square(x, y, this);
                        if (testSquare.TotalPower > highPowerLevel)
                        {
                            highPowerLevel = testSquare.TotalPower;
                            Squares.Add(testSquare);
                            Squares.RemoveAll(s => s != testSquare);
                        }
                    }
                }
            }
        }

        public Square HighestPoweredSquare => Squares.Where(s => s.TotalPower == Squares.Max(s2 => s2.TotalPower)).First();

        public FuelCell TLHighPower => HighestPoweredSquare.TopLeftCorner;


    }
}
