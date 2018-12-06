using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day2-2018.txt";
            List<string> boxIds = ReadTextIntoLines(filePath);
            Console.WriteLine($"Part 1: {Part1(boxIds)}");
            Console.WriteLine($"Part 2: {Part2(boxIds)}");
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

        public static string Part2(List<string> boxIds)
        {
            int idCharLength = boxIds[0].Length;

            for (int i = 0; i < boxIds.Count - 1; i++)
            {
                for (int j = i + 1; j < boxIds.Count; j++)
                {
                    Dictionary<int, char> matchCharIdxDict = new Dictionary<int, char>();

                    for (int k = 0; k < idCharLength && k <= matchCharIdxDict.Count + 1; k++)
                    {
                        if (boxIds[i][k] == boxIds[j][k])
                        {
                            matchCharIdxDict[k] = boxIds[i][k];
                        }
                    }
                
                    if (matchCharIdxDict.Count == idCharLength - 1)
                    {
                        return string.Concat(matchCharIdxDict.OrderBy(x => x.Key).Select(p => p.Value));
                    }
                }
            }

            return null;
        }

    public static List<string> ReadTextIntoLines(string filePath)
    {
        string rawInput = System.IO.File.ReadAllText(filePath);
        return rawInput.Split('\n').ToList();
    }
}
}
