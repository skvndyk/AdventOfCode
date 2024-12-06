using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2024.Day1
{
    class Day2_Program
    {
        static void Main(string[] args)
        {
            string filePath = $@"Day2\inputFileDay2-2024.txt";
            string exFilePath1 = $@"Day2\exInputFileDay2-2024_P1.txt";
            string exFilePath2 = $@"Day2\exInputFileDay2-2024_P2.txt";

            var exInputStrings1 = Common.Utilities.ReadFileToStrings(exFilePath1);
            var exInputStrings2 = Common.Utilities.ReadFileToStrings(exFilePath2);
            var inputStrings = Common.Utilities.ReadFileToStrings(filePath);

            //Console.WriteLine($"Example Part 1 answer: {Part1(exInputStrings1)}");
            //Console.WriteLine($"Example Part 2 answer: {Part2(exInputStrings2)}");

            Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            //Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var blah = ParseInputStrings(inputStrings);
            var safeRecords = new List<List<int>>();
            var numSafeRecords = 0;
            var numRecordsProcessed = 0;
            foreach (var record in blah)
            {

                //Console.WriteLine(string.Join(" ", record));
                var isAscending = false;
                if (record[0] == record[1] || (Math.Abs(record[0] - record[1]) > 3))
                {
                    //Console.WriteLine("either first 2 are equal or difference is greater than 3");
                    continue;
                }

                if (record[0] < record[1])
                {
                    isAscending = true;
                }
                for (int i = 1; i < record.Count - 1; i++)
                {
                    if ((record[i] > record[i + 1] && isAscending) || (record[i] < record[i + 1] && !isAscending) || (record[i] == record[i+1]))
                    {
                        //Console.WriteLine("either not ascending or not descending or they're equal");
                        break;
                    }

                    else
                    {
                        if (Math.Abs(record[i] - record[i + 1]) > 3)
                        {
                            //Console.WriteLine("difference greater than 3");
                            break;
                        }

                        else if (i == record.Count - 2)
                        {
                            numSafeRecords++;
                            safeRecords.Add(record);
                            break;
                        }
                    }
                }
                numRecordsProcessed++;
            }
            return numSafeRecords;
        }

        private static int Part2(List<string> inputStrings)
        {
            return 0;
        }

        private static List<List<int>> ParseInputStrings(List<string> strings)
        {
            var recordList = new List<List<int>>();
            foreach (var line in strings)
            {
                var record = new List<int>();
                var splitRecord = line.Split(" ");
                foreach (var rec in splitRecord)
                {
                    record.Add(int.Parse(rec));
                }

                recordList.Add(record);
            }
            return recordList;
        }
    }
}
