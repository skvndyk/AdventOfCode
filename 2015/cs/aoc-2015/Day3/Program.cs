using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day3-2015.txt";
            string input = System.IO.File.ReadAllText(filePath);
            Console.WriteLine($@"Part1 answer: {Part1(input)}");
            Console.WriteLine($@"Part2 answer: {Part2(input)}");
            Console.ReadLine();
        }

        public static int Part1(string input)
        {
            return GetPath(input).Count;
        }

        public static int Part2(string input)
        {
            //could prob do something fancy with linq
            List<char> santaDirs = new List<char>();
            List<char> robotDirs = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    santaDirs.Add(input[i]);
                }
                else
                {
                    robotDirs.Add(input[i]);
                }
            }

            HashSet<Tuple<int, int>> santaPath = GetPath(String.Concat(santaDirs));
            HashSet<Tuple<int, int>> robotPath = GetPath(String.Concat(robotDirs));
            return santaPath.Union(robotPath).ToList().Count;
        }

        public static HashSet<Tuple<int, int>> GetPath(string input)
        {
            int x = 0;
            int y = 0;
            Tuple<int, int> oldCoords = new Tuple<int, int>(x, y);
            HashSet<Tuple<int, int>> coords = new HashSet<Tuple<int, int>>() { oldCoords };
            foreach (char dir in input)
            {
                (x, y) = GetNewCoords(oldCoords, dir);
                oldCoords = new Tuple<int, int>(x, y);
                coords.Add(oldCoords);
            }
            return coords;
        }
        public static (int, int) GetNewCoords(Tuple<int, int> oldCoords, char dir)
        {
            int x = oldCoords.Item1;
            int y = oldCoords.Item2;
            switch (dir)
            {
                case '^':
                    y++;
                    break;
                case 'v':
                    y--;
                    break;
                case '<':
                    x--;
                    break;
                case '>':
                    x++;
                    break;
                default:
                    throw new Exception("Found unexpected character");
            }
            return (x, y);
        }
    }
}
