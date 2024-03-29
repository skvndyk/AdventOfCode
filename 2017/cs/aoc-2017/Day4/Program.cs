﻿using System;
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
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines)}");
            Console.ReadLine();
        }

        public static int Part1(List<string> lines)
        {
            int numValid = 0;
            foreach (string line in lines)
            {
                List<string> words = line.Split(' ').ToList();
                HashSet<string> hashSetWords = new HashSet<string>();
                foreach (string word in words)
                {
                    hashSetWords.Add(word);
                }
                if (words.Count == hashSetWords.Count)
                {
                    numValid++;
                }
            }
            return numValid;
        }

        public static int Part2(List<string> lines)
        {
            int numValid = 0;
            foreach (string line in lines)
            {
                List<string> words = line.Split(' ').ToList();
                HashSet<string> hashedWords = new HashSet<string>();
                foreach (string word in words)
                {
                    char[] letters = word.ToCharArray();
                    Array.Sort(letters);
                    hashedWords.Add(letters.Aggregate("", (current, letter) => current + letter));
                }
               
                if (words.Count == hashedWords.Count)
                {
                    numValid++;
                }
            }
            return numValid;
        }

    }
}
