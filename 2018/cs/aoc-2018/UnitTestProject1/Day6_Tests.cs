using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day6;

namespace UnitTestProject1
{
    [TestClass]
    public class Day6_Tests
    {

        [TestMethod]
        public void ParseToCoords()
        {
            string filePath = "day6-2018-test.txt";
            List<string> lines = Program.ReadTextIntoLines(filePath);
            List<Coord> coords = Program.ReadLinesIntoCoords(lines);

        }

        [TestMethod]
        public void DisplayGrid()
        {
            string filePath = "day6-2018-test.txt";
            List<string> lines = Program.ReadTextIntoLines(filePath);
            List<Coord> points = Program.ReadLinesIntoCoords(lines);
            Program.DisplayGrid(points);
        }
       
    }
}
