using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocLib
{
    public static class Extensions
    {
        public static int GetNextIndex<T>(this List<T> list, int index)
        {
            return index + 1 > list.Count() - 1 ? 0 : index + 1;
        }
        public static int GetPreviousIndex<T>(this List<T> list, int index)
        {
            return index - 1 < 0 ? list.Count() - 1 : index - 1;
        }
    }
}
