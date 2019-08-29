using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Day10.Models;

namespace Day10
{
    class Program
    {
        public static readonly Regex _gridRgx = 
            new Regex(@"position=<(?'posX'-?\d*),(?'posY'-?\d*)>velocity=<(?'velX'-?\d*),?(?'velY'-?\d*)>");
        public static void Main(string[] args)
        {
            string fileName = "day10-2018-example.txt";
            Grid grid = ParseInputFile(fileName);
            grid.PrintGrid();
            Task.Delay(1000);
            Console.Clear();
            while (true)
            {
                grid.ApplyVelocities();
                grid.PrintGrid();
                Task.Delay(1000);
                Console.Clear();
            }
        }

        public static Grid ParseInputFile(string fileName)
        {
            List<Point> points = new List<Point>();

            List<string> lines = File.ReadAllLines(fileName).ToList();
            foreach (var line in lines)
            {
                string trimmedLine = line.Replace(" ", "");
                MatchCollection matches = _gridRgx.Matches(trimmedLine);
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;

                    Point point = new Point()
                    {
                        InitialPosition = new Position()
                        {
                            X = Convert.ToInt32(groups["posX"].Value),
                            Y = Convert.ToInt32(groups["posY"].Value)
                        },

                        Velocity = new Position()
                        {
                            X = Convert.ToInt32(groups["velX"].Value),
                            Y = Convert.ToInt32(groups["velY"].Value)
                        },
                    };

                    point.CurrentPosition = point.InitialPosition;
                    points.Add(point);
                }
            }

            return new Grid()
            {
                Points = points
            };
        }
    }
}
