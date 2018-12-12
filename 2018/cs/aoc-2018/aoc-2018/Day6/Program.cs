using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day6-2018.txt";
            List<int> lines = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();

        }

        public static int Part1(List<int> lines)
        {
            throw new NotImplementedException();
        }

        public static int Part2(List<int> lines)
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
