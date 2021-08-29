using System;
using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;

namespace ToyRobot.InputValidator
{

    // This class checks the parameters for the "PLACE" command.
    public class PlaceParameterValidator
    {        
        // "PLACE" ToyCommand should have 3 parameters as (X,Y,F)
        private const int ParameterCount = 3;
        
        // Input count should be - 2.
        private const int CommandInputCount = 2;

        public PlaceParameter ValidateParameters(string[] input)
        {
            ToyDirection direction;
            ToyPosition position = null;

            if (input.Length != CommandInputCount)
                throw new ArgumentException("Please give the PLACE command as : PLACE X,Y,F");

            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Please give the PLACE command as : PLACE X,Y,F");

            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Only following directions are valid: NORTH|EAST|SOUTH|WEST");
            
            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new ToyPosition(x, y);

            return new PlaceParameter(position, direction);
        }
    }
}
