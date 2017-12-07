﻿using System;
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
            Console.WriteLine($"Part 1: {Part1(blockInts)}");
            Console.ReadLine();
        }

        public static int Part1(List<int> blockInts)
        {
            List<Bank> banks = IntsToBanks(blockInts);
            List<BankConfig> seenConfigs = new List<BankConfig>();
            BankConfig currConfig = new BankConfig(){Banks = banks };
            int cycles = 0;
            while (!seenConfigs.Any(c => c.Equals(currConfig)))
            {
                seenConfigs.Add(currConfig);
                List<Bank> currBanks = currConfig.Banks;
                List<Bank> maxBanks = currBanks.Where(b => b.NumBlocks == currBanks.Max(c => c.NumBlocks)).ToList();
                Bank bankToDistribute = maxBanks.First(m => m.Index == maxBanks.Min(m1 => m1.Index));
                BankConfig newConfig = DistributeBlocks(currConfig, bankToDistribute);
                currConfig = newConfig;
                cycles++;
            }
            return cycles;
        }   

        public static List<Bank> IntsToBanks(List<int> blockInts)
        {
            return blockInts.Select((b, i) => new Bank() {Index = i, NumBlocks = b}).ToList();
        }

        public static BankConfig DistributeBlocks(BankConfig inputBankConfig, Bank bankToDistribute)
        {
            //moving in a circle, add all of its blocks to the rest of the banks
            int blocksToDistribute = bankToDistribute.NumBlocks;
            int currIdx = bankToDistribute.Index;
            currIdx = inputBankConfig.Banks.GetNextIndex(currIdx);
            inputBankConfig.Banks.First(b => b.Equals(bankToDistribute)).NumBlocks = 0;
            for (int i = 1; i <= blocksToDistribute; i++)
            {
                inputBankConfig.Banks.First(b => b.Index == currIdx).NumBlocks++;
                currIdx = inputBankConfig.Banks.GetNextIndex(currIdx);
            }
            return inputBankConfig;
        }

       
        
    }
}