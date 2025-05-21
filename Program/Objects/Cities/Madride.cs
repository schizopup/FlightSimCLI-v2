
using System;
using FlightSimulator;

namespace FlightSimulator
{
    internal class Madride : iCity
    {
        public static string city = "Madride";
        public static int location = 240;


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
