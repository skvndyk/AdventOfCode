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
            List<List<int>> dimensions = ParseFile(input);
            int y = 4;
        }

        public static void Part1()
        {

        }

        public static void Part2()
        {

        }

        public static List<List<int>> ParseFile(string input)
        {
            List<string> dimStrings = input.Split(Environment.NewLine.ToCharArray()).ToList();
            return dimStrings.Select(d => d.Split('x').Select(s => Int32.Parse(s)).ToList()).ToList();
         }
    }
}
