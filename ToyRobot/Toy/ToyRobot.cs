using System;
using ToyRobot.Toy.Interface;

namespace ToyRobot.Toy
{

    public class ToyRobot : IToyRobot
    {
        public ToyDirection ToyDirection { get; set; }
        public ToyPosition ToyPosition { get; set; }

        // Sets the toy's position and direction.
        public void Place(ToyPosition position, ToyDirection direction)
        {
            this.ToyPosition = position;
            this.ToyDirection = direction;
        }

        // Determines the next position of the toy based on the direction it's currently facing.
        public ToyPosition GetNextPosition()
        {
            var newPosition = new ToyPosition(ToyPosition.X, ToyPosition.Y);
            switch (ToyDirection)
            {
                case ToyDirection.North:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case ToyDirection.East:
                    newPosition.X = newPosition.X + 1;
                    break;
                case ToyDirection.South:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                case ToyDirection.West:
                    newPosition.X = newPosition.X - 1;
                    break;
            }
            return newPosition;
        }

        // Rotates the direction of the toy 90 degreesto the left.
        public void RotateLeft()
        {
            Rotate(-1);
        }

        // Rotates the direction of the toy 90 degrees to the right.
        public void RotateRight()
        {
            Rotate(1);
        }

        // Determines the new direction of the toy. The new direction is based
        // on current direction and the rotation command (LEFT - Right)
        // the code uses the enumerate values for the NSEW and a modulus
        // operator to calculate the new direction.
        public void Rotate(int rotationNumber)
        {
            var directions = (ToyDirection[])Enum.GetValues(typeof(ToyDirection));
            ToyDirection newDirection;
            if ((ToyDirection + rotationNumber) < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = ((int)(ToyDirection + rotationNumber)) % directions.Length;
                newDirection = directions[index];
            }
            ToyDirection = newDirection;
        }       
    }
}
