using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class Location
    {
        public static Dictionary<Direction, Location> DirectionUnits = new Dictionary<Direction, Location>()
        {
            { Direction.North, new Location(0, 1) },
            { Direction.East, new Location(1, 0) },
            { Direction.South, new Location(0, -1) },
            { Direction.West, new Location(-1, 0) }
        };

        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Location operator +(Location a, Location b)
        {
            return new Location(a.X + b.X, a.Y + b.Y);
        }

        public bool IsInBounds(Location sw, Location ne)
        {
            return
                X >= sw.X && Y >= sw.Y &&
                X <= ne.X && Y <= ne.Y;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", X, Y);
        }
    }
}
