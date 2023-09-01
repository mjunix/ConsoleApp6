using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class SimulatorTests
    {
        [Theory]
        [InlineData(3, 5, 0, 1, new Command[] { }, 0, 1)]
        [InlineData(3, 5, 0, 1, new Command[] { Command.Quit }, 0, 1)]
        [InlineData(3, 5, 2, 4, new Command[] { Command.MoveForward }, 2, 3)]
        [InlineData(3, 5, 0, 1, new Command[] { Command.MoveForward, Command.Quit, Command.MoveBackward }, 0, 0)]
        [InlineData(4, 4, 2, 2, new Command[] { Command.MoveForward, Command.TurnLeft, Command.MoveForward, Command.TurnRight, Command.MoveBackward, Command.TurnRight, Command.MoveBackward, Command.TurnLeft, Command.MoveForward, Command.Quit}, 0, 1)]
        public void TestSimulationWithRectangularTable(int tableWidth, int tableHeight, int startPositionX, int startPositionY, Command[] commands, int finalPositionX, int finalPositionY)
        {
            ITable table = new RectangularTable(tableWidth, tableHeight);

            Position expect = new(finalPositionX, finalPositionY);

            Assert.Equal(expect, Simulator.Simulate(table, startPositionX, startPositionY, commands));
        }
    }
}
