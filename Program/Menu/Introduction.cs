using System;

namespace FlightSimulator
{
    internal class Introduction
    {

        //shows the introduction and returns the choice made in the menu
        public static int Introduction1()
        {
            Console.WriteLine("Welcome to the Flight Simulator!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("This is a simple flight sim ");
            Console.WriteLine("made in C#. It will simulate a ");
            Console.WriteLine("flight from one city to another.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Be mindful of the weather,");
            Console.WriteLine("fuel capacity, and the status of");
            Console.WriteLine("your aircraft, as otherwise it will");
            Console.WriteLine("crash and you will lose the game.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press 1 for a tutorial");
            Console.WriteLine("Press 2 to start the game");
            Console.WriteLine("Press 3 to exit");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Please enter your choice:");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            return choice;
        }
    }
}
