using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day4-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<string> jumpListString = input.Split('\n').ToList();
            List<int> jumpList = jumpListString.Select(int.Parse).ToList();
            Console.WriteLine($"Part 1: {Part1(jumpList)}");
            Console.ReadLine();
        }

        public static int Part1(List<int> jumpList)
        {
            List<int> origJumpList = jumpList;
            int currIdx = 0;
            int prevIdx;
            
            int numSteps = 0;
            while (currIdx < jumpList.Count)
            {
                prevIdx = currIdx;
                currIdx += jumpList[prevIdx];
                jumpList[prevIdx]++;
                numSteps++;
            }
            return numSteps;
        }

        public static int Part2(List<int> jumpList)
        {
            throw new NotImplementedException();
        }
    }
}
