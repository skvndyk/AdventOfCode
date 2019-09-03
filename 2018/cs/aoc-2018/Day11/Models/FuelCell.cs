using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Models
{
    public class FuelCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int PowerLevel { get; set; }

        public FuelCell(int x, int y, int serialNum)
        {
            X = x;
            Y = y;
            int rackId = X + 10;
            int powerLevel = rackId * Y;
            powerLevel += serialNum;
            powerLevel *= rackId;

            string powerLevelString = powerLevel.ToString();
            if (powerLevelString.Length > 2)
            {
                powerLevel = Convert.ToInt32(powerLevelString[powerLevelString.Length - 3].ToString());
            }
            else
            {
                powerLevel = 0;
            }

            powerLevel -= 5;

            PowerLevel = powerLevel;
        }
    }
}
