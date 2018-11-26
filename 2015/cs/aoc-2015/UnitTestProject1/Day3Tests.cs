using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;

namespace UnitTestProject1
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Part2_TestCase1()
        {
            string input = "^v";
            Assert.AreEqual(3, Day3.Program.Part2(input));
        }

        [TestMethod]
        public void Part2_TestCase2()
        {
            string input = "^>v<";
            Assert.AreEqual(3, Day3.Program.Part2(input));
        }

        [TestMethod]
        public void Part2_TestCase3()
        {
            string input = "^v^v^v^v^v";
            Assert.AreEqual(11, Day3.Program.Part2(input));
        }
    }
}
