using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12.Models
{
    public class PotRow
    {
        public Regex regex = new Regex(@"(?<rule>[\.#]{5}) *=> *(?<result>[\.#])");

        public Dictionary<char, bool> Mapper = new Dictionary<char, bool>() { { '#', true }, { '.', false } };
        public Dictionary<bool, char> ReverseMapper = new Dictionary<bool, char>() { { true, '#' }, { false, '.' } };
        public List<Rule> Rules { get; set; }
        public List<Pot> Pots { get; set; }
        public List<List<Pot>> HistoricalPots { get; set; }

        public int CurrentGeneration { get; set; }
        public int GenerationsToApply { get; set; } = 1;

        public PotRow(string initialState, string rulesFileName, int? generationsToApply = null )
        {
            CurrentGeneration = 0;
            Rules = new List<Rule>();
            HistoricalPots = new List<List<Pot>>();
            if (generationsToApply != null)
            {
                GenerationsToApply = (int) generationsToApply;
            }

            Pots = new List<Pot>();
            int i = 0;
            foreach (var symbol in initialState)
            {
                Pots.Add(new Pot(i, symbol.Equals('#')));
                i++;
            }

            SetRules(rulesFileName);
            SortPots();
            HistoricalPots.Add(Pots);
            PrintRow();
            CurrentGeneration++;
        }

        private void SortPots()
        {
            Pots = Pots.OrderBy(p => p.Number).ToList();
        }

        public void PrintRow()
        {
            string rowContents = string.Concat(Pots.Select(p => ReverseMapper[p.HasPlant]));
            //todo fix spacing on this for 2 digit gens
            Console.WriteLine($"{CurrentGeneration}: {rowContents}");
        }

        public void SetRules(string rulesFileName)
        {
            List<string> lines = File.ReadAllLines(rulesFileName).ToList();
            foreach (string line in lines)
            {
                Rules.Add(ParseRule(line));
            }
        }

        private Rule ParseRule(string ruleLine)
        {
            var match = regex.Match(ruleLine);
            var ruleBefore = match.Groups["rule"].ToString();
            var ruleAfter = match.Groups["result"].ToString();

            Rule rule = new Rule();
            for (int i = 0; i < 5; i++)
            {
                char symbol = ruleBefore[i];
                rule.Parms[i - 2] = Mapper[symbol];
            }

            rule.HasPlantAfter = Mapper[char.Parse(ruleAfter)];

            return rule;
        }

        public void ApplyRules()
        {
            for (int i = 1; i <= GenerationsToApply; i++)
            {
                List<Pot> copyPots = new List<Pot>(Pots);
                foreach (var rule in Rules)
                {
                    ApplyRule(rule, copyPots);
                }
                foreach (var copyPot in copyPots)
                {
                    if (!copyPot.AffectedByRules)
                    {
                        copyPot.HasPlant = false;
                    }
                }
                Pots = copyPots;
                SortPots();
                HistoricalPots.Add(Pots);
                //PrintRow();
                CurrentGeneration++;
                ResetPotRuleStatus();
            }
        }

        private void ResetPotRuleStatus()
        {
            foreach (var pot in Pots)
            {
                pot.AffectedByRules = false;
            }
        }

        public void ApplyRule(Rule rule, List<Pot> copyPots)
        {
            string toPrint = string.Concat(rule.Parms.Values.Select(v => ReverseMapper[v]).ToList());
            Console.WriteLine($"Rule: {toPrint}");

            foreach (var pot in Pots)
            {
                List<Pot> newPots = new List<Pot>();
                var currPot = copyPots.Where(cp => cp.Number == pot.Number).First();
                bool ruleMatches = true;
                //see if rule applies to current pot and its neighbors
                foreach (var pos in rule.Parms.Keys.AsEnumerable())
                {
                    int potNumToConsider = pot.Number + pos;

                    if (!copyPots.Any(p => p.Number == potNumToConsider))
                    {
                        //temporarily add outlier pots
                        var newPot = new Pot(potNumToConsider, false);
                        copyPots.Add(newPot);
                        newPots.Add(newPot);
                        SortPots();
                    }

                    if (copyPots.Exists(p => p.Number == potNumToConsider))
                    {
                        var potInQuestion = copyPots.Where(p => p.Number == potNumToConsider).First();
                        if (potInQuestion.HasPlant != rule.Parms[pos])
                        {
                            ruleMatches = false;
                            break;
                        }
                    }
                }

                if (ruleMatches)
                {
                    currPot.HasPlant = rule.HasPlantAfter;
                    currPot.AffectedByRules = true;
                    if (!newPots.Any(np => np.HasPlant))
                    {
                        foreach (var newPot in newPots)
                        {
                            copyPots.Remove(newPot);
                        }
                    }
                }
                else
                {
                    //dry ;(
                    foreach (var newPot in newPots)
                    {
                        copyPots.Remove(newPot);
                    }
                }
            }
        }
    }
}
