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
        public static readonly Regex _logRgx = new Regex(@"\[(?<datetime>\d{4}-\d{2}-\d{2} \d{2}:\d{2})\] ((?<namedGuard>(Guard #(?<guardId>\d+)) (begins shift))|(?<sleeps>falls asleep)|(?<wakes>wakes up))");
        public static readonly Regex _dtRgx = new Regex(@"(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2}) (?<hour>\d{2}):(?<minute>\d{2})");
        static void Main(string[] args)
        {
            string filePath = "day4-2018.txt";
            Console.WriteLine($"Part 1: {Part1(filePath)}");
            Console.WriteLine($"Part 2: {Part2(filePath)}");
            Console.ReadLine();
        }

        public static int Part1(string filePath)
        {
            List<LogEntry> logEntries = ParseFileIntoLogEntries(filePath);
            List<LogEntry> sortedEntries = logEntries.OrderBy(e => e.DateTime).ToList();
            List<LogEntry> linkedEntries = CreateLinkedListFromEntries(sortedEntries);
            List<LogEntry> completeEntryList = SetGuardIds(linkedEntries);
            string sleepiestGuardId = GetSleepiestGuard(completeEntryList);
            //todo what minute does that guard spend asleep the most?
            throw new NotImplementedException();
        }

        public static string Part2(string filePath)
        {
            throw new NotImplementedException();
        }

        public static string GetSleepiestGuard(List<LogEntry> logEntries)
        {
            Dictionary<string, int> sleepingTimesDict = new Dictionary<string, int>();
            foreach (LogEntry entry in logEntries)
            {
                if (entry.GuardObservation.Action == GuardObservation.GuardAction.FallsAsleep)
                {
                    if (entry.NextEntry.GuardObservation.Action == GuardObservation.GuardAction.WakesUp)
                    {
                        string id = entry.GuardObservation.GuardId;
                        int sleepTime = entry.NextEntry.MinuteValue - entry.MinuteValue;
                        if (sleepingTimesDict.TryGetValue(id, out int val))
                        {
                            sleepingTimesDict[id] += sleepTime;
                        }
                        else { sleepingTimesDict[id] = sleepTime; }
                    }
                    else { throw new Exception("Expected next entry to be of type WakesUp");}
                    

                }
            }
            return sleepingTimesDict.FirstOrDefault(t => t.Value == sleepingTimesDict.Max(d => d.Value)).Key;
        }

       
        public static List<LogEntry> SetGuardIds(List<LogEntry> logEntries)
        {
            foreach (LogEntry entry in logEntries)
            {
                entry.GuardObservation.GuardId = ReturnMatchingGuardId(entry);
            }
            return logEntries;
        }

        public static string ReturnMatchingGuardId(LogEntry entry)
        {
            LogEntry currEntry = entry;
            while (string.IsNullOrEmpty(currEntry.GuardObservation.GuardId))
            {
                currEntry = currEntry.PreviousEntry;
                ReturnMatchingGuardId(currEntry);
            }
            return currEntry.GuardObservation.GuardId;
        }

        public static List<LogEntry> ParseFileIntoLogEntries(string filePath)
        {
            List<string> lines = ReadTextIntoLines(filePath);
            return ConvertLinesToSortedLogEntries(lines);
        }

        public static List<LogEntry> ConvertLinesToSortedLogEntries(List<string> lines)
        {
            return lines.Select(ConvertLineToLogEntry).ToList();
        }

        public static List<LogEntry> CreateLinkedListFromEntries(List<LogEntry> entries)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].NextEntry = i == entries.Count - 1 ? null : entries[i + 1];
                entries[i].PreviousEntry = i == 0 ? null : entries[i - 1];
            }
            return entries;
        }

        public static List<LogEntry> AddGuardIdIfNeeded(LogEntry entry, List<LogEntry> entries)
        {
            throw new NotImplementedException();
        }

        public static LogEntry ConvertLineToLogEntry(string line)
        {
            Match match = _logRgx.Match(line);
            if (!match.Success) throw new Exception($@"could not parse line with contents {line}");
            GroupCollection groups = match.Groups;
            DateTime dateTime = ParseDateTimeFromLogEntry(groups["datetime"].Value);
            GuardObservation guardObservation = new GuardObservation();
            if (!string.IsNullOrEmpty(groups["namedGuard"].Value))
            {
                guardObservation.GuardId = groups["guardId"].Value;
                guardObservation.Action = GuardObservation.GuardAction.BeginsShift;
            }
            else
            {
                if (!string.IsNullOrEmpty(groups["sleeps"].Value))
                {
                    guardObservation.Action = GuardObservation.GuardAction.FallsAsleep;
                }
                else if (!string.IsNullOrEmpty(groups["wakes"].Value))
                {
                    guardObservation.Action = GuardObservation.GuardAction.WakesUp;
                }
                else
                {
                    throw new Exception("Couldn't find a valid guard action");

                }
            }
            return new LogEntry(){DateTime = dateTime, GuardObservation = guardObservation};
        }
        public static DateTime ParseDateTimeFromLogEntry(string dateTime)
        {
            Match match = _dtRgx.Match(dateTime);
            if (!match.Success) throw new Exception($@"could not parse datetime string {dateTime}");
            GroupCollection groups = match.Groups;
            return new DateTime(int.Parse(groups["year"].Value), int.Parse(groups["month"].Value), int.Parse(groups["day"].Value), int.Parse(groups["hour"].Value), int.Parse(groups["minute"].Value), 0);

        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
