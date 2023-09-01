using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Simulator
    {
        /// <summary>
        /// Simulate a moving object on a table.
        /// </summary>
        /// <param name="table">The table the object is moving on</param>
        /// <param name="startPosition">Initial position of the moving object</param>
        /// <param name="commands">The commands to execute</param>
        /// <returns>The final position of the object after executing the commands</returns>
        /// <exception cref="ArgumentException">If starting position is illegal on this table</exception>
        public static Position Simulate(ITable table, Position startPosition, Command[] commands)
        {
            MovingObject movingObject = new(startPosition);

            if (!table.IsValidPosition(startPosition))
            {
                throw new InvalidPositionException($"Illegal start position on table: {startPosition}");
            }

            foreach (var command in commands)
            {
                switch (command)
                {
                    case Command.MoveForward:
                        movingObject.Move(MoveDirection.Forward);
                        break;
                    case Command.MoveBackward:
                        movingObject.Move(MoveDirection.Backward);
                        break;
                    case Command.TurnLeft:
                        movingObject.Turn(TurnDirection.Left);
                        break;
                    case Command.TurnRight:
                        movingObject.Turn(TurnDirection.Right);
                        break;
                    case Command.Quit:
                        return movingObject.CurrentPosition;
                }

                if (!table.IsValidPosition(movingObject.CurrentPosition))
                {
                    throw new InvalidPositionException($"Illegal position: {movingObject.CurrentPosition}");
                }
            }

            return movingObject.CurrentPosition;
        }
    }
}
