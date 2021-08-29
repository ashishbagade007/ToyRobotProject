using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;
using ToyRobot.Toy.Interface;
using ToyRobot.ToyBoard.Interface;

namespace ToyRobot.ToyMovementProcessings
{
    /// <summary>
    /// Performing toy movement according to input commands
    /// </summary>
    public class ToyMovementProcessing
    {
        public IToyRobot ToyRobot { get; private set; }
        public IToyBoard SquareBoard { get; private set; }
        public IInputValidator InputParser { get; private set; }

        public ToyMovementProcessing(IToyRobot toyRobot, IToyBoard squareBoard, IInputValidator inputParser)
        {
            ToyRobot = toyRobot;
            SquareBoard = squareBoard;
            InputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var command = InputParser.ValidateCommand(input);
            if (command != ToyCommand.Place && ToyRobot.ToyPosition == null) return string.Empty;

            switch (command)
            {
                case ToyCommand.Place:
                    var placeCommandParameter = InputParser.ValidateCommandParameter(input);
                    if (SquareBoard.IsValidPosition(placeCommandParameter.ToyPosition))
                        ToyRobot.Place(placeCommandParameter.ToyPosition, placeCommandParameter.ToyDirection);
                    break;
                case ToyCommand.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (SquareBoard.IsValidPosition(newPosition))
                        ToyRobot.ToyPosition = newPosition;
                    break;
                case ToyCommand.Left:
                    ToyRobot.RotateLeft();
                    break;
                case ToyCommand.Right:
                    ToyRobot.RotateRight();
                    break;
                case ToyCommand.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", ToyRobot.ToyPosition.X,
                ToyRobot.ToyPosition.Y, ToyRobot.ToyDirection.ToString().ToUpper());
        }
    }
}
