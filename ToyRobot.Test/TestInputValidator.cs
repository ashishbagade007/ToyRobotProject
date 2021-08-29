using System;
using NUnit.Framework;
using ToyRobot.InputValidator;
using ToyRobot.Toy;

namespace ToyRobot.Test
{
    [TestFixture]
    public class TestInputValidator
    {
        /// <summary>
        /// Test valid place command
        /// </summary>
        [Test]
        public void TestValidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = inputParser.ValidateCommand(rawInput);

            // assert
            Assert.AreEqual(ToyCommand.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { inputParser.ValidateCommand(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT"));
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [Test]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = inputParser.ValidateCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.ToyPosition.X);
            Assert.AreEqual(3, placeCommandParameter.ToyPosition.Y);
            Assert.AreEqual(ToyDirection.West, placeCommandParameter.ToyDirection);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var inputParser = new InputParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate
            {  var placeCommandParameter = inputParser.ValidateCommandParameter(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [Test]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new PlaceParameterValidator();
            string[] rawInput = "PLACE 2,4,OneDirection".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ValidateParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST"));
        }

        /// <summary>
        /// Test a place command with an invalid parameter format
        /// </summary>
        [Test]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            var paramParser = new PlaceParameterValidator();
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ValidateParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

    }
}
