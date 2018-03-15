using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class Prog
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string ChildStringList { get; set; }
        public List<Prog> ChildProgList { get; set; }
    }
}
