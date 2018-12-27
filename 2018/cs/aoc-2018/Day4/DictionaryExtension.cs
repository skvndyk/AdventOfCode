using System;
using System.Collections.Generic;

namespace Day4
{
    public static class DictionaryExtension
    {
        public static Dictionary<T, int> AddOrUpdate<T>(this Dictionary<T, int> dict, T key, int toAdd=1)
        {
            //todo just doing this temporarily bc VS version at home doesn't have right version of c#
            //if (dict.TryGetValue(key, out int val))
            //{
            //    dict[key] += toAdd;
            //}
            //else
            //{
            //    dict[key] = toAdd;
            //}
            //return dict;
            throw new NotImplementedException();
        }
    }
}