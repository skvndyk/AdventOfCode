using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;


namespace UnitTestProject2
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2_P1()
        {
            string filePath = "day2p1-2017.txt";
            int results = Day2.Program.Part1(filePath);
            Assert.AreEqual(18, results);
        }

        [TestMethod]
        public void Day2_P2()
        {
            string filePath = "day2p2-2017.txt";
            int results = Day2.Program.Part2(filePath);
        }
    }
}
