using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Utilities
    {
        public static List<string> ReadFileToStrings(string filePath)
        {
            var stringArr = File.ReadAllLines(filePath);
            return stringArr.ToList();
        }
    }
}
