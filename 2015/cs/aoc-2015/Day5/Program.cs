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
            Console.WriteLine($@"Part2 answer: {Part2(inputList)}");
            Console.ReadLine();

        }

        public static int Part1(List<string> inputList)
        {
            return inputList.Count(str => IsGoodStringPart1(str));
        }

        public static int Part2(List<string> inputList)
        {
            return inputList.Count(str => IsGoodStringPart2(str));
        }

        public static List<string> ParseInput(string input)
        {
            return input.Split(Environment.NewLine.ToCharArray()).ToList();
        }

        public static bool IsGoodStringPart1(string input) => HasThreePlusVowelsPart1(input) && HasRepetitionPairsPart1(input) && !HasBadStringPart1(input);
 
        public static bool HasThreePlusVowelsPart1(string input)
        {
            int numVowels = input.Count(ch => vowels.Any(v => v == ch));
            return numVowels >= 3;
        }

        public static bool HasRepetitionPairsPart1(string input)
        {
            bool hasRepetitionPair = false;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i+1])
                {
                    hasRepetitionPair = true;
                    break;
                }
            }
            return hasRepetitionPair;
        }

        public static bool HasBadStringPart1(string input)
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

        public static bool IsGoodStringPart2(string input) =>
            HasRepeatWithOneInbetweenPart2(input) && HasNonOverlapPairPart2(input);
       

        public static bool HasRepeatWithOneInbetweenPart2(string input)
        {
            bool hasRepeatWithOneInbetween = false;
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == input[i + 2])
                {
                    hasRepeatWithOneInbetween = true;
                    break;
                }
            }
            return hasRepeatWithOneInbetween;
        }

        public static bool HasNonOverlapPairPart2(string input)
        {
            bool hasNonOverlapPair = false;
            string subString;
            for (int i = 0; i < input.Length - 1; i++)
            {
                subString = input.Substring(i, 2);
                for (int j = i + 2; j < input.Length - 1; j++)
                {
                    if (input[j] == subString[0] && input[j + 1] == subString[1] && i + 1 != j)
                    {
                        hasNonOverlapPair = true;
                        break;
                    }
                }
            }
            return hasNonOverlapPair;
        }
    }
}
