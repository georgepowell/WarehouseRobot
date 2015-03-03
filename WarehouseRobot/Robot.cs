using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    /// <summary>
    /// Represents a Robot's state within the warehouse (Location + Direction).
    /// Methods exist to move and rotate the robot.
    /// </summary>
    public class Robot
    {
        public IntVector2D Location { get; set; }

        public Direction Direction { get; set; }

        public Robot(int x, int y, Direction direction)
            : this(new IntVector2D(x, y), direction) { }

        public Robot(IntVector2D location, Direction direction)
        {
            this.Location = location;
            this.Direction = direction;
        }
        
        public void MoveForward()
        {
            Location += IntVector2D.DirectionUnit(Direction);
        }

        public void RotateClockwise()
        {
            Direction = (Direction)((int)(Direction + 1) % 4);
        }

        public void RotateAnticlockwise()
        {
            Direction = (Direction)((int)(Direction + 3) % 4);
        }

        /// <summary>
        /// Alternative to the other public methods, robots can be controlled with instructions.
        /// </summary>
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
