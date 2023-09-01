using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class MovingObjectTests
    {
        [Fact]
        public void NewMovingObjectWithOnlyInitialPositionShouldSetInitialPosition()
        {
            Position initialPosition = new(3, 5);
            MovingObject movingObject = new(initialPosition);

            Assert.Equal(initialPosition, movingObject.CurrentPosition);
        }

        [Fact]
        public void NewMovingObjectWithOnlyInitialPositionShouldFaceNorth()
        {
            MovingObject movingObject = new(new Position(3, 5));

            Assert.Equal(CardinalDirection.North, movingObject.CurrentDirection);
        }

        [Fact]
        public void NewMovingObjectWithBothInitialPositionAndInitialDirectionShouldSetInitialPosition()
        {
            MovingObject movingObject = new(new Position(3, 5), CardinalDirection.South);

            Assert.Equal(new Position(3, 5), movingObject.CurrentPosition);
        }

        [Fact]
        public void NewMovingObjectWithBothInitialPositionAndInitialDirectionShouldSetInitialDirection()
        {
            MovingObject movingObject = new(new Position(3, 5), CardinalDirection.South);

            Assert.Equal(CardinalDirection.South, movingObject.CurrentDirection);
        }

        [Theory]
        [InlineData(CardinalDirection.North, TurnDirection.Left, CardinalDirection.West)]
        [InlineData(CardinalDirection.East, TurnDirection.Left, CardinalDirection.North)]
        [InlineData(CardinalDirection.South, TurnDirection.Left, CardinalDirection.East)]
        [InlineData(CardinalDirection.West, TurnDirection.Left, CardinalDirection.South)]
        [InlineData(CardinalDirection.North, TurnDirection.Right, CardinalDirection.East)]
        [InlineData(CardinalDirection.East, TurnDirection.Right, CardinalDirection.South)]
        [InlineData(CardinalDirection.South, TurnDirection.Right, CardinalDirection.West)]
        [InlineData(CardinalDirection.West, TurnDirection.Right, CardinalDirection.North)]
        public void TurnChangesCardinalDirection(CardinalDirection startingDirection, TurnDirection turnDirection, CardinalDirection expectedDirection)
        {
            MovingObject movingObject = new(new Position(0, 0), startingDirection);
            movingObject.Turn(turnDirection);

            Assert.Equal(expectedDirection, movingObject.CurrentDirection);
        }

        [Theory]
        [InlineData(3, 5, CardinalDirection.North, TurnDirection.Left)]
        [InlineData(3, 5, CardinalDirection.East, TurnDirection.Left)]
        [InlineData(3, 5, CardinalDirection.South, TurnDirection.Left)]
        [InlineData(3, 5, CardinalDirection.West, TurnDirection.Left)]
        [InlineData(3, 5, CardinalDirection.North, TurnDirection.Right)]
        [InlineData(3, 5, CardinalDirection.East, TurnDirection.Right)]
        [InlineData(3, 5, CardinalDirection.South, TurnDirection.Right)]
        [InlineData(3, 5, CardinalDirection.West, TurnDirection.Right)]
        public void TurnDoesNotChangePosition(int initialPositionX, int initialPositionY, CardinalDirection startingDirection, TurnDirection turnDirection)
        {
            MovingObject movingObject = new(new Position(initialPositionX, initialPositionY), startingDirection);
            Position expect = new(initialPositionX, initialPositionY);
            
            movingObject.Turn(turnDirection);

            Assert.Equal(expect, movingObject.CurrentPosition);
        }

        [Theory]
        [InlineData(3, 5, CardinalDirection.North, MoveDirection.Forward, 3, 4)]
        [InlineData(3, 5, CardinalDirection.East, MoveDirection.Forward, 4, 5)]
        [InlineData(3, 5, CardinalDirection.South, MoveDirection.Forward, 3, 6)]
        [InlineData(3, 5, CardinalDirection.West, MoveDirection.Forward, 2, 5)]
        [InlineData(3, 5, CardinalDirection.North, MoveDirection.Backward, 3, 6)]
        [InlineData(3, 5, CardinalDirection.East, MoveDirection.Backward, 2, 5)]
        [InlineData(3, 5, CardinalDirection.South, MoveDirection.Backward, 3, 4)]
        [InlineData(3, 5, CardinalDirection.West, MoveDirection.Backward, 4, 5)]
        public void MoveChangesPosition(int initialPositionX, int initialPositionY, CardinalDirection initialDirection, MoveDirection moveDirection, int expectX, int expectY)
        {
            MovingObject movingObject = new(new Position(initialPositionX, initialPositionY), initialDirection);
            movingObject.Move(moveDirection);

            Position expect = new(expectX, expectY);
            
            Assert.Equal(expect, movingObject.CurrentPosition);
        }

        [Theory]
        [InlineData(3, 5, CardinalDirection.North, MoveDirection.Forward)]
        [InlineData(3, 5, CardinalDirection.East, MoveDirection.Forward)]
        [InlineData(3, 5, CardinalDirection.South, MoveDirection.Forward)]
        [InlineData(3, 5, CardinalDirection.West, MoveDirection.Forward)]
        [InlineData(3, 5, CardinalDirection.North, MoveDirection.Backward)]
        [InlineData(3, 5, CardinalDirection.East, MoveDirection.Backward)]
        [InlineData(3, 5, CardinalDirection.South, MoveDirection.Backward)]
        [InlineData(3, 5, CardinalDirection.West, MoveDirection.Backward)]
        public void MoveDoesNotChangesCardinalDirection(int initialPositionX, int initialPositionY, CardinalDirection initialDirection, MoveDirection moveDirection)
        {
            MovingObject movingObject = new(new Position(initialPositionX, initialPositionY), initialDirection);
            movingObject.Move(moveDirection);

            CardinalDirection expect = initialDirection;

            Assert.Equal(expect, movingObject.CurrentDirection);
        }
    }
}
