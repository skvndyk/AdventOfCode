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
            Position position = new Position() { X = 3, Y = 5 };
            int serialNum = 8;
            int expectedPowerLevel = 4;

            Assert.AreEqual(expectedPowerLevel, Program.CalculatePowerLevel(position, serialNum));
        }


        [TestMethod]
        public void P1A()
        {
            Position position = new Position() { X = 122, Y = 79 };
            int serialNum = 57;
            int expectedPowerLevel = -5;

            Assert.AreEqual(expectedPowerLevel, Program.CalculatePowerLevel(position, serialNum));
        }

        [TestMethod]
        public void P1B()
        {
            Position position = new Position() { X = 217, Y = 196 };
            int serialNum = 39;
            int expectedPowerLevel = 0;

            Assert.AreEqual(expectedPowerLevel, Program.CalculatePowerLevel(position, serialNum));
        }

        [TestMethod]
        public void P1C()
        {
            Position position = new Position() { X = 101, Y = 153 };
            int serialNum = 71;
            int expectedPowerLevel = 4;

            Assert.AreEqual(expectedPowerLevel, Program.CalculatePowerLevel(position, serialNum));
        }
    }
}
