
using System;
using System.Numerics;
using System.Security.Cryptography;

namespace FlightSimulator
 {
    using System;
    using System.Net.NetworkInformation;
    using System.Reflection;
    using static System.Net.Mime.MediaTypeNames;

    interface IAircraft //ml2 patron de conception Factory
    {
      public  int fuel { get; set; }
        public int altitude { get; set; }
        public int speed { get; set; }
        public string Nom { get; set; }
        public int AltitudeMax { get; set; }
        public string Modele { get; set; }
        public Wings wings { get; set; }  
        public Radar radar { get; set; } 
        public Cabin cabin { get; set; } 
        public Engine engine { get; set; }         
        public bool status { get; set; }
        int getFuel();
        int getAltitude();
        int getMaxAltitude();
        int getSpeed();
        string getPlane();
        void AfficherType();
        void startEngine();
        void stopEngine();
        void takeOff();
        void setFuel(int fuel);
        void setAltitude(int altitude);
        void setSpeed(int speed);
        void increaseAltitude(string s);
        void decreaseAltitude(string s);
        void landingMode(ref string flightstate);
        void repair();
        void planeDamage(int damage);

    }
    abstract class AircraftBase : IAircraft //ml2 nouvelle classe pour traiter les variables communes a avion et helicoptere
    {
        public int fuel { get; set; }
        public int altitude { get; set; }
        public int speed { get; set; }
        public string Nom { get; set; }
        public int AltitudeMax { get; set; }
        public string Modele { get; set; }
        public bool status { get; set; }

        public Wings wings { get; set; }
        public Radar radar { get; set; }
        public Cabin cabin { get; set; }
        public Engine engine { get; set; }
        // Constructeur sans paramètres
        public AircraftBase()
        {
            wings = new Wings(); //ml2 Initialisation automatique
            engine = new Engine(); //ml2 Initialisation automatique
            radar = new Radar(); //ml2 Initialisation automatique
            cabin = new Cabin(); //ml2 Initialisation automatique
        }
        public abstract void AfficherType();//ml2  methode abstract car specifique (non commune) a avion et helicoptere

        public void startEngine()
        {
            engine.setStatus(true); // ajout ml
        }

        //  void AfficherType();
        public void stopEngine()
        {
            if (altitude <= 0)    //ml0 verifier si on est au sol
                engine.setStatus(false); // ajout ml
        }

        public void takeOff()
        {
            status = engine.getStatus();
            if (status == true) //ml etait = et non ==
            {
                altitude = 1000;
                speed = 250;   //ml0  - vitesse de take off ajoutee
            }
            else
            {
                Console.WriteLine("Engine is not on");
            }
        }

        public void increaseAltitude(string flightstate)
        {
            if (flightstate == "air")
            //    status = engine.getStatus();  //ml0 il faut verifier pour le mode de vol et non que le moteur est "on"
            //    if (status == true) //ml0 - changé = pour ==
            {
                this.altitude += 1000; //ml ajout on ajoute 1000 pied a l'altitude
            }
            else
            {
                Console.WriteLine("IAircraft is not in air state");  //ml0 was "engine not on"
            }

        }

        public void decreaseAltitude(string flightstate)
        {
            if ((flightstate == "air") || (flightstate == "landing"))

            {
                this.altitude -= 1000; //ml on soustrait 1000 pied a l'altitude
            }
            else
            {
                Console.WriteLine("Aircraft is not in air or landing state");  //ml0 was "engine not on"
            }
        }

        public void landingMode(ref string flightstate)
        {
            //if (this.altitude == 0) {
            //    status = engine.getStatus();
            //    if (status=false) {
            //        Console.WriteLine("Landing mode activated");
            //    }
            //    else {
            //        Console.WriteLine("Engine must be off to activate landing mode");
            //    }
            //}
            //else {
            //    Console.WriteLine("You must be on the ground to activate landing mode");
            //}


            if (flightstate == "air") //ml0

            {
                flightstate = "landing"; //ml0
            }
            else
            {
                Console.WriteLine("Aircraft is not in air state"); //ml1 //ml0 
            }
        }

        public void repair()
        {
            if (altitude != 0)
            {
                Console.WriteLine("Must be on ground to repair the aircraft!");
                bool status = engine.getStatus();
                if (status == true) //ml2 etait  =
                {
                    Console.WriteLine("The engine must be off to repair the aircraft!");
                }
            }
            else
            {
                int currentDamage = engine.getDamage();
                engine.setDamage(-(currentDamage));
                radar.setDamage(-(currentDamage));
                cabin.setDamage(-(currentDamage));
                wings.setDamage(-(currentDamage));

                setFuel(100); //ml2 la reparation inclue un refill de fuel.
            }
        }

        public string getPlane()
        {
            return this.Nom; //ml2 name//ml ajout
        }


        public int getAltitude()
        {
            return this.altitude; //ml ajout
        }

        public int getMaxAltitude()
        {
            return this.AltitudeMax; //ml ajout
        }

        public int getFuel()
        {
            return fuel; //ml1 correction était //ml0 100 valeur temporaire
        }

        public int getSpeed()
        {
            return speed; //ml valeur temporaire
        }
        public void planeDamage(int damage)
        { //ml ajout (int deltadamage) et public  void a toutes les methodes

            engine.setDamage(damage);
            radar.setDamage(damage);
            cabin.setDamage(damage);
            wings.setDamage(damage);
        }

         public void setFuel(int fuel)
        {
            throw new NotImplementedException();
        }

        public void setAltitude(int altitude)
        {
            throw new NotImplementedException();
        }

        public void setSpeed(int speed)
        {
            throw new NotImplementedException();
        }
    }

    class Plane : AircraftBase //ml2  classe Plane maintenant avec déclaration des variables non communes entre avion et helico
    {                           //ml2 les variables communes sont héritées de AircraftBase
         public int NombrePassagers { get; set; }
        public int NombreMoteurs { get; set; }
        public int Autonomie { get; set; }

      
        //ml2 constructeur
        public Plane(string nom, int altitudemax, string modele, int nombremoteurs, int nombrepassagers, int autonomie)
        {
            fuel = 100;
            altitude = 0;
            speed = 0;
            Nom = nom;
            AltitudeMax = altitudemax;
            Modele = modele;

            NombreMoteurs = nombremoteurs;
            NombrePassagers = nombrepassagers;
            Autonomie = autonomie;
        }

        public override void AfficherType() //ml2 traitement de l'affichage pour classe Plane
        {
            //ml0   Console.WriteLine($"Nom: {Nom}\nModèle: {Modele}\nAltitude: {altitude} ft\nVitesse: {speed} mph"); //pour tout afficher
            Console.Write($"Model:{Modele}, "); //ml2
            Console.Write($"AltitudeMax:{AltitudeMax} ft, motors:{NombreMoteurs}, "); //ml2
            Console.WriteLine($"Passengers:{NombrePassagers}, Autonomy:{Autonomie} mi"); //ml2
        }

    }

    class Helicopter : AircraftBase//ml2  nouvelle classe Helicopter avec déclaration des variables non communes entre avion et helico
    {                           //ml2 les variables communes sont héritées de AircraftBase

        public int NombreRotors { get; set; }
   
        public string VolStationnaire { get; set; }

        //ml2 constructeur
        public Helicopter(string nom, int altitudemax, string modele, int nombrerotors, string volstationnaire)
        {
            fuel = 100;
            altitude = 0;
            speed = 0;
            Nom = nom;
            AltitudeMax = altitudemax;
            Modele = modele;

            NombreRotors = nombrerotors;
            VolStationnaire = volstationnaire;
        }

        public override void AfficherType()   //ml2 traitement de l'affichage pour classe Helicopter
        {
            //ml2   Console.WriteLine($"Nom: {Nom}\nModèle: {Modele}\nAltitude: {altitude} ft\nVitesse: {speed} mph"); //pour tout afficher
            Console.Write($"Model:{Modele}, "); //ml2
            Console.WriteLine($"MaxAltitude:{AltitudeMax} ft, rotors:{NombreRotors},Stationary flight:{VolStationnaire}"); //ml2
        }
    }

    // Classe Factory pour créer les instances de IAircraft
    static class AeronefFactory
    {
        public static IAircraft CreerAeronef(string type)
        {
            return type.ToLower() switch
            {
                "avion1" => new Plane("plane 1", 12000, "Gulfstream 550", 2, 5, 4000),
                "avion2" => new Plane("plane 2", 12000, "Gulfstream 650", 2, 5, 6000),
                "helicoptere1" => new Helicopter("helico 1", 12000, "JetRanger 206", 1, "yes"),
                "helicoptere2" => new Helicopter("helico 2", 12000, "JetRanger 400", 2, "no"),
                _ => throw new ArgumentException("Type d'aéronef inconnu")
            };
        }

        //ml2 non utilise public int damage; //ml ajout temporaire


        // public static void setPlane() //ml2 nouveau prototype retourne string
        //  
        public static string setPlane()
        { //ml2 utilise factory
            Console.WriteLine("Please select from the following");
            Console.WriteLine("1. Gulstream1 (aircraft)");
            Console.WriteLine("2. Gulstream2 (aircraft)");
            Console.WriteLine("3. JetRanger1 (helicopter)");
            Console.WriteLine("4. JetRanger2 (helicopter)");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You have selected Gulfstream1");
                    return "avion1";
                  
                case "2":
                    Console.WriteLine("You have selected Gulfstream2");
                    return "avion2";
                case "3":
                    Console.WriteLine("You have selected JetRanger1");
                    return "helicoptere1";
                case "4":
                    Console.WriteLine("You have selected JetRanger2");
                    return "helicoptere2";
                default:
                    return "no selection";
            }
        }

    }
}

