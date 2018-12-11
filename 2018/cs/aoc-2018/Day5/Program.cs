using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day5-2018.txt";
            string bigString = ReadTextIntoString(filePath);
            Console.WriteLine($"Part 1: {Part1(bigString)}");
            //Console.WriteLine($"Part 2: {Part2(bigString)}");
            Console.ReadLine();

        }

        public static int Part1(string bigString)
        {
            bool moreToDestroy = true;
            string currString = bigString;
            
            do
            {
                List<int> idxsToDestroy = new List<int>();
                for (int i = 0; i < currString.Length - 1; i++)
                {
                    if (string.Equals(currString[i].ToString().ToUpper(), currString[i + 1].ToString().ToUpper()) &&
                        currString[i] != currString[i + 1])
                    {
                        idxsToDestroy.Add(i);
                        idxsToDestroy.Add(i+1);
                        break;
                    }
                }
                if (idxsToDestroy.Count > 0)
                {
                    StringBuilder newString = new StringBuilder();
                    List<int> idxsToKeep = Enumerable.Range(0, currString.Length).Where(i => !idxsToDestroy.Contains(i))
                        .ToList();
                    if (idxsToKeep.Count > 0)
                    {
                        foreach (int idx in idxsToKeep)
                        {
                            newString.Append(currString[idx]);
                        }
                    }
                    currString = newString.ToString();
                }
                if (idxsToDestroy.Count == 0 || currString == "")
                {
                    moreToDestroy = false;
                }

            } while (moreToDestroy);
            return currString.Length;
        }


        public static int Part2(string bigString)
        {
            throw new NotImplementedException();
        }

        public static string ReadTextIntoString(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
