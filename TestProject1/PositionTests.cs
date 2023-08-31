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

        [Theory]
        [InlineData(3, 5, 3, 5, true)]
        [InlineData(3, 3, 3, 3, true)]
        [InlineData(3, 5, 5, 3, false)]
        [InlineData(3, 3, 5, 5, false)]
        public void Test_Equals(int x1, int y1, int x2, int y2, bool expected)
        {
            Position p1 = new(x1, y1);
            Position p2 = new(x2, y2);

            Assert.Equal(expected, p1.Equals(p2));
        }

        [Fact]
        public void Test_GetHashCodeWithEqualPositions()
        {
            Position p1 = new(3, 5);
            Position p2 = new(3, 5);

            Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
        }

        [Fact]
        public void Test_ToString()
        {
            Position position = new(3, 5);
            Assert.Equal("[3, 5]", position.ToString());
        }
    }
}
