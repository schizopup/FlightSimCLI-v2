using System;
using System.ComponentModel.Design;
using System.Numerics;
using static FlightSimulator.Game;

namespace FlightSimulator
{
    internal class Game
    {
        // Singleton instances for managing weather and trip
        static Weather weatherEvent = new Weather();
        static Trip trip = new Trip();
        private List<ActionHistorique> _historique = new List<ActionHistorique>();

        // Helper method to check engine status of aircraft
        internal static string enginestatus(IAircraft a)
        {
            if (a.engine.getStatus() == false)
            {
                return "engine off";
            }
            else
            { 
                return "engine running";
            }
        }

        // Class to store historical actions with timestamps
        public class ActionHistorique
        {
            public string Description { get; }
            public DateTime Timestamp { get; }

            public ActionHistorique(string description)
            {
                Description = description;
                Timestamp = DateTime.Now;
            }

            public override string ToString()
            {
                return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] {Description}";
            }
        }

        // Method to display flight recorder history
        public void RejouerHistorique()
        {
            Console.WriteLine("\nDownloading blackbox...");

            foreach (var action in _historique)
            {
                Console.WriteLine(action.ToString());
            }

            Console.WriteLine("End of download.");
        }
        
        // Main game loop and initialization
        public void startGame()
        {
            // Initial aircraft setup
            string planeselection = AeronefFactory.setPlane();
            IAircraft aircraft = AeronefFactory.CreerAeronef(planeselection);

            // Game state variables
            string newspeed = "S";
            int deltaFuel = 0;
            int fuel = aircraft.getFuel();
            int damage = weatherEvent.getDamage();
            string weather = weatherEvent.weatherChange();
            trip.StartTrip();
            int distance = trip.getDistance();
            int time = 0;
            int game = 1;
            int altitude = aircraft.getAltitude();
            int departuredistance = 0;
            string flightstate = "ground";
            bool status;
            string warning = "";
            string actionhistorique = "";

            // Main game loop
            while (game == 1)
            {
                Console.Clear();

                // Game over condition checks
                if (fuel <= 0)
                {
                    Console.WriteLine("You ran out of fuel. Game over!");
                    GameOver.gameOverScreen();
                }

                if (flightstate == "exploded")
                {
                    Console.WriteLine("You exploded. Use repair?");
                }

                if (aircraft.wings.getDamage() >= 99)
                {
                    Console.WriteLine("Your wings are damaged. Game over!");
                    GameOver.gameOverScreen();
                }

                if (aircraft.engine.getDamage() >= 99)
                {
                    Console.WriteLine("Your engine is damaged. Game over!");
                    GameOver.gameOverScreen();
                }

                if (aircraft.cabin.getDamage() >= 99)
                {
                    Console.WriteLine("Your cabin is damaged. Game over!");
                    GameOver.gameOverScreen();
                }

                if (aircraft.radar.getDamage() >= 99)
                {
                    Console.WriteLine("Your radar is damaged. Game over!");
                    GameOver.gameOverScreen();
                }

                if (altitude < 0)
                {
                    Console.WriteLine("You crashed. Game over!");
                    GameOver.gameOverScreen();
                }

                if (aircraft.getAltitude() >= aircraft.getMaxAltitude())
                {
                    Console.WriteLine("Your altitude is too high. You exploded. Repair?");
                    GameOver.gameOverScreen();
                }

                // Display game interface and status
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Notifications:" + warning);
                Console.WriteLine("Trip from " + trip.getCity1() + " to " + trip.getCity2());
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Aircraft: " + aircraft.getPlane());
                aircraft.AfficherType();
                Console.WriteLine("Weather: " + weather);
                Console.WriteLine("Flight state: " + flightstate);
                Console.WriteLine("Fuel:" + aircraft.fuel);
                Console.WriteLine("Engine status: " + enginestatus(aircraft));
                Console.WriteLine("Engine:" + aircraft.engine.getDamage() + " damage");
                Console.WriteLine("Wings:" + aircraft.wings.getDamage() + " damage");
                Console.WriteLine("Cabin:" + aircraft.cabin.getDamage() + " damage");
                Console.WriteLine("Radar:" + aircraft.radar.getDamage() + " damage");
                Console.WriteLine("Distance left:" + distance + " mi, from departure:" + departuredistance + " mi");
                Console.WriteLine("Speed: " + newspeed + "-" + aircraft.speed + " MPH");
                Console.WriteLine("Altitude:" + aircraft.getAltitude() + " ft");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Start the engine");
                Console.WriteLine("2. Stop the engine (only on land)");
                Console.WriteLine("3. Take off (engine must be on)");
                Console.WriteLine("4. Augment altitude (1000ft)");
                Console.WriteLine("5. Decrease altitude (1000ft)");
                Console.WriteLine("6. Landing mode (needed to land safely)");
                Console.WriteLine("7. Repair (must be on ground)");
                Console.WriteLine("8. Change speed");
                Console.WriteLine("9. Display flight recorder events (run without refresh)");
                Console.WriteLine("10. Quit the simulation");

                // Check for user input
                if (Console.KeyAvailable)
                {
                    string action = Console.ReadLine();

                    // Process user actions
                    switch (action)
                    {
                        case "1": // Start engine
                            actionhistorique = "Start engine";
                            aircraft.startEngine();

                            if (aircraft.engine.getStatus() == false)
                            {
                                Console.WriteLine("could not start engine");
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "2": // Stop engine
                            actionhistorique = "Stop engine";
                            aircraft.stopEngine();

                            if (aircraft.engine.getStatus() == false) 
                            {
                                aircraft.speed = 0;
                            } 
                            else 
                            {
                                Console.WriteLine("could not stop engine");
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "3": // Take off procedure
                            actionhistorique = "Take off";
                            aircraft.takeOff();

                            if (aircraft.getAltitude() > 0) 
                            { 
                                flightstate = "air"; deltaFuel = 5; 
                            }
                            else 
                            {
                                Console.WriteLine("could not take off");
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "4": // Increase altitude
                            actionhistorique = "Increase altitude";
                            aircraft.increaseAltitude(flightstate);

                            if (aircraft.getAltitude() >= 12000)
                            {
                                flightstate = "exploded";
                                Console.WriteLine("Your aircraft exploded. Repair needed(option 7)?");
                            }
                            else if (aircraft.getAltitude() >= 10000) 
                            {
                                warning = "Your altitude is near the limit ";
                            }

                            if (warning.Contains("landing"))
                            {
                                warning = "";
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "5": // Decrease altitude
                            actionhistorique = "Decrease altitude";
                            aircraft.decreaseAltitude(flightstate);

                            if (warning.Contains("altitude"))
                            {
                                if (aircraft.getAltitude() < 10000)
                                {
                                    warning = "";
                                }

                                if (flightstate != "landing")
                                {
                                    warning = "Alert landing mode not On";
                                    if (aircraft.getAltitude() < 1000)
                                    flightstate = "exploded";
                                }
                                else if (aircraft.getAltitude() == 0)
                                {
                                    flightstate = "ground";
                                    Console.WriteLine("You auto-landed successfully.");
                                    aircraft.speed = 0;
                                }
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "6": // Landing mode
                            actionhistorique = "Set landing mode";
                            aircraft.landingMode(ref flightstate);

                            if (warning.Contains("landing"))
                            {
                                warning = "";
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "7": // Repair and refuel
                            actionhistorique = "Repair and refuel aircraft";
                            flightstate = "ground";
                            aircraft.repair();
                            warning = "";
                            aircraft.speed = 0;
                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "8": // Speed control
                            status = aircraft.engine.getStatus();

                            if (status == true)
                            {
                                Console.WriteLine("Enter new speed (S, C, F):");
                                newspeed = Console.ReadLine().ToUpper();

                                if (newspeed == "S")
                                {
                                    deltaFuel = 5;
                                    aircraft.speed = 250;
                                }
                                else if (newspeed == "C")
                                {
                                    deltaFuel = 10;
                                    aircraft.speed = 350;
                                }
                                else if (newspeed == "F")
                                {
                                    deltaFuel = 15;
                                    aircraft.speed = 450;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid speed. Please try again.");
                                    continue;
                                }

                                actionhistorique = "Set speed to " + newspeed; ;
                            }
                            else
                            {
                                Console.WriteLine("Engine is not on");
                            }

                            aircraft.fuel = aircraft.fuel - deltaFuel;
                            break;

                        case "9": // Display flight recorder
                            actionhistorique = "Display black box events";
                            RejouerHistorique();
                            break;

                        case "10": // Quit game
                            actionhistorique = "Quit game";
                            game = 0;
                            lastAction = "Quit";
                            actions.Add(lastAction); //ml0 ajout
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            lastAction = "Invalid choice";
                            actions.Add(lastAction); //ml0 ajout
                            break;
                    }

                    // Record action in history
                    _historique.Add(new ActionHistorique(actionhistorique));

                }
                else
                {
                    System.Threading.Thread.Sleep(3000);
                }

                // Check win condition
                if (distance <= 0)
                {
                    GameOver.gameWinScreen();
                    game = 0;
                }

                // Update end of turn state
                weather = weatherEvent.weatherChange();
                damage = weatherEvent.getDamage();
                if (altitude == 0) damage = 0;
                aircraft.planeDamage(damage);
                status = aircraft.engine.getStatus();
                altitude = aircraft.getAltitude();

                // Process movement and fuel consumption if engine is running
                if (status == true)
                {
                    if (altitude >= 1)
                    {
                        int deltadistance = aircraft.getSpeed();
                        distance = distance - deltadistance;
                        departuredistance = departuredistance + deltadistance;
                        aircraft.fuel = aircraft.fuel - deltaFuel;

                        // Additional effects during stormy weather
                        if (weather == "Stormy")
                        {
                            aircraft.fuel = aircraft.fuel - 1;
                            aircraft.altitude = aircraft.altitude - 100;
                        }

                        fuel = aircraft.fuel;
                    }
                }
            }
        }
    }
}