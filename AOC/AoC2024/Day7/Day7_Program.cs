using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2024.Day7
{
    class Day7_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day7\inputFileDay7-2024.txt";
            string exFilePath = $@"Day7\exInputFileDay7-2024.txt";
            string exFilePath2 = $@"Day7\exInputFileDay7-2024_P2.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var lines = ParseInputStrings(inputStrings);
            //var line = lines[0]; // 2 operands
            //var combos = GetAllCombos(line.Operands.Count-1);

            var line2 = lines[1];
            var combos2 = GetAllCombos(line2.Operands.Count - 1);
            return 0;

        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public delegate int MathOperation(int a, int b);

        private static List<Line> ParseInputStrings(List<string> inputStrings)
        {
            var lines = new List<Line>();
            foreach (var inputString in inputStrings)
            {
                var line = new Line();
                var splitOne = inputString.Split(":");
                line.TestValue = int.Parse(splitOne[0]);
                line.Operands = splitOne[1].Trim().Split(" ").Select(x => int.Parse(x)).ToList();
                lines.Add(line);
            }
            return lines;
        }

        //static void GetCombinations(List<int> operands)
        //{
        //    var operators = new List<MathOperation> { Add, Multiply };
        //    var combinations = new List<List<MathOperation>>();
        //    //add initial values of all Add or all Multiply
        //    var combination = new List<MathOperation>();

        //    //add the adds
        //    for (int i = 0; i < operands.Count; i++)
        //    {
        //        combination.Add(Add);
        //    }

        //    combinations.Add(combination);

        //    var combination2 = new List<MathOperation>();
        //    for (int i = 0; i < operands.Count; i++)
        //    {
        //        combination2.Add(Multiply);
        //    }

        //    combinations.Add(combination2);


        //}

        //add, multiply
        // _  _  _  _  _
        //todo generalize later
        public static List<List<MathOperation>> GetAllCombos(int count)
        {
            var operatorOptions = new List<MathOperation>{ Add, Multiply };
            var combinations = new List<List<MathOperation>>();
            for (int numAdds = 0; numAdds <= count ; numAdds++)
            {
                //a = Add
                //m = multiply
                var combination = new List<MathOperation>();
                var numMultiplies = count - numAdds;
                //a: 0, m: 3

                //setup the Xs
                var combo = new List<MathOperation>();
                for (int i = 0; i < numMultiplies; i++)
                {
                    combo.Add(Multiply);
                }

                if (combo.Count == count)
                {
                    combinations.Add(combo);
                }

                //set up the As
                else
                {
                    for (int i = 0; i < numAdds; i++)
                    {
                        combo.Add(Add);
                    }

                    combinations.Add(combo);
                    //shift As left
                    if (count > 2)
                    {
                        for (int i = 0; i < numAdds; i++)
                        {
                            var temp = combo[count - 2];
                            combo[count - 2] = combo[count - 1];
                            combo[count - 1] = temp;
                            combinations.Add(combo);
                        }
                    }
                    
                }

            }
            return combinations;
        }

        #region lil classes
        public class Line
        {
            public int TestValue { get; set; }
            public List<int> Operands { get; set; } = new List<int>();
        }



        #endregion
    }


}
