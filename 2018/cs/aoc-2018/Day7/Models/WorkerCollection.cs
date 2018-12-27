using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7.Models
{
    public class WorkerCollection
    {
        public WorkerCollection(int numWorkersNeeded)
        {
            Workers = new List<Worker>();
            for (int i = 1; i <= numWorkersNeeded; i++)
            {
                Workers.Add( new Worker() { Id = i } );
            }
        }
        public List<Worker> Workers { get; set; }
        public Worker GetWorkerById(int id) => Workers.FirstOrDefault(w => w.Id == id);
        public List<Worker> WorkersNeedingWork => Workers.Where(w => w.HasWorkToDo).ToList();

    }
}
