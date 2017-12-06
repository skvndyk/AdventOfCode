using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day4;

namespace UnitTestProject2
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void Day4_P1A()
        {
            List<string> lines = new List<string>()
            {
                "aa bb cc dd ee"
            };
            Assert.AreEqual(1, Day4.Program.Part1(lines));
        }

        [TestMethod]
        public void Day4_P1B()
        {
            List<string> lines = new List<string>()
            {
                "aa bb cc dd aa"
            };
            Assert.AreEqual(0, Day4.Program.Part1(lines));
        }

        [TestMethod]
        public void Day4_P1C()
        {
            List<string> lines = new List<string>()
            {
                "aa bb cc dd aaa"
            };
            Assert.AreEqual(1, Day4.Program.Part1(lines));
        }

        //part 2
        [TestMethod]
        public void Day4_P2A()
        {
            List<string> lines = new List<string>()
            {
                "abcde fghij"
            };
            Assert.AreEqual(1, Day4.Program.Part2(lines));
        }

        [TestMethod]
        public void Day4_P2B()
        {
            List<string> lines = new List<string>()
            {
                "abcde xyz ecdab"
            };
            Assert.AreEqual(0, Day4.Program.Part2(lines));
        }

        [TestMethod]
        public void Day4_P2C()
        {
            List<string> lines = new List<string>()
            {
                "a ab abc abd abf abj"
            };
            Assert.AreEqual(1, Day4.Program.Part2(lines));
        }

        [TestMethod]
        public void Day4_P2D()
        {
            List<string> lines = new List<string>()
            {
                "iiii oiii ooii oooi oooo"
            };
            Assert.AreEqual(1, Day4.Program.Part2(lines));
        }

        [TestMethod]
        public void Day4_P2E()
        {
            List<string> lines = new List<string>()
            {
                "oiii ioii iioi iiio"
            };
            Assert.AreEqual(0, Day4.Program.Part2(lines));
        }
    }
}
