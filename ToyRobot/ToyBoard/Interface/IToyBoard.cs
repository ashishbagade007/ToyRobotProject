using ToyRobot.Toy;

namespace ToyRobot.ToyBoard.Interface
{
    public interface IToyBoard
    {
        // returns if the toy is inside the board or not
        bool IsValidPosition(ToyPosition position);
    }
}
