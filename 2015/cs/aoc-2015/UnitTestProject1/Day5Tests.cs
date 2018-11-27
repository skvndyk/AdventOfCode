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
            Assert.IsTrue(Program.IsGoodStringPart1(input));
        }

        [TestMethod]
        public void Part1_Test2()
        {
            string input = "aaa";
            Assert.IsTrue(Program.IsGoodStringPart1(input));

        }

        [TestMethod]
        public void Part1_Test3()
        {
            string input = "jchzalrnumimnmhp";
            Assert.IsFalse(Program.IsGoodStringPart1(input));
        }

        [TestMethod]
        public void Part1_Test4()
        {
            string input = "haegwjzuvuyypxyu";
            Assert.IsFalse(Program.IsGoodStringPart1(input));
        }

        [TestMethod]
        public void Part1_Test5()
        {
            string input = "dvszwmarrgswjxmb";
            Assert.IsFalse(Program.IsGoodStringPart1(input));
        }


        [TestMethod]
        public void Part2_Test1()
        {
            string input = "qjhvhtzxzqqjkmpb";
            Assert.IsTrue(Program.IsGoodStringPart2(input));
        }

        [TestMethod]
        public void Part2_Test2()
        {
            string input = "xxyxx";
            Assert.IsTrue(Program.IsGoodStringPart2(input));

        }

        [TestMethod]
        public void Part2_Test3()
        {
            string input = "uurcxstgmygtbstg";
            Assert.IsFalse(Program.IsGoodStringPart2(input));
        }

        [TestMethod]
        public void Part2_Test4()
        {
            string input = "ieodomkazucvgmuy";
            Assert.IsFalse(Program.IsGoodStringPart2(input));
        }


    }
}
