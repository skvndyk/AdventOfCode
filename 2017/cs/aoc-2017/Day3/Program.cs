using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day3.Models;

namespace Day3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Part1();
        }
        public static void Part1()
        {
            Spiral spiral = new Spiral(16);
            spiral.PrintSpiral();
            Console.ReadLine();
        }
       
    }
}
