using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day12;
using Day12.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class Day12_Tests
    {
        [TestMethod]
        public void P1()
        {
            string initialState = "#..#.#..##......###...###";
            string rulesFileName = "day12-2018-test.txt";
            PotRow potRow = new PotRow(initialState, rulesFileName);
            potRow.ApplyRules();
        }


      
    }
}
