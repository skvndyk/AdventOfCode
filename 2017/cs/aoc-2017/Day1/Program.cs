using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Day1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("day1-2017.txt");
            Console.WriteLine(Part1(input));
            Console.WriteLine(Part2(input));
            Console.ReadLine();
        }

        public static int Part1(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    if (input[i] == input[0])
                    {
                        sum += Int32.Parse(input[i].ToString());
                    }
                }
                else
                {
                    if (input[i] == input[i + 1])
                    {
                        sum += Int32.Parse(input[i].ToString());
                    }
                }
            }
            return sum;
        }

        public static int Part2(string input)
        {
            int sum = 0;
            int half = input.Length / 2;
            for (int i = 0; i < input.Length; i++)
            {
                int compareIdx = (i + half) > input.Length - 1 ? (i + half) % half : i + half;
                if (input[i] == input[compareIdx])
                {
                    sum += Int32.Parse(input[i].ToString());
                }
            }
            return sum;
        }
    }
}
