using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Program
    {
        public const int initialFrequency = 0;
        static void Main(string[] args)
        {
            string filePath = "day1-2018.txt";
            List<int> lines = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();

        }

        public static int Part1(List<int> lines)
        {
            return lines.Sum();
        }

        public static int Part2(List<int> lines)
        {
            List<int> freqsSeen = new List<int>();
            int currFreq = 0;
            int idx = 0;
            do
            {
                if (idx < lines.Count)
                {
                    freqsSeen.Add(currFreq);
                    currFreq += lines[idx];
                    
                    idx++;
                }
                else { idx = 0; }

            } while (!freqsSeen.Contains(currFreq));
           
            return currFreq;
        }

        public static List<int> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Replace("+", string.Empty).Split('\n').Select(int.Parse).ToList();
        }
    }
}
