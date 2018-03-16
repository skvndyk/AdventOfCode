using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class Prog
    {
        public Prog()
        {
            ChildStringList = new List<string>();
            ChildProgList = new List<Prog>();
            ParentProgList = new List<Prog>();
        }
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> ChildStringList { get; set; }
        public List<Prog> ChildProgList { get; set; }
        public List<Prog> ParentProgList { get; set; }
    }
}
