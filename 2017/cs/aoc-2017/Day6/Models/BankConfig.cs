using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6.Models
{
    public class BankConfig
    {
        public BankConfig()
        {
            Banks = new List<Bank>();
        }
        public List<Bank> Banks { get; set; }

        public BankConfig Copy()
        {
            BankConfig newConfig = new BankConfig();
            foreach (Bank bank in Banks)
            {
                newConfig.Banks.Add(new Bank()
                {
                    Index = bank.Index,
                    NumBlocks = bank.NumBlocks
                });
            }
            return newConfig;
        }
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
