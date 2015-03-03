using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarehouseRobot;

namespace UnitTests
{
    [TestClass]
    public class ExampleUnitTest
    {
        const string input = "5 5\n1 2 N\n<^<^<^<^^\n3 3 E\n^^>^^>^>>^\n\n";
        const string output = "1 3 N\n5 1 E\n";

        [TestMethod]
        public void ExampleTest()
        {
            Assert.AreEqual(Program.InputOutput(input.Split('\n')), output);
        }
    }
}
