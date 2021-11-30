using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class Utilities
    {
        public static List<string> ReadFileToStrings(string filePath)
        {
            var stringArr = File.ReadAllLines(filePath);
            foreach (var str in stringArr)
            {
                str.Trim();
            }
            return stringArr.ToList();
        }

        //public static List<GroupCollection> RegExSplitter(string pattern, string text)
        //{
        //    var rx = new Regex(pattern);
        //    MatchCollection matches = rx.Matches(text);
        //    return matches;
        //}
    }
}
