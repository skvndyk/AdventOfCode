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
            var root = Directory.GetCurrentDirectory();
            var stringArr = File.ReadAllLines(Path.Combine(root, filePath));
 
            return stringArr.ToList();
        }

        public static (bool, int?) IsCharDigit(char character)
        {
            return (int.TryParse(character.ToString(), out int parsedInt), parsedInt);
        }
        
    }
}
