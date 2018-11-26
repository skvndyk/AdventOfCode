using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "day2-2015.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<List<int>> allBoxDims = ParseFile(input);
            Console.WriteLine(Part1(allBoxDims));
            Console.ReadLine();
        }

        public static int Part1(List<List<int>> allBoxDims)
        {
            int sum = 0;
            foreach (List<int> dims in allBoxDims)
            {
                sum += GetSurfaceArea(dims) + GetAreaOfSmallestSide(dims);
            }
            return sum;
        }

        public static void Part2()
        {

        }

        public static List<List<int>> ParseFile(string input)
        {
            List<string> dimStrings = input.Split(Environment.NewLine.ToCharArray()).ToList();
            return dimStrings.Select(d => d.Split('x').Select(s => Int32.Parse(s)).ToList()).ToList();
        }

        public static int GetSurfaceArea(List<int> dimensions)
        {
            int surfaceArea = 2 * dimensions[0] * dimensions[1] + 2 * dimensions[1] * dimensions[2] +
                   2 * dimensions[2] * dimensions[0];
            return surfaceArea;
        }

        public static int GetAreaOfSmallestSide(List<int> dimensions)
        {
            List<int> newDims = new List<int>(dimensions);
            int longestSide = newDims.Max();
            newDims.Remove(longestSide);
            return newDims[0] * newDims[1];
        }
    }
}
