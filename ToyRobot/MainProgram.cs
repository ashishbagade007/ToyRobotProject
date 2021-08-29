using System;
using ToyRobot.InputValidator.Interface;
using ToyRobot.Toy;
using ToyRobot.Toy.Interface;
using ToyRobot.ToyBoard.Interface;

namespace ToyRobot
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            IToyBoard squareBoard = new ToyBoard.ToyBoard(5, 5);
            IInputValidator inputParser = new InputValidator.InputValidator();
            IToyRobot robot = new Toy.ToyRobot();
            var toyMover = new ToyMovementProcessings.ToyMovementProcessing(robot, squareBoard, inputParser);

            var stopAndExit = false;
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopAndExit = true;
                else
                {
                    try
                    {
                        var output = toyMover.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopAndExit);
        }
    }
}
