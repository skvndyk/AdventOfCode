using System;
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
            List<LogEntry> logEntries = Program.ParseFileIntoLogEntries(filePath);
            int y = 4;
        }   
    }
}
