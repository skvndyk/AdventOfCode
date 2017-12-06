using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day4-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            List<string> lines = input.Split('\n').ToList();
            Console.WriteLine($"Part 1:{Part1(lines)}");
            Console.ReadLine();
        }

        public static int Part1(List<string> lines)
        {
            int numValid = 0;
            int numDupesFound = 0;
            foreach (string line in lines)
            {
                List<string> words = line.Split(' ').ToList();
                HashSet<string> hashSetWords = new HashSet<string>();
                foreach (string word in words)
                {
                    hashSetWords.Add(word);
                }
                if (words.Count != hashSetWords.Count)
                {
                    numDupesFound++;
                }
                else
                {
                    numValid++;
                }
            }
            return numValid;
        }

    }
}
