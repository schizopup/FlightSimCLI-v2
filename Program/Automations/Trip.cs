
using System;

namespace FlightSimulator
{
    internal class Trip
    {
        // singleton + city randomizer
        static Random rand = new Random();
        public int city1 = rand.Next(1, 5);
        public int city2 = rand.Next(1, 5);
        public string city1Name = "";
        public string city2Name = "";
        public int city1Location;
        public int city2Location;
        public int distance;


        // randomizes the trip for the game
        public void StartTrip()
        {
        
        // if both cities are the same, randomizes the second city
        while(city1==city2)
        {
            city2 = rand.Next(1, 5);
        }

        // sets the city1 name and location based off the random number assigned
        switch (city1)
        {
            case 1:
                city1Name = Montreal.getCity();
                city1Location = Montreal.getLocation();
                break;
            case 2:
                city1Name = Paris.getCity();
                city1Location = Paris.getLocation();
                break;
            case 3:
                city1Name = LosAngeles.getCity();
                city1Location = LosAngeles.getLocation();

                break;
            case 4:
                city1Name = MexicoCity.getCity();
                city1Location = MexicoCity.getLocation();
                break;
            case 5:
                city1Name = Madride.getCity();
                city1Location = Madride.getLocation();
                break;            
        }

    
        // sets the city2 name and location based off the random number assigned
        switch (city2)
        {
            case 1:
                city2Name = Montreal.getCity();
                city2Location = Montreal.getLocation();
                break;
            case 2:
                city2Name = Paris.getCity();
                city2Location = Paris.getLocation();
                break;
            case 3:
                city2Name = LosAngeles.getCity();
                city2Location = LosAngeles.getLocation();
                break;
            case 4:
                city2Name = MexicoCity.getCity();
                city2Location = MexicoCity.getLocation();
                break;
            case 5:
                city2Name = Madride.getCity();
                city2Location = Madride.getLocation();
                break;
        }
    }
    
    
    // gets the distance between the two cities
    public int getDistance()
    {
        // calculates the distance between the two cities
        distance = Math.Abs((city1Location - city2Location)*200);

        // if distance is in the negative, turn it into a positive
        if(distance<0)
        {
            distance = (distance * -1) + 3000;
        }

        return distance;
    }

    // gets the city1 name
    public string getCity1()
    {
        return city1Name;
    }

    // gets the city2 name
    public string getCity2()
    {
        return city2Name;
    }
}
}