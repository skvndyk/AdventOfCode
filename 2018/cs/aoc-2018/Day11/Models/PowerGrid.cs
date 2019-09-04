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
        public Square HLSquare { get; set; }
        public List<FuelCell> FuelCells { get; set; }
        public int Height = 300;
        public int Width = 300;
        public PowerGrid(int serialNum)
        {
            SerialNum = serialNum;
            FuelCells = new List<FuelCell>();

            SetFuelCells();
            GetHLSquare();

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
        private void GetHLSquare()
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
                            HLSquare = testSquare;
                        }
                    }
                }
            }
        }

        public FuelCell TLHighPower => HLSquare.TopLeftCorner;


    }
}
