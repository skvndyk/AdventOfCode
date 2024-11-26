using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2023.Day1
{
    class Day8_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day8\inputFileDay8-2023.txt";
            string exFilePath1 = $@"Day8\exInputFileDay8-2023_P1.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath1);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var map = ConvertInputToDataStructures(inputStrings);
            var currentNode = map.Nodes.FirstOrDefault(n => n.MapPoint == "AAA");
            var gameCounter = 0;
            while (currentNode.MapPoint != "ZZZ")
            {
                currentNode = map.ApplyDirection(currentNode);
                gameCounter++;
            }
            
            return gameCounter;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }



        #region lil classes
        public class Map
        {
            public Instructions Instructions { get; set; }
            public List<Node> Nodes { get; set; } = new List<Node>();

            public Map(string inputString)
            {
                Instructions = new Instructions(inputString);
            }

            public Node ApplyDirection(Node node)
            {
                return Move(node, Instructions.Directions[Instructions.IndexCounter]);
            }
            private Node Move(Node node, int idx)
            {
                Instructions.IncreaseIndexCounter();
                return Nodes.Where(n => n.MapPoint == node.Elements[idx]).FirstOrDefault();
            }
        }

        public class Instructions
        {
            public List<int> Directions { get; set; } = new List<int>();
            public int IndexCounter { get; set; } = 0;

            public Instructions(string inputString)
            {
                foreach (var elem in inputString)
                {
                    Directions.Add(elem == 'L' ? 0 : 1);
                }
            }

            public void IncreaseIndexCounter()
            {
                if (IndexCounter == Directions.Count - 1)
                {
                    IndexCounter = 0;
                }
                else
                {
                    IndexCounter++;
                }
            }
        }

        public class Node
        {
            public string MapPoint { get; set; }
            public List<string> Elements { get; set; } = new List<string>(2);

            public override string ToString()
            {
                return $@"{MapPoint} = ({Elements[0]}, {Elements[1]})";
            }
        }


        private static Map ConvertInputToDataStructures(List<string> inputStrings)
        {
            var map = new Map(inputStrings[0]);
            for (int i = 2; i < inputStrings.Count; i++)
            {
                var node = new Node();
                node.MapPoint = inputStrings[i][..3];
                node.Elements.Add(inputStrings[i][7..10]);
                node.Elements.Add(inputStrings[i][12..15]);
                map.Nodes.Add(node);
            }

            return map;
        }
        #endregion
    }
}
