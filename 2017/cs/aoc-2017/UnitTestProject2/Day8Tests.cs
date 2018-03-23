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
            int maxRegValue = Program.ProcessLine(input);
            Assert.AreEqual(1, maxRegValue);
        }
    }
}
