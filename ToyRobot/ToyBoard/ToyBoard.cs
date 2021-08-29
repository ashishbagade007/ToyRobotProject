using ToyRobot.Toy;
using ToyRobot.ToyBoard.Interface;

namespace ToyRobot.ToyBoard
{
    /// <summary>
    /// Board for toy defines rows and columns initially, also validates if the toy is going to fall off and prevents that.
    /// </summary>
    public class ToyBoard : IToyBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public ToyBoard(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        // Confirm that the toy position is inside the board itself.
        public bool IsValidPosition(ToyPosition position)
        {
            return position.X < Columns && position.X >= 0 && 
                   position.Y < Rows && position.Y >= 0;
        }
    }
}
