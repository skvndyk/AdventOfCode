using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    public class Program
    {
        public static readonly Regex _logRgx = new Regex(@"\[(?<datetime>\d{4}-\d{2}-\d{2} \d{2}:\d{2})\] ((Guard #(?<guardId>\d+)) (?<begin>begins shift)|(?<sleep>falls asleep)|(?<wake>wakes up))");
        public static readonly Regex _dtRgx = new Regex(@"\[((\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}))\]");
        static void Main(string[] args)
        {
            string filePath = "day4-2018.txt";
            List<LogEntry> logEntries = ParseFileIntoLogEntries(filePath);
            Console.WriteLine($"Part 1: {Part1(logEntries)}");
            Console.WriteLine($"Part 2: {Part2(logEntries)}");
            Console.ReadLine();
        }

        public static int Part1(List<LogEntry> logEntries)
        {
            throw new NotImplementedException();
        }

        public static string Part2(List<LogEntry> logEntries)
        {
            throw new NotImplementedException();
        }

        public static List<LogEntry> ParseFileIntoLogEntries(string filePath)
        {
            List<string> lines = ReadTextIntoLines(filePath);
            return ConvertLinesToSortedLogEntries(lines);
        }

        public static List<LogEntry> ConvertLinesToSortedLogEntries(List<string> lines)
        {
            List<LogEntry> entries = new List<LogEntry>();
            foreach (string line in lines)
            {
                Match match = _logRgx.Match(line);
                if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
                GroupCollection groups = match.Groups;
                DateTime dateTime = ParseDateTimeFromLogEntry(groups["datetime"].Value);
                GuardObservation guardObservation = new GuardObservation();
                if (!string.IsNullOrEmpty(groups["guardId"].Value))
                {
                    guardObservation.GuardId = groups["guardId"].Value;
                }
                guardObservation.Action
                
                

            }
            throw new NotImplementedException();
        }

        public static DateTime ParseDateTimeFromLogEntry(string dateTime)
        {
            Match match = _dtRgx.Match(dateTime);
            if (!match.Success) throw new Exception($@"could not parse datetime string {dateTime}");
            GroupCollection groups = match.Groups;
            return new DateTime(int.Parse(groups[1].ToString()), int.Parse(groups[2].ToString()), int.Parse(groups[3].ToString()), int.Parse(groups[4].ToString()), int.Parse(groups[5].ToString()), 0);

        }
        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
