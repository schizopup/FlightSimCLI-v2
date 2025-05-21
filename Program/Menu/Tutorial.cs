
using System;

namespace FlightSimulator
{
    internal class Tutorial
    {
        
        // shows the tutorial
        public static void ShowTutorial()
        {
            Console.WriteLine("Welcome to the tutorial!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("In this game you must make");
            Console.WriteLine("choices in real time.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The aircraft has 4 parts:");
            Console.WriteLine("1. The wings");
            Console.WriteLine("2. The engine");
            Console.WriteLine("3. The cabin");
            Console.WriteLine("4. The radar");
            Console.WriteLine("If any of these parts break the");
            Console.WriteLine("aircraft will crash and you will lose.");
            Console.WriteLine("These parts have chances to damage");
            Console.WriteLine("during weather events");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("There are 4 weather events");
            Console.WriteLine("1. Sunny (No damage)");
            Console.WriteLine("2. Windy (Low damage)");
            Console.WriteLine("3. Rainy (Medium damage)");
            Console.WriteLine("4. Stormy (High damage)");
            Console.WriteLine("These events happens randomly");
            Console.WriteLine("each 30 seconds, so be warry.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("You will be given a list of");
            Console.WriteLine("actions to keep your aircraft");
            Console.WriteLine("flying. Every aircraft model");
            Console.WriteLine("has a fuel reservoire of 100.");
            Console.WriteLine("Each speed uses different amounts");
            Console.WriteLine("of fuel per action.");
            Console.WriteLine("Slow takes 5, medium takes 10,");
            Console.WriteLine("and fast takes 15.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The  actions are as follows:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("1. Start the engine");
            Console.WriteLine("2. Stop the engine (only on land)");
            Console.WriteLine("3. Take off (engine must be on)");
            Console.WriteLine("4. Augument altitude (1000ft)");
            Console.WriteLine("5. Decrease altitude (1000ft)");
            Console.WriteLine("6. Landing mode (needed to land safely)");
            Console.WriteLine("7. Repair (must be on ground)");
            Console.WriteLine("8. Change speed");
            Console.WriteLine("9. Quit the simualation");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

