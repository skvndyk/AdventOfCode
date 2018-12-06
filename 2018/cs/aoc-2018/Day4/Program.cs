using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        public static readonly Regex _rgx = new Regex($@"\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2})\] (((Guard #(\d+)) (?:begins shift))|(falls asleep)|(wakes up))");
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
            throw new NotImplementedException();
        }

        public static List<string> ReadTextIntoLines(string filePath)
        {
            string rawInput = System.IO.File.ReadAllText(filePath);
            return rawInput.Split('\n').ToList();
        }
    }
}
