using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day5;

namespace UnitTestProject1
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void Part1_Test1()
        {
            string input = "ugknbfddgicrmopn";
            Assert.IsTrue(Program.IsGoodString(input));
        }

        [TestMethod]
        public void Part1_Test2()
        {
            string input = "aaa";
            Assert.IsTrue(Program.IsGoodString(input));

        }

        [TestMethod]
        public void Part1_Test3()
        {
            string input = "jchzalrnumimnmhp";
            Assert.IsFalse(Program.IsGoodString(input));
        }

        [TestMethod]
        public void Part1_Test4()
        {
            string input = "haegwjzuvuyypxyu";
            Assert.IsFalse(Program.IsGoodString(input));
        }

        [TestMethod]
        public void Part1_Test5()
        {
            string input = "dvszwmarrgswjxmb";
            Assert.IsFalse(Program.IsGoodString(input));
        }


    }
}
