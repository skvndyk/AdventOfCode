using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day6;

namespace UnitTestProject2
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Day6_P1()
        {
            List<int> blockInts = new List<int>(){0, 2, 7, 0};
            Day6.Program.Part1(blockInts);
        }
    }
}
