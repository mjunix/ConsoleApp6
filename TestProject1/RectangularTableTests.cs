using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class RectangularTableTests
    {
        [Fact]
        public void NewRectangularTableSetsWidth()
        {
            RectangularTable table = new(3, 5);
            Assert.Equal(3, table.Width);
        }

        [Fact]
        public void NewRectangularTableSetsHeight()
        {
            RectangularTable table = new(3, 5);
            Assert.Equal(5, table.Height);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(-1, -1)]
        [InlineData(-1, 3)]
        [InlineData(3, -1)]
        public void InvalidWidthOrHeightThrowsException(int width, int height)
        {
            Assert.Throws<ArgumentException>(() => { new RectangularTable(width, height); });
        }

        [Theory]
        [InlineData(1, 1, 0, 0, true)]
        [InlineData(1, 1, 1, 0, false)]
        [InlineData(1, 1, 0, 1, false)]
        [InlineData(1, 1, 1, 1, false)]
        [InlineData(1, 1, -1, 0, false)]
        [InlineData(1, 1, 0, -1, false)]
        [InlineData(1, 1, -1, -1, false)]
        [InlineData(3, 5, 0, 0, true)]
        [InlineData(3, 5, 1, 2, true)]
        [InlineData(3, 5, 2, 4, true)]
        [InlineData(3, 5, -1, 0, false)]
        [InlineData(3, 5, 0, -1, false)]
        [InlineData(3, 5, -1, -1, false)]
        [InlineData(3, 5, 3, 0, false)]
        [InlineData(3, 5, 0, 5, false)]
        [InlineData(3, 5, 3, 5, false)]
        [InlineData(3, 5, 100, 200, false)]
        public void IsValidPosition(int width, int height, int x, int y, bool expected)
        {
            RectangularTable table = new(width, height);
            Position position = new(x, y);

            Assert.Equal(expected, table.IsValidPosition(position));
        }
    }
}
