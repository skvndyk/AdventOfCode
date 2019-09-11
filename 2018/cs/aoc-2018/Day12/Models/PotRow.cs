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

        public int CurrentGeneration { get; set; }

        public PotRow(string initialState, string rulesFileName)
        {
            CurrentGeneration = 0;
            Rules = new List<Rule>();

            Pots = new List<Pot>();
            int i = 0;
            foreach (var symbol in initialState)
            {
                Pots.Add(new Pot(i, symbol.Equals('#')));
                i++;
            }

            SetRules(rulesFileName);
            PrintRow();
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
    }
}
