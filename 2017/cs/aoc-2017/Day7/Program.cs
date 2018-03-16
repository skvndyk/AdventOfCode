using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Day7.Models;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "day7-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            //todo not crazy about tuple useage here, again.
            Prog part1Result = Part1(input);
            Part2(part1Result);
            Console.WriteLine($@"Part 1: {part1Result.Name}");
            Console.ReadLine();
        }

        public static Prog Part1(string input)
        {
            List<Prog> firstPassProgs = ParseFile(input);
            foreach (Prog prog in firstPassProgs)
            {
                SetRelationships(firstPassProgs, prog);
            }
            return firstPassProgs.First(p => p.ParentProgList.Count == 0);
        }

        public static void Part2(Prog baseProg)
        {
            List<Branch> branches = new List<Branch>();
            //start at base, find total of each branch's weight
            foreach (Prog childProg in baseProg.ChildProgList)
            {
                int branchWeight = 0;
                branchWeight += childProg.Weight;
                TraverseTree(childProg, ref branchWeight);
                branches.Add(new Branch() { Parent = baseProg, BranchWeight = branchWeight});
            }

        }

        public static Prog TraverseTree(Prog parentProg, ref int branchWeight)
        {
            foreach (Prog childProg in parentProg.ChildProgList)
            {
                branchWeight += childProg.Weight;
                TraverseTree(childProg, ref branchWeight);
            }
            return parentProg;
        }
        public static List<Prog> ParseFile(string input)
        {
            List<Prog> progs = new List<Prog>();
            string pattern = @"([a-z]*) \((\d+)\)( -> (.*))?";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Prog prog = new Prog()
                {
                    Name = match.Groups[1].Value,
                    Weight = int.Parse(match.Groups[2].Value)
                };
                if (match.Groups[3].Value != string.Empty)
                {
                    string children = match.Groups[4].Value;
                    prog.ChildStringList = Regex.Replace(children, @"\s", "").Split(',').ToList();
                }
                progs.Add(prog);
            }
            return progs;
        }

        public static List<Prog> SetRelationships(List<Prog> allProgs, Prog currProg)
        {
            if (currProg.ChildStringList.Count > 0)
            {
                foreach (string childString in currProg.ChildStringList)
                {
                    Prog childProg = allProgs.First(p => p.Name == childString);
                    if (childProg != null)
                    {
                        currProg.ChildProgList.Add(childProg);
                        childProg.ParentProgList.Add(currProg);
                    }
                }
            }
            return allProgs;
        }

        
    }
}
