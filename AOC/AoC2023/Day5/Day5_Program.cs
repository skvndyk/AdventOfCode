using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day5_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day5\inputFileDay5-2023.txt";
            string exFilePath1 = $@"Day5\exInputFileDay5-2023_P1.txt";
            string exFilePath2 = $@"Day5\exInputFileDay5-2023_P2.txt";

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

            var almanac = InputStringsToAlmanac(inputStrings);

            return 0;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static Almanac InputStringsToAlmanac(List<string> inputStrings)
        {
            var almanac = new Almanac();
            var processingQueue = new Queue<string>();
            inputStrings.ForEach(processingQueue.Enqueue);

            string seedsPattern = $@"(seeds: )(.*)";
            string seedToSoilPattern = $@"(seed-to-soil map: )(.*)";
            string soilToFertilizerPattern = $@"(soil-to-fertilizer map: )(.*)";
            string fertilizerToWaterPattern = $@"(fertilizer-to-water map: )(.*)";
            string waterToLightPattern = $@"(water-to-light map: )(.*)";
            string lightToTemperaturePattern = $@"(light-to-temperature map: )(.*)";
            string temperatureToHumidityPattern = $@"(temperature-to-humidity: )(.*)";
            string humidityToLocationPattern = $@"(humidity-to-location: )(.*)";

            var mappingList = new List<(string source, string destination)>()
            {
                ( "seed", "soil" ),
                ( "soil", "fertilizer" ),
                ( "fertilizer", "water" ),
                ( "water", "light" ),
                ( "light", "temperature" ),
                ( "temperature", "humidity" ),
                ( "humidity", "location" )
            };

            //var mapPatterns = new List<string>()
            //{
            //    seedToSoilPattern,
            //    soilToFertilizerPattern,
            //    fertilizerToWaterPattern,
            //    fertilizerToWaterPattern,
            //    waterToLightPattern,
            //    lightToTemperaturePattern,
            //    temperatureToHumidityPattern,
            //    humidityToLocationPattern

            //}


            var seedLine = processingQueue.Dequeue();
            var seedRegex = new Regex(seedsPattern);
            var seedMatches = seedRegex.Matches(seedLine);
            var seedGroup = seedMatches[0].Groups[2];
            almanac.SetSeeds(seedGroup.Value.Split(" ").Select(int.Parse).ToList());

            foreach (var mapEntry in mappingList)
            {
                var headerToFind = $@"{mapEntry.source}-to-{mapEntry.destination} map:";
                var map = new Map(mapEntry.source, mapEntry.destination);
                almanac.Maps.Add(map);

                var nextLine = processingQueue.Dequeue();
                while (!nextLine.Contains(headerToFind))
                {
                    nextLine = processingQueue.Dequeue();
                }

                var keepLooping = true;
                var mapLine = processingQueue.Dequeue();
                while (keepLooping)
                {
                    var lineList = mapLine.Split(" ").ToList();
                    map.MapEntries.Add(new MapEntry(
                        sourceRange: int.Parse(lineList[1]),
                        destinationRange: int.Parse(lineList[0]), 
                        rangeLength: int.Parse(lineList[2])
                        ));
                    //todo work on this so it doesn't dequue end of filead
                    if (processingQueue.Count > 0)
                        mapLine = processingQueue.Dequeue();
                    else
                        keepLooping = false;

                    if (mapLine == "")
                        keepLooping = false;
                }
            }

            return null;

        }
        #region lil classes
        public class Almanac
        {
            public List<Seed> Seeds { get; set; } = new List<Seed>();
            public List<Map> Maps { get; set; } = new List<Map>();

            public Almanac()
            {

            }
            public void SetSeeds(List<int> seedInts)
            {
                Seeds = seedInts.Select(x => new Seed(x)).ToList();
            }

        }

        public class Seed
        {
            public int Id { get; set; }
            public int Soil { get; set; } = 0;
            public int Fertilizer { get; set; } = 0;
            public int Water { get; set; } = 0;
            public int Light { get; set; } = 0;
            public int Temperature { get; set; } = 0;
            public int Humidity { get; set; } = 0;
            public int Location { get; set; } = 0;

            public Seed(int id)
            {
                Id = id;
            }
        }

        public class Map
        {
            public string SourceType { get; set; }
            public string DestinationType { get; set; }
            public List<MapEntry> MapEntries {get; set; } = new List<MapEntry>();
           
            public Map(string sourceType, string destinationType)
            {
                SourceType = sourceType;
                DestinationType = destinationType;
            }
        }

        public class MapEntry
        {
             public int SourceStart { get; set; }
            public int SourceRange { get; set; }

            public int DestinationStart { get; set; }
            public int DestinationRange { get; set; }

            public int RangeLength { get; set; }

             public MapEntry(int sourceRange, int destinationRange, int rangeLength)
            {
                SourceRange = sourceRange;
                DestinationRange = destinationRange;
                RangeLength = rangeLength;
            }
        }

        #endregion
    }
}
