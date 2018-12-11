using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    
    public class LogEntry
    {
        public DateTime DateTime { get; set; }
        public int MinuteValue => DateTime.Minute;
        public GuardObservation GuardObservation { get; set; }
        public LogEntry PreviousEntry { get; set; }
        public LogEntry NextEntry { get; set; }
    }

}
