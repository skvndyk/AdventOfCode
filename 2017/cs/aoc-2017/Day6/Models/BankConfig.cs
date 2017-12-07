using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Models
{
    public class BankConfig
    {
        public List<Bank> Banks { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            BankConfig b = obj as BankConfig;
            if (b == null) return false;
            if (Banks.SequenceEqual(b.Banks))
            {
                return true;
            }
            return false;
        }
    }
}
