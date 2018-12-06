using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Day3
{
    public class Program
    {
        public static readonly Regex _rgx = new Regex($@"#(\d*) @ (\d*),(\d*): (\d*)x(\d*)");
        static void Main(string[] args)
        {
            string filePath = "day3-2018.txt";
            List<FabricClaim> claims = ParseInput(filePath);
            //Console.WriteLine($"Part 1: {Part1(lines)}");
            //Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();

        }

        public static int Part1(List<FabricClaim> claims)
        {
            throw new NotImplementedException();
        }

        public static int Part2(List<FabricClaim> claims)
        {
            throw new NotImplementedException();
        }

        public static List<FabricClaim> ParseInput(string filePath)
        {
            return GetClaimsFromLines(ReadTextIntoLines(filePath));
        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }

        public static List<FabricClaim> GetClaimsFromLines(List<string> lines)
        {
            return lines.Select(ParseLineToClaim).ToList();
        }
        public static FabricClaim ParseLineToClaim(string line)
        {
            Match match = _rgx.Match(line);
            if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
            GroupCollection groups = match.Groups;
            return new FabricClaim(groups[1].Value, int.Parse(groups[2].Value), 
                int.Parse(groups[3].Value), int.Parse(groups[4].Value), int.Parse(groups[5].Value));
        }
    }
}
