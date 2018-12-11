using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day5;

namespace UnitTestProject1
{
    [TestClass]
    public class Day5_Tests
    {

        [TestMethod]
        public void Part1_T1()
        {
            string input = "aA";
            Assert.AreEqual(0, Program.Part1(input));

        }

        [TestMethod]
        public void Part1_T2()
        {
            string input = "abBA";
            Assert.AreEqual(0, Program.Part1(input));

        }

        [TestMethod]
        public void Part1_T3()
        {
            string input = "abAB";
            Assert.AreEqual(4, Program.Part1(input));

        }

        [TestMethod]
        public void Part1_T4()
        {
            string input = "aabAAB";
            Assert.AreEqual(6, Program.Part1(input));

        }

        [TestMethod]
        public void Part1_T5()
        {
            string input = "dabAcCaCBAcCcaDA";
            Assert.AreEqual(10, Program.Part1(input));
        }


        [TestMethod]
        public void Part2_T1()
        {
            string input = "dabAcCaCBAcCcaDA";
            Assert.AreEqual(4, Program.Part2(input));

        }
    }
}
