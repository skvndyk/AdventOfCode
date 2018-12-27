﻿using System;
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
            //Console.WriteLine($"Part 2: {Part2(lines, numWorkersNeeded)}");
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
            StepCollection stepCollection = new StepCollection();
            ReadLinesIntoSteps(lines, stepCollection);
            AssignStepsToWorkers(stepCollection, numWorkersNeeded);
            throw new NotImplementedException();
        }

        public static void AssignStepsToWorkers(StepCollection stepCollection, int numWorkersNeeded)
        {
            int workerIdx = 0;
            WorkerCollection workerCollection = new WorkerCollection(numWorkersNeeded);
            //todo would be nice to factor this stuff out between part1 and part2...
            Step currStep = GetFirstStep(stepCollection);
            stepCollection.PlacedSteps.Add(currStep);
            workerCollection.GetWorkerById(workerIdx).CurrentStep = currStep;
            while (stepCollection.PlacedSteps.Count < stepCollection.AllSteps.Count)
            {
                currStep = GetNextStep(stepCollection, currStep);
                stepCollection.PlacedSteps.Add(currStep);
            }
        }

        public static void WorkUntilReassignmentNeeded(WorkerCollection workerCollection)
        {
            while (workerCollection.WorkersNeedingWork != null && workerCollection.WorkersNeedingWork.Count > 0)
            {
                foreach (Worker worker in workerCollection.WorkersNeedingWork)
                {
                    worker.DecrementStepCtr();
                }
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
            stepCollection.PlacedSteps.Add(currStep);
            
            while (stepCollection.PlacedSteps.Count < stepCollection.AllSteps.Count)
            {
                currStep = GetNextStep(stepCollection, currStep);
                stepCollection.PlacedSteps.Add(currStep);
            }
        }

        public static string GenerateTreeString(StepCollection stepCollection)
        {
            return stepCollection.PlacedSteps.Aggregate("", (current, step) => current + step.Id);
        }

        public static Step GetNextStep(StepCollection stepCollection, Step currStep)
        {
            List<Step> potentialNextSteps = new List<Step>();
            List<Step> unplacedSteps = stepCollection.AllSteps.Except(stepCollection.PlacedSteps).ToList();
            foreach (Step step in unplacedSteps)
            {
                if (step.PreviousStepRequirements.All(s => stepCollection.PlacedSteps.Contains(s)))
                {
                    potentialNextSteps.Add(step);
                }
            }
            return potentialNextSteps.First(s => s.IdNum == potentialNextSteps.Min(s2 => s2.IdNum));

        }

        public static Step GetFirstStep(StepCollection stepCollection)
        {
            //todo could this be done in fewer lines?
            var candidates = stepCollection.AllSteps.Where(s => s.PreviousStepRequirements.Count == 0).ToList();
            return candidates.First(s => s.IdNum == candidates.Min(s2 => s2.IdNum));
        }
    }
}
