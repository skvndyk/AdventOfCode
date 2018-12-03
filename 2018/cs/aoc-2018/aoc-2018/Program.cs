using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2018
{
    public class Program
    {
        public const int initialFrequency = 0;
        static void Main(string[] args)
        {
            string filePath = "day1-2018.txt";
            Console.WriteLine($"Part 1: {Part1(filePath)}");
            //Console.WriteLine($"Part 2: {Part2(filePath)}");
            Console.ReadLine();

        }

        public static int Part1(string filePath)
        {
            List<int> input = ReadTextIntoLines(filePath);
            return input.Sum();
        }

        public static int Part2(string input)
        {
            throw new NotImplementedException();
        }

        public static List<int> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Replace("+", string.Empty).Split('\n').Select(int.Parse).ToList();
        }
    }
}
