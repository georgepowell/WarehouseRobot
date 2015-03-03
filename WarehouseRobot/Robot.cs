using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class Robot
    {
        public Location Location { get; set; }

        public Direction Direction { get; set; }

        public Robot(int x, int y, Direction direction)
            : this(new Location(x, y), direction) { }

        public Robot(Location location, Direction direction)
        {
            this.Location = location;
            this.Direction = direction;
        }
        
        public void MoveForward()
        {
            Location += Location.DirectionUnits[Direction];
        }

        public void RotateClockwise()
        {
            Direction = (Direction)((int)(Direction + 1) % 4);
        }

        public void RotateAnticlockwise()
        {
            Direction = (Direction)((int)(Direction + 3) % 4);
        }

        public void Execute(Instruction instruction)
        {
            switch (instruction)
            {
                case Instruction.MoveForward:
                    MoveForward();
                    break;
                case Instruction.RotateClockwise:
                    RotateClockwise();
                    break;
                case Instruction.RotateAnticlockwise:
                    RotateAnticlockwise();
                    break;
            }
        }

        public enum Instruction
        {
            MoveForward,
            RotateClockwise,
            RotateAnticlockwise
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Location.X, Location.Y, Direction.ToString()[0]);
        }
    }
}
