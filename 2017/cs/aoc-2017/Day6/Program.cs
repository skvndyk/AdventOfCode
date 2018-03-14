using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6.Models;
using AocLib;
using AocLib = AocLib.AocLib;

namespace Day6
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day6-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<string> blockStrings = input.Split('\t').ToList();
            List<int> blockInts = blockStrings.Select(int.Parse).ToList();
            Tuple<List<BankConfig>, BankConfig> part1Results = Part1(blockInts);
            int numCycles = Part2(part1Results);
            Console.WriteLine($"Part 1: {part1Results.Item1.Count}");
            Console.WriteLine($"Part 2: {numCycles}");
            Console.ReadLine();
        }

        //not super pleased about this signature, make another class? go class crazy??
        public static Tuple<List<BankConfig>, BankConfig> Part1(List<int> blockInts)
        {
            List<Bank> banks = IntsToBanks(blockInts);
            List<BankConfig> seenConfigs = new List<BankConfig>();
            BankConfig currConfig = new BankConfig(){Banks = banks };
            BankConfig newConfig = currConfig.Copy();
            while (!seenConfigs.Any(c => c.Equals(newConfig)))
            {
                seenConfigs.Add(newConfig);
                currConfig = newConfig.Copy();
                List<Bank> currBanks = currConfig.Banks;
                List<Bank> maxBanks = currBanks.Where(b => b.NumBlocks == currBanks.Max(c => c.NumBlocks)).ToList();
                Bank bankToDistribute = maxBanks.First(m => m.Index == maxBanks.Min(m1 => m1.Index));
                newConfig = DistributeBlocks(currConfig, bankToDistribute);
            }
            BankConfig loopedConfig = newConfig;
            var tuple = Tuple.Create(seenConfigs, loopedConfig);
            return tuple;
        }

        public static int Part2(Tuple<List<BankConfig>, BankConfig> part1Results)
        {
            List<BankConfig> seenConfigs = part1Results.Item1;
            BankConfig loopedConfig = part1Results.Item2;
            IEnumerable<BankConfig> loopConfigs = seenConfigs.Where(c => c.Equals(loopedConfig));
            //this expression is gross!
            int idx = loopConfigs.Select(x => seenConfigs.IndexOf(x)).ToList()[0];
            return part1Results.Item1.Count - idx;
        }

        public static List<Bank> IntsToBanks(List<int> blockInts)
        {
            return blockInts.Select((b, i) => new Bank() {Index = i, NumBlocks = b}).ToList();
        }

        public static BankConfig DistributeBlocks(BankConfig inputBankConfig, Bank bankToDistribute)
        {
            BankConfig newConfig = inputBankConfig;
            //moving in a circle, add all of its blocks to the rest of the banks
            int blocksToDistribute = bankToDistribute.NumBlocks;
            int currIdx = bankToDistribute.Index;
            currIdx = newConfig.Banks.GetNextIndex(currIdx);
            newConfig.Banks.First(b => b.Equals(bankToDistribute)).NumBlocks = 0;
            for (int i = 1; i <= blocksToDistribute; i++)
            {
                newConfig.Banks.First(b => b.Index == currIdx).NumBlocks++;
                currIdx = newConfig.Banks.GetNextIndex(currIdx);
            }
            return newConfig;
        }

       
        
    }
}
