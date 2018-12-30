using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8.Models
{
    public class Tree
    {
        public List<Node> AllNodes { get; set; } = new List<Node>();
        public List<Node> VisitedNodes { get; set; } = new List<Node>();
    }
}
