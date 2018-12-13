using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Day6
{
    public class Grid
    {
        public Grid(List<Coord> namedPoints)
        {
            NamedPoints = namedPoints;
        }
        public List<Coord> NamedPoints { get; set; }
        public Coord MinXCoord => NamedPoints.FirstOrDefault(p => p.X == NamedPoints.Min(p1 => p1.X));
        public Coord MaxXCoord => NamedPoints.FirstOrDefault(p => p.Y == NamedPoints.Max(p1 => p1.Y));
        public Coord MinYCoord => NamedPoints.FirstOrDefault(p => p.Y == NamedPoints.Min(p1 => p1.Y));
        public Coord MaxYCoord => NamedPoints.FirstOrDefault(p => p.Y == NamedPoints.Max(p1 => p1.Y));
        public bool DoesNamedPointExistAtCoord(int x, int y) => NamedPoints.Contains(new Coord(){ X = x, Y = y });

        private List<Coord> _availableCoords;
        public List<Coord> AvailableCoords
        {
            get
            {
                if (_availableCoords == null)
                {
                    SetAvailableCoords();
                }
                return _availableCoords;
            }

        }
        public void SetAvailableCoords()
        {
            _availableCoords = new List<Coord>();
            //get all coords covered by rectangle
            for (int x = MinXCoord.X; x <= MaxXCoord.X; x++)
            {
                for (int y = MinYCoord.Y; y <= MaxYCoord.Y; y++)
                {
                    Coord coord = new Coord(){X = x, Y = y};
                    coord.ClosestNamedPoint = GetClosestNamedPoint(coord);
                    _availableCoords.Add(coord);
                }
            }
        }


        public Coord GetClosestNamedPoint(Coord coord)
        {
            int shortestDistance = 999999999;
            Coord closestNamedPoint = null;
            foreach (Coord namedPoint in NamedPoints)
            {
                if (GetManhattanDistance(coord, namedPoint) < shortestDistance)
                {
                    closestNamedPoint = namedPoint;
                }
            }
            return closestNamedPoint;
        }

        private int GetManhattanDistance(Coord coordA, Coord coordB)
        {
            return Math.Abs(coordA.X - coordB.X) + Math.Abs(coordA.Y - coordB.Y);
        }
    }
}