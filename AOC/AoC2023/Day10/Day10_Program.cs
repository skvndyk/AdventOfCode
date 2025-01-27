using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using static AoC2023.Day10.Day10_Program;

namespace AoC2023.Day10
{
    class Day10_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day10\inputFileDay10-2023.txt";
            string exFilePath1 = $@"Day10\exInputFileDay10-2023_P1.txt";

            var exInputStrings = Common.Utilities.ReadFileToStrings(exFilePath1);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            Console.WriteLine($"Part 1 example answer: {Part1(exInputStrings)}");
            //Console.WriteLine($"Part 2 example answer: {Part2(exInputStrings)}");

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var grid = ParseInputStrings(inputStrings);
            return 0;

        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }


        #region helper methods
        private static Grid ParseInputStrings(List<string> inputStrings)
        {
            var grid = new Grid();
            for (int y = 0; y < inputStrings.Count; y++)
            {
                var line = inputStrings[y];
                for (int x = 0; x < line.Length; x++)
                {
                    grid.Tiles.Add(new Tile(line[x]) { XCoord = x, YCoord = y });
                }
            }

            grid.PrintGrid();
            return grid;
        }

        #endregion

        #region lil classes

        public class Grid
        {
            public List<Tile> Tiles { get; set; } = new List<Tile>();
            public Tile GetAnimalTile => Tiles.FirstOrDefault(x => x.TileType == TileType.Animal);

            public Tile GetTileByCoords(int x, int y) => Tiles.FirstOrDefault(t => t.XCoord == x && t.YCoord == y);
            public List<Tile> GetTileRow(int y) => Tiles.Where(t => t.YCoord == y).ToList();
            public List<Tile> GetTileColumn(int x) => Tiles.Where(t => t.XCoord == x).ToList();

            public void PrintGrid()
            {
                for (int y = 0; y < Tiles.Count; y++)
                {
                    var tileRow = GetTileRow(y).OrderBy(x => x.XCoord).ToList();
                    Console.WriteLine(string.Join("", tileRow));
                }
            }
        
        }

        public class Tile
        {
            public TileType TileType { get; set; }
            public int XCoord { get; set; }
            public int YCoord { get; set; }

            public Tile(char tileChar) => TileType = ParsingDict[tileChar];

            public override string ToString()
            {
                return ParsingDict.FirstOrDefault(x => x.Value == TileType).Key.ToString();
            }

        }

        public enum TileType
        {
            Vertical,
            Horizontal,
            NorthEast,
            NorthWest,
            SouthWest,
            SouthEast,
            Ground,
            Animal
        }

        public static Dictionary<char, TileType> ParsingDict= new Dictionary<char, TileType>()
        {
            {'|', TileType.Vertical},
            {'-', TileType.Horizontal},
            {'L', TileType.NorthEast},
            {'J', TileType.NorthWest},
            {'7', TileType.SouthWest},
            {'F', TileType.SouthEast},
            {'.', TileType.Ground},
            {'S', TileType.Animal}
        };

        #endregion
    }
}
