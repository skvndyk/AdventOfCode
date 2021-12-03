using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day2_2021
{
    class Program
    {
        public static readonly Regex _patternRgx =
         new Regex(@"(?'direction'forward|up|down) (?'units'\d*)");

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string filePath = "day2-2021.txt";
            string exFilePath = "day2-ex-2021.txt";
            List<string> inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($@"Part 1 Answer:{ParseInputLinesPart1(inputStrings)}");
            //Console.WriteLine($@"Part 2 Answer:{ParseInputLinesPart2(inputStrings)}");
            Console.ReadLine();
        }

        private static int ParseInputLinesPart1(List<string> inputStrings)
        {
            var location = new Location { Position = 0, Depth = 0 };
            var steps = new List<Step>();
            foreach (var str in inputStrings)
            {
                var match = _patternRgx.Match(str);
                steps.Add(new Step(match.Groups["direction"].Value, int.Parse(match.Groups["units"].Value)));
            }

            foreach (var step in steps)
            {
                location.ApplyStep(step);
            }

            return location.Position * location.Depth;
        }

        private static void ParseInputLinesPart2(List<string> inputStrings)
        {

        }

        public class Step
        {
            public string Direction { get; set; }
            public int Units { get; set; }

            public Step(string direction, int units)
            {
                Direction = direction;
                Units = units;
            }
        }

        public class Location
        {
            public int Position { get; set; }
            public int Depth { get; set; }

            public void ApplyStep(Step step)
            {
                switch (step.Direction)
                {
                    case "forward":
                        Position += step.Units;
                        break;
                    case "down":
                        Depth += step.Units;
                        break;
                    case "up":
                        Depth -= step.Units;
                        break;

                }
            }
        }
    }
}
