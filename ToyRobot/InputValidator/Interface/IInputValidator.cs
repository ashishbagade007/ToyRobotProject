using System;
using ToyRobot.Toy;

namespace ToyRobot.InputValidator.Interface
{
    public interface IInputValidator
    {
        // process the input from the user.
        ToyCommand ValidateCommand(string[] rawInput);

        // validate and return proper place parameter
        PlaceParameter ValidateCommandParameter(string[] input);
    }
}
