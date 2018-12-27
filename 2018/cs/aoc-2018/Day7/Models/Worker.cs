using System.Net;

namespace Day7.Models
{
    public class Worker
    {
       
        public int Id { get; set; }

        //todo need null checking and stuff here
        public Step CurrentStep { get; set; }
        public int StepCtr { get; protected set; }

        public bool IsStepComplete => StepCtr == 0;
        public bool HasStepAssignment => CurrentStep != null;
        public bool HasWorkToDo => !IsStepComplete && HasStepAssignment;

        public void DecrementStepCtr() => StepCtr = StepCtr > 0 ? StepCtr-- : StepCtr;
        public void AssignStepToWorker(Step currStep)
        {
            CurrentStep = currStep;
            StepCtr = currStep.IdNum;
        }
    }
}