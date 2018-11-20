using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Day8.Models;

namespace Day8
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day8-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            Console.WriteLine($@"Part 1: {ProcessLine(input).Part1}");
            Console.WriteLine($@"Part 2: {ProcessLine(input).Part2}");
            Console.ReadLine();
        }

        public static Solutions ProcessLine(string input)
        {
            int maxValue = 0;
            int currMaxValue;
            List<Register> registers = new List<Register>();
            string pattern = @"([a-z]+) (inc\b|dec\b) (-?\d+) (if) ([a-z]+) (>|<|==|<=|>=|!=) (-?\d+)";

            List<string> lines = input.Split('\n').ToList();
            foreach (string line in lines)
            {
                MatchCollection matches = Regex.Matches(line, pattern);
                GroupCollection matchGroups = matches[0].Groups;

                Instruction instruction = new Instruction()
                {
                    //todo could probably lump a lot of register creation logic in here
                    RegisterToModifyName = matchGroups[1].Value,
                    Modification = matchGroups[2].Value,
                    Amount = int.Parse(matchGroups[3].Value),
                    LHRegisterName = matchGroups[5].Value,
                    Condition = matchGroups[6].Value,
                    ConditionRH = int.Parse(matchGroups[7].Value)
                };
                instruction.RegisterToModify = instruction.FindOrCreateRegister(instruction.RegisterToModifyName, ref registers);
                instruction.PerformInstruction(ref registers);

                currMaxValue = registers.First(r2 => r2.Value == registers.Max(r1 => r1.Value)).Value;
                if (currMaxValue > maxValue)
                {
                    maxValue = currMaxValue;
                }
            }

            return new Solutions()
            {
                Part1 = registers.First(r2 => r2.Value == registers.Max(r1 => r1.Value)).Value,
                Part2 = maxValue
            };
           
        }
    }
}
