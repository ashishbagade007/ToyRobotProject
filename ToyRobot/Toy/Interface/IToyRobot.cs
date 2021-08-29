namespace ToyRobot.Toy.Interface
{
    public interface IToyRobot
    {
        ToyDirection ToyDirection { get; set; }
        ToyPosition ToyPosition { get; set; }

        // Place toy
        void Place(ToyPosition position, ToyDirection direction);

        // get toy position
        ToyPosition GetNextPosition();

        // rotate toy left
        void RotateLeft();

        // rotate toy right
        void RotateRight();

        // rotate toy
        void Rotate(int rotationNumber);
    }
}
