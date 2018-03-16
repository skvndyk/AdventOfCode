using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Day8
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "day8-2017.txt";
            string input = System.IO.File.ReadAllText(filePath);
            //parse each line using regex:
            //0: register
            //1: inc/dec (dict with +/-, generic here?)
            //2: if
            //3: condition
                //register, (>, <, >=, <=, ==, !=) num
           
            //create Dict<string, int> for register, value
            //translate line into "instruction"
            //...
        }
    }
}
