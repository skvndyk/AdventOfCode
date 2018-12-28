using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class WorkLog
    {
        public WorkLog()
        {
            TimeElapsed = 0;
            CurrWorkerIdx = 0;
        }
        public int TimeElapsed { get; set; }
        public int CurrWorkerIdx { get; set; }
        public WorkerCollection WorkerCollection { get; set; }
    }
}
