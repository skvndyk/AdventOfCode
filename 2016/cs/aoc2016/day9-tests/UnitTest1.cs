﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day9;

namespace Day9Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            string input = "A(1x5)BC";
            string results = Day9.Program.getDecompressed1(input);
            Assert.AreEqual(results, "ABBBBBC");
        }

        [TestMethod]
        public void TestCase2()
        {
            string input = "(3x3)XYZ";
            string results = Day9.Program.getDecompressed1(input);
            Assert.AreEqual(results, "XYZXYZXYZ");
        }

        [TestMethod]
        public void TestCase3()
        {
            string input = "A(2x2)BCD(2x2)EFG";
            string results = Day9.Program.getDecompressed1(input);
            Assert.AreEqual(results, "ABCBCDEFEFG");
        }

        [TestMethod]
        public void TestCase4()
        {
            string input = "(6x1)(1x3)A";
            string results = Day9.Program.getDecompressed1(input);
            Assert.AreEqual(results, "(1x3)A");
        }

        [TestMethod]
        public void TestCase5()
        {
            string input = "X(8x2)(3x3)ABCY";
            string results = Day9.Program.getDecompressed1(input);
            Assert.AreEqual(results, "X(3x3)ABC(3x3)ABCY");
        }

        [TestMethod]
        public void TestCaseP2_1()
        {
            string input = "(3x3)XYZ";
            string results = Day9.Program.getDecompressed2(input);
            Assert.AreEqual(results, "XYZXYZXYZ");
        }

        [TestMethod]
        public void TestCaseP2_2()
        {
            string input = "X(8x2)(3x3)ABCY";
            string results = Day9.Program.getDecompressed2(input);
            Assert.AreEqual(results, "XABCABCABCABCABCABCY");
        }

        [TestMethod]
        public void TestCaseP2_3()
        {
            string input = "(27x12)(20x12)(13x14)(7x10)(1x12)A";
            string results = Day9.Program.getDecompressed2(input);
            Assert.AreEqual(results.Length, 241920);
        }

        [TestMethod]
        public void TestCaseP2_4()
        {
            string input = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";
            string results = Day9.Program.getDecompressed2(input);
            Assert.AreEqual(results.Length, 445);
        }
    }
}
