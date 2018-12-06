using System.Collections.Generic;
using System.Linq;

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
            UpperRight = new Coord(x + Width, y);
            LowerLeft = new Coord(x, y + Height);
            LowerRight = new Coord(x + Width, y + Height);

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
            for (int h = UpperLeft.X; h <= UpperRight.X; h++)
            {
                //top
                _CoordsCovered.Add(new Coord(h, UpperLeft.Y));
                //bottom
                _CoordsCovered.Add(new Coord(h, LowerLeft.Y));
            }

            //get coords along left and right of claim
            for (int v = UpperLeft.Y; v <= LowerLeft.Y; v++)
            {
                //left
                _CoordsCovered.Add(new Coord(UpperLeft.X, v));
                //right
                _CoordsCovered.Add(new Coord(UpperRight.X, v));
            }
        }
    }
}