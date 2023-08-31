using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Interface for a table that an object moves on.
    /// </summary>
    internal interface ITable
    {
        /// <summary>
        /// Return true if the given position is a valid position on this table, false otherwise.
        /// </summary>
        /// <param name="position">The position to check</param>
        /// <returns></returns>
        public bool IsValidPosition(Position position);
    }
}
