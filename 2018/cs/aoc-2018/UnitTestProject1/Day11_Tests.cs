using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day11;
using Day11.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class Day11_Tests
    {
        [TestMethod]
        public void P0A()
        {
            int x = 3;
            int y = 5;
            int serialNum = 8;
            int expectedPowerLevel = 4;

            FuelCell position = new FuelCell(x, y, serialNum);
            Assert.AreEqual(expectedPowerLevel, position.PowerLevel);
        }


        [TestMethod]
        public void P1A()
        {
            int x = 122;
            int y = 79;
            int serialNum = 57;
            int expectedPowerLevel = -5;

            FuelCell position = new FuelCell(x, y, serialNum);
            Assert.AreEqual(expectedPowerLevel, position.PowerLevel);

        }

        [TestMethod]
        public void P1B()
        {
            int x = 217;
            int y = 196;
            int serialNum = 39;
            int expectedPowerLevel = 0;

            FuelCell position = new FuelCell(x, y, serialNum);
            Assert.AreEqual(expectedPowerLevel, position.PowerLevel);
        }

        [TestMethod]
        public void P1C()
        {
            int x = 101;
            int y = 153;
            int serialNum = 71;
            int expectedPowerLevel = 4;

            FuelCell position = new FuelCell(x, y, serialNum);
            Assert.AreEqual(expectedPowerLevel, position.PowerLevel);
        }
    }
}
