using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6.Models;

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
            Part1(blockInts);
        }

        public static void Part1(List<int> blockInts)
        {
            List<Bank> banks = IntsToBanks(blockInts);
            List<BankConfig> seenConfigs = new List<BankConfig>();
            BankConfig currConfig = new BankConfig(){Banks = banks };
            while (!seenConfigs.Any(c => c.Equals(currConfig)))
            {
                
            }
            //todo need equality comparison for currConfig
            //compare current config to seen configs
            //while current config != any of the seen configs,
            //LOOP
            //get bank with most blocks (ties resolved by smallest idx)
            //moving in a circle, add all of its blocks to the rest of the banks
        }   

        public static List<Bank> IntsToBanks(List<int> blockInts)
        {
            return blockInts.Select((b, i) => new Bank() {Index = i, NumBlocks = b}).ToList();
        }

       
        
    }
}
