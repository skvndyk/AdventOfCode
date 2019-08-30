using Day11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int serialNum = 5535;
        }

        public static int CalculatePowerLevel(Position pos, int serialNum)
        {
            int rackId = pos.X + 10;
            int powerLevel = rackId * pos.Y;
            powerLevel += serialNum;
            powerLevel *= rackId;

            string powerLevelString = powerLevel.ToString();
            if (powerLevelString.Length > 2)
            {
                powerLevel = Convert.ToInt32(powerLevelString[powerLevelString.Length - 3]);
            }
            else
            {
                powerLevel = 0;
            }

            powerLevel -= 5;

            return powerLevel;
        }
    }
}
