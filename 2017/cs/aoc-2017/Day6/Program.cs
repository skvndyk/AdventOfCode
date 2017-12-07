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
        }   

        public static List<Bank> IntsToBanks(List<int> blockInts)
        {
            return blockInts.Select(i => new Bank() {NumBlocks = i}).ToList();
        }
    }
}
