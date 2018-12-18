using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class Step
    {
        public string Id { get; set; }
        public int IdNum => Id.ToCharArray().First();
        public List<Step> PreviousStepRequirements { get; set; } = new List<Step>();
        public Step GetEarlierStep(Step other)
        {
            return IdNum < other.IdNum ? this : other;
        }
        //not using these rn but maybe need them for p2?
        public Step PreviousStep;   
        public int PathPos;

        public override bool Equals(object obj)
        {
            var st = obj as Step;
            if (st == null) return false;
            return Id == st.Id;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Id.GetHashCode();
            return hash;
        }
    }
}
