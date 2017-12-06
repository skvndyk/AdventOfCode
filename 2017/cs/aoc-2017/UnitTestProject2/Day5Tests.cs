using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day5;

namespace UnitTestProject2
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Day3_P1()
        {
            List<int> input = new List<int>(){0, 3, 0, 1, -3};
            int numSteps = Day5.Program.Part1(input);
            Assert.AreEqual(5, numSteps);
        }
       
    }
}
