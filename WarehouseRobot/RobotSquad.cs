using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class RobotSquad
    {
        public Location WarehouseNorthEast { get; private set; }

        public List<Tuple<Robot, IEnumerable<Robot.Instruction>>> RobotInsructions { get; private set; }

        public IEnumerable<Robot> Robots { get { return RobotInsructions.Select(n => n.Item1); } }

        public RobotSquad(Location northEast)
        {
            this.WarehouseNorthEast = northEast;
            RobotInsructions = new List<Tuple<Robot, IEnumerable<Robot.Instruction>>>();
        }

        public void AddRobotInstruction(Robot robot, IEnumerable<Robot.Instruction> instructions)
        {
            RobotInsructions.Add(new Tuple<Robot, IEnumerable<Robot.Instruction>>(robot, instructions));
        }

        public void Start()
        {
            foreach (var robotInstruction in RobotInsructions)
            {
                var robot = robotInstruction.Item1;
                var instructions = robotInstruction.Item2;
                foreach (var instruction in instructions)
                {
                    robot.Execute(instruction);
                    if (!robot.Location.IsInBounds(new Location(0, 0), WarehouseNorthEast))
                        throw new InvalidOperationException("One of the robots crashed into a wall");
                }
            }
        }
    }

    static class IEnumeratorExtensions
    {
        public static T ReadCurrent<T>(this IEnumerator<T> instance)
        {
            instance.MoveNext();
            return instance.Current;
        }
    }
}
