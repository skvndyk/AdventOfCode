using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;
using System.Collections.Generic;
using Day3.Models;


namespace UnitTestProject2
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void GetNextIndex()
        {
            List<string> stringList = new List<string>() {"item1", "item2", "item3"};
            int testIndex = stringList.GetNextIndex(2);
            Assert.AreEqual(0, testIndex);
            Assert.AreEqual("item1", stringList[testIndex]);
        }

        [TestMethod]
        public void Day3_P1A()
        {
            int input = 1;
            Spiral spiral = new Spiral(input);
            Assert.AreEqual(0, spiral.GetManhattanDistanceToCenter(input));
        }
        [TestMethod]
        public void Day3_P1B()
        {
            int input = 12;
            Spiral spiral = new Spiral(input);
            Assert.AreEqual(3, spiral.GetManhattanDistanceToCenter(input));
        }
        [TestMethod]
        public void Day3_P1C()
        {
            int input = 23;
            Spiral spiral = new Spiral(input);
            Assert.AreEqual(2, spiral.GetManhattanDistanceToCenter(input));
        }
        [TestMethod]
        public void Day3_P1D()
        {
            int input = 1024;
            Spiral spiral = new Spiral(input);
            Assert.AreEqual(31, spiral.GetManhattanDistanceToCenter(input));
        }
    }
}
