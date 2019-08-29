using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9.Models
{
    public class Player
    {
        public int Value { get; set; }
        public List<Marble> Marbles { get; set; } = new List<Marble>();
        public int TotalScore => Marbles.Sum(m => m.Value);
    }
}
