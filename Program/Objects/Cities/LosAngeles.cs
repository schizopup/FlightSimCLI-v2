
using System;
using FlightSimulator;

namespace FlightSimulator
{
    internal class LosAngeles : iCity
    {
        public static string city = "Los Angeles";
        public static int location = 340;


        // returns the city name
        public static string getCity()
        {
            return city;
        }

        // returns the location of the city
        public static int getLocation()
        {
            return location;
        }
    }
}
