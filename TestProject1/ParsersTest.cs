using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class ParsersTest
    {
        [Theory]
        [InlineData("4,4,2,2", 4, 4, 2, 2)]
        [InlineData("4,3,2,1", 4, 3, 2, 1)]
        [InlineData("4 4 2 2", 4, 4, 2, 2)]
        [InlineData("4 3 2 1", 4, 3, 2, 1)]
        public void Test_ParseHeader(string line, int expectTableWidth, int expectTableHeight, int expectPositionX, int expectPositionY)
        {
            var expect = (expectTableWidth, expectTableHeight, new Position(expectPositionX, expectPositionY));
            Assert.Equal(expect, Parsers.ParseHeader(line));
        }

        [Theory]
        [InlineData("1,4,1,3,2,3,2,4,1,0", new Command[] { Command.MoveForward, Command.TurnLeft, Command.MoveForward, Command.TurnRight, Command.MoveBackward, Command.TurnRight, Command.MoveBackward, Command.TurnLeft, Command.MoveForward, Command.Quit })]
        [InlineData("1 4 1 3 2 3 2 4 1 0", new Command[] { Command.MoveForward, Command.TurnLeft, Command.MoveForward, Command.TurnRight, Command.MoveBackward, Command.TurnRight, Command.MoveBackward, Command.TurnLeft, Command.MoveForward, Command.Quit })]
        public void Test_ParseCommads(string line, Command[] expect)
        {
            Assert.Equal(expect, Parsers.ParseCommands(line));
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1 1 0")]
        [InlineData("1 1 0 0 1")]
        [InlineData("x x x x")]
        [InlineData("1 1 x x")]
        public void ParseHeaderWithInvalidInput(string line)
        {
            Assert.Throws<Exception>(() => Parsers.ParseHeader(line));
        }

        [Theory]
        [InlineData("99999")]
        [InlineData("x")]
        [InlineData("3 x")]
        public void ParseCommandsWithInvalidInput(string line)
        {
            Assert.Throws<Exception>(() => Parsers.ParseCommands(line));
        }
    }
}
