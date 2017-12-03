using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public static class Day3Extensions
    {
        public static int GetNextIndex<T>(this List<T> list, int index)
        {
            return index + 1 > list.Count() - 1 ? 0 : index + 1;
        }
    }
}
