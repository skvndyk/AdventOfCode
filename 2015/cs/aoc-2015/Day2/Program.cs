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
            Console.WriteLine($@"Part1 answer: {Part1(allBoxDims)}");
            Console.WriteLine($@"Part2 answer: {Part2(allBoxDims)}");
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

        public static int Part2(List<List<int>> allBoxDims)
        {
            int sum = 0;
            foreach (List<int> dims in allBoxDims)
            {
                sum += GetSmallestPerimeter(dims) + GetCubicVolume(dims);
            }
            return sum;
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
            List<int> twoShortestSides = GetTwoShortestSides(dimensions);
            return twoShortestSides[0] * twoShortestSides[1];
        }

        public static List<int> GetTwoShortestSides(List<int> dimensions)
        {
            List<int> newDims = new List<int>(dimensions);
            int longestSide = newDims.Max();
            newDims.Remove(longestSide);
            return newDims;
        }

        public static int GetSmallestPerimeter(List<int> dimensions)
        {
            List<int> twoShortestSides = GetTwoShortestSides(dimensions);
            return 2 * (twoShortestSides[0] + twoShortestSides[1]);
        }

        public static int GetCubicVolume(List<int> dimensions)
        {
            return dimensions[0] * dimensions[1] * dimensions[2];
        }
    }
}
