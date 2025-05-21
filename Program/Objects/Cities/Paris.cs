using System;
using FlightSimulator;

namespace FlightSimulator
{
    internal class Paris : iCity
    {
        public static string city = "Paris";
        public static int location = 500; //ml1 était 300 (idem Mexico)


        // returns the city name
        public static string getCity()
        {
            return city;
        }

        // returns the city location
        public static int getLocation()
        {
            return location;
        }
    }
}
