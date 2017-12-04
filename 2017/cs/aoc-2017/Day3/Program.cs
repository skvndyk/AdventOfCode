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
            int input1 = 312051;
            //Console.WriteLine($"Part 1 answer: {Part1(input1)}");
            //Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
            int input2_1 = 10000;
            int input2_2 = 312051;
            Console.WriteLine($"Part 2 answer: {Part2(input2_1, input2_2)}");
            Console.ReadLine();
        }

        public static int Part1(int input)
        {
            Spiral spiral = new Spiral(input, Spiral.PuzzlePart.Part1);
            return spiral.GetManhattanDistanceToCenter(input);
        }

        public static int Part2(int input1, int input2)
        {
            Spiral spiral = new Spiral(input1, Spiral.PuzzlePart.Part2, input2);
            return spiral.Squares.Last().value ?? throw new Exception("square has no value!");
        }
    }
}
