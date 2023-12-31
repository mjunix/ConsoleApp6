﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Represents a position in 2D space.
    /// (Has a X and Y coordinate.)
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X-coordinate of this position.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y-coordinate of this position.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Create a new position with given coordinates.
        /// </summary>
        /// <param name="x">X-coordinate of position</param>
        /// <param name="y">Y-coordinate of position</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (X == p.X) && (Y == p.Y);
            }
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        /// <summary>
        /// Returns a string representation of this position.
        /// </summary>
        /// <returns>A string of the form "[X, Y]"</returns>
        public override string ToString()
        {
            return $"[{this.X}, {this.Y}]";
        }
    }
}
