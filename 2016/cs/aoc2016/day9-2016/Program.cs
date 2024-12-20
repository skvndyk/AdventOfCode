﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Day9
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("day9-2016.txt");
            string results = getDecompressed2(input);
            Console.WriteLine(results.Length);
            Console.ReadLine();
        }

        public static string getDecompressed1(string input)
        {
            bool inMarker = false;
            bool markerExists = false;

            int x = 0;
            int lenData = input.Length;
            int charNum = 0;
            int repeatNum = 0;
            int pos = 0;

            char currChar;

            string marker = "";
            string decompressed = "";
            string toRepeat = "";

            Tuple<int, int> markerTuple;


            while (x < lenData)
            {
                if (!markerExists)
                {
                    currChar = input[x];
                    if (!inMarker)
                    {
                        if (currChar != '(')
                        {
                            decompressed += currChar;
                        }
                        else
                        {
                            inMarker = true;
                        }
                    }
                    else
                    {
                        if (currChar != ')')
                        {
                            marker += currChar;
                        }
                        else
                        {
                            inMarker = false;
                            markerExists = true;
                            markerTuple = analyzeMarker(marker);
                            charNum = markerTuple.Item1;
                            repeatNum = markerTuple.Item2;
                        }
                    }
                    x += 1;
                }
                else
                {
                    toRepeat = "";
                    for (int i = 0; i < charNum; i++)
                    {
                        pos = x + i;
                        toRepeat += input[pos];
                    }
                    for (int j = 0; j < repeatNum; j++)
                    {
                        decompressed += toRepeat;
                    }
                    marker = "";
                    markerExists = false;
                    x = pos + 1;
                }
            }
            return decompressed;
        }


        public static string getDecompressed2(string input)
        {
            bool inMarker = false;
            bool markerExists = false;
            bool allDecompressed = true;

            int x = 0;
            int lenData = input.Length;
            int charNum = 0;
            int repeatNum = 0;
            int pos = 0;
            int holdingPos = 0;

            char currChar;

            string marker = "";
            string decompressed = "";
            string toRepeat = "";
            string toProcess = input;

            Tuple<int, int> markerTuple;

            string pattern = @".*(d*xd*).*";
            Regex regex = new Regex(pattern);

            do
            {
                if (x == lenData && !allDecompressed)
                {
                    x = 0;
                    toProcess = decompressed;
                    lenData = toProcess.Length;
                    decompressed = "";
                    allDecompressed = true;
                }
                while (x < lenData)
                {
                    if (!markerExists)
                    {
                        currChar = toProcess[x];
                        if (!inMarker)
                        {
                            if (currChar != '(')
                            {
                                decompressed += currChar;
                            }
                            else
                            {
                                holdingPos = x;
                                inMarker = true;
                                allDecompressed = false;
                            }
                        }
                        else
                        {
                            if (currChar != ')')
                            {
                                marker += currChar;
                            }
                            else
                            {
                                inMarker = false;
                                markerExists = true;
                                markerTuple = analyzeMarker(marker);
                                charNum = markerTuple.Item1;
                                repeatNum = markerTuple.Item2;
                            }
                        }
                        x += 1;
                    }
                    else
                    {
                        toRepeat = "";
                        for (int i = 0; i < charNum; i++)
                        {
                            pos = x + i;
                            toRepeat += toProcess[pos];
                        }
                        for (int j = 0; j < repeatNum; j++)
                        {
                            decompressed += toRepeat;
                        }
                        marker = "";
                        markerExists = false;
                        x = pos + 1;
                    }
                }
                if (regex.Matches(decompressed).Count == 0)
                {
                    allDecompressed = true;
                }

            } while (!allDecompressed);

            return decompressed;
        }

        public static Tuple<int, int> analyzeMarker(string marker)
        {
            string[] strippedMarker = marker.Split('x');
            int numChars = Int32.Parse(strippedMarker[0].ToString());
            int numRepeats = Int32.Parse(strippedMarker[1].ToString());
            return new Tuple<int, int>(numChars, numRepeats);
        }
    }
}