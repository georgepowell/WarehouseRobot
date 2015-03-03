using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    /// <summary>
    /// Represents the centralised control of the squad of robots in a warehouse.
    /// It is configured by adding robots + instructions one by one and then calling Start() to move the robots.
    /// </summary>
    public class RobotSquad
    {
        public IntVector2D WarehouseNorthEast { get; private set; }

        public List<Tuple<Robot, IEnumerable<Robot.Instruction>>> RobotInsructions { get; private set; }

        public IEnumerable<Robot> Robots { get { return RobotInsructions.Select(n => n.Item1); } }

        public RobotSquad(IntVector2D northEast)
        {
            this.WarehouseNorthEast = northEast;
            RobotInsructions = new List<Tuple<Robot, IEnumerable<Robot.Instruction>>>();
        }

        /// <summary>
        /// Adds a robot along with its associated instruction sequence
        /// </summary>
        public void AddRobotInstruction(Robot robot, IEnumerable<Robot.Instruction> instructions)
        {
            RobotInsructions.Add(new Tuple<Robot, IEnumerable<Robot.Instruction>>(robot, instructions));
        }

        /// <summary>
        /// Executes each robot's instructions in the order they were added
        /// </summary>
        public void Start()
        {
            foreach (var robotInstruction in RobotInsructions)
            {
                var robot = robotInstruction.Item1;
                var instructions = robotInstruction.Item2;
                foreach (var instruction in instructions)
                {
                    robot.Execute(instruction);
                    if (!robot.Location.IsInBounds(new IntVector2D(0, 0), WarehouseNorthEast))
                        throw new InvalidOperationException("One of the robots crashed into a wall");
                }
            }
        }
    }
}
