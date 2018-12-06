using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public enum GuardAction { BeginsShift, WakesUp, FallsAsleep }
    public class LogEntry
    {
        public DateTime DateTime { get; set; }
        public int MinuteValue => DateTime.Minute;

    }

    public class GuardObservation
    {
        public string GuardId { get; set; }
        public GuardAction GuardAction { get; set; }
    }
}
