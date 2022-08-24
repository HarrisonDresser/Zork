using System;

namespace Zork
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            // string inputString = System.Console.ReadLine();
            //inputString = inputString.ToUpper();

            String inputString = Console.ReadLine().Trim().ToUpper();

            //.Trim() does trailing and precedding spaces - also leftTrim() - and rightTrim()

            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for Playing.");
            }

            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
            }

            else
            {
                //$ is important to ensure the string value of inputString is displayed
                Console.WriteLine($"Unrecognized commad: {inputString}");
            }

        }
    }
}