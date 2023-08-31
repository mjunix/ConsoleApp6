using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Represents a rectangular table with a width and a height.
    /// </summary>
    public class RectangularTable : ITable
    {
        /// <summary>
        /// Width oth this table.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Height of this table
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Create a new RectangularTable with the given width and height.
        /// </summary>
        /// <param name="width">Width of table, must be positive</param>
        /// <param name="height">Height of table, must be positive</param>
        /// <exception cref="ArgumentException"></exception>
        public RectangularTable(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException($"width must be positive, given width was: {width}");
            }

            if (height <= 0)
            {
                throw new ArgumentException($"height must be positive, given height was: {height}");
            }

            Width = width;
            Height = height;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
        }
    }
}
