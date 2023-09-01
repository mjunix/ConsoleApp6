using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Represents a moveable object that has a position and a direction.
    /// </summary>
    public class MovingObject
    {
        /// <summary>
        /// Current position of the object
        /// </summary>
        public Position CurrentPosition { get; private set; }

        /// <summary>
        /// Current direction of the object.
        /// </summary>
        public CardinalDirection CurrentDirection { get; private set; } = CardinalDirection.North;

        /// <summary>
        /// Create a new MovingObject with the given position and direction.
        /// </summary>
        /// <param name="initialPosition">Initial position of the object</param>
        /// <param name="initialDirection">Initial direction of the object</param>
        public MovingObject(Position initialPosition, CardinalDirection initialDirection)
        {
            this.CurrentPosition = initialPosition;
            this.CurrentDirection = initialDirection;
        }

        /// <summary>
        /// Create a new MovingObject with the given initial position and a default direction of CardinalDirection.North.
        /// </summary>
        /// <param name="initialPosition">Initial position of the object</param>
        public MovingObject(Position initialPosition) : this(initialPosition, CardinalDirection.North)
        {

        }

        /// <summary>
        /// Turn the object. (Updates its CurrentDirection)
        /// </summary>
        /// <param name="turnDirection">Direction to turn the object</param>
        public void Turn(TurnDirection turnDirection)
        {
            switch (turnDirection)
            {
                case TurnDirection.Left:
                    TurnLeft();
                    break;
                case TurnDirection.Right:
                    TurnRight();
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case CardinalDirection.North:
                    CurrentDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.East:
                    CurrentDirection = CardinalDirection.North;
                    break;
                case CardinalDirection.South:
                    CurrentDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.West:
                    CurrentDirection = CardinalDirection.South;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (CurrentDirection)
            {
                case CardinalDirection.North:
                    CurrentDirection = CardinalDirection.East;
                    break;
                case CardinalDirection.East:
                    CurrentDirection = CardinalDirection.South;
                    break;
                case CardinalDirection.South:
                    CurrentDirection = CardinalDirection.West;
                    break;
                case CardinalDirection.West:
                    CurrentDirection = CardinalDirection.North;
                    break;
            }
        }

        /// <summary>
        /// Move the object. (Updates its CurrentPosition)
        /// </summary>
        /// <param name="moveDirection">Direction to move the object</param>
        public void Move(MoveDirection moveDirection)
        {
            switch(moveDirection)
            {
                case MoveDirection.Forward:
                    MoveForward();
                    break;
                case MoveDirection.Backward:
                    MoveBackward();
                    break;
            }
        }

        private void MoveForward()
        {
            switch (CurrentDirection)
            {
                case CardinalDirection.North:
                    CurrentPosition = new(CurrentPosition.X, CurrentPosition.Y - 1);
                    break;
                case CardinalDirection.East:
                    CurrentPosition = new(CurrentPosition.X + 1, CurrentPosition.Y);
                    break;
                case CardinalDirection.South:
                    CurrentPosition = new(CurrentPosition.X, CurrentPosition.Y + 1);
                    break;
                case CardinalDirection.West:
                    CurrentPosition = new(CurrentPosition.X - 1, CurrentPosition.Y);
                    break;
            }
        }

        private void MoveBackward()
        {
            switch (CurrentDirection)
            {
                case CardinalDirection.North:
                    CurrentPosition = new(CurrentPosition.X, CurrentPosition.Y + 1);
                    break;
                case CardinalDirection.East:
                    CurrentPosition = new(CurrentPosition.X - 1, CurrentPosition.Y);
                    break;
                case CardinalDirection.South:
                    CurrentPosition = new(CurrentPosition.X, CurrentPosition.Y - 1);
                    break;
                case CardinalDirection.West:
                    CurrentPosition = new(CurrentPosition.X + 1, CurrentPosition.Y);
                    break;
            }
        }
    }
}
