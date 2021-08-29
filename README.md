Toy Robot Simulator


This C# .NET solution is a simulator of a toy robot that moves on a tabletop. The development of this project is driven by unit tests. These are included in this repository. A full requirements specification can be found here:
Processor
Command :
A class is used to represent user input data, validate it and return appropriate object types or error messages. The class has no dependencies and it's methods are unit tested before being set to work with the rest of the application.
Instructions and Valid Commands
Follow the on screen instructions to place a robot and move it around the board. To exit the application at any time type EXIT (this must be in uppercase)
PLACE X,Y,FACING : This puts the toy on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. If the toy is already placed, issuing another valid PLACE command will place the toy in the newly specified location.
MOVE : This moves the toy one unit forward in the direction it is currently facing.
LEFT : This rotates the toy 90 degrees to the left (i.e. counter-clockwise) without changing the position.
RIGHT : This rotates toy 90 degrees to the right (i.e. clockwise) without changing the position.
REPORT : This announces the X,Y and direction of the toy by printing to the console.
Installing and Running
The application runs in a single executable file which can be opened by double clicking it. The user can follow instructions on the console and also use it to type their input. For convenience the file can be downloaded from here:
ToyRobotSimulator.exe
Unit Testing
C# Test files are found here: BattleShipsTests
Tests were run using the nuget packages: NUnit 2.6.4 and NUnit Test Adapter 2.0.0
Notes and Acknowledgements
A full list of information sources can be found here: Acknowledgements.txt.
Supported Operating Systems and Issues
Toy Robot Simulator should run on any Windows operating system. It has been tested on Windows 10 Home Edition 32-bit. Existing issues can be logged on the Issues page.
