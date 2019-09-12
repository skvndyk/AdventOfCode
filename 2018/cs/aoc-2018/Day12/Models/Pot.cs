using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12.Models
{
    public class Pot
    {
        public Pot(int num, bool hasPlant)
        {
            Number = num;
            HasPlant = hasPlant;
        }
        public int Number { get; set; }
        public bool HasPlant { get; set; }
        public bool AffectedByRules { get; set; } = false;
        
    }
}
