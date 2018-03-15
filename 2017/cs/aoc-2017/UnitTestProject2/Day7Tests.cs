using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day7;
using Day7.Models;
using System.Text.RegularExpressions;

namespace UnitTestProject2
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void ParseInput()
        {
            string filePath = "TestInput/Day7/day7-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<Prog> progs = Day7.Program.ParseFile(input);
        }

        //not an actual test, just messing around w regex
        [TestMethod]
        public void GetChildrenTest()
        {
            string childString = "ktlj, cntj, xhth";
            Program.GetChildren(childString);

        }

        //not an actual test, just messing around w regex
        [TestMethod]
        public void RegexTest()
        {
            string pattern = @"([a-z]*) (\(\d+\)) (->) (.*)";
            string input = "pbga (66) -> ktlj, cntj, xhth\n";
            var y = Regex.Matches(input, pattern);

        }

        
    }


}
