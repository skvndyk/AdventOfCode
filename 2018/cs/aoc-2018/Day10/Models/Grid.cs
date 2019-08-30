using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.Models
{
    public class Grid
    {
        public List<Point> Points { get; set; }

        public int MaxX => Points.Max(p => p.CurrentPosition.X);
        public int MinX => Points.Min(p => p.CurrentPosition.X);

        public int MaxY => Points.Max(p => p.CurrentPosition.Y);
        public int MinY => Points.Min(p => p.CurrentPosition.Y);

        public int CurrentHeight => Math.Abs(MaxY - MinY);
        public int CurrentWidth => Math.Abs(MaxX - MinX);

        public void ApplyVelocities()
        {
            foreach (var point in Points)
            {
                point.ApplyVelocity();
            }
        }

        public void PrintGrid(int counter)
        {
            List<string> toPrint = new List<string>();

            if (CurrentHeight <= 150 && CurrentWidth <= 150)
            {
                Console.WriteLine($"{counter} iteration gave us something to print!");
                Console.WriteLine($"Writing to file now");
                string filename = $"{counter}.txt";

                using (var fs = File.Create(filename))
                using (var writer = new StreamWriter(fs))
                {
                    for (int y = MinY; y <= MaxY; y++)
                    {
                        string lineToPrint = "";

                        for (int x = MinX; x <= MaxX; x++)
                        {
                            if (Points.Any(p => p.CurrentPosition.X == x && p.CurrentPosition.Y == y))
                            {
                                lineToPrint += "#";
                            }
                            else
                            {
                                lineToPrint += " ";
                            }
                        }

                        writer.WriteLine(lineToPrint);
                    }
                }

                Console.WriteLine("Finished writing file, press any key to continue");
                Console.ReadLine();
              
            }
        }
    }
}
