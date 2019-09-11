using System.Collections.Generic;

namespace Day12.Models
{
    public class Rule
    {
        public Dictionary<int, bool> Parms { get; set; }
        public bool HasPlantBefore => Parms[0];
        public bool HasPlantAfter { get; set; }

        public Rule()
        {
            Parms = new Dictionary<int, bool>()
            { 
                { -2, false },
                { -1, false },
                { 0, false },
                { 1, false },
                { 2, false }
            };
        }
    }
}