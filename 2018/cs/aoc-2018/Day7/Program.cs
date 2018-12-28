using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Day7.Models;

namespace Day7
{
    public class Program
    {
        public static readonly Regex _rgx= new Regex(@"(?:Step) ([A-Z]{1}) (?:must be finished before step) ([A-Z]{1}).*");
        
        static void Main(string[] args)
        {
            string filePath = "day7-2018.txt";
            List<string> lines = ReadTextIntoLines(filePath);
            int numWorkersNeeded = 5;
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines, numWorkersNeeded)}");
            Console.ReadLine();
        }

        public static string Part1(List<string> lines)
        {
            StepCollection stepCollection = new StepCollection();
            ReadLinesIntoSteps(lines, stepCollection);
            TraverseStepTree(stepCollection);
            return GenerateTreeString(stepCollection);
        }

        public static int Part2(List<string> lines, int numWorkersNeeded)
        {
            //176: too low
            StepCollection stepCollection = new StepCollection();
            ReadLinesIntoSteps(lines, stepCollection);
            WorkLog workLog = new WorkLog();
            workLog.WorkerCollection = new WorkerCollection(numWorkersNeeded);
            DoTheWork(stepCollection, numWorkersNeeded, workLog);
            return workLog.TimeElapsed;
        }

        public static void DoTheWork(StepCollection stepCollection, int numWorkersNeeded, WorkLog workLog)
        {
            string headerString = "Second\t\t";
            for (int i = 1; i <= numWorkersNeeded; i++)
            {
                headerString += $"Worker {i}\t";
            }
            headerString += "Done\n";
            System.IO.File.WriteAllText("day7-2018p2-results.txt", headerString);
           //todo would be nice to factor this stuff out between part1 and part2...
            Step currStep = GetFirstStep(stepCollection);
            stepCollection.AssignedSteps.Add(currStep);
            workLog.WorkerCollection.GetWorkerById(workLog.CurrWorkerIdx).AssignStepToWorker(currStep);
            while (!stepCollection.AllStepsCompleted)
            {
                AssignStepsIfPossible(stepCollection, workLog, currStep);
                WorkUntilReassignmentNeeded(stepCollection, workLog);
            }
        }


        public static void AssignStepsIfPossible(StepCollection stepCollection, WorkLog workLog, Step currStep)
        {
            while (GetNextStepP2(stepCollection, currStep) != null && workLog.WorkerCollection.InactiveWorkers.Count > 0)
            {
                currStep = GetNextStepP2(stepCollection, currStep);
                Worker inactiveWorker = workLog.WorkerCollection.InactiveWorkers.First();
                inactiveWorker.AssignStepToWorker(currStep);
                stepCollection.AssignedSteps.Add(currStep);
                AssignStepsIfPossible(stepCollection, workLog, currStep);
            }
       }

        public static void WorkUntilReassignmentNeeded(StepCollection stepCollection, WorkLog workLog)
        {
            if (workLog.WorkerCollection.HasActiveWorkers)
            {
                List<Worker> currActiveWorkers = workLog.WorkerCollection.ActiveWorkers;
                int initialCount = workLog.WorkerCollection.ActiveWorkers.Count;
                int currCount = initialCount;
                while (currCount == initialCount)
                {
                    WriteCurrentStatusToScreen(workLog, stepCollection);
                    workLog.TimeElapsed++;
                    foreach (Worker worker in currActiveWorkers)
                    {
                        worker.DecrementStepCtr();
                        if (worker.IsStepComplete)
                        {
                            stepCollection.CompletedSteps.Add(worker.CurrentStep);
                            worker.RemoveFinishedStep();
                        }
                    }
                    currCount = workLog.WorkerCollection.ActiveWorkers.Count;
                }
            }
        }

        public static void WriteCurrentStatusToScreen(WorkLog workLog, StepCollection stepCollection)
        {
            int numWorkers = workLog.WorkerCollection.Workers.Count;
            string outputString = $"{workLog.TimeElapsed}\t\t\t";
            for (int i = 0; i < numWorkers; i++)
            {
                Worker currWorker = workLog.WorkerCollection.Workers[i];
                outputString += currWorker.IsActive ? $"{currWorker.CurrentStep.Id}\t\t\t" : ".\t\t\t";
            }
            outputString += stepCollection.CompletedSteps.Aggregate("", (current, step) => current + step.Id);
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"day7-2018p2-results.txt", true))
            {
                file.WriteLine(outputString);
            }
        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }

        public static void ReadLinesIntoSteps(List<string> lines, StepCollection stepCollection)
        {
            List<Step> steps = new List<Step>();
            foreach (string line in lines)
            {
                Match match = _rgx.Match(line);
                if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
                GroupCollection groups = match.Groups;
                Step step1 = GetStepFromListById(groups[1].Value, stepCollection);
                Step step2 = GetStepFromListById(groups[2].Value, stepCollection);
                step2.PreviousStepRequirements.Add(step1);
            }
        }

        public static Step GetStepFromListById(string id, StepCollection stepCollection)
        {   
            Step step = stepCollection.AllSteps.FirstOrDefault(s => s.Id == id);
            if (step != null)
            {
                return step;
            }
            else
            {
                Step newStep = new Step(){Id = id};
                stepCollection.AllSteps.Add(newStep);
                return newStep;
            }
        }

        public static void TraverseStepTree(StepCollection stepCollection)
        {
            Step currStep = GetFirstStep(stepCollection);
            stepCollection.CompletedSteps.Add(currStep);
            
            while (stepCollection.CompletedSteps.Count < stepCollection.AllSteps.Count)
            {
                currStep = GetNextStep(stepCollection, currStep);
                stepCollection.CompletedSteps.Add(currStep);
            }
        }

        public static string GenerateTreeString(StepCollection stepCollection)
        {
            return stepCollection.CompletedSteps.Aggregate("", (current, step) => current + step.Id);
        }

        public static Step GetNextStep(StepCollection stepCollection, Step currStep)
        {
            List<Step> nonCompletedSteps = stepCollection.NonCompletedSteps;
            List<Step> potentialNextSteps = nonCompletedSteps.Where(step => step.PreviousStepRequirements.All(s => stepCollection.CompletedSteps.Contains(s))).ToList();
            return potentialNextSteps.First(s => s.IdNum == potentialNextSteps.Min(s2 => s2.IdNum));
        }

        public static Step GetNextStepP2(StepCollection stepCollection, Step currStep)
        {
            List<Step> unassignedSteps = stepCollection.UnassignedSteps;
            List<Step> potentialNextSteps = unassignedSteps.Where(step => step.PreviousStepRequirements.All(s => stepCollection.CompletedSteps.Contains(s))).ToList();
            return potentialNextSteps.FirstOrDefault(s => s.IdNum == potentialNextSteps.Min(s2 => s2.IdNum));
        }

        public static Step GetFirstStep(StepCollection stepCollection)
        {
            //todo could this be done in fewer lines?
            var candidates = stepCollection.AllSteps.Where(s => s.PreviousStepRequirements.Count == 0).ToList();
            return candidates.First(s => s.IdNum == candidates.Min(s2 => s2.IdNum));
        }
    }
}
