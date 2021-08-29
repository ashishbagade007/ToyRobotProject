using System;
using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;

namespace ToyRobot.InputValidator
{
    public class InputValidator : IInputValidator
    {
        // Validate input
        public ToyCommand ValidateCommand(string[] rawInput)
        {
            ToyCommand command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Only use the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");          
            return command;
        }

        // Returns the place command parameter instance from the input
        public PlaceParameter ValidateCommandParameter( string[] input)
        {
            var thisPlaceCommandParameter = new PlaceParameterValidator();     
            return thisPlaceCommandParameter.ValidateParameters(input);
        }     
    }



}
