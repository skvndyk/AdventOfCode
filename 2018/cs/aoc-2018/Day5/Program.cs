using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Day5
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day5-2018.txt";
            string bigString = ReadTextIntoString(filePath);
            //Console.WriteLine($"Part 1: {Part1(bigString)}");
            Console.WriteLine($"Part 2: {Part2(bigString)}");
            Console.ReadLine();

        }

        public static int Part1(string bigString)
        {
            return GeneralDestruction(bigString).Length;
        }



        public static int Part2(string bigString)
        {
            string currString;
            int minVal = 99999;
            IEnumerable<int> alphabetEnum = Enumerable.Range(65, 26);
            List<char> alphaList = alphabetEnum.Select(Convert.ToChar).ToList();
            foreach (char alph in alphaList)
            {
                Console.WriteLine($@"removing {alph}");
                currString = bigString;
                List<int> idxsToDestroy = new List<int>();
                for (int i = 0; i < currString.Length; i++)
                {
                    if (string.Equals(currString[i].ToString().ToUpper(), alph.ToString()))
                    {
                        idxsToDestroy.Add(i);
                    }
                }
                currString = DestroyIdxs(idxsToDestroy, currString);

                // timing the process
                Stopwatch watch = new Stopwatch();
                watch.Start();
                int postDestroyLength = GeneralDestruction(currString).Length;
                watch.Stop();
                //

                Console.WriteLine($@"compacting string with {alph} removed {watch.Elapsed.TotalSeconds} seconds");
                if (postDestroyLength < minVal)
                {
                    minVal = postDestroyLength;
                }
            }
            return minVal;
        }

        public static string GeneralDestruction(string str)
        {
            bool moreToDestroy = true;
            string currString = str;

            do
            {
                List<int> idxsToDestroy = new List<int>();
                for (int i = 0; i < currString.Length - 1; i++)
                {
                    if (string.Equals(currString[i].ToString().ToUpper(), currString[i + 1].ToString().ToUpper()) &&
                        currString[i] != currString[i + 1])
                    {
                        idxsToDestroy.Add(i);
                        idxsToDestroy.Add(i + 1);
                        break;
                    }
                }
                if (idxsToDestroy.Count > 0)
                {

                    currString = DestroyIdxs(idxsToDestroy, currString);
                }
                if (idxsToDestroy.Count == 0 || currString == "")
                {
                    moreToDestroy = false;
                }

            } while (moreToDestroy);
            return currString;
        }


        public static string DestroyIdxs(List<int> destructionTargets, string currString)
        {
            StringBuilder newString = new StringBuilder();
            List<int> idxsToKeep = Enumerable.Range(0, currString.Length).Where(i => !destructionTargets.Contains(i))
                .ToList();
            if (idxsToKeep.Count > 0)
            {
                foreach (int idx in idxsToKeep)
                {
                    newString.Append(currString[idx]);
                }
            }
            return newString.ToString();
        }
        public static string ReadTextIntoString(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
