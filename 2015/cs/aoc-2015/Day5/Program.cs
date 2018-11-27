using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Program
    {
        private static List<string> badStrings = new List<string>() { "ab", "cd", "pq", "xy" };
        private static List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

        static void Main(string[] args)
        {
            string filePath = "day5-2015.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<string> inputList = ParseInput(input);
            Console.WriteLine($@"Part1 answer: {Part1(inputList)}");
            //Console.WriteLine($@"Part2 answer: {Part2(inputList)}");
            Console.ReadLine();

        }

        public static int Part1(List<string> inputList)
        {
            return inputList.Count(str => IsGoodString(str));
        }

        public static int Part2(List<string> inputList)
        {
            throw new NotImplementedException();
        }

        public static List<string> ParseInput(string input)
        {
            return input.Split(Environment.NewLine.ToCharArray()).ToList();
        }

        public static bool IsGoodString(string input) => HasThreePlusVowels(input) && HasRepetitionPairs(input) && !HasBadString(input);
 
        public static bool HasThreePlusVowels(string input)
        {
            int numVowels = input.Count(ch => vowels.Any(v => v == ch));
            return numVowels >= 3;
        }

        public static bool HasRepetitionPairs(string input)
        {
            bool hasRepetitionPair = false;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i+1])
                {
                    hasRepetitionPair = true;
                }
            }
            return hasRepetitionPair;
        }

        public static bool HasBadString(string input)
        {
            bool hasBadString = false;
            string subString = "";
            for (int i = 0; i < input.Length - 1; i++)
            {
                subString = input.Substring(i, 2);
                if (badStrings.Any(s => s == subString))
                {
                    hasBadString = true;
                    break;
                }
            }
            return hasBadString;
        }
    }
}
