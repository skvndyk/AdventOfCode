using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day8;

namespace UnitTestProject2
{
    [TestClass]
    public class Day8Tests
    {
        [TestMethod]
        public void Day8Part1()
        {
            string filePath = "TestInput/Day8/day8-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            int maxRegValue = Program.ProcessLine(input).Part1;
            Assert.AreEqual(1, maxRegValue);
        }

        [TestMethod]
        public void Day8Part2()
        {
            string filePath = "TestInput/Day8/day8-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            int overallMaxRegValue = Program.ProcessLine(input).Part2;
            Assert.AreEqual(10, overallMaxRegValue);
        }
    }
}
