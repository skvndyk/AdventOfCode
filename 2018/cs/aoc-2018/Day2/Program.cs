using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day2-2018.txt";
            List<string> boxIds = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(boxIds)}");
            //Console.WriteLine($"Part 2: {Part2(boxIds)}");
            Console.ReadLine();
        }

        public static int Part1(List<string> boxIds)
        {
            int appearsTwice = 0;
            int appearsThrice = 0;
            foreach (string boxId in boxIds)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                foreach (char letter in boxId)
                {
                    if (dict.TryGetValue(letter, out int val))
                    {
                        dict[letter] += 1;
                    }
                    else
                    {
                        dict[letter] = 1;
                    }
                }
                if (dict.Values.Contains(2))
                {
                    appearsTwice++;
                }
                if (dict.Values.Contains(3))
                {
                    appearsThrice++;
                }

            }
            return appearsTwice * appearsThrice;
        }

        public static int Part2(List<string> boxIds)
        {
            throw new NotImplementedException();
        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
