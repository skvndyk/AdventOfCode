using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day3;
using System.Collections.Generic;


namespace UnitTestProject2
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void GetNextIndex()
        {
            List<string> stringList = new List<string>() { "item1", "item2", "item3" };
            int testIndex = stringList.GetNextIndex(2);
            Assert.AreEqual(0, testIndex);
            Assert.AreEqual("item1", stringList[testIndex]);
        }
    }
}
