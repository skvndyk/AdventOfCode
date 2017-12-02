using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {   
        static void Main(string[] args)
        {
            string filePath = "day2-2017.txt";
            Console.WriteLine(Part1(filePath));
            //Part2(filePath);
            Console.ReadLine();
        }

        public static int Part1(string filePath)
        {
            int sum = 0;
            List<List<string>> splitLines = ReadTextIntoLists(filePath);
            foreach (List<string> row in splitLines)
            {
                List<int> intRow = row.ConvertAll(r => Int32.Parse(r)).ToList();
                int highVal = intRow.Max();
                int lowVal = intRow.Min();
                int diff = highVal - lowVal;
                sum += diff;
            }
            return sum;
        }
        public static int Part2(string filePath)
        {
            int sum = 0;
            List<List<string>> splitLines = ReadTextIntoLists(filePath);
            foreach (List<string> row in splitLines)
            {
                List<int> intRow = row.ConvertAll(r => Int32.Parse(r)).ToList();
                

            }
            return sum;
        }
        public static List<List<string>> ReadTextIntoLists(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            List<string> lines = rawInput.Split('\n').ToList();
            List<List<string>> splitLines = new List<List<string>>();
            foreach (string line in lines)
            {
                splitLines.Add(line.Split('\t').ToList());
            }
            return splitLines;
        }

        public static List<Tuple<int, int>> GetPermutations(List<int> values)
        {
            List<Tuple<int, int>> perms = new List<Tuple<int, int>>();
            throw new NotImplementedException();
        }
    }
}
