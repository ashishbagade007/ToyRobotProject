using NUnit.Framework;
using ToyRobot.InputValidator;
using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;
using ToyRobot.Toy.Interface;
using ToyRobot.ToyBoard.Interface;
using ToyRobot.ToyBoard;

namespace ToyRobot.Test
{
    [TestFixture]
    public class TestToyMovementProcessing
    {
        /// <summary>
        /// Test a valid place command
        /// </summary>
        [Test]
        public void TestValidToyMovementProcessingPlace()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var movementProcessor = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);

            // act
            movementProcessor.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.ToyPosition.X);
            Assert.AreEqual(4, robot.ToyPosition.Y);
            Assert.AreEqual(ToyDirection.East, robot.ToyDirection);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidToyMovementProcessingPlace()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var movementProcessor = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);

            // act
            movementProcessor.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.ToyPosition);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidToyMovementProcessingMove()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var movementProcessor = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);

            // act
            movementProcessor.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", movementProcessor.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Test]
        public void TestInvalidToyMovementProcessingMove()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var movementProcessor = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);

            // act
            movementProcessor.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            
            // assert
            Assert.AreEqual("Output: 2,4,NORTH", movementProcessor.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidToyMovementProcessingReport()
        {
            // arrange
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputParser();
            IToyRobot robot = new ToyRobot();
            var movementProcessor = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);
            
            // act
            movementProcessor.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            movementProcessor.ProcessCommand("LEFT".Split(' '));
            movementProcessor.ProcessCommand("MOVE".Split(' '));
            var output = movementProcessor.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
