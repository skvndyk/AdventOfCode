using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12.Models
{
    public class PotRow
    {
        public List<Rule> Rules { get; set; }
        public List<Pot> Pots { get; set; }

        public int CurrentGeneration { get; set; }

        public PotRow(string initialState)
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
            var pots = new List<Pot>();
            var currPot = new Pot(2, false);
            for (int i = 0; i < 5; i++)
            {
                char symbol = ruleLine[i];
                pots.Add(new Pot(i, symbol.Equals('#')));
            }
            foreach (var pot in pots)
            {
                
            }
        }
    }
}
