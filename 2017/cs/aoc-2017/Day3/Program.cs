using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int input = 312051;
            stopWatch.Stop();
            Console.WriteLine($"Part 1 answer: {Part1(input)}");
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
            Console.ReadLine();
        }

        public static int Part1(int input)
        {
            Spiral spiral = new Spiral(input, Spiral.PuzzlePart.Part1);
            return spiral.GetManhattanDistanceToCenter(input);
        }

        public static int Part2(int input)
        {
            Spiral spiral = new Spiral(input, Spiral.PuzzlePart.Part2);
            throw new NotImplementedException();
        }
    }
}
