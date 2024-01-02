using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day2_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day2\inputFileDay2-2023.txt";
            string exFilePath1 = $@"Day2\exInputFileDay2-2023_P1.txt";
            string exFilePath2 = $@"Day2\exInputFileDay2-2023_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings1)}");
            Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var gamesDetailsList = StringsToGameDetailsList(inputStrings);
            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
           return 0;
        }

        #region lil classes
        class GameDetails
        {
            public int Id { get; set; }
            public List<Subset> Subsets = new List<Subset>();
        } 

        class Subset
        {
            public int RedCubeCount { get; set; }
            public int GreenCubeCount { get; set; }
            public int BlueCubeCount { get; set; }
        }
        #endregion

        #region local utils
        private static List<GameDetails> StringsToGameDetailsList(List<string> inputStrings)
        {
            var gameDetailsList = new List<GameDetails>();
            foreach (var str in inputStrings)
            {
                gameDetailsList.Add(StringToGameDetails(str));
            }

            return gameDetailsList;
        }
        
        private static GameDetails StringToGameDetails(string inputString)
        {
            var gameDetails = new GameDetails();
            string pattern = $@"Game (\d+):(( (\d+ \w*,?);?)*)";
            Regex regex = new Regex(pattern);

            string red = "red";
            string green = "green";
            string blue = "blue";

            var redRegex = new Regex($@"(\d+) {red}");
            var greenRegex = new Regex($@"(\d+) {green}");
            var blueRegex = new Regex($@"(\d+) {blue}");
            

            MatchCollection matches = regex.Matches(inputString);
            gameDetails.Id = int.Parse(matches[0].Groups[1].Value);

            var stepsString = matches[0].Groups[2].Value;
            var steps = stepsString.Split(";");
            foreach (var step in steps)
            {
                var redCount = 0;
                var redMatches = redRegex.Matches(step);
                if (redMatches.Count > 0)
                {
                    redCount = int.Parse(redMatches[0].Groups[1].Value);
                }
                
                var greenCount = 0;
                var greenMatches = greenRegex.Matches(step);
                if (greenMatches.Count > 0)
                {
                    greenCount = int.Parse(greenMatches[0].Groups[1].Value);
                }
                

                var blueCount = 0;
                var blueMatches = blueRegex.Matches(step);
                if (blueMatches.Count > 0)
                {
                    blueCount = int.Parse(blueMatches[0].Groups[1].Value);
                }

                var subSet = new Subset()
                {
                    RedCubeCount = redCount,
                    GreenCubeCount = greenCount,
                    BlueCubeCount = blueCount
                };

                gameDetails.Subsets.Add(subSet);
            }

            return gameDetails;

        }
        #endregion
    }
}
