using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseRobot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RobotWarehouseIO(ConsoleInput()));

            Console.ReadLine();
        }

        /// <summary>
        /// Returns the console input line by line as an IEnumerable
        /// </summary>
        public static IEnumerable<string> ConsoleInput()
        {
            while (true)
                yield return Console.ReadLine();
        }

        /// <summary>
        /// Creates a configuration of robots from the input, then returns a string output representing where the robots are after following their instructions. The input is interpretted as a sequence of strings each on a new line.
        /// </summary>
        /// <param name="input">An enumerable sequence of input strings. Each new string is interpretted to be on a new line.</param>
        /// <returns>The output of the program, given the input.</returns>
        public static string RobotWarehouseIO(IEnumerable<string> input)
        {
            var inputEnumerator = input.GetEnumerator();
            string output = "";

            string northEastIn = inputEnumerator.ReadNext();

            IntVector2D northEast = locationFromString(northEastIn);
            RobotSquad squad = new RobotSquad(northEast);

            for (; ; )
            {
                string robotIn = inputEnumerator.ReadNext();

                // An empty line for robot position indicates end of input
                if (String.IsNullOrEmpty(robotIn))
                    break;

                var robot = robotFromString(robotIn);
                string instructionsIn = inputEnumerator.ReadNext();
                var instructions = instructionsFromString(instructionsIn);

                squad.AddRobotInstruction(robot, instructions);
            }

            squad.Start();

            foreach (var robot in squad.Robots)
                output += robot + "\n";

            return output;
        }

        static Dictionary<char, Robot.Instruction> instructionFromChar = new Dictionary<char, Robot.Instruction>()
        {
            { '<', Robot.Instruction.RotateAnticlockwise },
            { '>', Robot.Instruction.RotateClockwise },
            { '^', Robot.Instruction.MoveForward }
        };

        static Dictionary<string, Direction> directionFromChar = new Dictionary<string, Direction>()
        {
            { "N", Direction.North },
            { "E", Direction.East },
            { "S", Direction.South },
            { "W", Direction.West }
        };

        static IntVector2D locationFromString(string pos)
        {
            string[] parts = pos.Split(' ');
            int x = 0;
            int y = 0;

            bool failed = !(parts.Length == 2 &&
                Int32.TryParse(parts[0], out x) &&
                Int32.TryParse(parts[1], out y));

            if (failed)
                throw new ArgumentException("pos needs to be two integers seperated by spaces e.g. \"1 2\"");
            else
                return new IntVector2D(x, y);
        }

        static Robot robotFromString(string robotPos)
        {
            string[] parts = robotPos.Split(' ');
            int x = 0;
            int y = 0;

            bool failed = !(parts.Length == 3 &&
                Int32.TryParse(parts[0], out x) &&
                Int32.TryParse(parts[1], out y) &&
                directionFromChar.ContainsKey(parts[2]));


            if (failed)
                throw new ArgumentException("robotPos needs to be two integers and a direction seperated by spaces e.g. \"1 2 E\"");
            else
                return new Robot(x, y, directionFromChar[parts[2]]);
        }

        static IEnumerable<Robot.Instruction> instructionsFromString(string instructions)
        {
            return instructions.Select(c => instructionFromChar[c]);
        }
    }
}
