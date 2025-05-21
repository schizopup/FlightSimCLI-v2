
namespace FlightSimulator
{
  
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            bool gameState = true;

            game.startGame();

            while (gameState=true)
            {
                int choice = Introduction.Introduction1();
                switch (choice)
                {
                    case 1:
                        Tutorial.ShowTutorial();
                        break;
                    case 2:
                        game.startGame();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
