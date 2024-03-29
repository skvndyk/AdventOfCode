﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day4;

namespace UnitTestProject1
{
    [TestClass]
    public class Day4_Tests
    {

        [TestMethod]
        public void Part1_T1()
        {
            string filePath = "day4-2018-test.txt";
            Assert.AreEqual(Program.Part1(filePath), 240);

        }

        [TestMethod]
        public void Part2_T1()
        {
            string filePath = "day4-2018-test.txt";
            Assert.AreEqual(Program.Part2(filePath), 4455);

        }
    }
}
