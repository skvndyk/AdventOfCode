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
            List<Prog> firstPassProgs = ParseFile(input);
            //todo get children!
        }

        public static void Part1()
        {
           
        }

        public static void Part2()
        {

        }

        public static List<Prog> ParseFile(string input)
        {
            List<Prog> progs = new List<Prog>();
            string pattern = @"([a-z]*) \((\d+)\)(?: (->) (.*)(?=\))?";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                Prog prog = new Prog()
                {
                    Name = match.Groups[1].Value,
                    Weight = int.Parse(match.Groups[2].Value)
                };
                if (match.Groups.Count > 3)
                {
                    prog.ChildStringList = match.Groups[4].Value;
                }
                progs.Add(prog);
            }
            return progs;
        }

        public static List<Prog> GetChildren(string childString)
        {
            string noSpaceChild = Regex.Replace(childString, @"\s", "");
            List<string> splitChildStrings = noSpaceChild.Split(',').ToList();
            return splitChildStrings.Select(splitChildString => new Prog() {Name = splitChildString}).ToList();
            //todo get child name, look for child in list of progs
            //todo if it already exists, set them equal
            //todo if not, create it
            //todo do this recursively

            //ex: abc => def ghi jkl
            //ex: def => qrs tuv wyx (do you want to go down to the leaf right away?)
            // 
        }
    }
}
