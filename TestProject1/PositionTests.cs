using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class PositionTests
    {
        [Fact]
        public void NewPositionShouldSetXCoordinate()
        {
            Position position = new(3, 5);
            Assert.Equal(3, position.X);
        }

        [Fact]
        public void NewPositionShouldSetYCoordinate()
        {
            Position position = new(3, 5);
            Assert.Equal(5, position.Y);
        }
    }
}
