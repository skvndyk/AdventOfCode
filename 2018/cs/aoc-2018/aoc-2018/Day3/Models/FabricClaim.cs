using System.Collections.Generic;
using System.Linq;
using Day3.Models;

namespace Day3
{
    public class FabricClaim
    {
        public FabricClaim(string id, int x, int y, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
            UpperLeft = new Coord(x, y);
            UpperRight = new Coord(x + Width - 1, y);
            LowerLeft = new Coord(x, y + Height - 1);
            LowerRight = new Coord(x + Width - 1, y + Height - 1);

        }
        public string Id { get; set; }
        public Coord UpperLeft { get; set; }
        private Coord UpperRight;
        private Coord LowerLeft;
        private Coord LowerRight;
        public int Width { get; set; }
        public int Height { get; set; }
        private List<Coord> _CoordsCovered;
        public List<Coord> CoordsCovered
        {
            get
            {
                if (_CoordsCovered == null)
                {
                    SetCoordsCovered();
                }
                return _CoordsCovered;
            }

        }

        public void SetCoordsCovered()
        {
            _CoordsCovered = new List<Coord>();
            //get all coords covered by rectangle
           for (int x = UpperLeft.X; x <= UpperRight.X; x++)
            {
                for (int y = UpperLeft.Y; y <= LowerLeft.Y; y++)
                {
                    _CoordsCovered.Add(new Coord(x,y));
                }
            }
        }
    }
}