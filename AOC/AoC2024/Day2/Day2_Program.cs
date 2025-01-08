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

            //Console.WriteLine($"Part 1 answer: {Part1(inputStrings)}");
            Console.WriteLine($"Part 2 answer: {Part2(inputStrings)}");
        }

        private static int Part1(List<string> inputStrings)
        {
            var blah = ParseInputStrings(inputStrings);
            var numSafeRecords = 0;
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
                    if ((record[i] > record[i + 1] && isAscending) || (record[i] < record[i + 1] && !isAscending) || (record[i] == record[i + 1]))
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
                            break;
                        }
                    }
                }
            }
            return numSafeRecords;
        }

        private static int Part2(List<string> inputStrings)
        {
            var reportList = ParseInputStrings(inputStrings);
            var numSafeReports = 0;
            var numReportsProcessed = 0;

            foreach (var report in reportList)
            {
                var badLevels = AnalyzeRecord(report);

                Console.WriteLine($"Report {numReportsProcessed + 1} ({string.Join(" ", report)}) originally has {badLevels.Count}");
                if (badLevels.Count > 0)
                {
                    foreach (var key in badLevels.Keys)
                    {
                        Console.WriteLine($"Level {key + 1}: {badLevels[key]}");
                    }

                    
                    Console.WriteLine("Attempting to fix report");
                    var reportFixable = false;
                    //add first element manually, otherwise we always assume it's the 2nd element's fault
                    badLevels[0] = report[0];
                    foreach (var candidate in badLevels.Keys)
                    {
                        var fixedReport = new List<int>(report);
                        fixedReport.RemoveAt(candidate);
                        Console.WriteLine($"Tried to fix report by removing element at level {candidate + 1} ({badLevels[candidate]})");
                        Console.WriteLine($"Fixed report: {string.Join(" ", fixedReport)}");
                        if (AnalyzeRecord(fixedReport).Count == 0)
                        {
                            Console.WriteLine("Report fixed!\n");
                            reportFixable = true;
                            numSafeReports++;
                            break;
                        }
                    }
                    if (!reportFixable)
                    {
                        Console.WriteLine("Could not fix report\n");
                    }
                
                }
                else
                {
                    Console.WriteLine("Report is safe\n");
                    numSafeReports++;
                }
                numReportsProcessed++;
            }


            return numSafeReports;
        }

        private static Dictionary<int, int> AnalyzeRecord(List<int> report)
        {
            var badLevels = new Dictionary<int, int>();
            var isAscending = false;
            if (report[0] == report[1] || (Math.Abs(report[0] - report[1]) > 3))
            {
                //Console.WriteLine("either first 2 are equal or difference is greater than 3");
                badLevels[1] = report[1];
            }

            if (report[0] < report[1])
            {
                isAscending = true;
            }
            for (int i = 1; i < report.Count - 1; i++)
            {
                if ((report[i] > report[i + 1] && isAscending) || (report[i] < report[i + 1] && !isAscending) || (report[i] == report[i + 1]))
                {
                    //Console.WriteLine("either not ascending or not descending or they're equal");
                    badLevels[i + 1] = report[i + 1];
                }

                else
                {
                    if (Math.Abs(report[i] - report[i + 1]) > 3)
                    {
                        //Console.WriteLine("difference greater than 3");
                        badLevels[i + 1] = report[i + 1];
                    }

                    else if (i == report.Count - 2)
                    {
                        break;
                    }
                }
            }
            return badLevels;

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
