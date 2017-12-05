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
            bool dupeFound;
            int numValid = 0;
            foreach (string line in lines)
            {
                dupeFound = false;
                List<string> words = line.Split(' ').ToList();
                for (int i = 0; i < words.Count; i++)
                {
                    if (dupeFound)
                    {
                        break;
                    }
                    for (int j = i + 1; j < words.Count; j++)
                    {
                            if (String.Equals(words[i], words[j]))
                            {
                                dupeFound = true;
                                break;
                            }
                    }
                }
                if (!dupeFound)
                {
                    numValid += 1;
                }
            }
            
            return numValid;
        }
       
    }
}
