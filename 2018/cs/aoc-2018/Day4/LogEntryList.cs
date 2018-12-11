using System;
using System.Collections.Generic;

namespace Day4
{
    public class LogEntryList
    {
        public List<LogEntry> LogEntries { get; set; }

        public void SetGuardIdsIfNeeded()
        {
            foreach (LogEntry entry in LogEntries)
            {
                entry.GuardObservation.GuardId = ReturnMatchingGuardId(entry);
            }
        }

        public string ReturnMatchingGuardId(LogEntry entry)
        {
            LogEntry currEntry = entry;
            while (string.IsNullOrEmpty(currEntry.GuardObservation.GuardId))
            {
                currEntry = currEntry.PreviousEntry;
                ReturnMatchingGuardId(currEntry);
            }
            return currEntry.GuardObservation.GuardId;
        }
      
    }
}