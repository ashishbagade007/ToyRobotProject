namespace ToyRobot.Toy
{
    /// <summary>
    /// This class represents the toy position.
    /// </summary>
    public class ToyPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ToyPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
