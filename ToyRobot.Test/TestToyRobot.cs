using NUnit.Framework;
using ToyRobot.Toy;

namespace ToyRobot.Test
{
    [TestFixture]
    public class TestToyRobot
    {
        /// <summary>
        /// Test toy turn left
        /// </summary>
        [Test]
        public void TestValidToyTurnLeft()
        {
            // arrange
            var robot = new ToyRobot { ToyDirection = ToyDirection.West, ToyPosition = new ToyPosition(2, 2) };

            // act
            robot.RotateLeft();

            // assert
            Assert.AreEqual(ToyDirection.South,robot.ToyDirection);
        }

        /// <summary>
        /// Test toy turn right
        /// </summary>
        [Test]
        public void TestValidToyTurnRight()
        {
            // arrange
            var robot = new ToyRobot { ToyDirection = ToyDirection.West, ToyPosition = new ToyPosition(2, 2) };

            // act
            robot.RotateRight();

            // assert
            Assert.AreEqual(ToyDirection.North, robot.ToyDirection);
        }


        /// <summary>
        /// Test move
        /// </summary>
        [Test]
        public void TestValidToyMove()
        {
            // arrange
            var robot = new ToyRobot { ToyDirection = ToyDirection.East, ToyPosition = new ToyPosition(2, 2) };

            // act
            var nextPosition = robot.GetNextPosition();

            // assert
            Assert.AreEqual(3, nextPosition.X);
            Assert.AreEqual(2, nextPosition.Y);
        }

        /// <summary>
        /// Test set toy position and direction
        /// </summary>
        [Test]
        public void TestValidToyPositionAndDirection()
        {
            // arrange
            var position = new ToyPosition(3, 3);
            var robot = new ToyRobot();

            // act
            robot.Place(position, ToyDirection.North);

            // assert
            Assert.AreEqual(3, robot.ToyPosition.X);
            Assert.AreEqual(3, robot.ToyPosition.Y);
            Assert.AreEqual(ToyDirection.North, robot.ToyDirection);
        }

    }
}
