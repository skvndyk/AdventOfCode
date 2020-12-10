using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day1_2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = Common.Utilities.ReadFileToStrings(Path.GetFullPath("day1-2020.txt"));
            //var pair = FindPair(lines);
            //Console.WriteLine($"Part 1: {pair[0]} * {pair[1]} = {pair[0] * pair[1]}");

            var triplet = FindTriplet(lines);
            Console.WriteLine($"Part 2: {triplet[0]} * {triplet[1]} * {triplet[2]} = {triplet[0] * triplet[1] * triplet[2]}");

            Console.Read();
        }

        public static List<int> FindPair(List<string> lines)
        {
            int desiredSum = 2020;
            var pair = new List<int>();
            var intLines = lines.Select(l => Convert.ToInt32(l)).ToList();

            bool foundPair = false;
            for (int i = 0; i < intLines.Count; i++)
            {
                for (int j = 0; j < intLines.Count - 1; j++)
                {
                    if (foundPair) break;

                    if (intLines[i] + intLines[j] == desiredSum)
                    {
                        pair.Add(intLines[i]);
                        pair.Add(intLines[j]);
                        foundPair = true;
                    }
                }
            }
            return pair;
        }

        public static List<int> FindTriplet(List<string> lines)
        {
            int desiredSum = 2020;
            var triplet = new List<int>();
            var intLines = lines.Select(l => Convert.ToInt32(l)).ToList();

            bool foundTriplet = false;
            for (int i = 0; i < intLines.Count; i++)
            {
                for (int j = 0; j < intLines.Count - 1; j++)
                {
                    for (int k = 0; k < intLines.Count - 2; k++)
                    {
                        if (foundTriplet) break;

                        if (intLines[i] + intLines[j] + intLines[k] == desiredSum)
                        {
                            triplet.Add(intLines[i]);
                            triplet.Add(intLines[j]);
                            triplet.Add(intLines[k]);
                            foundTriplet = true;
                        }
                    }
                    
                }
            }
            return triplet;
        }
    }
}
