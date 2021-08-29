using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;

namespace ToyRobot.InputValidator
{
    // "PLACE" command parameters storage.
    public class PlaceParameter
    {
        public ToyPosition ToyPosition { get; set; }
        public ToyDirection ToyDirection { get; set; }

        public PlaceParameter(ToyPosition position,ToyDirection direction)
        {
            ToyPosition = position;
            ToyDirection = direction;
        }
    }
}
