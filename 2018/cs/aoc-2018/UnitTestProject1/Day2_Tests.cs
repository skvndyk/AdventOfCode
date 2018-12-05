using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;

namespace UnitTestProject1
{
    [TestClass]
    public class Day2_Tests
    {

        [TestMethod]
        public void P2_T1()
        {
            string filePath = "day2-2018-test.txt";
            List<string> lines = Day2.Program.ReadTextIntoLines(filePath);
            Assert.AreEqual(Program.Part2(lines), 1);
        }   
    }
}
