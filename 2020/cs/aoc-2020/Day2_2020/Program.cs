using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2_2020
{
    class Program
    {
        //public const string REPETITION = "repetition";
        //public const string REQ_LETTER = "reqLetter";
        //public const string PASSWORD = "password";

        public static readonly Regex _patternRgx =
            new Regex(@"(?'minRepetition'\d*)-(?'maxRepetition'\d*) (?'reqLetter'[a-zA-Z]): (?'password'[a-zA-Z]*)");
        //(?'name'subexpression)

        public static void Main(string[] args)
        {
            var exFilePath = "day2-ex-2020.txt";
            var filePath = "day2-2020.txt";
            var inputLines = Common.Utilities.ReadFileToStrings(filePath);
            Console.WriteLine($@"Part 1: {ParseInputFile1(inputLines)} matching passwords");
            Console.WriteLine($@"Part 2: {ParseInputFile2(inputLines)} matching passwords");
            Console.ReadLine();
        }

        public static int ParseInputFile1(List<string> inputLines)
        {
            int numMatchingPasswords = 0;
            foreach (var line in inputLines)
            {
                MatchCollection matches = _patternRgx.Matches(line);
                foreach (Match match in matches)
                {
                    var passwordRule = new PasswordRule(match, PuzzlePart.One);
                    var numRepetitions = passwordRule.Password.Count(l => l == passwordRule.RequiredLetter);
                    if (numRepetitions >= passwordRule.MinRepetition && numRepetitions <= passwordRule.MaxRepetition)
                    {
                        numMatchingPasswords++;
                    }
                }
            }
            return numMatchingPasswords;
        }

        public static int ParseInputFile2(List<string> inputLines)
        {
            int numMatchingPasswords = 0;
            foreach (var line in inputLines)
            {
                MatchCollection matches = _patternRgx.Matches(line);
                foreach (Match match in matches)
                {
                    var passwordRule = new PasswordRule(match, PuzzlePart.Two);
                    if (passwordRule.Password[passwordRule.Position1 - 1] == passwordRule.RequiredLetter ^ passwordRule.Password[passwordRule.Position2 - 1] == passwordRule.RequiredLetter)
                    {
                        numMatchingPasswords++;
                    }
                }
            }
            return numMatchingPasswords;
        }

        public class PasswordRule
        {
            public int MinRepetition { get; set; }
            public int MaxRepetition { get; set; }
            public int Position1 {get; set;}
            public int Position2 { get; set; }
            public char RequiredLetter { get; set; }
            public string Password { get; set; }

            public PasswordRule(Match match, PuzzlePart puzzlePart)
            {
                switch (puzzlePart)
                {
                    case PuzzlePart.One:
                        MinRepetition = int.Parse(match.Groups["minRepetition"].Value);
                        MaxRepetition = int.Parse(match.Groups["maxRepetition"].Value);
                        break;
                    case PuzzlePart.Two:
                        Position1 = int.Parse(match.Groups["minRepetition"].Value);
                        Position2 = int.Parse(match.Groups["maxRepetition"].Value);
                        break;
                }
                RequiredLetter = match.Groups["reqLetter"].Value.ToCharArray()[0];
                Password = match.Groups["password"].Value;
            }
        }

        public enum PuzzlePart { One, Two}
    }
}
