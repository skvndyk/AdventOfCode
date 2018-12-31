using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day8;

namespace UnitTestProject1
{
    [TestClass]
    public class Day8_Tests
    {

        [TestMethod]
        public void P1()
        {
            string filePath = "day8-2018-test.txt";
            List<int> lines = Program.ReadTextIntoLines(filePath);
            Assert.AreEqual(138,Program.Part1(lines));
        }

        [TestMethod]
        public void P2()
        {
            string filePath = "day8-2018-test.txt";
            List<int> lines = Program.ReadTextIntoLines(filePath);
            Assert.AreEqual(66, Program.Part2(lines));
        }
    }
}
