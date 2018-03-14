using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day6;
using Day6.Models;

namespace UnitTestProject2
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Day6_P1()
        {
            List<int> blockInts = new List<int>() { 0, 2, 7, 0 };
            List<BankConfig> seenConfigs = Day6.Program.Part1(blockInts).Item1;
            Assert.AreEqual(5, seenConfigs.Count);
        }

        [TestMethod]
        public void Day6_P2()
        {
            List<int> blockInts = new List<int>() { 0, 2, 7, 0 };
            Tuple<List<BankConfig>, BankConfig> part1Results = Day6.Program.Part1(blockInts);
            Assert.AreEqual(4, Day6.Program.Part2(part1Results));
        }

        [TestMethod]
        public void ConfigEqualityTest()
        {
            Bank bank1 = new Bank() { NumBlocks = 0, Index = 0 };
            Bank bank2 = new Bank() { NumBlocks = 2, Index = 1 };

            Bank bank1a = new Bank() { NumBlocks = 0, Index = 0 };
            Bank bank2a = new Bank() { NumBlocks = 2, Index = 1 };

            BankConfig seenConfig = new BankConfig()
            {
                Banks = new List<Bank>() { bank1, bank2}
            };

            BankConfig currConfig = new BankConfig()
            {
                Banks = new List<Bank>() { bank1a, bank2a }
            };
            
            Assert.IsTrue(seenConfig.Equals(currConfig));
        }

        [TestMethod]
        public void BankEqualityTest()
        {
            Bank bank1 = new Bank() { NumBlocks = 0, Index = 0 };
            Bank bank2 = new Bank() { NumBlocks = 2, Index = 1 };

            Bank bank1a = new Bank() { NumBlocks = 1, Index = 1 };
            Bank bank2a = new Bank() { NumBlocks = 1, Index = 1 };

            Assert.IsFalse(bank1.Equals(bank2));
            Assert.IsTrue(bank1a.Equals(bank2a));


        }
    }
}
