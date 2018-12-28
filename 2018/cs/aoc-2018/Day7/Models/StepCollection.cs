using System.Collections.Generic;
using System.Linq;

namespace Day7.Models
{
    public class StepCollection
    {
        //todo placed vs completed steps is confusing btw 2 parts of this problem
        public List<Step> AllSteps { get; set; } = new List<Step>();

        //for p1
        public List<Step> CompletedSteps { get; set; } = new List<Step>();
        public List<Step> NonCompletedSteps => AllSteps.Except(CompletedSteps).ToList();

      
        //todo, hmm this would allow for duplicates but eh
        public bool AllStepsCompleted => CompletedSteps.Count == AllSteps.Count;
    }
}
