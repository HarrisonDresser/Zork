using System;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return _rooms[_location.Row, _location.Column];
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.Write($"{_rooms[_currentRow, _currentColumn]}\n>");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString = "";
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = " Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "A rubber mat saying 'Welcome to Zork! lies by the door."; 
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:     
                    case Commands.EAST:   
                    case Commands.WEST:
                        if (Move(command))
                        {
                           outputString = $"You moved {command}.";
                           //outputString = (_rooms[_currentRow, _currentColumn].ToString());
                        }
                        else
                        {
                            outputString = "The way is shut";
                        }
                        
                        break;

                    default:
                        outputString = "Unknown command.";
                        break;

                }

                Console.WriteLine(outputString);
            }
        }

        private static Commands ToCommand(string commandString) => (Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN);

        private static bool Move(Commands command)
        {
            bool didMove;

            switch (command)
            {
                case Commands.NORTH when _currentRow < _rooms.GetLength(0) - 1:
                    _currentRow++;
                    didMove = true;
                    break;
                case Commands.SOUTH when _currentRow > 0:
                    _currentRow--;
                    didMove = true;
                    break;

                case Commands.EAST when _currentColumn < _rooms.GetLength(1) - 1:
                    _currentColumn++;
                    didMove = true;
                        break;

                case Commands.WEST when _currentColumn > 0:
                        _currentColumn--;
                        didMove = true;
                        break;

                default:
                    didMove = false;
                    break;
            }
            return didMove;
        }

        private static readonly string[,] _rooms =
        {
            {"Rocky Trail", "South of House", "Canyon View"},
            { "Forest", "West of House", "Behind House"},
            { "Dense Woods", "North of House", "Clearing"}
        };

        private static int _currentRow = 1;
        private static int _currentColumn = 1;

        private static (int Row, int Column) _location = (1, 1);

        //private static int _currentRoom = 1;



    }
}