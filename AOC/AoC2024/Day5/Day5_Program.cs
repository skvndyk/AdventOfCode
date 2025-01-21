using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AoC2024.Day5
{
    class Day5_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day5\inputFileDay5-2024.txt";
            string exFilePath = $@"Day5\exInputFileDay5-2024.txt";
            string exFilePath2 = $@"Day5\exInputFileDay5-2024_P2.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var sumCorrectPageNumbers = 0;
            var manual = ParseInputStrings(inputStrings);
            var isOrderCorrect = true;
            foreach (var update in manual.Updates)
            {
                isOrderCorrect = true;
                foreach (var pageNum in update.PageNumbers)
                {
                    var relevantRules = manual.Rules.Where(r => r.IsPageNumberPartOfRule(pageNum)).ToList();
                    if (relevantRules.Any())
                    {
                        foreach (var rule in relevantRules)
                        {
                            if (!update.IsRuleFollowed(rule))
                            {
                                isOrderCorrect = false;
                                break;
                            }
                        }
                    }

                    if (!isOrderCorrect) break;
                }

                update.DoesFollowRules = isOrderCorrect;
            }

            var correctUpdates = manual.Updates.Where(u => u.DoesFollowRules).ToList();
            foreach (var cUpdate in correctUpdates)
            {
                sumCorrectPageNumbers += cUpdate.MiddleNumber;
            }
            return sumCorrectPageNumbers;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;  
        }

        private static Manual ParseInputStrings(List<string> inputStrings)
        {
            var rules = new List<Rule>();
            var i = 0;
            for (; !string.IsNullOrEmpty(inputStrings[i]); i++)
            {
                var splitString = inputStrings[i].Split('|');
                rules.Add(new Rule
                {
                    Before = int.Parse(splitString[0]),
                    After = int.Parse(splitString[1])
                });
            }

            i++;

            var updates = new List<Update>();

            for (; i < inputStrings.Count; i++)
            {
                var update = new Update();
                var splitString = inputStrings[i].Split(',');
                foreach (var s in splitString)
                {
                    update.PageNumbers.Add(int.Parse(s));
                }

                updates.Add(update);
            }

            return new Manual(rules, updates);
        }

        #region lil classes
        private class Rule
        {
            public int Before { get; set; }
            public int After { get; set; }

            public override string ToString()
            {
                return $"{Before} -> {After}";
            }

            public bool IsPageNumberPartOfRule(int pageNum)
            {
                return (Before == pageNum) || (After == pageNum);
            }
        }

        private class Update
        {
            public List<int> PageNumbers { get; set; } = new List<int>();
            public bool DoesFollowRules = false;

            public bool IsRuleFollowed(Rule rule)
            {
                var indexOfBefore = PageNumbers.IndexOf(rule.Before);
                var indexOfAfter = PageNumbers.IndexOf(rule.After);

                if (indexOfBefore != -1 && indexOfAfter != -1)
                {
                    return indexOfBefore < indexOfAfter;
                }

                return true;
            }

            public int MiddleNumber => PageNumbers[(int)Math.Floor((decimal)PageNumbers.Count / 2)];
            public override string ToString()
            {
                return string.Join(",", PageNumbers);
            }
        }

        private class Manual
        {
            public List<Rule> Rules { get; set; } = new List<Rule>();
            public List<Update> Updates { get; set; } = new List<Update>();

            public Manual(List<Rule> rules, List<Update> updates)
            {
                Rules = rules;
                Updates = updates;
            }
        }
        #endregion
    }
}
