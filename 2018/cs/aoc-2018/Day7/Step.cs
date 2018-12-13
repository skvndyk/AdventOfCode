using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Step
    {
        public string Id { get; set; }
        public int IdNum => Id.ToCharArray().First();
        public List<Step> StepsToComeBefore { get; set; } = new List<Step>();
        public Step GetEarlierStep(Step other)
        {
            return IdNum < other.IdNum ? this : other;
        }

        public Step NextStep;
        public Step PreviousStep;

        //public override bool Equals(object obj)
        //{
        //    var st = obj as Step;
        //    if (st == null) return false;
        //    return Id == st.Id;
        //}

        //public override int GetHashCode()
        //{
        //    int hash = GetType().GetHashCode();
        //    hash = (hash * 397) ^ Id.GetHashCode();
        //    return hash;
        //}
    }
}
