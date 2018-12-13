using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Program
    {
        public static readonly Regex _rgx= new Regex(@"(?:Step) ([A-Z]{1}) (?:must be finished before step) ([A-Z]{1}).*");
        
        static void Main(string[] args)
        {
            string filePath = "day6-2018.txt";
            List<string> lines = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(lines)}");
            //Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();
        }

        public static int Part1(List<string> lines)
        {
            StepCollection stepCollection = new StepCollection();
            List<Step> steps = ReadLinesIntoSteps(lines, stepCollection);
            
            throw new NotImplementedException();
        }

        public static int Part2(List<string> lines)
        {
            throw new NotImplementedException();
        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }

        public static List<Step> ReadLinesIntoSteps(List<string> lines, StepCollection stepCollection)
        {
            List<Step> steps = new List<Step>();
            foreach (string line in lines)
            {
                Match match = _rgx.Match(line);
                if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
                GroupCollection groups = match.Groups;
                Step step1 = GetStepFromListById(groups[1].Value, stepCollection);
                Step step2 = GetStepFromListById(groups[1].Value, stepCollection);
                step1.StepsToComeBefore.Add(step2);
                
            }
            return steps;
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
    }
}
