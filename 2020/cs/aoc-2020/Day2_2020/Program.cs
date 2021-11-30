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
            Console.WriteLine($@"Part 1: {ParseInputFile1(filePath)} matching passwords");
            Console.ReadLine();
        }

        public static int ParseInputFile1(string filePath)
        {
            int numMatchingPasswords = 0;
            var exLines = Common.Utilities.ReadFileToStrings(filePath);
            foreach (var line in exLines)
            {
                MatchCollection matches = _patternRgx.Matches(line);
                foreach (Match match in matches)
                {
                    var passwordRule = new PasswordRule(match);
                    var numRepetitions = passwordRule.Password.Count(l => l == passwordRule.RequiredLetter.ToCharArray()[0]);
                    if (numRepetitions >= passwordRule.MinRepetition && numRepetitions <= passwordRule.MaxRepetition)
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
            public string RequiredLetter { get; set; }
            public string Password { get; set; }

            public PasswordRule(Match match)
            {
                MinRepetition = int.Parse(match.Groups["minRepetition"].Value);
                MaxRepetition = int.Parse(match.Groups["maxRepetition"].Value);
                RequiredLetter = match.Groups["reqLetter"].Value;
                Password = match.Groups["password"].Value;
            }
        }
    }
}
