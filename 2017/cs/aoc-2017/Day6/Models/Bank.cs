using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Models
{
    public class Bank
    {
        public int Index { get; set; }
        public int NumBlocks { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Bank b = obj as Bank;
            if (b == null) return false;
            if (Index == b.Index && NumBlocks == b.NumBlocks)
            {
                return true;
            }
            return false;
        }
    }
}
