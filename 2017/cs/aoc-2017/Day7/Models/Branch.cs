using System.Collections.Generic;

namespace Day7.Models
{
    public class Branch
    {
        public Prog Parent { get; set; }
        public int BranchWeight { get; set; }
        //todo implement this
        public List<Prog> FirstGenChildren { get; set; }
    }
}