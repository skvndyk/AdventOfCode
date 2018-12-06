using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;

namespace UnitTestProject1
{
    [TestClass]
    public class Day3_Tests
    {

        [TestMethod]
        public void Part1_T1()
        {
            string filePath = "day3-2018.txt";
            List<FabricClaim> claims = Program.ParseInput(filePath);
            Assert.AreEqual(4, Program.Part1(claims));
        }   
    }
}
