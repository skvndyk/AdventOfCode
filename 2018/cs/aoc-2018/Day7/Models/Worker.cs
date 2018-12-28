using System.Net;

namespace Day7.Models
{
    public class Worker
    {
       
        public int Id { get; set; }

        //todo need null checking and stuff here
        public Step CurrentStep { get; set; }
        public int? StepCtr { get; set; }

        public bool IsStepComplete => StepCtr == 0;
        public bool HasStepAssignment => CurrentStep != null;
        public bool IsActive => !IsStepComplete && HasStepAssignment;

        public void DecrementStepCtr()
        {
            if (StepCtr > 0)
            {
                StepCtr--;
            }
        }

        public void AssignStepToWorker(Step currStep)
        {
            CurrentStep = currStep;
            StepCtr = currStep.IdNum - 64;
        }

        public void RemoveFinishedStep()
        {
            CurrentStep = null;
            StepCtr = null;
        }
    }
}