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
    }

}
