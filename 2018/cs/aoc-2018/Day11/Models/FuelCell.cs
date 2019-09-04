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

        public bool AssignedToSquare { get; set; }

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

        public override bool Equals(object value)
        {
            FuelCell fuelCell = value as FuelCell;

            return (X == fuelCell.X) && (Y == fuelCell.Y);
        }

        public override int GetHashCode()
        {
            var hashCode = 494920130;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + PowerLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + AssignedToSquare.GetHashCode();
            return hashCode;
        }
    }
}
