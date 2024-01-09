using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2023.Day1
{
    class Day5_Program
    {
        public static readonly List<(string, string)> mappingList = new List<(string source, string destination)>()
            {
                ( "seed", "soil" ),
                ( "soil", "fertilizer" ),
                ( "fertilizer", "water" ),
                ( "water", "light" ),
                ( "light", "temperature" ),
                ( "temperature", "humidity" ),
                ( "humidity", "location" )
        };

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

        private static long Part1(List<string> inputStrings)
        {

            var almanac = InputStringsToAlmanac(inputStrings);
            almanac.IdkSetSomeSeeds();
            return almanac.InputSeeds.Min(s => s.Location);
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

            

            var seedLine = processingQueue.Dequeue();
            var seedRegex = new Regex(seedsPattern);
            var seedMatches = seedRegex.Matches(seedLine);
            var seedGroup = seedMatches[0].Groups[2];

            almanac.SetInputSeeds(seedGroup.Value.Split(" ").Select(Int64.Parse).ToList());

            foreach (var (source, destination) in mappingList)
            {
                var headerToFind = $@"{source}-to-{destination} map:";
                var map = new Map(source, destination);
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
                        sourceStart: Int64.Parse(lineList[1]),
                        destinationStart: Int64.Parse(lineList[0]), 
                        rangeLength: Int64.Parse(lineList[2])
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

            return almanac;

        }
        #region lil classes
        public class Almanac
        {
            public List<Seed> InputSeeds { get; set; } = new List<Seed>();
            public List<Map> Maps { get; set; } = new List<Map>();

            public Almanac()
            {

            }

            public Map GetMapBySourceType(string sourceType) => Maps.FirstOrDefault(x => x.SourceType == sourceType);

            public void SetInputSeeds(List<long> seedInts)
            {
                InputSeeds = seedInts.Select(x => new Seed(x)).ToList();
            }

            public void IdkSetSomeSeeds()
            {
                //soil
                var soilMap = GetMapBySourceType("seed");
                foreach (var mapEntry in soilMap.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Id >= mapEntry.SourceStart && s.Id <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Id - mapEntry.SourceStart;
                        seed.Soil = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Soil == 0)
                    {
                        seed.Soil = seed.Id;
                    }
                }

                //fertilizer
                var fertilizerMap = GetMapBySourceType("soil");
                foreach (var mapEntry in fertilizerMap.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Soil >= mapEntry.SourceStart && s.Soil <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Soil - mapEntry.SourceStart;
                        seed.Fertilizer = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Fertilizer == 0)
                    {
                        seed.Fertilizer = seed.Soil;
                    }
                }

                //water
                var waterMap = GetMapBySourceType("fertilizer");
                foreach (var mapEntry in waterMap.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Fertilizer >= mapEntry.SourceStart && s.Fertilizer <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Fertilizer - mapEntry.SourceStart;
                        seed.Water = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Water == 0)
                    {
                        seed.Water = seed.Fertilizer;
                    }
                }

                //light
                var lightMap = GetMapBySourceType("water");
                foreach (var mapEntry in lightMap.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Water >= mapEntry.SourceStart && s.Water <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Water - mapEntry.SourceStart;
                        seed.Light = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Light == 0)
                    {
                        seed.Light = seed.Water;
                    }
                }

                //temperature
                var temperature = GetMapBySourceType("light");
                foreach (var mapEntry in temperature.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Light >= mapEntry.SourceStart && s.Light <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Light - mapEntry.SourceStart;
                        seed.Temperature = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Temperature == 0)
                    {
                        seed.Temperature = seed.Light;
                    }
                }

                //humidity
                var humidity = GetMapBySourceType("temperature");
                foreach (var mapEntry in humidity.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Temperature >= mapEntry.SourceStart && s.Temperature <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Temperature - mapEntry.SourceStart;
                        seed.Humidity = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Humidity == 0)
                    {
                        seed.Humidity = seed.Temperature;
                    }
                }

                //location
                var location = GetMapBySourceType("humidity");
                foreach (var mapEntry in location.MapEntries)
                {
                    var potentialSeeds = InputSeeds.Where(s => s.Humidity >= mapEntry.SourceStart && s.Humidity <= mapEntry.SourceStart + (mapEntry.RangeLength - 1));
                    foreach (var seed in potentialSeeds)
                    {
                        var idx = seed.Humidity - mapEntry.SourceStart;
                        seed.Location = mapEntry.DestinationStart + idx;
                    }
                }
                foreach (var seed in InputSeeds)
                {
                    if (seed.Location == 0)
                    {
                        seed.Location = seed.Humidity;
                    }
                }


                
            }

            public void SetThatSeed(Seed seed)
            {
                //soil
                var soilMap = GetMapBySourceType("seed");
                foreach (var mapEntry in soilMap.MapEntries)
                {
                    if (seed.Id >= mapEntry.SourceStart && seed.Id <= mapEntry.SourceStart + (mapEntry.RangeLength - 1))
                    {
                        var idx = seed.Id - mapEntry.SourceStart;
                        seed.Fertilizer = mapEntry.DestinationStart + idx;
                    }
                }

            }

        }

        public class Seed
        {
            public long Id { get; set; }
            public long Soil { get; set; } = 0;
            public long Fertilizer { get; set; } = 0;
            public long Water { get; set; } = 0;
            public long Light { get; set; } = 0;
            public long Temperature { get; set; } = 0;
            public long Humidity { get; set; } = 0;
            public long Location { get; set; } = 0;

            public Seed(long id)
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
             public long SourceStart { get; set; }
            public long DestinationStart { get; set; }
            public long RangeLength { get; set; }

             public MapEntry(long sourceStart, long destinationStart, long rangeLength)
            {
                SourceStart = sourceStart;
                DestinationStart = destinationStart;
                RangeLength = rangeLength;
            }
        }

        #endregion
    }
}
