using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;

namespace UnitTestProject1
{
    [TestClass]
    public class Day1_Tests
    {

        [TestMethod]
        public void P2_T0()
        {
            List<int> lines = new List<int>() { 1, -2, 3, 1 };
            Assert.AreEqual(2, Day1.Program.Part2(lines));
        } 

        [TestMethod]
        public void P2_T1()
        {
            List<int> lines = new List<int>(){1, -1};
            Assert.AreEqual(0, Day1.Program.Part2(lines));
        }

        [TestMethod]
        public void P2_T2()
        {
            List<int> lines = new List<int>() { 3, 3, 4, -2, -4 };
            Assert.AreEqual(10, Day1.Program.Part2(lines));
        }

        [TestMethod]
        public void P2_T3()
        {
            List<int> lines = new List<int>() { -6, 3, 8, 5, -6 };
            Assert.AreEqual(5, Day1.Program.Part2(lines));
        }

        [TestMethod]
        public void P2_T4()
        {
            List<int> lines = new List<int>() { 7, 7, -2, -7, -4 };
            Assert.AreEqual(14, Day1.Program.Part2(lines));
        }
    }
}
