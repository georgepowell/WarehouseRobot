using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    /// <summary>
    /// Represents a 2D vector with Integer components
    /// </summary>
    public class IntVector2D
    {
        static Dictionary<Direction, IntVector2D> DirectionUnits = new Dictionary<Direction, IntVector2D>()
        {
            { Direction.North, new IntVector2D(0, 1) },
            { Direction.East, new IntVector2D(1, 0) },
            { Direction.South, new IntVector2D(0, -1) },
            { Direction.West, new IntVector2D(-1, 0) }
        };

        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static IntVector2D DirectionUnit(Direction direction)
        {
            return DirectionUnits[direction];
        }

        public static IntVector2D operator +(IntVector2D a, IntVector2D b)
        {
            return new IntVector2D(a.X + b.X, a.Y + b.Y);
        }

        public bool IsInBounds(IntVector2D sw, IntVector2D ne)
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
