using System.Collections.Generic;

namespace Day4
{
    public class GuardObservation
    {
        public enum GuardAction { BeginsShift, WakesUp, FallsAsleep }

        public static readonly Dictionary<string, GuardAction> ActionDictionary = new Dictionary<string, GuardAction>()
        {
            { "begins shift" ,  GuardAction.BeginsShift },
            { "falls asleep", GuardAction.FallsAsleep },
            { "wakes up", GuardAction.WakesUp }
        };

        public string GuardId { get; set; }
        public GuardAction Action { get; set; }
        public Dictionary<int, int> SleepyDict { get; set; } = new Dictionary<int, int>();
    }

}