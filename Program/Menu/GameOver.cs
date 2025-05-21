
using System;

namespace FlightSimulator
{
    internal class GameOver
    {

        // shows the game over screen
        public static void gameOverScreen()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }

        // shows the game win screen
        public static void gameWinScreen()
        {
            Console.Clear();
            Console.WriteLine("You won!");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}
